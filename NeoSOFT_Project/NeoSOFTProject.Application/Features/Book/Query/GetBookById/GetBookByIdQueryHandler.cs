using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Application.DTOs;
using NeoSOFTProject.Application.Features.Book.Query.GetAllBook;

namespace NeoSOFTProject.Application.Features.Book.Query.GetBookById
{
   public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetAllBooksDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetAllBooksDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);
            return _mapper.Map<GetAllBooksDto>(book);
        }
    }
}
