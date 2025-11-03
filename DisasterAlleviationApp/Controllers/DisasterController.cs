using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviationApp.Controllers
{
    public class DisasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Report() => View();

        [HttpPost]
        public IActionResult Report(IncidentReport report)
        {
            _context.IncidentReports.Add(report);
            _context.SaveChanges();
            ViewBag.Message = $"Incident reported at {report.Location}!";
            return View();
        }
    }
}
