using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IAtividadeService
    {
        Task<IEnumerable<Atividade>> GetAtividadesAsync();

        Task<int> SetAtividadeAsync(Atividade atividade);

        Task<int> UpdateAtividadeAsync(Atividade atividade);
    }
}
