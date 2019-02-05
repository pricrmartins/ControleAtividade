using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.TurmasAlunoViewModels
{
    public class ConsultarTurmasAlunoViewModel
    {
        public IEnumerable<Turma> Turmas { get; set; }
        public List<TurmasAluno> TurmasAluno { get; set; }
        public string Pesquisar { get; set; }
    }

    public class TurmasAluno
    {
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
        public string Status { get; set; }
    }
}
