﻿using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [HttpPost]
        public async Task<IActionResult> Register (RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User { Email=registrationViewModel.Email,UserName= registrationViewModel.UserName };
                var registrationSucesss=await userManager.CreateAsync (newUser,registrationViewModel.Password);
                if(registrationSucesss.Succeeded)
                {
                await signInManager.SignInAsync(newUser,isPersistent:false);
                    return RedirectToAction("Index", "Home");
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
        public IActionResult Login()
        {
            return View();
        }
      
        public IActionResult Logout() 
        {
        return View();
        }
    }
}
