using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Criar(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Atualizar(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TodoItem BuscaPorId(Guid id, string usuario)
        {
            return _context.Todos.AsNoTracking()
                .FirstOrDefault(x => x.Id == id && x.Usuario == usuario);
        }

        public IEnumerable<TodoItem> BuscaPorPeriodo(string usuario, DateTime data, bool concluido)
        {
            return _context.Todos.AsNoTracking()
                .Where(x => x.Usuario == usuario && x.Data == data && x.Concluido == concluido)
                .OrderBy(x => x.Data);
        }

        public IEnumerable<TodoItem> BuscaTodos(string usuario)
        {
            return _context.Todos.AsNoTracking()
                .Where(x => x.Usuario == usuario)
                .OrderBy(x => x.Data);
        }

        public IEnumerable<TodoItem> BuscaTodosConcluidos(string usuario)
        {
            return _context.Todos.AsNoTracking()
                .Where(x => x.Usuario == usuario && x.Concluido == true)
                .OrderBy(x => x.Data);
        }

        public IEnumerable<TodoItem> BuscaTodosNaoConcluidos(string usuario)
        {
            return _context.Todos.AsNoTracking()
                .Where(x => x.Usuario == usuario && x.Concluido == false)
                .OrderBy(x => x.Data);
        }
    }
}