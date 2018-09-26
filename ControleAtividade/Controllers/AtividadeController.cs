using ControleAtividade.Models;
using ControleAtividade.Models.AtividadesViewModels;
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
    public class AtividadeController : Controller
    {
        private readonly IAtividadeService _atividadeService;
        private readonly IProfessorService _professorService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IQuestaoService _questaoService;
        private readonly IOpcao_CorretaService _opcao_Correta;
        private readonly IOpcaoService _opcao;

        public AtividadeController(IAtividadeService atividadeService, IQuestaoService questaoService,
            IProfessorService professorService, UserManager<ApplicationUser> userManager, IOpcao_CorretaService opcao_Correta, IOpcaoService opcao)
        {
            _atividadeService = atividadeService;
            _professorService = professorService;
            _userManager = userManager;
            _questaoService = questaoService;
            _opcao_Correta = opcao_Correta;
            _opcao = opcao;
        }

        public async Task<IActionResult> Index(string Pesquisar = null)
        {
            IEnumerable<Atividade> atividades = await _atividadeService.GetAtividadesAsync();
            var usuarioAtual = await _userManager.GetUserAsync(User);

            if (usuarioAtual.TipoUsuario != 2)
            {
                return RedirectToAction("Index", "Perfil");
            }

            if (!string.IsNullOrWhiteSpace(Pesquisar))
            {
                atividades = atividades.Where(atividade => atividade.Nome.ToUpper().Contains(Pesquisar.ToUpper()));
            }

            return View(new ConsultarAtividadesViewModel
            {
                Atividades = atividades.ToList()
            });
        }

        [HttpGet]
        public ActionResult Cadastrar(string returnUrl = null, string msgError = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewBag.msgError = msgError;
            return View(new CadastrarAtividadeViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(CadastrarAtividadeViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var usuarioAtual = await _userManager.GetUserAsync(User);
                Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);

                if (usuarioAtual.TipoUsuario != 2)
                {
                    return RedirectToAction("Cadastrar", new { msgError = "Necessário estar com o perfil Professor para realizar essa ação." });
                }
                await _atividadeService.SetAtividadeAsync(new Atividade { Descricao = model.Descricao, Nome = model.Nome, Tipo = model.Tipo });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detalhar(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Atividade atividade = await _atividadeService.GetAtividade(id);
            return View(new DetalharAtividadeViewModel { Atividade = atividade });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Atividade atividade = await _atividadeService.GetAtividade(id);
            return View(new EditarAtividadeViewModel { Descricao = atividade.Descricao, Nome = atividade.Nome, Tipo = atividade.Tipo, Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(EditarAtividadeViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var usuarioAtual = await _userManager.GetUserAsync(User);
                Professor professor = await _professorService.GetProfessorPorCPFAsync(usuarioAtual.UserName);

                if (usuarioAtual.TipoUsuario != 2)
                {
                    return RedirectToAction("Editar", new { msgError = "Necessário estar com o perfil Professor para realizar essa ação." });
                }
                Atividade atividade = await _atividadeService.GetAtividade(model.Id);
                atividade.Descricao = model.Descricao;
                atividade.Nome = model.Nome;
                atividade.Tipo = model.Tipo;

                await _atividadeService.UpdateAtividadeAsync(atividade);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarQuestao(int Id, string Pesquisar = null)
        {
            IEnumerable<Questao> questoes = await _questaoService.GetQuestoesPorAtividadeAsync(Id);
            if (!string.IsNullOrWhiteSpace(Pesquisar))
            {
                questoes = questoes.Where(q => q.Cabecalho.ToUpper().Contains(Pesquisar.ToUpper()));
            }
            return View(new ConsultarQuestaoViewModel
            {
                Questoes = questoes.ToList(),
                Atividade = await _atividadeService.GetAtividade(Id)
            });
        }

        [HttpGet]
        public ActionResult CadastrarQuestao(int Id)
        {
            return View(new CadastrarQuestaoViewModel { IdAtividade = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarQuestao(CadastrarQuestaoViewModel cadastrarQuestaoViewModel)
        {
            if (ModelState.IsValid)
            {
                int opcaoCorreta = cadastrarQuestaoViewModel.Selecionado != null ? int.Parse(cadastrarQuestaoViewModel.Selecionado) : -1;
                if (opcaoCorreta != -1)
                {
                    cadastrarQuestaoViewModel.Opcoes[opcaoCorreta].Opcao_Correta = new Opcao_Correta { Correta = true };
                }
                Questao questao = new Questao
                {
                    IdAtividade = cadastrarQuestaoViewModel.IdAtividade,
                    Cabecalho = cadastrarQuestaoViewModel.Cabecalho,
                    Texto = cadastrarQuestaoViewModel.Texto,
                    ListaOpcao = cadastrarQuestaoViewModel.Opcoes
                };
                await _questaoService.SetQuestaoAsync(questao);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditarQuestao(int Id)
        {
            Questao questao = await _questaoService.GetQuestaoPorId(Id);

            EditarQuestaoViewModel editarQuestaoViewModel = new EditarQuestaoViewModel
            {
                Cabecalho = questao.Cabecalho,
                IdQuestao = questao.Id,
                Opcoes = questao.ListaOpcao,
                Texto = questao.Texto
            };

            int indiceOpcao = 0;
            foreach (Opcao opcao in questao.ListaOpcao)
            {
                Opcao_Correta opcao_Correta = await _opcao_Correta.GetOpcaoCorreta(opcao.Id);
                if (opcao_Correta != null)
                {
                    editarQuestaoViewModel.Selecionado = indiceOpcao.ToString();
                    break;
                }
                indiceOpcao++;
            }
            return View(editarQuestaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarQuestao(EditarQuestaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                int opcaoCorreta = model.Selecionado != null ? int.Parse(model.Selecionado) : -1;
                Questao questao = await _questaoService.GetQuestaoPorId(model.IdQuestao);

                int indiceOpcao = 0;
                foreach (Opcao opcao in questao.ListaOpcao)
                {
                    Opcao_Correta opcao_Correta = await _opcao_Correta.GetOpcaoCorreta(opcao.Id);
                    if (opcao_Correta != null)
                    {
                        if (indiceOpcao.ToString() != model.Selecionado)
                        {
                            opcao_Correta.IdOpcao = model.Opcoes[opcaoCorreta].Id;
                            await _opcao_Correta.UpdateOpcao_CorretaAsync(opcao_Correta);
                            break;
                        }
                    }
                    indiceOpcao++;
                    await _opcao.UpdateOpcaoAsync(opcao);
                }

                questao.Cabecalho = model.Cabecalho;
                questao.Texto = model.Texto;

                await _questaoService.UpdateQuestaoAsync(questao);
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> DetalharQuestao(int Id)
        {
            Questao questao = await _questaoService.GetQuestaoPorId(Id);

            EditarQuestaoViewModel editarQuestaoViewModel = new EditarQuestaoViewModel
            {
                Cabecalho = questao.Cabecalho,
                IdQuestao = questao.Id,
                Opcoes = questao.ListaOpcao,
                Texto = questao.Texto
            };

            int indiceOpcao = 0;
            foreach (Opcao opcao in questao.ListaOpcao)
            {
                Opcao_Correta opcao_Correta = await _opcao_Correta.GetOpcaoCorreta(opcao.Id);
                if (opcao_Correta != null)
                {
                    editarQuestaoViewModel.Selecionado = indiceOpcao.ToString();
                    break;
                }
                indiceOpcao++;
            }
            return View(editarQuestaoViewModel);
        }
    }
}
