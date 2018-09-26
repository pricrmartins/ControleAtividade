using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IOpcao_CorretaService
    {
        Task<IEnumerable<Opcao_Correta>> GetOpcoesAsync();

        Task<int> SetOpcao_CorretaAsync(Opcao_Correta opcao_Correta);

        Task<int> UpdateOpcao_CorretaAsync(Opcao_Correta opcao_Correta);

        Task<Opcao_Correta> GetOpcaoCorreta(int IdOpcao);
    }
}
