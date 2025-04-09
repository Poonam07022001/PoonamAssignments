using MediatR;
using NeoSOFTProject.Application.DTOs;

namespace NeoSOFTProject.Application.Features.Book.Command.AddBook
{
    public class AddBookCommand : IRequest<AddBooksDto>
    {
        public AddBooksDto BookDto { get; set; }

        public AddBookCommand(AddBooksDto bookDto)
        {
            BookDto = bookDto;
        }
    }
}
