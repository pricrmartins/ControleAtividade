using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class Turma_AlunoService : ITurma_AlunoService
    {
        public readonly ApplicationDbContext _context;

        public Turma_AlunoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<bool> ExisteAlunoVinculadoNaTurma(int IdAluno, string CodigoTurma)
        {
            var turma_Aluno = await _context.Turmas_Aluno
                .Where(turma => turma.IdAluno == IdAluno && turma.CodigoTuma.Equals(CodigoTurma)).FirstOrDefaultAsync();

            return turma_Aluno != null ? true : false;
        }

        public async Task<IEnumerable<Turma_Aluno>> GetAlunosPorProfessorAsync(int IdProfessor)
        {
            var turmas_Aluno = await _context.Turmas_Aluno
                .Include(turma => turma.Turma)
                .Include(turma => turma.Turma.Professor)
                .Where(turma => turma.Turma.IdProfessor == IdProfessor)
                .ToArrayAsync();

            return turmas_Aluno;
        }

        public async Task<IEnumerable<Turma_Aluno>> GetTurmasDiferenteAlunoAsync(int IdAluno)
        {
            var turmas_Aluno = await _context.Turmas_Aluno
                .Where(turma => turma.IdAluno != IdAluno)
                .Include(turma => turma.Turma)
                .Include(turma => turma.Turma.Professor)
                .ToArrayAsync();

            return turmas_Aluno;
        }

        public async Task<IEnumerable<Turma_Aluno>> GetTurmasPorAlunoAsync(Aluno aluno)
        {
            var turmas_Aluno = await _context.Turmas_Aluno
                .Where(turma => turma.IdAluno == aluno.Id)
                .Include(turma => turma.Turma)
                .Include(turma => turma.Turma.Professor)
                .ToArrayAsync();

            return turmas_Aluno;
        }

        public async Task<IEnumerable<Turma_Aluno>> GetTurmas_AlunoAsync()
        {
            var turmas_Aluno = await _context.Turmas_Aluno
                .Include(turma => turma.Aluno)
                .Include(turma => turma.Turma)
                .ToArrayAsync();

            return turmas_Aluno;
        }

        public async Task<int> SetTurma_AlunoAsync(Turma_Aluno turma_Aluno)
        {
            _context.Turmas_Aluno.Add(turma_Aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateTurma_AlunoAsync(Turma_Aluno turma_Aluno)
        {
            _context.Turmas_Aluno.Update(turma_Aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
