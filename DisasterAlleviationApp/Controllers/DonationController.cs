using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviationApp.Controllers
{
    public class DonationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
            ViewBag.Message = $"Donation from {donation.DonorName} added successfully!";
            return View();
        }

        public IActionResult List() => View();
    }
}
