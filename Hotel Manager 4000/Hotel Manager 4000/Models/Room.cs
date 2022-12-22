using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Manager_4000.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomLevel { get; set;}
        
        [ForeignKey("GuestId")]
        [InverseProperty("Rooms")]
       public Guest Guests { get; set; }
    }
}
