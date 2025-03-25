using Event_Booking_App.Models;

namespace Event_Booking_App.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<int> AddEvent(Event events);
        Task<Event> GetById(int id);
        Task<int> UpdateEvent(Event events);
        Task<int> DeleteEvent(int id);
    }
}
