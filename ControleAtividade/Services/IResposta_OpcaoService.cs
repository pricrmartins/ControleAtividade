using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IResposta_OpcaoService
    {
        Task<IEnumerable<Resposta_Opcao>> GetResposta_OpcaoAsync();

        Task<int> SetResposta_OpcaoAsync(Resposta_Opcao resposta_Opcao);

        Task<int> UpdateResposta_OpcaoAsync(Resposta_Opcao resposta_Opcao);
    }
}
