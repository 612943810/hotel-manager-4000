using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel_Manager_4000.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       public IActionResult HotelListing()
        {
            return View();
        }

    }
}