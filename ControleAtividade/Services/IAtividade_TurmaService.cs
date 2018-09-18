using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IAtividade_TurmaService
    {
        Task<IEnumerable<Atividade_Turma>> GetAtividades_TurmaAsync();

        Task<int> SetAtividade_TurmaAsync(Atividade_Turma atividade_Turma);

        Task<int> UpdateAtividade_TurmaAsync(Atividade_Turma atividade_Turma);
    }
}
