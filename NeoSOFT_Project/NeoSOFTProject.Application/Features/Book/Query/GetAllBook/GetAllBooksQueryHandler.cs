using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Application.DTOs;
namespace NeoSOFTProject.Application.Features.Book.Query.GetAllBook
{
    class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<GetAllBooksDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBooksDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooks();
            return _mapper.Map<List<GetAllBooksDto>>(books);
        }

       
    }


}
