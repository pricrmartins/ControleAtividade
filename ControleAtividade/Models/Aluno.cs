using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Turma")]
        public string CodigoTurma { get; set; }

        [ForeignKey("Usuario")]
        [Required]
        public string Matricula { get; set; }

        public Usuario Usuario { get; set; }
        public Turma Turma { get; set; }
    }
}
