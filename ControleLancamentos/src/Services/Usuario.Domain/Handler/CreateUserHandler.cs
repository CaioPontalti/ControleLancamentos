using Controle.Shared.Contracts;
using Controle.Shared.Core;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuario.Domain.Commands;
using Usuario.Domain.Interfaces;

namespace Usuario.Domain.Handler
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseCommand> Handle(CreateUserCommand command)
        {
            var response = new ResponseCommand();

            command.Validate();
            if (command.Invalid)
            {
                response.AddNotifications(command.Notifications);
                return response;
            }

            if (await _userRepository.UserExiste(command.Login) != null)
            {
                response.AddNotification(new Notification("Usuario", "Usuário já existe."));
                return response;
            }

            var user = new Models.Usuario(command.Login, command.Senha);

            await _userRepository.Save(user);

            response.AddValue(new { Mensagem = "Usuário Cadastrado", Id = user.Id, Login = user.Login });

            return response;
        }
    }
}
