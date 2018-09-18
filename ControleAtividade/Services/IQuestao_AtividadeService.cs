using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IQuestao_AtividadeService
    {
        Task<IEnumerable<Questao_Atividade>> GetQuestoes_AtividadeAsync();

        Task<int> SetQuestao_AtividadeAsync(Questao_Atividade questao_Atividade);

        Task<int> UpdateQuestao_Atividadesync(Questao_Atividade questao_Atividade);
    }
}
