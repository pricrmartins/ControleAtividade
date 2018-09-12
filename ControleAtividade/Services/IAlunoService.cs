using ControleAtividade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Services
{
    interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetItemAsync();
    }
}
