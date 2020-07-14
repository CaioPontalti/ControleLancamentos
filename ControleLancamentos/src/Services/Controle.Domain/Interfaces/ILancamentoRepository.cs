using Controle.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Domain.Interfaces
{
    public interface ILancamentoRepository
    {
        Task GerarLancamento(Lancamento lancamento);
        Task<IEnumerable> RetornarLancamentos();

        Task<IEnumerable> RetornarLancamentosContaOrigem(string contaOrigem);
    }
}
