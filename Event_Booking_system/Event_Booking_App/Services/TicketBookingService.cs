using Event_Booking_App.Models;
using Event_Booking_App.Repository;

namespace Event_Booking_App.Services
{
    public class TicketBookingService : ITicketBookingServices
    {
        readonly ITicketBookingRepository _ticketBookingRepository;

        public TicketBookingService(ITicketBookingRepository ticketBookingRepository)
        {
            _ticketBookingRepository = ticketBookingRepository;
        }

        public async Task<int> BookTicket(int userId, int eventId, int quantity)
        {
            return await _ticketBookingRepository.BookTicket(userId, eventId, quantity);
        }

        public async Task<int> CancelBooking(int bookingId)
        {
            return await _ticketBookingRepository.CancelBooking(bookingId);
        }

        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserId(int userId)
        {
            return await _ticketBookingRepository.GetBookingsByUserId(userId);
        }
    }
}
