﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class AtividadeService : IAtividadeService
    {
        public readonly ApplicationDbContext _context;

        public AtividadeService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public async Task<IEnumerable<Atividade>> GetAtividadesAsync()
        {
            var atividades = await _context.Atividades.ToArrayAsync();

            return atividades;
        }

        public async Task<int> SetAtividadeAsync(Atividade atividade)
        {
            await _context.Atividades.AddAsync(atividade);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateAtividadeAsync(Atividade atividade)
        {
            _context.Atividades.Update(atividade);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}