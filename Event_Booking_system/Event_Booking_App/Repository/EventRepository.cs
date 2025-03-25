using Event_Booking_App.Context;
using Event_Booking_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_App.Repository
{
    public class EventRepository : IEventRepository
    {
        readonly EventBookingDB _eventBookingDB;

        public EventRepository(EventBookingDB eventBookingDB)
        {
            _eventBookingDB = eventBookingDB;
        }

        public async Task<int> AddEvent(Event events)
        {
             await _eventBookingDB.Events.AddAsync(events);
            return await _eventBookingDB.SaveChangesAsync();
        }

        public async Task<int> DeleteEvent(int id)
        {
            var eventEntity = await _eventBookingDB.Events.FindAsync(id);
            if (eventEntity == null)
                return 0;

            _eventBookingDB.Events.Remove(eventEntity);
            return await _eventBookingDB.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventBookingDB.Events.ToListAsync();
        }

        public async Task<Event> GetById(int id)
        {
            return await _eventBookingDB.Events.FindAsync(id);
        }

        public async Task<int> UpdateEvent(Event events)
        {
            var existingEvent = await _eventBookingDB.Events.FindAsync(events.Id);
            if (existingEvent == null)
                return 0;

            existingEvent.Name = events.Name;
            existingEvent.Location = events.Location;
            existingEvent.Date = events.Date;
            existingEvent.AvailableSeats = events.AvailableSeats;
            existingEvent.TicketPrice = events.TicketPrice;

            return await _eventBookingDB.SaveChangesAsync();
        }
    }
}
