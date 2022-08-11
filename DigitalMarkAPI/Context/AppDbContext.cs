using DigitalMarkAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarkAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            //modelBuilder.Entity<Client>().HasData(
            //    new Client
            //    {
            //        Id = 1,
            //        Name = "Cleber de Oliveira",
            //        Email = "cleber@gmail.com",
            //        Age = 20
            //    },
            //    new Client
            //    {
            //        Id = 2,
            //        Name = "Cecilia Goncalves",
            //        Email = "cecilia@gmail.com",
            //        Age = 59
            //    }
            //    );

            //modelBuilder.Entity<Project>().HasData(
            //    new Project
            //    {
            //        Id = 1,
            //        Name = "Digital Mark API",
            //        Language = ".NET"
            //    },
            //    new Project
            //    {
            //        Id = 2,
            //        Name = "Digital Mark Front",
            //        Language = "React"
            //    }
            //    );
        }
    }
}
