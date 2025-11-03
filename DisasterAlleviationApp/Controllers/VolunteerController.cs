using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviationApp.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();
            ViewBag.Message = $"Volunteer {volunteer.Name} registered successfully!";
            return View();
        }

        public IActionResult Tasks() => View(); // later: show volunteer tasks
    }
}
