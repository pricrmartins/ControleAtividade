using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Required]
        public string Matricula { get; set; }

        public Usuario Usuario { get; set; }

        public virtual List<Turma> ListaTurma { get; set; }
    }
}
