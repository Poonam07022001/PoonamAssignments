using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Application.DTOs;
using DomainBook = NeoSOFTProject.Domain.Entities.Book;

namespace NeoSOFTProject.Application.Features.Book.Command.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBooksDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddBooksDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = _mapper.Map<DomainBook>(request.BookDto);
            var result = await _bookRepository.AddBook(bookEntity);
            return _mapper.Map<AddBooksDto>(result);
        }
    }
}
