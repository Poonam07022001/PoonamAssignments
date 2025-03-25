using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_Booking_App.Constant;

namespace Event_Booking_App.Models
{
    public class TicketBooking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public  User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int Quantity { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public TicketBookingStatus Status { get; set; }
    }
}
