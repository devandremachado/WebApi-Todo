using System;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string titulo, string usuario, DateTime data)
        {
            Titulo = titulo;
            Concluido = false;
            Data = data;
            Usuario = usuario;
        }

        public string Titulo { get; private set; }

        public bool Concluido { get; private set; }

        public DateTime Data { get; private set; }
        
        public string Usuario { get; private set; }

        public void MarcaComoConcluido()
        {
            Concluido = true;
        }

        public void MarcaComoNaoConcluido()
        {
            Concluido = false;
        }

        public void AtualizarTitulo(string titulo)
        {
            Titulo = titulo;
        }
    }
}