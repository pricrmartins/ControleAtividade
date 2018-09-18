using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Opcao_CorretaService : IOpcao_CorretaService
    {
        public readonly ApplicationDbContext _context;

        public Opcao_CorretaService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Opcao_Correta>> GetOpcoesAsync()
        {
            var opcoes = await _context.Opcoes_Correta.ToArrayAsync();

            return opcoes;
        }

        public async Task<int> SetOpcao_CorretaAsync(Opcao_Correta opcao_Correta)
        {
            await _context.Opcoes_Correta.AddAsync(opcao_Correta);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateOpcao_CorretaAsync(Opcao_Correta opcao_Correta)
        {
            _context.Opcoes_Correta.Update(opcao_Correta);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
