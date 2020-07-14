using Controle.Domain.Commands.Lancamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tests.ControleFinanceiro.Lancamento.Commands
{
    [TestClass]
    public class CreateLancamentoCommandTest
    {
        [TestMethod]
        public void DadoUmLancamentoValido_IsValid()
        {
            var command = new CreateLancamentoCommand("1234", "123456", 10);
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmLancamentoInvalidoSemValor_IsInvalid()
        {
            var command = new CreateLancamentoCommand("1234", "123456",0);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmLancamentoInvalidoContasIguais_IsInvalid()
        {
            var command = new CreateLancamentoCommand("123456", "123456", 100);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmLancamentoInvalidoContasVazias_IsInvalid()
        {
            var command = new CreateLancamentoCommand("", "", 15);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

    }
}
