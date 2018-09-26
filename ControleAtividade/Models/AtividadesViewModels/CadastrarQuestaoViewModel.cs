using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleAtividade.Models.AtividadesViewModels
{
    public class CadastrarQuestaoViewModel
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

        public int IdAtividade { get; set; }
    }
}
