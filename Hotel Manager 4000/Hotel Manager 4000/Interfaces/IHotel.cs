using Hotel_Manager_4000.Models;
namespace Hotel_Manager_4000.Repository
{
    public interface IHotel
    {
        IEnumerable<HotelListing> findAll();
        HotelListing GetByID (int id);
        void Insert (HotelListing hotelListing);
        void Update(HotelListing hotelListing);
        void Delete(int hotelId);
        void Save();



    }

   
}
