using ControleAtividade.Models;
using ControleAtividade.Models.TurmasAlunoViewModels;
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
    public class TurmasController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAlunoService _alunoService;
        private readonly IProfessorService _professorService;
        private readonly ITurma_AlunoService _aluno_Turma_Service;
        public TurmasController(UserManager<ApplicationUser> userManager, IProfessorService professorService,
            ITurmaService turmaService, IAlunoService alunoService, ITurma_AlunoService aluno_Turma_Service)
        {
            _userManager = userManager;
            _turmaService = turmaService;
            _alunoService = alunoService;
            _aluno_Turma_Service = aluno_Turma_Service;
            _professorService = professorService;
        }
        public async Task<ActionResult> Index(string returnUrl = null, string Pesquisar = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var usuarioAtual = await _userManager.GetUserAsync(User);
            IEnumerable<Turma> turmas;
            if (usuarioAtual.TipoUsuario == 1)
            {
                Aluno aluno = await _alunoService.GetAlunoPorIdUsuario(usuarioAtual.Id);
                turmas = await _turmaService.GetTurmasAsync();
                if (!string.IsNullOrWhiteSpace(Pesquisar))
                {
                    turmas = turmas.Where(t => t.Codigo.ToUpper().Contains(Pesquisar.ToUpper()) || t.Nome.ToUpper().Contains(Pesquisar.ToUpper()));
                }
                return View(new ConsultarTurmasAlunoViewModel
                {
                    Turmas = turmas
                });
            }
            return RedirectToAction("Index", "Turma");
        }

        [HttpGet]
        public async Task<IActionResult> SolicitarEntrada(string codigo, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Turma turma = await _turmaService.GetTurmaPorCodigo(codigo);
            return View(new DetalharTurmaViewModel { Turma = turma });
        }
        [HttpPost]
        public async Task<IActionResult> SolicitarEntrada(DetalharTurmaViewModel detalharTurmaViewModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var usuarioAtual = await _userManager.GetUserAsync(User);
            if (usuarioAtual.TipoUsuario == 1)
            {
                Aluno aluno = await _alunoService.GetAlunoPorIdUsuario(usuarioAtual.Id);
                Professor professor = await _professorService.GetProfessorPorIdUsuario(usuarioAtual.Id);

                Turma turma = await _turmaService.GetTurmaPorCodigo(detalharTurmaViewModel.Turma.Codigo);
                if (await _aluno_Turma_Service.ExisteAlunoVinculadoNaTurma(aluno.Id, detalharTurmaViewModel.Turma.Codigo))
                {
                    ViewBag.Erro = "Você já está cadastrado na turma!";
                    return View(new DetalharTurmaViewModel { Turma = turma });
                }
                if (turma.IdProfessor != professor.Id)
                {
                    Turma_Aluno turma_Aluno = new Turma_Aluno { CodigoTuma = detalharTurmaViewModel.Turma.Codigo, Status = Turma_Aluno.StatusTurma.Pendente, IdAluno = aluno.Id };
                    await _aluno_Turma_Service.SetTurma_AlunoAsync(turma_Aluno);
                    ViewBag.Sucesso = "Aluno vinculado com sucesso, aguarde a validação do professor!";
                    ViewBag.Erro = null;
                }
                else
                {
                    ViewBag.Erro = "Você não pode ser aluno e professor da mesma turma!";
                    ViewBag.Sucesso = null;
                }
                return View(new DetalharTurmaViewModel { Turma = turma });
            }
            return RedirectToAction("Index", "Turma");
        }

        [HttpGet]
        public async Task<IActionResult> TurmasAluno()
        {
            var usuarioAtual = await _userManager.GetUserAsync(User);
            if (usuarioAtual.TipoUsuario == 1)
            {
                Aluno aluno = await _alunoService.GetAlunoPorIdUsuario(usuarioAtual.Id);
                return View(new TurmasAlunoCadastradoViewModel
                {
                    Turmas = await _aluno_Turma_Service.GetTurmasPorAlunoAsync(aluno)
                });
            }
            return RedirectToAction("Index", "Turma");
        }
    }
}
