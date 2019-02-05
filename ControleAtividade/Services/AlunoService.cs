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
        public async Task<Aluno> GetAlunoPorCPFAsync(string CPF)
        {
            var aluno = await _context.Alunos
                .Where(a => a.ApplicationUser.UserName.ToUpper().Equals(CPF.ToUpper()))
                .SingleOrDefaultAsync();

            return aluno;
        }

        public async Task<Aluno> GetAlunoPorIdAlunoAsync(int Id)
        {
            var aluno = await _context.Alunos
                .Include(a => a.ApplicationUser)
                .Where(a => a.Id == Id)
                .SingleOrDefaultAsync();

            return aluno;
        }

        public async Task<Aluno> GetAlunoPorIdUsuario(string Id)
        {
            var aluno = await _context.Alunos
                .Where(a => a.ApplicationUser.Id.Equals(Id))
                .SingleOrDefaultAsync();

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
