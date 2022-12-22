using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager_4000.Data
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
