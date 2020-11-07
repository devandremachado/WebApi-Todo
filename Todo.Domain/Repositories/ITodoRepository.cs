using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Criar(TodoItem todo);
        void Atualizar(TodoItem todo);
        TodoItem BuscaPorId(Guid id, string usuario);
        IEnumerable<TodoItem> BuscaTodos(string usuario);
        IEnumerable<TodoItem> BuscaTodosConcluidos(string usuario);
        IEnumerable<TodoItem> BuscaTodosNaoConcluidos(string usuario);
        IEnumerable<TodoItem> BuscaPorPeriodo(string usuario, DateTime data, bool concluido);
    }
}