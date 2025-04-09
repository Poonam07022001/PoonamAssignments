using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeoSOFTProject.Application.DTOs;
using NeoSOFTProject.Application.Features.Book.Command.AddBook;
using NeoSOFTProject.Application.Features.Book.Command.DeleteBook;
using NeoSOFTProject.Application.Features.Book.Command.UpdateBook;
using NeoSOFTProject.Application.Features.Book.Query.GetAllBook;
using NeoSOFTProject.Application.Features.Book.Query.GetBookById;
//using NeoSOFTProject.Application.Features.Book.Command
namespace NeoSOFTProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            return Ok(book);
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBook([FromBody] AddBooksDto bookDto)
        {
            var command = new AddBookCommand(bookDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return Ok($"Book with ID {id} has been deleted.");
        }

        [HttpPut("UpdateBook/{id}")]

        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto bookDto)
        {
            await _mediator.Send(new UpdateBookCommand { Id = id, BookDto = bookDto });
            return Ok(new { Message = $"Book with ID {id} updated successfully." });
        }

    }
}
