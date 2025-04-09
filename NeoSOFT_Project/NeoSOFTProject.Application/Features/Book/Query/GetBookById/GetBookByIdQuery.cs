using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NeoSOFTProject.Application.DTOs;

namespace NeoSOFTProject.Application.Features.Book.Query.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetAllBooksDto>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
