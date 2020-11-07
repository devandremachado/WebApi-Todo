using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CommandResultGenerico : ICommandResult
    {
        public CommandResultGenerico() { }
        public CommandResultGenerico(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}