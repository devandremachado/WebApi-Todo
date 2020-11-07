using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

// Red - Green - Refactory

namespace Todo.Domain.Tests.QuerieTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "andremachado", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "andremachado", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "UsuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "UsuarioC", DateTime.Now));
        }

        [TestMethod]
        public void Dado_a_consulta_deve_retornar_tarefas_apenas_do_usuario_andremachado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.BuscaTodos("andremachado"));
            Assert.AreEqual(2, result.Count());
        } 
    }
}
