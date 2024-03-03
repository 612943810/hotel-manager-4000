using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Models;
using Hotel_Manager_4000.Repository;
using Hotel_Manager_4000.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Manager_4000.Controllers
{
    public class HotelController : Controller
    {
        HotelRepository hotelRepository;
       
        public HotelController(HotelRepository hotelRepository) 
        {
            this.hotelRepository =hotelRepository;
        }
        public IActionResult HotelListing()
        {
            var hotels = hotelRepository.findAll();
            return View(hotels);
        }
     public IActionResult Add(HotelListing hotelListing) {
        hotelRepository.Insert(hotelListing);
         return RedirectToAction("HotelListing","Hotel");
        }
    }
}
