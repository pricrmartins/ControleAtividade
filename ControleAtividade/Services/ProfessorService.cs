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

        public async Task<int> SetProfessorAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            var resultado = await _context.SaveChangesAsync();
            return resultado;
        }
    }
}
