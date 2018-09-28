using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.TurmasViewModels
{
    public class CadastrarAtividadeViewModel
    {
        public List<Turma> Turmas { get; set; }
        public Turma Turma { get; set; }
        public string CodigoTurma { get; set; }
        [Required(ErrorMessage = "Campo atividade é obrigatório.")]
        public string Atividade { get; set; }
        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo tipo é obrigatório.")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo opção correta é obrigatório.")]
        public string OpcaoCorreta { get; set; }
        public List<Questao> Questoes { get; set; }

        [Required(ErrorMessage = "Campo cabeçalho é obrigatório.")]
        public string Cabecalho { get; set; }
        [Required(ErrorMessage = "Campo texto é obrigatório.")]
        public string Texto { get; set; }
        public byte[] Imagem { get; set; }
        public List<Opcao> Opcoes { get; set; }

    }
}
