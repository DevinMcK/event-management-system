using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagementSystem.Data;
using EventManagementSystem.Models;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> events = await _context.Events.ToListAsync();

            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Event? eventItem = await _context.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Event eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            Event? existingEvent =
                await _context.Events.FindAsync(eventItem.Id);

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

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Event? eventItem = await _context.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Event? eventItem = await _context.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}