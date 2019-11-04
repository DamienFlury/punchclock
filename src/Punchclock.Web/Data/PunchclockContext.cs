using System;
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
            var entries = new[]
            {
                new Entry
                {
                    Id = 1,
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(2)
                }
            };
            modelBuilder.Entity<Entry>().HasData(entries);
        }

        public DbSet<Entry> Entries { get; set; }
    }
}