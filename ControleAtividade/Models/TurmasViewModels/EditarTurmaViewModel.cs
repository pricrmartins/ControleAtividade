using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.TurmasViewModels
{
    public class EditarTurmaViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "O campo nome tem limite minimo de 6 caracteres e maximo de 20 caracteres.", MinimumLength = 6)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo nome tem limite minimo de 6 caracteres e maximo de 100 caracteres.", MinimumLength = 6)]
        public string Nome { get; set; }
    }
}
