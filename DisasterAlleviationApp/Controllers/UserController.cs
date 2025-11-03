using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviationApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            ViewBag.Message = $"User {user.FullName} registered successfully!";
            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (existingUser != null)
                ViewBag.Message = $"Welcome, {existingUser.FullName}!";
            else
                ViewBag.Message = "Invalid login!";

            return View();
        }
    }
}
