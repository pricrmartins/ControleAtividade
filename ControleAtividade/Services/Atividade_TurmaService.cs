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

        public async Task<Atividade_Turma> ExisteAtividadeAtivaNaTurma(string CodigoTurma, int IdAtividade)
        {
            return await _context.Atividades_Turma
                .Where(t => t.Turma.Codigo.ToUpper().Equals(CodigoTurma.ToUpper()) 
                && t.IdAtividade == IdAtividade && t.Disponivel)
                .Include(t => t.Atividade)
                .Include(t => t.Turma).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Atividade_Turma>> GetAtividadesTurmaCodigoAsync(string codigo)
        {
            var atividades_Turma = await _context.Atividades_Turma
                .Where(t => t.Turma.Codigo.ToUpper().Equals(codigo.ToUpper()))
                .Include(t => t.Atividade)
                .Include(t => t.Turma).ToArrayAsync();

            return atividades_Turma;
        }

        public async Task<IEnumerable<Atividade_Turma>> GetAtividades_TurmaAsync()
        {
            var atividades_Turma = await _context.Atividades_Turma
                .Include(t => t.Atividade)
                .Include(t => t.Turma).ToArrayAsync();

            return atividades_Turma;
        }

        public async Task<Atividade_Turma> GetAtividadeTurmaAsync(int IdAtividadeTurma)
        {
            var atividade_Turma = await _context.Atividades_Turma
                .Where(t => t.Id == IdAtividadeTurma)
                .Include(t => t.Atividade)
                .Include(t => t.Turma).FirstOrDefaultAsync();

            return atividade_Turma;
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
