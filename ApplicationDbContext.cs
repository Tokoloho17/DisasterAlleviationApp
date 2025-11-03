using Microsoft.EntityFrameworkCore;
using DisasterAlleviationApp.Models;

namespace DisasterAlleviationApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DBSets for all your models
        public DbSet<User> Users { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<IncidentReport> IncidentReports { get; set; }
    }
}
