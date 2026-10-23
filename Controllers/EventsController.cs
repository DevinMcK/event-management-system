using Microsoft.AspNetCore.Mvc;
using EventManagementSystem.Models;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        private static List<Event> events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Name = "Tech Expo 2026",
                Description = "A technology showcase for students.",
                Date = new DateTime(2026, 11, 14),
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(16, 0, 0),
                Venue = "Pretoria Convention Centre",
                MaximumAttendees = 500
            },

            new Event
            {
                Id = 2,
                Name = "Game Development Meetup",
                Description = "A meetup for aspiring game developers.",
                Date = new DateTime(2026, 11, 28),
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Venue = "Innovation Hub",
                MaximumAttendees = 120
            }
        };

        public IActionResult Index()
        {
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            eventItem.Id = events.Count > 0
                ? events.Max(e => e.Id) + 1
                : 1;

            events.Add(eventItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Event? eventItem = events.FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost]
        public IActionResult Edit(Event eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            Event? existingEvent = events.FirstOrDefault(e => e.Id == eventItem.Id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.Name = eventItem.Name;
            existingEvent.Description = eventItem.Description;
            existingEvent.Date = eventItem.Date;
            existingEvent.StartTime = eventItem.StartTime;
            existingEvent.EndTime = eventItem.EndTime;
            existingEvent.Venue = eventItem.Venue;
            existingEvent.MaximumAttendees = eventItem.MaximumAttendees;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Event? eventItem = events.FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Event? eventItem = events.FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            events.Remove(eventItem);

            return RedirectToAction("Index");
        }
    }
}