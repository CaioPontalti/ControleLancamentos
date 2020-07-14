using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Save(Models.Usuario user);
        Task<IEnumerable<Queries.UserQueryDTO>> GetAll();
        Task<Models.Usuario> GetUser(string login, string senha);
        Task<Models.Usuario> UserExiste(string login);

    }
}
