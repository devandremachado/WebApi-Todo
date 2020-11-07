using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> BuscaTodos(string usuario)
        {
            return x => x.Usuario == usuario;
        }

        public static Expression<Func<TodoItem, bool>> BuscaTodosConcluidos(string usuario)
        {
            return x => x.Usuario == usuario && x.Concluido == true;
        }

        public static Expression<Func<TodoItem, bool>> BuscaTodosNaoConcluidos(string usuario)
        {
            return x => x.Usuario == usuario && x.Concluido == false;
        }

        public static Expression<Func<TodoItem, bool>> BuscaPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            return x => 
                x.Usuario == usuario && 
                x.Concluido == concluido &&
                x.Data.Date == data.Date;
        }
    }
}