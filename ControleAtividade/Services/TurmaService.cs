using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class TurmaService : ITurmaService
    {
        public readonly ApplicationDbContext _context;

        public TurmaService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Turma>> GetTurmasPorProfessorAsync(int idProfessor)
        {
            var turmas = await _context.Turmas
                .Where(turma => turma.IdProfessor == idProfessor)
                .ToArrayAsync();

            return turmas;
        }

        public async Task<IEnumerable<Turma>> GetTurmasAsync()
        {
            var turmas = await _context.Turmas
                .Include(t => t.Professor)
                .Include(t => t.Professor.ApplicationUser)
                .ToArrayAsync();

            return turmas;
        }

        public async Task<int> SetTurmaAsync(Turma turma)
        {
            _context.Turmas.Add(turma);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateTurmaAsync(Turma turma)
        {
            _context.Turmas.Update(turma);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<bool> TurmaExists(string Codigo)
        {
           return await _context.Turmas.AnyAsync(t => t.Codigo.ToUpper().Equals(Codigo.ToUpper()));
        }

        public async Task<Turma> GetTurmaPorCodigo(string Codigo)
        {
            var turma = await _context.Turmas.Where(t => t.Codigo.ToUpper().Equals(Codigo.ToUpper()))
                .Include(t => t.Professor)
                .Include(t => t.Professor.ApplicationUser)
                .FirstOrDefaultAsync();

            return turma;
        }
    }
}
