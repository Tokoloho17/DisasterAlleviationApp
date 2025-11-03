using Microsoft.VisualStudio.TestTools.UnitTesting;
using DisasterAlleviationApp.Controllers;
using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DisasterAlleviationApp.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            // Create a new in-memory database for each test run
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        // ---------------- UserController ----------------
        [TestMethod]
        public void User_Register_Adds_User_To_Db()
        {
            var controller = new UserController(_context);
            var user = new User { FullName = "Test User", Email = "test@example.com", Password = "123" };

            var result = controller.Register(user) as ViewResult;

            Assert.AreEqual(1, _context.Users.Count());
            Assert.AreEqual("Test User", _context.Users.First().FullName);
            Assert.AreEqual($"User {user.FullName} registered successfully!", controller.ViewBag.Message);
        }

        [TestMethod]
        public void User_Login_Valid_Returns_Welcome_Message()
        {
            var controller = new UserController(_context);
            var user = new User { FullName = "Login User", Email = "login@example.com", Password = "pass" };
            _context.Users.Add(user);
            _context.SaveChanges();

            var result = controller.Login(new User { Email = "login@example.com", Password = "pass" }) as ViewResult;

            Assert.AreEqual($"Welcome, {user.FullName}!", controller.ViewBag.Message);
        }

        [TestMethod]
        public void User_Login_Invalid_Returns_Error_Message()
        {
            var controller = new UserController(_context);

            var result = controller.Login(new User { Email = "wrong@example.com", Password = "bad" }) as ViewResult;

            Assert.AreEqual("Invalid login!", controller.ViewBag.Message);
        }

        // ---------------- VolunteerController ----------------
        [TestMethod]
        public void Volunteer_Register_Adds_To_Db()
        {
            var controller = new VolunteerController(_context);
            var volunteer = new Volunteer { Name = "Vol User", Skills = "First Aid", Availability = "Weekends" };

            var result = controller.Register(volunteer) as ViewResult;

            Assert.AreEqual(1, _context.Volunteers.Count());
            Assert.AreEqual($"Volunteer {volunteer.Name} registered successfully!", controller.ViewBag.Message);
        }

        // ---------------- DonationController ----------------
        [TestMethod]
        public void Donation_Create_Adds_To_Db()
        {
            var controller = new DonationController(_context);
            var donation = new Donation { DonorName = "Donor1", ResourceType = "Food", Quantity = 10, Location = "City" };

            var result = controller.Create(donation) as ViewResult;

            Assert.AreEqual(1, _context.Donations.Count());
            Assert.AreEqual($"Donation from {donation.DonorName} added successfully!", controller.ViewBag.Message);
        }

        // ---------------- DisasterController ----------------
        [TestMethod]
        public void Disaster_Report_Adds_To_Db()
        {
            var controller = new DisasterController(_context);
            var report = new IncidentReport { ReporterName = "Reporter", DisasterType = "Flood", Location = "Area1", Description = "Test" };

            var result = controller.Report(report) as ViewResult;

            Assert.AreEqual(1, _context.IncidentReports.Count());
            Assert.AreEqual($"Incident reported at {report.Location}!", controller.ViewBag.Message);
        }

        // ---------------- AccountController ----------------
        [TestMethod]
        public void Account_Register_Adds_User_To_Db()
        {
            var controller = new AccountController(_context);
            var user = new User { FullName = "Account User", Email = "account@example.com", Password = "pwd" };

            var result = controller.Register(user) as ViewResult;

            Assert.AreEqual(1, _context.Users.Count(u => u.Email == user.Email));
            Assert.AreEqual("User registered successfully!", controller.ViewBag.Message);
        }

        [TestMethod]
        public void Account_Login_Returns_Message()
        {
            var controller = new AccountController(_context);
            var user = new User { FullName = "Login Account", Email = "accountlogin@example.com", Password = "pwd" };
            _context.Users.Add(user);
            _context.SaveChanges();

            ViewResult? viewResult = controller.Login(new User { Email = "accountlogin@example.com", Password = "pwd" }) as ViewResult;
            ViewResult? result = viewResult;

            Assert.IsTrue(controller.ViewBag.Message.Contains("Login attempt for"));
        }
    }
}
