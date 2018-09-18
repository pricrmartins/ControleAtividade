using ControleAtividade.Models;
using ControleAtividade.Models.PerfilViewModels;
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
    public class PerfilController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfessorService _professorService;
        private readonly IAlunoService _alunoService;
        public PerfilController(UserManager<ApplicationUser> userManager, IProfessorService professorService, IAlunoService alunoService)
        {
            _userManager = userManager;
            _professorService = professorService;
            _alunoService = alunoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PerfilProfessor()
        {
            var usuarioAtual = await _userManager.GetUserAsync(User);
            usuarioAtual.TipoUsuario = 2;
            await _userManager.UpdateAsync(usuarioAtual);
            Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);
            if (professor == null)
            {
                await _professorService.SetProfessorAsync(new Professor { IdApplicationUser = usuarioAtual.Id });
            }
            
            return RedirectToAction("Index","Professor");

        }

        public async Task<IActionResult> PerfilAluno()
        {
            var usuarioAtual = await _userManager.GetUserAsync(User);
            usuarioAtual.TipoUsuario = 1;
            await _userManager.UpdateAsync(usuarioAtual);
            Aluno aluno = await _alunoService.GetAlunoPorCPFAsync(usuarioAtual.UserName);
            if (aluno == null)
            {
                await _alunoService.SetAlunoAsync(new Aluno { IdApplicationUser = usuarioAtual.Id });
            }
            return RedirectToAction("Index","Aluno");

        }
    }
}
