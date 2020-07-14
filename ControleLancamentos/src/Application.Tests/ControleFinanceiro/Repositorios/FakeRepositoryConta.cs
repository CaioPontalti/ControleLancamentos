using Controle.Domain.Interfaces;
using Controle.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.ControleFinanceiro.Repositorios
{
    public class FakeRepositoryConta : IContaRepository
    {
        public FakeRepositoryConta()
        {

        }

        public async Task CadastrarConta(ContaCorrente conta)
        {
            await Task.CompletedTask;
        }

        public async Task<bool> ContaExiste(string numeroConta)
        {
            if(numeroConta == "123456")
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public Task<IEnumerable> RetornarContas()
        {
            throw new NotImplementedException();
        }
    }
}
