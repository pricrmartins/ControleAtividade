using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetProfessoresAsync();

        Task<int> SetProfessorAsync(Professor professor);

        Task<Professor> GetProfessorPorCPFAsync(string CPF);

        Task<int> UpdateProfessorAsync(Professor professor);

        Task<bool> ProfessorExists(string matricula);

        Task<Professor> GetProfessorPorIdUsuario(string IdUsuario);
    }
}
