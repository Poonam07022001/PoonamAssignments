using NeoSoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace NeoSoft.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
