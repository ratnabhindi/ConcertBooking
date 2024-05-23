using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ConcertBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;




namespace ConcertBooking.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):
            base(options)
        { 
        }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Concert> Concert { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
