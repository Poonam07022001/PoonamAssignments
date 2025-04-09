using NeoSoft.Application.Responses;
using MediatR;

namespace NeoSoft.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
