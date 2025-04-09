using NeoSoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace NeoSoft.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
