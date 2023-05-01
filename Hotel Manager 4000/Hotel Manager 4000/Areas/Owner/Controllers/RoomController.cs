using Hotel_Manager_4000.Areas.Owner.Models;
using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Manager_4000.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class RoomController : Controller
    {
        protected HotelContext ?hotelContext { get; set; }
        private Repository<Room>? roomData { get; set; }
       
        public RoomController(HotelContext context)
        {
            hotelContext= context;
        }
        public IActionResult Index()
        {
            var room = hotelContext.Rooms.OrderBy(model => model.RoomNumber).ToList();
            return View(room);
        }
        [HttpGet]
        public IActionResult CreateRoom()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(HotelContext ctx,Room room)
        {
            roomData = new Repository<Room>(ctx);
           
            roomData.InsertAsync(room);
           await roomData.SaveAsync();

            return RedirectToAction("Index", "Room");   
        }
    }
}
