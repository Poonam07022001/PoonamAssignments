using Event_Booking_App.Models;

namespace Event_Booking_App.Repository
{
    public interface ITicketBookingRepository
    {
        public Task<IEnumerable<TicketBooking>> GetAllTicket(string id);
        Task<IEnumerable<Event>> GetAllEvents();
        //Task<IEnumerable> GetAllUser();
        Task<int> AddBooking(TicketBooking ticketBooking);
        public Task<bool> CancelBooking(int bookingId);
    }
}
