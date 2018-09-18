using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface ITurmaService
    {
        Task<IEnumerable<Turma>> GetTurmasAsync();

        Task<int> SetTurmaAsync(Turma turma);

        Task<IEnumerable<Turma>> GetTurmasPorProfessorAsync(int idProfessor);

        Task<int> UpdateTurmaAsync(Turma turma);

        Task<bool> TurmaExists(string Codigo);

        Task<Turma> GetTurmaPorCodigo(string Codigo);
    }
}
