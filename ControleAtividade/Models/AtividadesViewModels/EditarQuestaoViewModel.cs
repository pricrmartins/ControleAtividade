using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleAtividade.Models.AtividadesViewModels
{
    public class EditarQuestaoViewModel
    {
        [Required]
        [Display(Name = "Cabeçalho")]
        public string Cabecalho { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public List<Opcao> Opcoes { get; set; }

        [Required]
        public string Selecionado { get; set; }

        public int IdQuestao { get; set; }
    }
}
