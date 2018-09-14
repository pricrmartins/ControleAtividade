using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.ProfessorViewModels
{
    public class LoginProfessorViewModel
    {
        [Required]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool Lembrar { get; set; }
        
    }
}
