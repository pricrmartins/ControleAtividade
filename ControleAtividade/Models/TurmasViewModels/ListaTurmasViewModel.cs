using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.TurmasViewModels
{
    public class ListaTurmasViewModel
    {
        public IEnumerable<Turma> Turmas { get; set; }
        public string Pesquisar { get; set; }
    }
}
