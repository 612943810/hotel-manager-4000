using Hotel_Manager_4000.Areas.Owner.Models;
using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Repository;
using Hotel_Manager_4000.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Manager_4000.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class RoomController : Controller
    {
    RoomRepository roomRepository;
       
        public RoomController(RoomRepository roomRepository)
        {
            roomRepository = roomRepository;
        }
        public IActionResult Index()
        {
            var room = roomRepository.findAll();
            return View(room);
        }
        [HttpGet]
        public IActionResult CreateRoom()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            roomRepository.Insert(room);
           return RedirectToAction("Index", "Room");   
        }
    }
}
