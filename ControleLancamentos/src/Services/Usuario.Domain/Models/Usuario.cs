using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Domain.Models
{
    public class Usuario 
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(string login, string senha)
        {
            Id = Guid.NewGuid();
            Login = login;
            Senha = senha;
        }

        public Usuario() { }
    }
}
