using Hotel_Manager_4000.Areas.Owner.Models;
using Hotel_Manager_4000.Models;

namespace Hotel_Manager_4000.Interfaces
{
    public interface IRoom
    {
        IEnumerable<Room> findAll();
        Room GetByID(int id);
        void Insert(Room hotelListing);
        void Update(Room hotelListing);
        void Delete(int hotelId);
        void Save();

    }
}
