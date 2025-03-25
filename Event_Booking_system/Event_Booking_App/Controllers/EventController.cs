using Event_Booking_App.Models;
using Event_Booking_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Event_Booking_App.Controllers
{
    public class EventController : Controller
    {
        readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        //[HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            return View(await _eventService.GetAllEventsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(Event events)
        {
            if (events == null)
                return BadRequest("Invalid event data.");

            var result = await _eventService.AddEvent(events);
            if (result > 0)
            {
                //return Ok(new { message = "Event added successfully!" });
                TempData["message"] = "Event added successfully!";
                return RedirectToAction("GetAllEvents");
            }
            else
            {            
                return View(events);
            }      
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventToEdit = await _eventService.GetById(id);

            if (eventToEdit == null)
            {
                TempData["message"] = "Event not found!";
                return RedirectToAction("GetAllEvents");
            }

            return View(eventToEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Event events)
        {
            int result = await _eventService.UpdateEvent(events);
                TempData["message"] = "Event updated successfully!";
                return  RedirectToAction("GetAllEvents");      
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            if (result > 0)
            {
                TempData["message"] = "Event deleted successfully!";
                return RedirectToAction("GetAllEvents");
            }
            else
            {
                TempData["message"] = "Event not found!";
            }
            return RedirectToAction("GetAllEvents");
        }
    }
}
