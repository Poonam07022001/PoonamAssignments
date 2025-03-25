using Event_Booking_App.Models;

namespace Event_Booking_App.Services
{
    public interface ITicketBookingServices
    {
        Task<IEnumerable<TicketBooking>> GetBookingsByUserId(int userId);
        Task<int> BookTicket(int userId, int eventId, int quantity);
        Task<int> CancelBooking(int bookingId);
    }
}
