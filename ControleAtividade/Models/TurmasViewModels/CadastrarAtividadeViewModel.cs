using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.TurmasViewModels
{
    public class CadastrarAtividadeViewModel
    {
        public List<Turma> Turmas { get; set; }
        public Turma Turma { get; set; }
        public string CodigoTurma { get; set; }
        public string Atividade { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string OpcaoCorreta { get; set; }
        public List<Questao> Questoes { get; set; }

        public string Cabecalho { get; set; }
        public string Texto { get; set; }
        public byte[] Imagem { get; set; }
        public List<Opcao> Opcoes { get; set; }

    }
}
