using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Models;
using Hotel_Manager_4000.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager_4000.Service
{
    public class HotelRepository : IHotel
    {
        private readonly HotelContext hotelContext;
        public HotelRepository(HotelContext context)
        {
            hotelContext = context;
        }
        public void Insert(HotelListing hotelListing)
        {
            hotelContext.Add(hotelListing);
            hotelContext.SaveChanges();
        }
        public IEnumerable<HotelListing> findAll()
        {
            return hotelContext.hotelListings.OrderBy(model => model.HotelId).ToList();
        }
        public HotelListing GetByID(int id)
        {
            return hotelContext.hotelListings.Find(id);
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


    }

}
