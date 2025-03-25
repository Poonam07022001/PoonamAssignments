using Event_Booking_App.Context;
using Event_Booking_App.Models;
using Event_Booking_App.Repository;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_App.Services
{
    public class EventService:IEventService
    {
        readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> AddEvent(Event events)
        {
            return await _eventRepository.AddEvent(events);
        }

        public async Task<int> DeleteEvent(int id)
        {
            return await _eventRepository.DeleteEvent(id);
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }

        public async Task<Event> GetById(int id)
        {
            return await _eventRepository.GetById(id);
        }

        public async Task<int> UpdateEvent(Event events)
        {
            return await _eventRepository.UpdateEvent(events);
        }
    }
}
