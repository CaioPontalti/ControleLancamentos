using Controle.Shared.Contracts;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Domain.Commands.Lancamento
{
    public class CreateLancamentoCommand : Notifiable, ICommand
    {
        public CreateLancamentoCommand(string numeroContaOrigem, string numeroContaDestino, decimal valor)
        {
            NumeroContaOrigem = numeroContaOrigem;
            NumeroContaDestino = numeroContaDestino;
            Valor = valor;
        }

        public string NumeroContaOrigem { get; set; }
        public string NumeroContaDestino { get; set; }
        public decimal Valor { get; set; }


        public void Validate()
        {
            if (Valor <= 0)
                AddNotification("Valor", "Valor da transferência não informado.");

            if(NumeroContaOrigem == NumeroContaDestino)
                AddNotification("Lançamento", "Conta de origem e destino não pode ser iguais.");

            AddNotifications(
                  new ValidationContract()
                       .Requires()
                       .IsNotNullOrEmpty(NumeroContaOrigem, "NumeroContaOrigem", "O número da Conta de origem é obrigatório")
                       .IsNotNullOrEmpty(NumeroContaDestino, "NumeroContaDestino", "O número da Conta de destino é obrigatório")
               );
        }
    }
}
