using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class OpcaoService : IOpcaoService
    {
        public readonly ApplicationDbContext _context;

        public OpcaoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Opcao>> GetOpcoesAsync()
        {
            var opcoes = await _context.Opcoes.ToArrayAsync();

            return opcoes;
        }

        public async Task<int> SetOpcaoAsync(Opcao opcao)
        {
            await _context.Opcoes.AddAsync(opcao);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateOpcaoAsync(Opcao opcao)
        {
            _context.Opcoes.Update(opcao);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
