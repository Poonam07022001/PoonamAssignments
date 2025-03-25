using Event_Booking_App.Constant;
using Event_Booking_App.Context;
using Event_Booking_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_App.Repository
{
    public class TicketBookingRepository : ITicketBookingRepository
    {
        readonly EventBookingDB _eventBookingDB;

        public TicketBookingRepository(EventBookingDB eventBookingDB)
        {
            _eventBookingDB = eventBookingDB;
        }

        public async Task<int> AddBooking(TicketBooking ticketBooking)
        {
            var eventEntity = await _eventBookingDB.Events
       .FirstOrDefaultAsync(e => e.Id == ticketBooking.EventId);

            if (eventEntity == null || eventEntity.AvailableSeats < ticketBooking.Quantity)
                return 0;

            // Reduce available seats
            eventEntity.AvailableSeats -= ticketBooking.Quantity;
            await _eventBookingDB.TicketBookings.AddAsync(ticketBooking);
            return await _eventBookingDB.SaveChangesAsync();
        }

        public async Task<bool> CancelBooking(int bookingId)
        {
            var booking = await _eventBookingDB.TicketBookings
               .Include(b => b.Event)
               .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null)
                return false; // Booking not found

            // Increase available seats in the event
            booking.Event.AvailableSeats += booking.Quantity;

            // Remove the booking
            _eventBookingDB.TicketBookings.Remove(booking);
            await _eventBookingDB.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventBookingDB.Events.ToListAsync();
        }

        public async Task<IEnumerable<TicketBooking>> GetAllTicket(string id)
        {
            var tickets = await _eventBookingDB.TicketBookings
                         .Include(t => t.Event)
                         .Where(t => t.UserId == id)
                         .ToListAsync();
            return tickets;
        }
    }
}
