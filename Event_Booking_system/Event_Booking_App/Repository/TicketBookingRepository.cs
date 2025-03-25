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

           public async Task<int> BookTicket(int userId, int eventId, int quantity)
    {
        var eventEntity = await _eventBookingDB.Events.FindAsync(eventId);
        if (eventEntity == null || eventEntity.AvailableSeats < quantity)
        {
            throw new Exception("Event not found or insufficient seats available.");
        }

        eventEntity.AvailableSeats -= quantity;

        var booking = new TicketBooking
        {
            UserId = userId,
            EventId = eventId,
            Quantity = quantity,
            BookingDate = DateTime.UtcNow,
            Status = TicketBookingStatus.Confirmed
        };

            _eventBookingDB.TicketBookings.Add(booking);
        return await _eventBookingDB.SaveChangesAsync();
    }

        public async Task<int> CancelBooking(int bookingId)
        {
            var booking = await _eventBookingDB.TicketBookings.FindAsync(bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found.");
            }

            var eventEntity = await _eventBookingDB.Events.FindAsync(booking.EventId);
            if (eventEntity != null)
            {   
                eventEntity.AvailableSeats += booking.Quantity;
            }

            booking.Status = TicketBookingStatus.Canceled; 
            return await _eventBookingDB.SaveChangesAsync();
        }


        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserId(int userId)
        {
            return await _eventBookingDB.TicketBookings
                        .Where(b => b.UserId == userId)
                        .Include(b => b.Event)
                        .ToListAsync();
        }
    }
}
