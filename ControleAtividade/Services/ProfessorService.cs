using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class ProfessorService : IProfessorService
    {
        public readonly ApplicationDbContext _context;

        public ProfessorService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public async Task<IEnumerable<Professor>> GetProfessoresAsync()
        {
            var professores = await _context.Professores.ToArrayAsync();

            return professores;
        }

        public async Task<Professor> GetProfessorPorCPFAsync(string CPF)
        {
            var professor = await _context.Professores
                .Where(a => a.ApplicationUser.UserName.ToUpper().Equals(CPF.ToUpper()))
                .Include(p => p.ApplicationUser)
                .SingleOrDefaultAsync();

            return professor;
        }

        public async Task<Professor> GetProfessorPorIdUsuario(string IdUsuario)
        {
            var professor = await _context.Professores
                .Where(a => a.ApplicationUser.Id.Equals(IdUsuario))
                .Include(p => p.ApplicationUser)
                .SingleOrDefaultAsync();

            return professor;
        }

        public async Task<bool> ProfessorExists(string matricula)
        {
            return await _context.Professores.AnyAsync(e => e.ApplicationUser.UserName.ToUpper().Equals(matricula.ToUpper()));
        }

        public async Task<int> SetProfessorAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateProfessorAsync(Professor professor)
        {
            _context.Professores.Update(professor);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
