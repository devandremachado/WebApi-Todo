using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

// Red - Green - Refactory

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CriarTodoCommandTests
    {
        private readonly CriarTodoCommand _comandoInvalido = new CriarTodoCommand("", "", DateTime.Now);
        private readonly CriarTodoCommand _comandoValido = new CriarTodoCommand("Titulo da Tarefa", "Andre Machado", DateTime.Now);
        
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            _comandoInvalido.Validate();
            Assert.AreEqual(_comandoInvalido.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            _comandoValido.Validate();
            Assert.AreEqual(_comandoValido.Valid, true);
        }
        
    }
}
