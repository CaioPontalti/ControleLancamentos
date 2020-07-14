using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Domain.Queries
{
    public class UserQueryDTO
    {
        public UserQueryDTO(Guid id, string login)
        {
            Id = id;
            Login = login;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
    }
}
