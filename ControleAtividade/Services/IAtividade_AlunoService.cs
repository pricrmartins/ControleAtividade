using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IAtividade_AlunoService
    {
        Task<IEnumerable<Atividade_Aluno>> GetAtividade_AlunosAsync();

        Task<int> SetAtividade_AlunoAsync(Atividade_Aluno atividade_Aluno);

        Task<int> UpdateAtividade_AlunoAsync(Atividade_Aluno atividade_Aluno);
    }
}
