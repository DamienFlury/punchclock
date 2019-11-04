using System;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.Data
{
    public class PunchclockContext : IdentityDbContext
    {
        public PunchclockContext(DbContextOptions<PunchclockContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var random = new Random();
            var departments = Enumerable.Range(1, 6).Select(x => new Department
            {
                Id = x,
                Title = $"Department {x}",
            }).ToList();
            var employees = Enumerable.Range(1, 20).Select(x => new Employee
            {
                Id = x.ToString(),
                Email = $"test{x}@test.com",
                DepartmentId = random.Next(1, 7),
            }).ToList();
            var entries = Enumerable.Range(1, 100).Select(x =>
                new Entry
                {
                    Id = x,
                    CheckIn = DateTime.Now.AddDays(-x),
                    CheckOut = DateTime.Now.AddDays(x),
                    EmployeeId = random.Next(1, 21).ToString(),
                }).ToList();
            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Entry>().HasData(entries);
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}