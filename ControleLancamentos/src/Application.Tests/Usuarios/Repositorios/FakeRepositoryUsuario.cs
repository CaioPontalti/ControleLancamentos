using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuario.Domain.Interfaces;
using Usuario.Domain.Queries;

namespace Application.Tests.Usuarios.Repositorios
{
    public class FakeRepositoryUsuario : IUserRepository
    {
        public Task<IEnumerable<UserQueryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario.Domain.Models.Usuario> GetUser(string login, string senha)
        {
            if (login == "user")
                return await Task.FromResult(new Usuario.Domain.Models.Usuario());
            else
                return null;
        }

        public async Task Save(Usuario.Domain.Models.Usuario user)
        {
            await Task.CompletedTask;
        }

        public async Task<Usuario.Domain.Models.Usuario> UserExiste(string login)
        {
            if (login == "user")
                return await Task.FromResult(new Usuario.Domain.Models.Usuario());
            else
                return null;
        }
    }
}
