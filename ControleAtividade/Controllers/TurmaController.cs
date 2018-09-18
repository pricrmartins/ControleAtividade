using ControleAtividade.Models;
using ControleAtividade.Models.TurmasViewModels;
using ControleAtividade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfessorService _professorService;

        public TurmaController(UserManager<ApplicationUser> userManager,
            ITurmaService turmaService, IProfessorService professorService)
        {
            _userManager = userManager;
            _turmaService = turmaService;
            _professorService = professorService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl = null, string Pesquisar = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var usuarioAtual = await _userManager.GetUserAsync(User);
            IEnumerable<Turma> turmas;
            if (usuarioAtual.TipoUsuario == 2)
            {
                Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);
                turmas = await _turmaService.GetTurmasPorProfessorAsync(professor.Id);
                if (!string.IsNullOrWhiteSpace(Pesquisar))
                {
                    turmas = turmas.Where(t => t.Codigo.ToUpper().Contains(Pesquisar.ToUpper()) || t.Nome.ToUpper().Contains(Pesquisar.ToUpper()));
                }
                return View(new ListaTurmasViewModel
                {
                    Turmas = turmas
                });
            }
            turmas = await _turmaService.GetTurmasAsync();
            if (!string.IsNullOrWhiteSpace(Pesquisar))
            {
                turmas = turmas.Where(t => t.Codigo.ToUpper().Contains(Pesquisar.ToUpper()) || t.Nome.ToUpper().Contains(Pesquisar.ToUpper()));
            }
            return View(new ListaTurmasViewModel
            {
                Turmas = turmas
            });
        }

        [HttpGet]
        public ActionResult Cadastrar(string returnUrl = null, string msgError = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewBag.msgError = msgError;
            return View(new CadastrarTurmaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(CadastrarTurmaViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                if (await _turmaService.TurmaExists(model.Codigo))
                {
                    return RedirectToAction("Cadastrar", new { msgError = "Código já cadastrado no sistema." });
                }
                var usuarioAtual = await _userManager.GetUserAsync(User);
                Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);

                if (usuarioAtual.TipoUsuario != 2)
                {
                    return RedirectToAction("Cadastrar", new { msgError = "Necessário estar com o perfil Professor para realizar essa ação." });
                }
                await _turmaService.SetTurmaAsync(new Turma { Codigo = model.Codigo, Nome = model.Nome, IdProfessor = professor.Id });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detalhar(string codigo, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Turma turma = await _turmaService.GetTurmaPorCodigo(codigo);
            return View(new DetalharTurmaViewModel { Turma = turma });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string codigo, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Turma turma = await _turmaService.GetTurmaPorCodigo(codigo);
            return View(new EditarTurmaViewModel { Codigo = turma.Codigo, Nome = turma.Nome });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(EditarTurmaViewModel editarTurmaViewModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Turma turma = await _turmaService.GetTurmaPorCodigo(editarTurmaViewModel.Codigo);
            turma.Nome = editarTurmaViewModel.Nome;
            await _turmaService.UpdateTurmaAsync(turma);
            return RedirectToAction("Index");
        }
    }
}
