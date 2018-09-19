using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Resposta_AtividadeService : IResposta_AtividadeService
    {
        public readonly ApplicationDbContext _context;

        public Resposta_AtividadeService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Resposta_Atividade>> GetRespostaAtividadePorAlunoAsync(int Id)
        {
            var resposta_Atividades = await _context.Resposta_Atividades
               .Where(a => a.IdAluno == Id).ToArrayAsync();

            return resposta_Atividades;
        }

        public async Task<IEnumerable<Resposta_Atividade>> GetResposta_AtividadesAsync()
        {
            var resposta_Atividades = await _context.Resposta_Atividades.ToArrayAsync();

            return resposta_Atividades;
        }

        public async Task<int> SetAtividade_AlunoAsync(Resposta_Atividade resposta_Atividade)
        {
            await _context.Resposta_Atividades.AddAsync(resposta_Atividade);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateResposta_AtividadeAsync(Resposta_Atividade resposta_Atividade)
        {
            _context.Resposta_Atividades.Update(resposta_Atividade);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
