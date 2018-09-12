using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAtividade.Models
{
    [Table("Turma")]
    public class Turma
    {
        [Key]
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nome { get; set; }

        [ForeignKey("Professor")]
        [Required]
        public int IdProfessor { get; set; }

        public Professor Professor { get; set; }
    }
}