using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

// Red - Green - Refactory

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CriarTodoHandlerTests
    {
        private readonly CriarTodoCommand _comandoInvalido = new CriarTodoCommand("", "", DateTime.Now);
        private readonly CriarTodoCommand _comandoValido = new CriarTodoCommand("Titulo da Tarefa", "Andre Machado", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private CommandResultGenerico _result = new CommandResultGenerico();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (CommandResultGenerico) _handler.Handle(_comandoInvalido);
            Assert.AreEqual(_result.Sucesso, false);
        } 

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _result = (CommandResultGenerico) _handler.Handle(_comandoValido);
            Assert.AreEqual(_result.Sucesso, true);
        }  
    }
}
