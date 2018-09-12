using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Usuario")]
    public class Usuario
    {

        [Required(ErrorMessage = "Informe seu número de matrícula!")]
        [Key]
        public string Matricula { get; set; }
        
        [Required(ErrorMessage = "Informe seu nome!")]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string UsuarioAplicacao { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
