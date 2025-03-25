using Event_Booking_App.Constant;
using Event_Booking_App.Models;
using Event_Booking_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Event_Booking_App.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TicketBookingController : Controller
    {
        readonly IEventService _eventService;
        readonly ITicketBookingServices _ticketBookingServices;
        readonly UserManager<User> _userManager;

        public User UserId { get; private set; }
        public TicketBookingController(IEventService eventService, ITicketBookingServices ticketBookingServices, UserManager<User> userManager)
        {
            _eventService = eventService;
            _ticketBookingServices = ticketBookingServices;
            _userManager = userManager;

        }

        [Authorize]

        [HttpGet]
        public async Task<IActionResult> GetAllTicket(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userTickets = await _ticketBookingServices.GetAllTicket(user.Id);
            return View(userTickets);
        }


        [HttpGet("{eventId}")]
        public async Task<IActionResult> AddBooking(int eventId)
        {

            var userId = await _userManager.GetUserAsync(User);
            ViewData["User"] = userId;

            ViewData["EventId"] = new SelectList(await _ticketBookingServices.GetAllEvents(), "Id", "EventId");

            return View();
        }

        [HttpPost("{eventId}")]
        public async Task<IActionResult> AddBooking(int eventId, TicketBooking ticketBooking)
        {
            var userId = await _userManager.GetUserAsync(User);

            //ticketBooking.User = userId;
            //ticketBooking.EventId = eventId;

            var booking = new TicketBooking
            {
                UserId = userId.Id,
                EventId = eventId,
                Quantity = ticketBooking.Quantity,
                BookingDate = DateTime.Now,
                Status = TicketBookingStatus.Confirmed
            };
            await _ticketBookingServices.AddBooking(booking);
            return RedirectToAction("GetAllTicket");
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var success = await _ticketBookingServices.CancelBooking(bookingId);

            if (!success)
            {
                TempData["Error"] = "Booking could not be cancelled.";
            }
            else
            {
                TempData["Success"] = "Booking cancelled successfully.";
            }

            return RedirectToAction("GetAllTicket");
        }


    }


}
