using Hotel_Manager_4000.Areas.Owner.Models;
using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ess;

namespace Hotel_Manager_4000.Data
{
    public class HotelContext : IdentityDbContext<User>
    {
        public HotelContext() { }
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options) { }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Guest>? Guests { get; set; }
        public DbSet<Owner>? Owners { get; set; } 
        public DbSet<HotelListing> hotelListings { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Hotel;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
        }
    }
}  
