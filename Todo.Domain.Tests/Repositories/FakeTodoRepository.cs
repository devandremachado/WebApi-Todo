using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Atualizar(TodoItem item)
        {
            
        }
        
        public TodoItem BuscaPorId(Guid id, string usuario)
        {
            return new TodoItem("Titulo da Tarefa", "André Machado", DateTime.Now);
        }

        public IEnumerable<TodoItem> BuscaPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> BuscaTodos(string usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> BuscaTodosConcluidos(string usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> BuscaTodosNaoConcluidos(string usuario)
        {
            throw new NotImplementedException();
        }

        public void Criar(TodoItem item)
        {
           
        }
    }
}