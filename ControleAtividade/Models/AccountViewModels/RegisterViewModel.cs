using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "O campo nome tem limite minimo de 6 caracteres e maximo de 100 caracteres.", MinimumLength = 6)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo nome tem limite de 100 caracteres.")]
        public string Matricula { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} tem tamanho minimo {2} e maximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmar senha não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
