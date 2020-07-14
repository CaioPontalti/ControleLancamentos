using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text;

namespace Controle.Domain.Models
{
    public class Lancamento
    {
        public Guid Id { get; private set; }
        public string NumeroContaOrigem { get; private set; }
        public string NumeroContaDestino { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataLancamento { get; private set; }

        private Lancamento() { }

        public Lancamento(string origem, string destino, decimal valor)
        {
            NumeroContaOrigem = origem;
            NumeroContaDestino = destino;
            Valor = valor;

            Id = Guid.NewGuid();
            DataLancamento = DateTime.Now;
        }
    }
}
