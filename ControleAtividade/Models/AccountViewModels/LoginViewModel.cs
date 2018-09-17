using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(11, ErrorMessage = "O campo deve ter 11 caracteres.", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
