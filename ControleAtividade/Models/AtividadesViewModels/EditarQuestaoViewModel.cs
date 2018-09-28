using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleAtividade.Models.AtividadesViewModels
{
    public class EditarQuestaoViewModel
    {
        [Required(ErrorMessage = "Campo cabeçalho é obrigatório.")]
        [Display(Name = "Cabeçalho")]
        public string Cabecalho { get; set; }

        [Required(ErrorMessage = "Campo texto é obrigatório.")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Campo opções é obrigatório.")]
        public List<Opcao> Opcoes { get; set; }

        [Required(ErrorMessage = "Campo correta é obrigatório.")]
        public string Selecionado { get; set; }

        public int IdQuestao { get; set; }
    }
}
