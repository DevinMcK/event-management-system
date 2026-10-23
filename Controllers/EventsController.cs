using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}