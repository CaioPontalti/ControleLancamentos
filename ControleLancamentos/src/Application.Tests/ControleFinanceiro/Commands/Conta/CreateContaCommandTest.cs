using Controle.Domain.Commands.Conta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tests.ControleFinanceiro.Conta.Commands
{
    [TestClass]
    public class CreateContaCommandTest
    {
        [TestMethod]
        public void DadoUmaContaValida_IsValid()
        {
            var command = new CreateContaCommand("123456");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmaContainvalida_IsInvalid()
        {
            var command = new CreateContaCommand("");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}
