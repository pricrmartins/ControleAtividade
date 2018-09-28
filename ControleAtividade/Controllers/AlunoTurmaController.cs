using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Models;
using ControleAtividade.Models.AlunoTurmaViewModels;
using ControleAtividade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleAtividade.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AlunoTurmaController : Controller
    {
        public readonly IAlunoService _alunoService;
        public readonly ITurma_AlunoService _turmaAlunoService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfessorService _professorService;

        public AlunoTurmaController(ITurma_AlunoService turmaAlunoService, IProfessorService professorService)
        {
            _turmaAlunoService = turmaAlunoService;
            _professorService = professorService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            Professor professor;
            var usuarioAtual = await _userManager.GetUserAsync(User);

            if (usuarioAtual.TipoUsuario != 2)
            {
                return RedirectToAction("Index", "Perfil");
            }
            professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);
            IEnumerable<Turma_Aluno> alunos = await _turmaAlunoService.GetAlunosPorProfessorAsync(professor.Id);

            return View(new ConsultarAlunoTurmaViewModel { Alunos = alunos.ToList() });
        }
    }
}
