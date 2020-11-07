using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CriarTodoCommand : Notifiable, ICommand
    {
        public CriarTodoCommand(){ }

        public CriarTodoCommand(string titulo, string usuario, DateTime data)
        {
            Titulo = titulo;
            Usuario = usuario;
            Data = data;
        }

        public string Titulo { get; set; }
        
        public string Usuario { get; set; }

        public DateTime Data { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Titulo, 3, "Titulo", "Por favor, descreva melhor esta tarefa!")
                    .HasMinLen(Usuario, 6, "Usuario", "Usuário inválido!")
            );
            
        }
    }
}