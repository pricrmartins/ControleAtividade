using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Atividade_AlunoService : IAtividade_AlunoService
    {
        public readonly ApplicationDbContext _context;

        public Atividade_AlunoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Atividade_Aluno>> GetAtividade_AlunosAsync()
        {
            var atividades_Aluno = await _context.Atividades_Aluno.ToArrayAsync();

            return atividades_Aluno;
        }

        public async Task<int> SetAtividade_AlunoAsync(Atividade_Aluno atividade_Aluno)
        {
            await _context.Atividades_Aluno.AddAsync(atividade_Aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateAtividade_AlunoAsync(Atividade_Aluno atividade_Aluno)
        {
            _context.Atividades_Aluno.Update(atividade_Aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
