using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IResposta_AtividadeService
    {
        Task<IEnumerable<Resposta_Atividade>> GetResposta_AtividadesAsync();

        Task<int> SetAtividade_AlunoAsync(Resposta_Atividade resposta_Atividade);

        Task<int> UpdateResposta_AtividadeAsync(Resposta_Atividade resposta_Atividade);

        Task<IEnumerable<Resposta_Atividade>> GetRespostaAtividadePorAlunoAsync(int Id);
    }
}
