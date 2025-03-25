using Event_Booking_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Booking_App.Controllers
{
    public class TicketBookingController : Controller
    {
        readonly IEventService _eventService;
        readonly ITicketBookingServices _ticketBookingServices;

        public TicketBookingController(IEventService eventService, ITicketBookingServices ticketBookingServices)
        {
            _eventService = eventService;
           _ticketBookingServices = ticketBookingServices;
        }

        // Display the booking form
        [HttpGet]
        public async Task<IActionResult> BookTicket(int eventId)
        {
            var eventDetails = await _eventService.GetById(eventId);
            if (eventDetails == null)
            {
                TempData["message"] = "Event not found!";
                //return RedirectToAction("GetAllEvents", "Event");
                return View();
            }
            return View(eventDetails);
        }

        // Handle the booking submission
        [HttpPost]
        public async Task<IActionResult> BookTicket(int eventId, int userId, int quantity)
        {
            var bookingId = await _ticketBookingServices.BookTicket(userId, eventId, quantity);
            if (bookingId > 0)
            {
                TempData["message"] = "Ticket booked successfully!";
                return RedirectToAction("GetBookingsByUser", new { userId });
            }
            TempData["message"] = "Failed to book ticket!";
             return RedirectToAction("GetAllEvents", "Event");
           //return View();
        }

        // View user's bookings
        public async Task<IActionResult> GetBookingsByUser(int userId)
        {
            var bookings = await _ticketBookingServices.GetBookingsByUserId(userId);
            return View(bookings);
        }

        // Cancel a booking
        public async Task<IActionResult> CancelBooking(int bookingId, int userId)
        {
            await _ticketBookingServices.CancelBooking(bookingId);
            TempData["message"] = "Booking canceled successfully!";
            return RedirectToAction("GetBookingsByUser", new { userId });
        }

    }


}
