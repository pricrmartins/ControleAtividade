using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Questao_Aluno")]
    public class Questao_Aluno
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Atividade_Aluno")]
        [Required]
        public int IdAtividade_Aluno { get; set; }

        [ForeignKey("Questao")]
        [Required]
        public int IdQuestao { get; set; }

        [ForeignKey("Opcao")]
        [Required]
        public int IdOpcao { get; set; }
        [NotMapped]
        public Atividade_Aluno Atividade_Aluno { get; set; }
        [NotMapped]
        public Questao Questao { get; set; }
        [NotMapped]
        public Opcao Opcao { get; set; }

    }
}
