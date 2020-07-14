using Application.Tests.ControleFinanceiro.Repositorios;
using Controle.Domain.Commands.Conta;
using Controle.Domain.Handler.Conta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Tests.ControleFinanceiro.Handler
{
    [TestClass]
    public class CreateContaHandlerTest
    {
        [TestMethod]
        public void DadoUmaContaValida_Valid()
        {
            var command = new CreateContaCommand("1234");

            var handler = new CreateContaHandler(new FakeRepositoryConta());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(0, result.Notifications.Count);
            Assert.AreEqual(true, result.Valid);
        }

        [TestMethod]
        public void DadoUmaContaJaExistente_IsInvalid()
        {
            var command = new CreateContaCommand("123456");

            var handler = new CreateContaHandler(new FakeRepositoryConta());
            var result = handler.Handle(command).Result;

            Assert.AreNotEqual(0, result.Notifications.Count);
            Assert.AreEqual(true, result.Invalid);
        }

        [TestMethod]
        public void DadoUmaContaVazia_IsInvalid()
        {
            var command = new CreateContaCommand("");

            var handler = new CreateContaHandler(new FakeRepositoryConta());
            var result = handler.Handle(command).Result;

            Assert.AreNotEqual(0, result.Notifications.Count);
            Assert.AreEqual(true, result.Invalid);
        }
    }
}
