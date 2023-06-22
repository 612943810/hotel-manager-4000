using Hotel_Manager_4000.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Manager_4000.Controllers
{
    public class HotelController : Controller
    {
        public HotelContext ?hotelContext { get; set; }
        public HotelController(HotelContext context) 
        {
            hotelContext = context;
        }
        public IActionResult HotelListing()
        {
            var hotels=hotelContext.hotelListings.OrderBy(model=>model.HotelId).ToList();
            return View(hotels);
        }
    }
}
