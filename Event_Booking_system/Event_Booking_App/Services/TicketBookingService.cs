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

        public async Task<int> AddBooking(TicketBooking ticketBooking)
        {
            return await _ticketBookingRepository.AddBooking(ticketBooking);

        }

        public async Task<bool> CancelBooking(int bookingId)
        {
            return await _ticketBookingRepository.CancelBooking(bookingId);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _ticketBookingRepository.GetAllEvents();
        }

        public async Task<IEnumerable<TicketBooking>> GetAllTicket(string id)
        {
            return await _ticketBookingRepository.GetAllTicket(id);

        }
    }
}
