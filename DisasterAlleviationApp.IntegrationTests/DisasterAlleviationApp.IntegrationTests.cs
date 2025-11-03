using Microsoft.VisualStudio.TestTools.UnitTesting;
using DisasterAlleviationApp.Controllers;
using DisasterAlleviationApp.Models;
using DisasterAlleviationApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DisasterAlleviationApp.IntegrationTests
{
    [TestClass]
    public sealed class ControllersIntegrationTests
    {
        private DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            // Each test gets its own unique in-memory database
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
        }

        // ----------- UserController -----------
        [TestMethod]
        public void User_Register_SavesUser()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new UserController(context);
                var user = new User { FullName = "Sipho Nkosi", Password = "abc123" };

                var result = controller.Register(user) as ViewResult;
                Assert.IsNotNull(result);

                var savedUser = context.Users.FirstOrDefault(u => u.FullName == "Sipho Nkosi");
                Assert.IsNotNull(savedUser);
                Assert.AreEqual($"User {user.FullName} registered successfully!", controller.ViewBag.Message);
            }
        }

        [TestMethod]
        public void User_Login_ReturnsCorrectMessage()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                // Add the user to the in-memory database
                var user = new User { FullName = "Zanele Dlamini", Password = "mypassword" };
                context.Users.Add(user);
                context.SaveChanges();

                var controller = new UserController(context);
                var result = controller.Login(user) as ViewResult;

                Assert.IsNotNull(result);
                Assert.AreEqual($"Welcome, {user.FullName}!", controller.ViewBag.Message);
            }
        }

        // ----------- VolunteerController -----------
        [TestMethod]
        public void Volunteer_Register_SavesVolunteer()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new VolunteerController(context);
                var volunteer = new Volunteer { Name = "Thabo Maseko", Skills = "First Aid", Availability = "Weekends" };

                var result = controller.Register(volunteer) as ViewResult;
                Assert.IsNotNull(result);

                var savedVolunteer = context.Volunteers.FirstOrDefault(v => v.Name == "Thabo Maseko");
                Assert.IsNotNull(savedVolunteer);
                Assert.AreEqual($"Volunteer {volunteer.Name} registered successfully!", controller.ViewBag.Message);
            }
        }

        // ----------- DonationController -----------
        [TestMethod]
        public void Donation_Create_SavesDonation()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new DonationController(context);
                var donation = new Donation { DonorName = "Naledi Khumalo", ResourceType = "Food", Quantity = 500, Location = "Joburg" };

                var result = controller.Create(donation) as ViewResult;
                Assert.IsNotNull(result);

                var savedDonation = context.Donations.FirstOrDefault(d => d.DonorName == "Naledi Khumalo");
                Assert.IsNotNull(savedDonation);
                Assert.AreEqual($"Donation from {donation.DonorName} added successfully!", controller.ViewBag.Message);
            }
        }

        // ----------- DisasterController -----------
        [TestMethod]
        public void Disaster_Report_SavesReport()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new DisasterController(context);
                var report = new IncidentReport { ReporterName = "Jane", DisasterType = "Flood", Location = "Soweto", Description = "Test Flood" };

                var result = controller.Report(report) as ViewResult;
                Assert.IsNotNull(result);

                var savedReport = context.IncidentReports.FirstOrDefault(r => r.ReporterName == "Jane");
                Assert.IsNotNull(savedReport);
                Assert.AreEqual($"Incident reported at {report.Location}!", controller.ViewBag.Message);
            }
        }

        // ----------- AccountController -----------
        [TestMethod]
        public void Account_Register_Post_SetsViewBagMessage()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AccountController(context);
                var user = new User { FullName = "Lerato Mokoena", Email = "lerato@example.com" };

                var result = controller.Register(user) as ViewResult;
                Assert.IsNotNull(result);
                Assert.AreEqual("User registered successfully!", controller.ViewBag.Message);
            }
        }

        [TestMethod]
        public void Account_Login_Post_SetsViewBagMessage()
        {
            var options = CreateNewContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AccountController(context);
                var user = new User { Email = "tshepo@example.com", Password = "pass123" };

                var result = controller.Login(user) as ViewResult;
                Assert.IsNotNull(result);
                Assert.IsTrue(controller.ViewBag.Message.Contains("Login attempt for"));
            }
        }
    }
}
