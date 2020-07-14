using Controle.Shared.Contracts;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Controle.Domain.Commands.Conta
{
    public class CreateContaCommand : Notifiable, ICommand
    {
        public string NumeroConta { get; set; }

        private CreateContaCommand() { }

        public CreateContaCommand(string numeroConta)
        {
            NumeroConta = numeroConta;
        }

        public void Validate()
        {
            AddNotifications(
               new ValidationContract()
                    .Requires()
                    .IsNotNullOrEmpty(NumeroConta, "NumeroConta", "O número da Conta é obrigatório")
            );
        }
    }
}
