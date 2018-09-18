using ControleAtividade.Services;
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
        private readonly IQuestao_AtividadeService _questaoAtividadeService;
        private readonly IOpcaoService _opcaoService;
        private readonly IOpcao_CorretaService _opcao_CorretaService;

        public Teste(IProfessorService professorService,
            IAtividadeService atividadeService,
            IAtividade_TurmaService atividade_TurmaService,
            ITurmaService turmaService,
            IQuestaoService questaoService,
            IQuestao_AtividadeService questaoAtividadeService,
            IOpcaoService opcaoService, IOpcao_CorretaService opcao_CorretaService)
        {
            _professorService = professorService;
            _atividadeService = atividadeService;
            _atividade_TurmaService = atividade_TurmaService;
            _turmaService = turmaService;
            _questaoService = questaoService;
            _questaoAtividadeService = questaoAtividadeService;
            _opcaoService = opcaoService;
            _opcao_CorretaService = opcao_CorretaService;
            ProfessorTeste professor = new ProfessorTeste(_professorService,
            _atividadeService, _atividade_TurmaService, _turmaService, _questaoService,
            _questaoAtividadeService, _opcaoService, _opcao_CorretaService);
        }


    }

    public class ProfessorTeste
    {
        private readonly IProfessorService _professorService;
        private readonly IAtividadeService _atividadeService;
        private readonly IAtividade_TurmaService _atividade_TurmaService;
        private readonly ITurmaService _turmaService;
        private readonly IQuestaoService _questaoService;
        private readonly IQuestao_AtividadeService _questaoAtividadeService;
        private readonly IOpcaoService _opcaoService;
        private readonly IOpcao_CorretaService _opcao_CorretaService;

        public ProfessorTeste(IProfessorService professorService,
            IAtividadeService atividadeService,
            IAtividade_TurmaService atividade_TurmaService,
            ITurmaService turmaService,
            IQuestaoService questaoService,
            IQuestao_AtividadeService questaoAtividadeService,
            IOpcaoService opcaoService, IOpcao_CorretaService opcao_CorretaService)
        {
            _professorService = professorService;
            _atividadeService = atividadeService;
            _atividade_TurmaService = atividade_TurmaService;
            _turmaService = turmaService;
            _questaoService = questaoService;
            _questaoAtividadeService = questaoAtividadeService;
            _opcaoService = opcaoService;
            _opcao_CorretaService = opcao_CorretaService;

            TestaProfessor();
        }

        public async void SalvarAtividade(Atividade atividade,
            List<Questao> questoes, List<Questao_Atividade> questao_Atividades,
            Atividade_Turma atividade_Turma, List<Opcao> opcoes, List<Opcao_Correta> opcoes_Correta)
        {
            await _atividadeService.SetAtividadeAsync(atividade);
            Console.WriteLine("Adicionado Atividade:{0}, para a turma {1}\n com a descrição: {2}.", atividade.Nome, atividade.Turma.Nome, atividade.Descricao);

            questoes.ForEach(SalvarQuestao);
            questao_Atividades.ForEach(SalvarQuestao_Atividade);
            opcoes.ForEach(SalvarOpcao);
            opcoes_Correta.ForEach(SalvarOpcao_Correta);
        }

        public async void SalvarQuestao(Questao questao)
        {
            await _questaoService.SetQuestaoAsync(questao);
            Console.WriteLine("Questão salva Cabeçalho: {0} e texto: {1}", questao.Cabecalho, questao.Texto);
        }

        public async void SalvarQuestao_Atividade(Questao_Atividade questao_Atividade)
        {
            await _questaoAtividadeService.SetQuestao_AtividadeAsync(questao_Atividade);
            Console.WriteLine("Adicionado Questão: {0}, com atividade{1}", questao_Atividade.Questao.Cabecalho, questao_Atividade.Atividade_Turma.Atividade.Nome);
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
            /// cadastra professor

            Professor professor = new Professor { IdApplicationUser = "c620b621-cf24-4076-9320-ab8aa805dfc7" };
            SalvarProfessor(professor);

            // cadastra Turma
            Turma turma = new Turma { Codigo = "A-123", Nome = "Turma SA", IdProfessor = professor.Id };
            SalvaTurma(turma);

            // cadastra Atividade da turma
            Atividade atividade = new Atividade
            {
                CodigoTurma = "A-123",
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
            
            List<Questao_Atividade> questao_Atividades = new List<Questao_Atividade>
            {
                new Questao_Atividade{ Atividade_Turma = atividade_Turma, Questao = listaQuestao[0] }
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
            SalvarAtividade(atividade, listaQuestao, questao_Atividades, atividade_Turma, listaOpcao, listaOpcaoCorreta);

        }
    }
}
