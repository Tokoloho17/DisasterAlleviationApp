using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviationApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // Could be a profile or user list
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            // Save user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            ViewBag.Message = "User registered successfully!";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            // Check if user exists in database (basic example)
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser != null)
            {
                ViewBag.Message = $"Login attempt for {user.Email}";
            }
            else
            {
                ViewBag.Message = "Invalid login!";
            }

            return View();
        }
    }
}

