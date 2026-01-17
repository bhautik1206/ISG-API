
using ISG_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static ISG_api.Models.Entities.StoreProcedure;
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
        public virtual DbSet<SpAddThread_Result> spAddThread { get; set; }
        public virtual DbSet<SpAddReview_Result> spAddReview { get; set; }
        public virtual DbSet<SpGetAllThread_Result> spGetAllThread { get; set; }
        public virtual DbSet<SpGetAllThread_Result> spGetThreadByUserID{ get; set; }
    }
}
