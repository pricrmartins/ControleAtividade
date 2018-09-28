using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AtividadesViewModels
{
    public class CadastrarAtividadeViewModel
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo tipo é obrigatório.")]
        public string Tipo { get; set; }
    }
}
