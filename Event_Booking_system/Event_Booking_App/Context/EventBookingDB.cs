using Event_Booking_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_App.Context
{
    public class EventBookingDB : IdentityDbContext<User>
    {
        public EventBookingDB(DbContextOptions<EventBookingDB> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }

        public DbSet<User> users { get; set; }



    }
}
