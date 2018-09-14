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

        [ForeignKey("ApplicationUser")]
        [Required]
        public string IdApplicationUser { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual List<Turma> ListaTurma { get; set; }
    }
}
