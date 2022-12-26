using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Manager_4000.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager )
        {
            userManager = userManager;
            signInManager = signInManager;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Register ()
        {
            return View();
        }
        public IActionResult Logout() 
        {
        return View();
        }
    }
}
