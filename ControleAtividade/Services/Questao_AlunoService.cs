using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Questao_AlunoService : IQuestao_AlunoService
    {
        public readonly ApplicationDbContext _context;

        public Questao_AlunoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        } 
        public async Task<IEnumerable<Questao_Aluno>> GetQuestoes_AlunoAsync()
        {
            var questoes_Aluno = await _context.Questoes_Aluno.ToArrayAsync();

            return questoes_Aluno;
        }

        public async Task<int> SetQuestao_AlunoAsync(Questao_Aluno questao_Aluno)
        {
            await _context.Questoes_Aluno.AddAsync(questao_Aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateQuestao_AlunoAsync(Questao_Aluno questao_Aluno)
        {
            _context.Questoes_Aluno.Update(questao_Aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
