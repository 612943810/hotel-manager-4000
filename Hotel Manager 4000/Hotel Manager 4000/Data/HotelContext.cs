﻿using Hotel_Manager_4000.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager_4000.Data
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            :base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
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
