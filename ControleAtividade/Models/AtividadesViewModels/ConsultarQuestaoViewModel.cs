using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AtividadesViewModels
{
    public class ConsultarQuestaoViewModel
    {
        public List<Questao> Questoes { get; set; }
        public Atividade Atividade { get; set; }
        public string Pesquisar { get; set; }
    }
}
