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
    public class ContaRepository : IContaRepository
    {
        private readonly ControleContext _controleContext;

        public ContaRepository(ControleContext controleContext)
        {
            _controleContext = controleContext;
        }

        public async Task CadastrarConta(ContaCorrente conta)
        {
            await _controleContext.ContaCorrente.AddAsync(conta);
            await _controleContext.SaveChangesAsync();
        }

        public async Task<bool> ContaExiste(string numeroConta)
        {
            var result = await _controleContext.ContaCorrente.AsNoTracking()
                .AnyAsync(c => c.NumeroConta == numeroConta);

            return result;
        }

        public async Task<IEnumerable> RetornarContas()
        {
            return await _controleContext.ContaCorrente.AsNoTracking().ToListAsync();
        }
    }
}
