using Controle.Shared.Contracts;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Domain.Commands
{
    public class CreateUserCommand : Notifiable, ICommand
    {

        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }

        public CreateUserCommand(string login, string senha, string confimarSenha)
        {
            Login = login;
            Senha = senha;
            ConfirmarSenha = confimarSenha;
        }

        private CreateUserCommand() { }

        public void Validate()
        {
            if (Senha != ConfirmarSenha)
                AddNotification(new Notification("Register", "Os campos de senha não conferem"));

            AddNotifications(
              new ValidationContract()
                   .Requires()
                   .HasMinLen(Senha, 3, "Senha", " A senha deve ter no mínimo 3 caracteres!")
                   .IsNotNullOrEmpty(Login, Login, "Login obrigatório")
           ); ;
        }
    }
}
