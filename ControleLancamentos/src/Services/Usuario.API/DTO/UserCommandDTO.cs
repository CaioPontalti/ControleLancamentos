using Controle.Shared.Contracts;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Usuario.API.DTO
{
    public class UserCommandDTO : Notifiable, ICommand
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(
              new ValidationContract()
                   .Requires()
                   .IsNullOrEmpty(Login, Login, " Campo Login é obrigatório")
                   .IsNullOrEmpty(Senha, Senha, " Campo Senha é obrigatório")
           );
        }
    }
}
