using Microsoft.AspNetCore.Mvc;

namespace Hotel_Manager_4000.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
