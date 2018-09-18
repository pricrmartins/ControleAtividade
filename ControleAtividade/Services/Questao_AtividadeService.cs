using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Questao_AtividadeService : IQuestao_AtividadeService
    {
        public readonly ApplicationDbContext _context;

        public Questao_AtividadeService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Questao_Atividade>> GetQuestoes_AtividadeAsync()
        {
            var questoes_Atividade = await _context.Questoes_Atividade.ToArrayAsync();

            return questoes_Atividade;
        }

        public async Task<int> SetQuestao_AtividadeAsync(Questao_Atividade questao_Atividade)
        {
            await _context.Questoes_Atividade.AddAsync(questao_Atividade);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateQuestao_Atividadesync(Questao_Atividade questao_Atividade)
        {
            _context.Questoes_Atividade.Update(questao_Atividade);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
