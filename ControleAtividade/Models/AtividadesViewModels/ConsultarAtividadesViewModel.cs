using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AtividadesViewModels
{
    public class ConsultarAtividadesViewModel
    {
        public List<Atividade> Atividades { get; set; }
        public string Pesquisar { get; set; }
    }
}
