using System.ComponentModel.DataAnnotations;


namespace Hotel_Manager_4000.Areas.Owner.Models
{   
    public class Guest
    {
        [Key]
        public int ?GuestId { get; set; }
        public string ? Name { get; set; }
      

        //[InverseProperty("Guests")]
        //public ICollection<Room> ?Rooms { get; set; }

    }
}
