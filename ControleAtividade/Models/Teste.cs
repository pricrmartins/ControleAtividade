using ControleAtividade.Services;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    public class Teste
    {
        private readonly IProfessorService _professorService;
        private readonly IAtividadeService _atividadeService;
        private readonly IAtividade_TurmaService _atividade_TurmaService;
        private readonly ITurmaService _turmaService;
        private readonly IQuestaoService _questaoService;
        private readonly IOpcaoService _opcaoService;
        private readonly IOpcao_CorretaService _opcao_CorretaService;

        public Teste(IProfessorService professorService,
            IAtividadeService atividadeService,
            IAtividade_TurmaService atividade_TurmaService,
            ITurmaService turmaService,
            IQuestaoService questaoService,
            IOpcaoService opcaoService, IOpcao_CorretaService opcao_CorretaService)
        {
            _professorService = professorService;
            _atividadeService = atividadeService;
            _atividade_TurmaService = atividade_TurmaService;
            _turmaService = turmaService;
            _questaoService = questaoService;
            _opcaoService = opcaoService;
            _opcao_CorretaService = opcao_CorretaService;
            ProfessorTeste professor = new ProfessorTeste(_professorService,
            _atividadeService, _atividade_TurmaService, _turmaService, _questaoService,
            _opcaoService, _opcao_CorretaService);
        }


    }

    public class ProfessorTeste
    {
        private readonly IProfessorService _professorService;
        private readonly IAtividadeService _atividadeService;
        private readonly IAtividade_TurmaService _atividade_TurmaService;
        private readonly ITurmaService _turmaService;
        private readonly IQuestaoService _questaoService;
        private readonly IOpcaoService _opcaoService;
        private readonly IOpcao_CorretaService _opcao_CorretaService;

        public ProfessorTeste(IProfessorService professorService,
            IAtividadeService atividadeService,
            IAtividade_TurmaService atividade_TurmaService,
            ITurmaService turmaService,
            IQuestaoService questaoService,
            IOpcaoService opcaoService, IOpcao_CorretaService opcao_CorretaService)
        {

            TestaProfessor();
        }

        public async void SalvarAtividade(Atividade atividade,
            List<Questao> questoes,
            Atividade_Turma atividade_Turma, List<Opcao> opcoes, List<Opcao_Correta> opcoes_Correta)
        {
            await _atividadeService.SetAtividadeAsync(atividade);
            Console.WriteLine("Adicionado Atividade:{0} com a descrição: {2}.", atividade.Nome, atividade.Descricao);

            questoes.ForEach(SalvarQuestao);
            opcoes.ForEach(SalvarOpcao);
            opcoes_Correta.ForEach(SalvarOpcao_Correta);
        }

        public async void SalvarQuestao(Questao questao)
        {
            await _questaoService.SetQuestaoAsync(questao);
            Console.WriteLine("Questão salva Cabeçalho: {0} e texto: {1}", questao.Cabecalho, questao.Texto);
        }

        public async void SalvarOpcao(Opcao opcao)
        {
            await _opcaoService.SetOpcaoAsync(opcao);
            Console.WriteLine("Adicionado opção: {0}, com a questão: {1}", opcao.Descricao, opcao.Questao.Cabecalho);
        }

        public async void SalvarOpcao_Correta(Opcao_Correta opcao_Correta)
        {
            await _opcao_CorretaService.SetOpcao_CorretaAsync(opcao_Correta);
            Console.WriteLine("Opcao correta adicionado à opção:{0}", opcao_Correta.Opcao.Descricao);
        }

        public async void SalvaTurma(Turma turma)
        {
            await _turmaService.SetTurmaAsync(turma);
            Console.WriteLine("Adicionado a turma {0}, pelo professor: {1}", turma.Nome, turma.Professor.ApplicationUser.Nome);
        }

        public async void SalvarProfessor(Professor professor)
        {
            await _professorService.SetProfessorAsync(professor);
            Console.WriteLine("Adicionado professor: {0}", professor.ApplicationUser.Nome);
        }

        public void TestaProfessor()
        {
            // cadastra professor
            Professor professor = new Professor
            {
                ApplicationUser = new ApplicationUser
                {
                    Email = "pricrmartins@gmail.com",
                    Nome = "Priscilla",
                    UserName = "12312312312",
                    PasswordHash = "123123"
                }
            };
            SalvarProfessor(professor);

            TestaTurma(professor);
        }

        public void TestaTurma(Professor professor)
        {
            // cadastra Turma
            Turma turma = new Turma { Codigo = "A-123", Nome = "Turma SA", IdProfessor = professor.Id };
            SalvaTurma(turma);
            TestaAtividade(turma);
        }

        public void TestaAtividade(Turma turma)
        {
            // cadastra Atividade na turma
            Atividade atividade = new Atividade
            {
                Nome = "Adição simples",
                Descricao = "Atividade para testar conhecimentos básicos de matemática",
                Tipo = "Matemática"
            };
            Atividade_Turma atividade_Turma = new Atividade_Turma
            {
                Atividade = atividade,
                Turma = turma
            };
            List<Questao> listaQuestao = new List<Questao>
            {
                new Questao
                {
                    Cabecalho = "Soma matemática",
                    Texto ="João tinha três maçãs e seu irmão Pedro comeu uma. Quantas sobraram?",
                    Atividade = atividade
                }
            };

            List<Opcao> listaOpcao = new List<Opcao>
            {
                new Opcao{ Questao = listaQuestao[0] ,Descricao = "sobraram 2 maçãs."},
                new Opcao{ Questao = listaQuestao[0] ,Descricao = "sobraram 1 maçã."},
                new Opcao{ Questao = listaQuestao[0] ,Descricao = "sobraram 3 maçã."}
            };
            List<Opcao_Correta> listaOpcaoCorreta = new List<Opcao_Correta>
            {
                new Opcao_Correta{ Correta = true, Opcao = listaOpcao[0] }
            };
            SalvarAtividade(atividade, listaQuestao, atividade_Turma, listaOpcao, listaOpcaoCorreta);
        }
    }

    public class AlunoTeste
    {
        private readonly IAlunoService _alunoService;
        private readonly ITurmaService _turmaService;
        private readonly IAtividade_TurmaService _atividade_TurmaService;
        private readonly IResposta_AtividadeService _resposta_AtividadeService;

        public AlunoTeste(IAlunoService alunoService, ITurmaService turmaService,
            IAtividadeService atividadeService, IAtividade_TurmaService atividade_TurmaService,
            IResposta_AtividadeService resposta_AtividadeService)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
            _atividade_TurmaService = atividade_TurmaService;
            _resposta_AtividadeService = resposta_AtividadeService;
        }

        public async void SalvarAluno(Aluno aluno)
        {
            await _alunoService.SetAlunoAsync(aluno);
            Console.WriteLine("Adicionado aluno: {0}", aluno.ApplicationUser.Nome);
        }

        public async void BuscarTurma(Turma turma)
        {
            await _turmaService.GetTurmaPorCodigo(turma.Codigo);
            Console.WriteLine($"Selecionado turma: {turma.Nome}");
        }

        public async void BuscarAtividadePendente(Turma turma, Aluno aluno)
        {
            IEnumerable<Atividade_Turma> atividades = await _atividade_TurmaService.GetAtividadesTurmaCodigoAsync(turma.Codigo);
            IEnumerable<Resposta_Atividade> atividadesRespondidas = await BuscarAtividadesRespondidas(aluno);

            List<Atividade_Turma> listaAtividades = atividades.ToList();
            List<Resposta_Atividade> listaAtividadesRespondidas = atividadesRespondidas.ToList();

            foreach (Resposta_Atividade itemAtividadesRespondidas in listaAtividadesRespondidas)
            {
                foreach (Atividade_Turma itemAtividades in listaAtividades)
                {
                    if (itemAtividadesRespondidas.Atividade_Turma.IdAtividade == itemAtividades.IdAtividade)
                    {
                        listaAtividades.Remove(itemAtividades);
                    }
                }
            }
            listaAtividades.ForEach(Print);
        }

        public void ResponderQuestaoAtividade()
        {

        }

        public async Task<IEnumerable<Resposta_Atividade>> BuscarAtividadesRespondidas(Aluno aluno)
        {
            var resultado = await _resposta_AtividadeService.GetRespostaAtividadePorAlunoAsync(aluno.Id);

            return resultado;
        }

        public void Print(Atividade_Turma atividade_Turma)
        {
            Console.WriteLine($"Atividades pendentes: {atividade_Turma.Atividade.Nome}");
        }
    }
}
