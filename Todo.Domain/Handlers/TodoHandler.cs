using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable,
        IHandler<CriarTodoCommand>,
        IHandler<AtualizarTodoCommand>,
        IHandler<MarcarTodoConcluidoCommand>,
        IHandler<MarcarTodoNaoConcluidoCommand>

    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CriarTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if(command.Invalid)
                return new CommandResultGenerico( false, "Ops, Parece que sua tarefa está errada!", command.Notifications);

            // Criar todo
            var todo = new TodoItem(command.Titulo, command.Usuario, command.Data);

            // Salvar todo no banco
            _repository.Criar(todo);

            // Notifica usuario
            return new CommandResultGenerico(true, "Tarefa salva com sucesso!", todo);
        }

        public ICommandResult Handle(AtualizarTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if(command.Invalid)
                return new CommandResultGenerico( false, "Ops, Parece que sua tarefa está errada!", command.Notifications);

            // Buscar todo
           var todo = _repository.BuscaPorId(command.Id, command.Usuario);

            // Altera Titulo
            todo.AtualizarTitulo(command.Titulo);

            // Salva no banco
            _repository.Atualizar(todo);

            // Notifica usuario
            return new CommandResultGenerico(true, "Tarefa salva com sucesso!", todo);
        }

        public ICommandResult Handle(MarcarTodoConcluidoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if(command.Invalid)
                return new CommandResultGenerico( false, "Ops, Parece que sua tarefa está errada!", command.Notifications);

            // Buscar todo
           var todo = _repository.BuscaPorId(command.Id, command.Usuario);

            // Altera estado do todo
           todo.MarcaComoConcluido();

            // Salva no banco
            _repository.Atualizar(todo);

            // Notifica usuario
            return new CommandResultGenerico(true, "Tarefa concluída com sucesso!", todo);
        }

        public ICommandResult Handle(MarcarTodoNaoConcluidoCommand command)
        {
                        // Fail Fast Validation
            command.Validate();
            if(command.Invalid)
                return new CommandResultGenerico( false, "Ops, Parece que sua tarefa está errada!", command.Notifications);

            // Buscar todo
           var todo = _repository.BuscaPorId(command.Id, command.Usuario);

            // Altera estado do todo
           todo.MarcaComoNaoConcluido();

            // Salva no banco
            _repository.Atualizar(todo);

            // Notifica usuario
            return new CommandResultGenerico(true, "Tarefa desmarcada como concluída com sucesso!", todo);
        }
    }
}