using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Resposta_OpcaoService : IResposta_OpcaoService
    {
        public readonly ApplicationDbContext _context;

        public Resposta_OpcaoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        } 

        public async Task<IEnumerable<Resposta_Opcao>> GetResposta_OpcaoAsync()
        {
            var resposta_Opcao = await _context.Resposta_Opcoes.ToArrayAsync();

            return resposta_Opcao;
        }

        public async Task<int> SetResposta_OpcaoAsync(Resposta_Opcao resposta_Opcao)
        {
            await _context.Resposta_Opcoes.AddAsync(resposta_Opcao);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateResposta_OpcaoAsync(Resposta_Opcao resposta_Opcao)
        {
            _context.Resposta_Opcoes.Update(resposta_Opcao);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
