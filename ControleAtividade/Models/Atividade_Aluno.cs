using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Atividade_Aluno")]
    public class Atividade_Aluno
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Atividade")]
        [Required]
        public int IdAtividade { get; set; }

        [ForeignKey("Aluno")]
        [Required]
        public int IdAluno { get; set; }

        [NotMapped]
        public Atividade Atividade { get; set; }
        [NotMapped]
        public Aluno Aluno { get; set; }

        public virtual List<Questao_Aluno> ListaQuestaoAluno { get; set; }
    }
}
