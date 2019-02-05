using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models.TurmasViewModels
{
    public class CadastrarAlunoTurmaViewModel
    {
        public IEnumerable<Turma_Aluno> Turma_Alunos { get; set; }
        public string Pesquisar { get; set; }
    }
}
