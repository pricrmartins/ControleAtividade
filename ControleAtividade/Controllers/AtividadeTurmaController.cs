using ControleAtividade.Models;
using ControleAtividade.Models.AtividadeTurmaViewModels;
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
    public class AtividadeTurmaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITurmaService _turmaService;
        private readonly IProfessorService _professorService;
        private readonly IAtividadeService _atividadeService;
        private readonly IAtividade_TurmaService _atividadeTurmaService;

        public AtividadeTurmaController(UserManager<ApplicationUser> userManager, ITurmaService turmaService,
            IProfessorService professorService, IAtividadeService atividadeService, IAtividade_TurmaService atividadeTurmaService)
        {
            _userManager = userManager;
            _turmaService = turmaService;
            _professorService = professorService;
            _atividadeService = atividadeService;
            _atividadeTurmaService = atividadeTurmaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string CodigoTurma = null, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            IEnumerable<Turma> turmas;
            IEnumerable<Atividade> atividades;
            var usuarioAtual = await _userManager.GetUserAsync(User);
            if (usuarioAtual.TipoUsuario == 2)
            {
                Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);
                turmas = await _turmaService.GetTurmasPorProfessorAsync(professor.Id);
                if (!string.IsNullOrWhiteSpace(CodigoTurma))
                {
                    turmas = turmas.Where(t => t.Codigo.Equals(CodigoTurma));
                }
                atividades = await _atividadeService.GetAtividadesPorProfessorAsync(professor.Id);
                CadastrarAtividadeTurmaViewModel model = new CadastrarAtividadeTurmaViewModel
                {
                    Turmas = turmas.ToList(),
                    Atividades = atividades.ToList(),
                    CodigoTurma = CodigoTurma ?? null
                };
                return View(model);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CadastrarAtividadeTurmaViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Turma turma = await _turmaService.GetTurmaPorCodigo(model.CodigoTurma);
                Atividade atividade = await _atividadeService.GetAtividade(model.IdAtividade);
                Atividade_Turma atividade_Turma = await _atividadeTurmaService.ExisteAtividadeAtivaNaTurma(model.CodigoTurma, model.IdAtividade);
                if (atividade_Turma != null)
                {
                    IEnumerable<Turma> turmas;
                    IEnumerable<Atividade> atividades;
                    var usuarioAtual = await _userManager.GetUserAsync(User);
                    ModelState.AddModelError(string.Empty, $"Não foi possivel adicionar a atividade {atividade.Nome}, " +
                        $"pois ela já está vinculada a turma {turma.Nome}, por favor desative ela para " +
                        $"adicionar uma nova! ");
                    Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);

                    turmas = await _turmaService.GetTurmasPorProfessorAsync(professor.Id);
                    atividades = await _atividadeService.GetAtividadesPorProfessorAsync(professor.Id);
                    model.Turmas = turmas.ToList();
                    model.Atividades = atividades.ToList();

                    return View("Index", model);
                }

                atividade_Turma = new Atividade_Turma
                {
                    IdAtividade = atividade.Id,
                    CodigoTurma = turma.Codigo,
                    Disponivel = model.Disponivel
                };
                await _atividadeTurmaService.SetAtividade_TurmaAsync(atividade_Turma);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int IdAtividadeTurma, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Atividade_Turma atividade_Turma = await _atividadeTurmaService.GetAtividadeTurmaAsync(IdAtividadeTurma);
            EditarAtividadeTurmaViewModel model = new EditarAtividadeTurmaViewModel
            {
                Atividades = new List<Atividade> { atividade_Turma.Atividade },
                Turmas = new List<Turma> { atividade_Turma.Turma },
                Disponivel = atividade_Turma.Disponivel,
                IdAtividadeTurma = atividade_Turma.Id,
                CodigoTurma = atividade_Turma.CodigoTurma,
                IdAtividade = atividade_Turma.IdAtividade
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarAtividadeTurmaViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Atividade_Turma atividade_Turma = await _atividadeTurmaService.ExisteAtividadeAtivaNaTurma(model.CodigoTurma, model.IdAtividade);
            if (atividade_Turma != null)
            {
                ModelState.AddModelError(string.Empty, $"Não foi possivel adicionar a atividade {atividade_Turma.Atividade.Nome}, " +
                    $"pois ela já está vinculada a turma {atividade_Turma.Turma.Nome}, por favor desative ela para " +
                    $"adicionar uma nova! ");
                model = new EditarAtividadeTurmaViewModel
                {
                    Atividades = new List<Atividade> { atividade_Turma.Atividade },
                    Turmas = new List<Turma> { atividade_Turma.Turma },
                    Disponivel = atividade_Turma.Disponivel,
                    IdAtividadeTurma = atividade_Turma.Id,
                    CodigoTurma = atividade_Turma.CodigoTurma,
                    IdAtividade = atividade_Turma.IdAtividade
                };
                return View("Editar", model);
            }

            atividade_Turma = await _atividadeTurmaService.GetAtividadeTurmaAsync(model.IdAtividadeTurma);
            atividade_Turma.Disponivel = model.Disponivel;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(string CodigoTurma,string Pesquisar = null, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            IEnumerable<Atividade_Turma> atividades = await _atividadeTurmaService.GetAtividadesTurmaCodigoAsync(CodigoTurma);

            if (!string.IsNullOrWhiteSpace(Pesquisar))
            {
                atividades = atividades.Where(a => a.Atividade.Nome.ToUpper().Contains(Pesquisar.ToUpper()));
            }

            return View(new ConsultarAtividadeTurmaViewModel
            {
                AtividadesTurma = atividades.ToList(),
                CodigoTurma = CodigoTurma
            });
        }

    }
}
