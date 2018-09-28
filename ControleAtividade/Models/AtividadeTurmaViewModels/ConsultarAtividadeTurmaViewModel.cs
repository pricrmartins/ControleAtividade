using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.AtividadeTurmaViewModels
{
    public class ConsultarAtividadeTurmaViewModel
    {
        public string Pesquisar { get; set; }

        public List<Atividade_Turma> AtividadesTurma { get; set; }

        public string CodigoTurma { get; set; }
    }
}
