using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class QuestaoService : IQuestaoService
    {
        public readonly ApplicationDbContext _context;

        public QuestaoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public async Task<IEnumerable<Questao>> GetQuestoesAsync()
        {
            var questoes = await _context.Questoes.ToArrayAsync();

            return questoes;
        }

        public async Task<int> SetQuestaoAsync(Questao questao)
        {
            await _context.Questoes.AddAsync(questao);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateQuestaoAsync(Questao questao)
        {
            _context.Questoes.Update(questao);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
