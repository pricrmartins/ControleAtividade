using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunosAsync();

        Task<int> SetAlunoAsync(Aluno aluno);

        Task<Aluno> GetAlunoPorCPFAsync(string CPF);

        Task<int> UpdateAlunoAsync(Aluno aluno);
    }
}
