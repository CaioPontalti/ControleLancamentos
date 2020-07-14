using Controle.Domain.Interfaces;
using Controle.Domain.Models;
using Controle.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Infra.Repositorios
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ControleContext _controleContext;

        public LancamentoRepository(ControleContext controleContext)
        {
            _controleContext = controleContext;
        }

        public async Task GerarLancamento(Lancamento lancamento)
        {
            await _controleContext.Lancamento.AddAsync(lancamento);
            await _controleContext.SaveChangesAsync();

        }

        public async Task<IEnumerable> RetornarLancamentos()
        {
            return await _controleContext.Lancamento.AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable> RetornarLancamentosContaOrigem(string contaOrigem)
        {
            return await _controleContext.Lancamento.AsNoTracking()
                .Where(c => c.NumeroContaOrigem == contaOrigem).ToListAsync();
        }
    }
}
