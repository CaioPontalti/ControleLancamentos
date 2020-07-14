using Controle.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task CadastrarConta(ContaCorrente conta);

        Task<bool> ContaExiste(string numeroConta);

        Task<IEnumerable> RetornarContas();
    }
}
