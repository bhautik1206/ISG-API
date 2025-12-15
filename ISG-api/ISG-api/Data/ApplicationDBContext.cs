
using ISG_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace ISG_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Coutnry { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<City> City { get; set; }
    }
}
