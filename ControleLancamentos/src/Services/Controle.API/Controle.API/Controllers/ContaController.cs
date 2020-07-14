using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle.Domain.Commands.Conta;
using Controle.Domain.Handler.Conta;
using Controle.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository _contaRepository;
        private readonly CreateContaHandler _createContaHandler;

        public ContaController(IContaRepository contaRepository, CreateContaHandler createContaHandler)
        {
            _contaRepository = contaRepository;
            _createContaHandler = createContaHandler;
        }

        [HttpPost]
        [Route("create-conta")]
        public async Task<IActionResult> CreateConta([FromBody] CreateContaCommand command)
        {
            var result = await _createContaHandler.Handle(command);

            if (result.Notifications.Any())
                return BadRequest(result.Notifications);

            return Ok(result);
        }

        [HttpGet]
        [Route("return-contas")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contaRepository.RetornarContas();
            return Ok(result);
        }
    }
}