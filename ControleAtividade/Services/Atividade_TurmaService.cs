using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Atividade_TurmaService : IAtividade_TurmaService
    {
        public readonly ApplicationDbContext _context;

        public Atividade_TurmaService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Atividade_Turma>> GetAtividades_TurmaAsync()
        {
            var atividades_Turma = await _context.Atividades_Turma.ToArrayAsync();

            return atividades_Turma;
        }

        public async Task<int> SetAtividade_TurmaAsync(Atividade_Turma atividade_Turma)
        {
            await _context.Atividades_Turma.AddAsync(atividade_Turma);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateAtividade_TurmaAsync(Atividade_Turma atividade_Turma)
        {
            _context.Atividades_Turma.Update(atividade_Turma);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
