using AutoMapper;
using NeoSoft.Application.Features.Events.Queries.GetEventsList;
using NeoSoft.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;

namespace NeoSoft.Application.Profiles
{
    public class EventVmCustomMapper : ITypeConverter<Event, EventListVm>
    {
        private readonly IDataProtector _protector;

        public EventVmCustomMapper(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public EventListVm Convert(Event source, EventListVm destination, ResolutionContext context)
        {
            EventListVm dest = new EventListVm()
            {
                EventId = _protector.Protect(source.EventId.ToString()),
                Name = source.Name,
                ImageUrl = source.ImageUrl,
                Date = source.Date
            };

            return dest;

        }
    }
}
