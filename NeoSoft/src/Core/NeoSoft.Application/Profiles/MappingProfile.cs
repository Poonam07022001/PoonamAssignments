using AutoMapper;
using NeoSoft.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.Application.Features.Categories.Commands.StoredProcedure;
using NeoSoft.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using NeoSoft.Application.Features.Events.Commands.CreateEvent;
using NeoSoft.Application.Features.Events.Commands.Transaction;
using NeoSoft.Application.Features.Events.Commands.UpdateEvent;
using NeoSoft.Application.Features.Events.Queries.GetEventDetail;
using NeoSoft.Application.Features.Events.Queries.GetEventsExport;
using NeoSoft.Application.Features.Events.Queries.GetEventsList;
using NeoSoft.Application.Features.Orders.GetOrdersForMonth;
using NeoSoft.Domain.Entities;

namespace NeoSoft.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
