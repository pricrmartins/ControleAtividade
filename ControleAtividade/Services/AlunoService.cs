using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtividade.Services
{
    public class AlunoService : IAlunoService
    {
        public readonly ApplicationDbContext _context;

        public AlunoService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public async Task<Aluno> GetAlunoPorMatriculaAsync(string matricula)
        {
            var aluno = await _context.Alunos
                .Where(a => a.ApplicationUser.Matricula.ToUpper().Equals(matricula.ToUpper()))
                .SingleAsync();

            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosAsync()
        {
            var alunos = await _context.Alunos.ToArrayAsync();

            return alunos;
        }

        public async Task<int> SetAlunoAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }

        public async Task<int> UpdateAlunoAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);

            var resultado = await _context.SaveChangesAsync();

            return resultado;
        }
    }
}
