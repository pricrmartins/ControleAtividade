using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Questao_Atividade")]
    public class Questao_Atividade
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Atividade_Turma")]
        [Required]
        public int IdAtividadeTurma { get; set; }

        [ForeignKey("Questao")]
        [Required]
        public int IdQuestao { get; set; }

        public Questao Questao { get; set; }

        public Atividade_Turma Atividade_Turma { get; set; }
    }
}
