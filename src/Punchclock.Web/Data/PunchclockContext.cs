using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.Data
{
    public class PunchclockContext : IdentityDbContext<Employee>
    {
        public PunchclockContext(DbContextOptions<PunchclockContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var departments = new[]
            {
                new Department
                {
                    Id = 1,
                    Title = "Software Engineering"
                },
                new Department
                {
                    Id = 2,
                    Title = "IT Support"
                },
                new Department
                {
                    Id = 3,
                    Title = "Creation"
                }
            };
            modelBuilder.Entity<Department>().HasData(departments);

        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}