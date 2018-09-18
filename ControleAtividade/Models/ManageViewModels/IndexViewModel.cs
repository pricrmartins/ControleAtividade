using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "CPF")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
