using System.ComponentModel.DataAnnotations;
using Event_Booking_App.Constant;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Event_Booking_App.Models
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        [Required]
        public string FirstName  { get; set; }

        [Required]
        public string LastName { get; set; }
        //public string Email { get; set; }
        //public UserRole Role { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }

    }
}
