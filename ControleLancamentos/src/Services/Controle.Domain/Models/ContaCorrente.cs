using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Domain.Models
{
    public class ContaCorrente
    {
        public Guid Id { get; private set; }
        public string NumeroConta { get; private set; }

        public ContaCorrente(string numeroConta)
        {
            Id = Guid.NewGuid();
            NumeroConta = numeroConta;
        }
    }
}
