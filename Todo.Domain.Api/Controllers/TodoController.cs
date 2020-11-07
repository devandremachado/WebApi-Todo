using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    //[Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodos([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaTodos("andremachado"));
        }

        [Route("concluidos")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodosConcluidos([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaTodosConcluidos("andremachado"));
        }

        [Route("concluidos/hoje")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodosConcluidosHoje([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaPorPeriodo("andremachado", DateTime.Now.Date, true));
        }

        [Route("concluidos/amanha")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodosConcluidosAmanha([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaPorPeriodo("andremachado", DateTime.Now.Date.AddDays(1), true));
        }

        [Route("naoconcluidos")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodosNaoConcluidos([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaTodosNaoConcluidos("andremachado"));
        }

        [Route("naoconcluidos/hoje")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodosNaoConcluidosHoje([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaPorPeriodo("andremachado", DateTime.Now.Date, false));
        }

        [Route("naoconcluidos/amanha")]
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> BuscaTodosNaoConcluidosAmanha([FromServices] ITodoRepository repository)
        {
            return Ok(repository.BuscaPorPeriodo("andremachado", DateTime.Now.Date.AddDays(1), false));
        }

        [Route("")]
        [HttpPost]
        public ActionResult<CommandResultGenerico> Criar([FromBody] CriarTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.Usuario = "andremachado";
            return Ok ((CommandResultGenerico)handler.Handle(command));
        }

        [Route("")]
        [HttpPut]
        public ActionResult<CommandResultGenerico> Atualizar([FromBody] AtualizarTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.Usuario = "andremachado";
            return Ok((CommandResultGenerico)handler.Handle(command));
        }

        [Route("marcar-concluido")]
        [HttpPut]
        public ActionResult<CommandResultGenerico> MarcarConcluido([FromBody] MarcarTodoConcluidoCommand command, [FromServices] TodoHandler handler)
        {
            command.Usuario = "andremachado";
            return Ok((CommandResultGenerico)handler.Handle(command));
        }

        [Route("marcar-nao-concluido")]
        [HttpPut]
        public ActionResult<CommandResultGenerico> MarcarNaoConcluido([FromBody] MarcarTodoNaoConcluidoCommand command, [FromServices] TodoHandler handler)
        {
            command.Usuario = "andremachado";
            return Ok((CommandResultGenerico)handler.Handle(command));
        }
    }
}
