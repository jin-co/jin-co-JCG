using ETicket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setting connection between many to many
            modelBuilder.Entity<ActorMovie>().HasKey(am => new
            {
                // setting compound key
                am.ActorId,
                am.MovieId
            });

            // connecting movie to actor movie table
            modelBuilder.Entity<ActorMovie>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.ActorMovies)
                .HasForeignKey(m => m.MovieId);

            // connecting Actor to actor movie table
            modelBuilder.Entity<ActorMovie>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.ActorMovies)
                .HasForeignKey(a => a.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        // lastly I have to define table names for each model
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        // order related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}
