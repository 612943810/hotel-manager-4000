using Hotel_Manager_4000.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Manager_4000.Models
{
    public class SeedData
    {

        public static async Task CreateUsers(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            User ownerUser = new User
            {
                Id = 3,
                FirstName = "Pauline",
                LastName = "Erna",
                UserName = "pauer",
                Password = "#h!2o!hLw4za",
                ConfirmPassword = "#h!2o!hLw4za",
                Email = "pauline.erna@hotel",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            string mainOwner = "Owner";

            await roleManager.CreateAsync(new IdentityRole(mainOwner));

            var newResult = await userManager.CreateAsync(ownerUser,ownerUser.Password);
            if (newResult.Succeeded)
            {
              
                    await userManager.AddToRoleAsync(ownerUser,mainOwner);
               
            }
        }
        }
}
