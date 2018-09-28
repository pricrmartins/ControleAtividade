using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AtividadeTurmaViewModels
{
    public class CadastrarAtividadeTurmaViewModel
    {
        public List<Turma> Turmas { get; set; }

        public List<Atividade> Atividades { get; set; }

        [Required(ErrorMessage ="É necessário selecionar uma turma")]
        public string CodigoTurma { get; set; }

        [Required(ErrorMessage = "É necessário selecionar uma atividade")]
        public int IdAtividade { get; set; }

        [Display(Name ="Disponível")]
        public bool Disponivel { get; set; }
    }
}
