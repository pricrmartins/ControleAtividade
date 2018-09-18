using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IQuestao_AlunoService
    {
        Task<IEnumerable<Questao_Aluno>> GetQuestoes_AlunoAsync();

        Task<int> SetQuestao_AlunoAsync(Questao_Aluno questao_Aluno);

        Task<int> UpdateQuestao_AlunoAsync(Questao_Aluno questao_Aluno);
    }
}
