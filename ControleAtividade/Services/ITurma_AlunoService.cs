using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface ITurma_AlunoService
    {
        Task<IEnumerable<Turma_Aluno>> GetTurmas_AlunoAsync();

        Task<int> SetTurma_AlunoAsync(Turma_Aluno turma_Aluno);

        Task<int> UpdateTurma_AlunoAsync(Turma_Aluno turma_Aluno);

        Task<IEnumerable<Turma_Aluno>> GetTurmasPorAlunoAsync(Aluno aluno);

        Task<IEnumerable<Turma_Aluno>> GetAlunosPorProfessorAsync(int IdProfessor);

        Task<IEnumerable<Turma_Aluno>> GetTurmasDiferenteAlunoAsync(int IdAluno);

        Task<bool> ExisteAlunoVinculadoNaTurma(int IdAluno, string CodigoTurma);
    }
}
