using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Booking_App.Models
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
