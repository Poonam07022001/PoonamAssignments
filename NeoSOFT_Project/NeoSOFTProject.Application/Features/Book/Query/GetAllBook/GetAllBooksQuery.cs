using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NeoSOFTProject.Application.DTOs;


namespace NeoSOFTProject.Application.Features.Book.Query.GetAllBook
{
    public class GetAllBooksQuery : IRequest<List<GetAllBooksDto>> { }
}
