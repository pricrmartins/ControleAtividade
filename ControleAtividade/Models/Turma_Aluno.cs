using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Turma_Aluno")]
    public class Turma_Aluno
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Turma")]
        [Required]
        public string CodigoTuma { get; set; }

        [ForeignKey("Aluno")]
        [Required]
        public int IdAluno { get; set; }

        public Turma Turma { get; set; }

        [NotMapped]
        public Aluno Aluno { get; set; }
    }
}
