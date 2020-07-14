using Application.Tests.Usuarios.Repositorios;
using Controle.Domain.Handler.Conta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Usuario.Domain.Commands;
using Usuario.Domain.Handler;

namespace Application.Tests.Usuarios.Handler
{
    [TestClass]
    public class CreateUserHandlerTest
    {
        [TestMethod]
        public void DadoUmUsuarioValido_Valid()
        {
            var command = new CreateUserCommand("Usuario", "1234", "1234");

            var handler = new CreateUserHandler(new FakeRepositoryUsuario());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(0, result.Notifications.Count);
            Assert.AreEqual(true, result.Valid);
        }

        [TestMethod]
        public void DadoUmUsuarioJaCadastrado_IsInvalid()
        {
            var command = new CreateUserCommand("user", "1234", "1234");

            var handler = new CreateUserHandler(new FakeRepositoryUsuario());
            var result = handler.Handle(command).Result;

            Assert.AreNotEqual(0, result.Notifications.Count);
            Assert.AreEqual(true, result.Invalid);
        }
    }
}
