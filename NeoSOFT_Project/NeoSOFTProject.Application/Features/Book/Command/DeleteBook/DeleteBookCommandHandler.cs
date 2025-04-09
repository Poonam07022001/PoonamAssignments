using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NeoSOFTProject.Application.Contracts.Persistence;

namespace NeoSOFTProject.Application.Features.Book.Command.DeleteBook
{
    class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteBook(request.Id);
            return Unit.Value;
        }
    }
}
