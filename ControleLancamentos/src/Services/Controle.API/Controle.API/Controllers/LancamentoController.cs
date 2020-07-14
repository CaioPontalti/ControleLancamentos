using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle.Domain.Commands.Lancamento;
using Controle.Domain.Handler.Lancamento;
using Controle.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly CreateLancamentoHandler _createLancamentoHandler;
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoController(CreateLancamentoHandler createLancamentoHandler, ILancamentoRepository lancamentoRepository)
        {
            _createLancamentoHandler = createLancamentoHandler;
            _lancamentoRepository = lancamentoRepository;
        }

        [HttpPost]
        [Route("create-lancamento")]
        public async Task<IActionResult> CreateLancamento([FromBody] CreateLancamentoCommand command)
        {
            var result = await _createLancamentoHandler.Handle(command);

            if (result.Notifications.Any())
                return BadRequest(result.Notifications);

            return Ok(result);
        }

        [HttpGet]
        [Route("return-lancamentos")]
        public async Task<IActionResult> ReturnLancamento()
        {
            var result = await _lancamentoRepository.RetornarLancamentos();

            return Ok(result);
        }

        [HttpGet]
        [Route("return-lancamentos/{conta}")]
        public async Task<IActionResult> ReturnLancamentoConta(string conta)
        {
            var result = await _lancamentoRepository.RetornarLancamentosContaOrigem(conta);

            return Ok(result);
        }
    }
}