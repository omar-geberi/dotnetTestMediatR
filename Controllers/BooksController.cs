using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_book.BookMediators;
using dotnet_book.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> List()
        {
            return await _mediator.Send(new GetAllBooks.QueryBooks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Details(int id)
        {
            return await _mediator.Send(new GetBookById.QueryBook{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateBook.CreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, EditBook.EditCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new DeleteBook.DeleteCommand{Id = id});
        }   
    }
}