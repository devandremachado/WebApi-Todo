using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntitieTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todoValido = new TodoItem("Titulo da tarefa", "André Machado", DateTime.Now); 

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_todoValido.Concluido, false);
        }    
    }
}