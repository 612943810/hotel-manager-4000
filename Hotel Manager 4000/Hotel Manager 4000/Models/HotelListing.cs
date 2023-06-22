﻿using System.ComponentModel.DataAnnotations;

namespace Hotel_Manager_4000.Models
{
    public class HotelListing
    {
        [Key]
        public int ?HotelId { get; set; }
        public string ?HotelName { get; set; }
        public string ?Vaccancies { get; set;}
    }
}