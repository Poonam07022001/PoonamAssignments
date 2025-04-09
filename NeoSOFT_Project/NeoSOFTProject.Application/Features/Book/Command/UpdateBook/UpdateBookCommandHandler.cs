using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Application.Exceptions;
using DomainBook = NeoSOFTProject.Domain.Entities.Book;

namespace NeoSOFTProject.Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var updatedBook = _mapper.Map<DomainBook>(request.BookDto);
            updatedBook.Id = request.Id;

            await _bookRepository.UpdateBook(updatedBook);

            return Unit.Value;
        }
    }
}
