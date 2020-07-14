using Controle.Domain.Commands.Conta;
using Controle.Domain.Interfaces;
using Controle.Domain.Models;
using Controle.Shared.Contracts;
using Controle.Shared.Core;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controle.Domain.Handler.Conta
{
    public class CreateContaHandler : ICommandHandler<CreateContaCommand>
    {
        private readonly IContaRepository _contaRepository;

        public CreateContaHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<ResponseCommand> Handle(CreateContaCommand command)
        {
            var response = new ResponseCommand();

            command.Validate();
            if (command.Invalid)
            {
                response.AddNotifications(command.Notifications);
                return response;
            }

            if (await _contaRepository.ContaExiste(command.NumeroConta))
            {
                response.AddNotification(new Notification("Conta", "A conta informada já existe!"));
                return response;
            }

            var conta = new ContaCorrente(command.NumeroConta);
            await _contaRepository.CadastrarConta(conta);

            response.AddValue(command.NumeroConta);

            return response;
        }
    }
}
