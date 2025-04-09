using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NeoSOFTProject.Application.DTOs;

namespace NeoSOFTProject.Application.Features.Book.Command.UpdateBook
{
   public class UpdateBookCommand :IRequest<Unit>
    {
        public int Id { get; set; } // ID of the book to update
        public UpdateBookDto BookDto { get; set; } = null!;
    }
}
