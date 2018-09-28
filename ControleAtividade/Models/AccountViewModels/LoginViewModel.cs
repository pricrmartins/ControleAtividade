using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo deve ter 11 caracteres.", MinimumLength = 14)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar?")]
        public bool RememberMe { get; set; }
    }
}
