using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IQuestaoService
    {
        Task<IEnumerable<Questao>> GetQuestoesAsync();

        Task<int> SetQuestaoAsync(Questao questao);

        Task<int> UpdateQuestaoAsync(Questao questao);

        Task<IEnumerable<Questao>> GetQuestoesPorAtividadeAsync(int IdAtividade);

        Task<Questao> GetQuestaoPorId(int IdQuestao);
    }
}
