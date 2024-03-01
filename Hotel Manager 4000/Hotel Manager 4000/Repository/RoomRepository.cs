using Hotel_Manager_4000.Areas.Owner.Models;
using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Interfaces;
using Hotel_Manager_4000.Models;

namespace Hotel_Manager_4000.Repository
{
    public class RoomRepository : IRoom
    {
        private readonly HotelContext hotelContext;
        public RoomRepository(HotelContext context)
        {
            hotelContext = context;
        }
        public void Insert(Room roomListing)
        {
            hotelContext.Add(roomListing);
            hotelContext.SaveChanges();
        }
        public IEnumerable<Room> findAll()
        {
            return hotelContext.Rooms.OrderBy(model => model.RoomNumber).ToList();
        }
        public Room GetByID(int id)
        {
            return hotelContext.Rooms.Find(id);
        }

        public void Update(HotelListing hotelListing)
        {

            hotelContext.Update(hotelListing);
            hotelContext.SaveChanges();
        }


        public void Delete(int hotelId)
        {
            HotelListing hotelListing = hotelContext.hotelListings.Find(hotelId);
            hotelContext.Remove(hotelListing);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }



        public void Update(Room hotelListing)
        {
            throw new NotImplementedException();
        }
    }

}

