﻿using System.ComponentModel.DataAnnotations;

namespace Hotel_Manager_4000.Areas.Owner.Models
{
    public class Owners
    {
        [Key]
        public int ?OwnerId { get; set; }
        public string ?OwnerName { get; set; }

    }
}
