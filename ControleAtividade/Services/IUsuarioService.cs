using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetItemAsync();
    }
}
