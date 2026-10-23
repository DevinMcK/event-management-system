using Microsoft.AspNetCore.Mvc;
using EventManagementSystem.Models;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            List<Event> events = new List<Event>
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

            return View(events);
        }
    }
}