using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle.Shared.Core;
using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Usuario.API.DTO;
using Usuario.API.Services;
using Usuario.Domain.Commands;
using Usuario.Domain.Handler;
using Usuario.Domain.Interfaces;
using Usuario.Domain.Queries;
using Usuario.Infra.Repositorio;

namespace Usuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CreateUserHandler _createUserHandler;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UsuarioController(CreateUserHandler createUserHandler, IUserRepository userRepository, IConfiguration configuration)
        {
            _createUserHandler = createUserHandler;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ResponseCommand> Create([FromBody] CreateUserCommand command)
        {
            var result = await _createUserHandler.Handle(command);

            return result;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ResponseCommand> Login([FromBody] UserCommandDTO userCommand)
        {
            var response = new ResponseCommand();
            
            var userCreate = new Domain.Models.Usuario(userCommand.Login, userCommand.Senha);
            var user = await _userRepository.GetUser(userCreate.Login, userCreate.Senha);

            if (user == null) 
            {
                response.AddNotification(new Notification("Login", "Usuario ou Senha inválidos."));
                return response;
            }

            var instaceToken = new TokenService(_configuration);
            var token = await instaceToken.GenerateToken(user);

            response.AddValue(new { Mensagem = "Login efetuado com sucesso", Token = token });

            return response;
        }


        [HttpGet]
        [Route("return-users")]
        [Authorize]
        public async Task<IEnumerable<UserQueryDTO>> GetAll()
        {
            var result = await _userRepository.GetAll();

            return result;

        }
    }
}