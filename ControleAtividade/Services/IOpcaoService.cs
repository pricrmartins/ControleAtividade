using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IOpcaoService
    {
        Task<IEnumerable<Opcao>> GetOpcoesAsync();

        Task<int> SetOpcaoAsync(Opcao opcao);

        Task<int> UpdateOpcaoAsync(Opcao opcao);
    }
}
