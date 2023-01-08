using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Manager_4000.Areas.Owner.Models;

    public class Room
    { 
        public int ?RoomId { get; set; }
    [Required(ErrorMessage = "Please enter an first name.")]
    public int ?RoomNumber { get; set; }
        public int ?RoomLevel { get; set; }

        //[ForeignKey("GuestId")]
        //[InverseProperty("Rooms")]
        //public Guest? Guests { get; set; }
    }

