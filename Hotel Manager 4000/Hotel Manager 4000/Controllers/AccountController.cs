using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hotel_Manager_4000.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManagerValue,SignInManager<User> signInManagerValue )
        {
            userManager = userManagerValue;
            signInManager = signInManagerValue;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register (RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User { Email=registrationViewModel.Email,FirstName=registrationViewModel.FirstName,LastName=registrationViewModel.LastName, 
                    UserName= registrationViewModel.UserName,Password=registrationViewModel.Password,ConfirmPassword=registrationViewModel.ConfirmPassword,Role=registrationViewModel.Role};
                var registrationSucesss=await userManager.CreateAsync (newUser,registrationViewModel.Password);
                if(registrationSucesss.Succeeded)
                {
                    if (!User.IsInRole(newUser.Role))
                    {
                       userManager.AddToRoleAsync(newUser,newUser.Role);                  
                    }
                await signInManager.SignInAsync(newUser,isPersistent:false);
                    return RedirectToAction("Index", "Home", new {Area="Owner"});
                }
                else 
                { 
                foreach(var websiteError in registrationSucesss.Errors)
                    {
                        ModelState.AddModelError("The registration was not successful",websiteError.Description);
                    }
                }
            }
            return View(registrationViewModel);
        }
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
          
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password,isPersistent:false,lockoutOnFailure:false);
                if(loginResult.Succeeded)
                {

                    if (User.IsInRole("Administrator"))
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Administrator" });
                    }
                    else if(User.IsInRole("Owner"))
                    {
                       return RedirectToAction("Index", "Home", new { Area = "Owner" });
                    }
                   
                      
                    
                } else
                    {
return RedirectToAction("Error", "Account","" );
                    }
                   
                   
                
            }
            return View();
        }

     
       [HttpGet]
        public async Task<IActionResult> Logout() 
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home",new { Area = "" });
        }
    }
}