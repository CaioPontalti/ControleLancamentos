using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Domain.Interfaces;
using Usuario.Domain.Queries;
using Usuario.Infra.Context;

namespace Usuario.Infra.Repositorio
{
    public class UsuarioRepository : IUserRepository
    {
        private readonly UsuarioContext _usuarioContext;

        public UsuarioRepository(UsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }

        public async Task<IEnumerable<UserQueryDTO>> GetAll()
        {
            var usersList = new List<UserQueryDTO>();
            var users = await _usuarioContext.Usuario.AsNoTracking().ToListAsync();
            foreach (var item in users)
            {
                usersList.Add(new UserQueryDTO(item.Id, item.Login));
            }

            return await Task.FromResult(usersList);
        }

        public async Task<Domain.Models.Usuario> GetUser(string login, string senha)
        {
            return await _usuarioContext.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login && u.Senha == senha);
        }

        public async Task Save(Domain.Models.Usuario user)
        {
            await _usuarioContext.Usuario.AddAsync(user);
            await _usuarioContext.SaveChangesAsync();
        }

        public async Task<Domain.Models.Usuario> UserExiste(string login)
        {
            return await _usuarioContext.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
