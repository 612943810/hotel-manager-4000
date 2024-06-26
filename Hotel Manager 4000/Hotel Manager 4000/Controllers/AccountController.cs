﻿using Hotel_Manager_4000.Areas.Owner.Models;
using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hotel_Manager_4000.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<User> userManagerValue, SignInManager<User> signInManagerValue, RoleManager<IdentityRole> roleManagerValue)
        {
            userManager = userManagerValue;
            signInManager = signInManagerValue;
            roleManager = roleManagerValue;
        }
        public IActionResult Register()
        {
            var roleList = roleManager.Roles.Select(roleData => new { RoleID= roleData.Id, RoleName = roleData.Name }).ToList();
            ViewBag.Roles = new SelectList(roleList,"RoleName","RoleName");

            return View();
        }

    
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User { Email = registrationViewModel.Email, FirstName = registrationViewModel.FirstName, LastName = registrationViewModel.LastName,
                    UserName = registrationViewModel.UserName, Password = registrationViewModel.Password, ConfirmPassword = registrationViewModel.ConfirmPassword };
                var registrationSucesss = await userManager.CreateAsync(newUser, registrationViewModel.Password);
                if (registrationSucesss.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    
                    var roleType = registrationViewModel.Role;
                    var roleName = await roleManager.FindByNameAsync(roleType);
                 
                    await userManager.AddToRoleAsync(newUser,roleType);
                    
           
               return RedirectToAction("Index", "Home", new { Area = "" });
                }
                else
                {
                    foreach (var websiteError in registrationSucesss.Errors)
                    {
                        ModelState.AddModelError("The registration was not successful", websiteError.Description);
                    }
                }
            }
            return View(registrationViewModel);
        }

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, isPersistent: false, lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home","");

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