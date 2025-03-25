using Event_Booking_App.Constant;

namespace Event_Booking_App.Models
{
    public class TicketBooking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int Quantity { get; set; }
        public DateTime BookingDate { get; set; }
        public TicketBookingStatus Status { get; set; }
    }
}
