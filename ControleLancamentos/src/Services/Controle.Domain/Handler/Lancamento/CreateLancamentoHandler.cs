using Controle.Domain.Commands.Lancamento;
using Controle.Domain.Interfaces;
using Controle.Domain.Models;
using Controle.Shared.Contracts;
using Controle.Shared.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Domain.Handler.Lancamento
{
    public class CreateLancamentoHandler : ICommandHandler<CreateLancamentoCommand>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public CreateLancamentoHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<ResponseCommand> Handle(CreateLancamentoCommand command)
        {
            var response = new ResponseCommand();

            command.Validate();
            if (command.Invalid)
            {
                response.AddNotifications(command.Notifications);
                return response;
            }

            var lancamento = new Models.Lancamento(
                command.NumeroContaOrigem,
                command.NumeroContaDestino,
                command.Valor);

            await _lancamentoRepository.GerarLancamento(lancamento);

            response.AddValue( new { Mensagem = "Lançamento efetuado com sucesso.",
                                     Compovante = lancamento.Id,
                                     Origem = lancamento.NumeroContaOrigem,
                                     Destino = lancamento.NumeroContaDestino,
                                     Valor = lancamento.Valor,
                                     Data = lancamento.DataLancamento.ToString("dd-MM-yyyy")
            });

            return response;
        }
    }
}
