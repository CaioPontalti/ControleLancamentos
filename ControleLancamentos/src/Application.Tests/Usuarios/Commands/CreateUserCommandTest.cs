using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Usuario.Domain.Commands;

namespace Application.Tests.Usuarios.Commands
{
    [TestClass]
    public class CreateUserCommandTest
    {
        [TestMethod]
        public void DadoUmLoginValido_IsValid()
        {
            var command = new CreateUserCommand("usuario", "123456", "123456");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmLoginComSenhasDiferentes_IsInvalid()
        {
            var command = new CreateUserCommand("usuario", "123", "123456");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmLoginComSenhaMenorQue3_IsInvalid()
        {
            var command = new CreateUserCommand("usuario", "12", "12");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmLoginUsuarioBranco_IsInvalid()
        {
            var command = new CreateUserCommand("", "1234", "1234");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}
