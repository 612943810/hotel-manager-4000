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
            var appRoles = new[] { "Owner", "Secretary", "Staff", "Guest", "Administrator" };
            foreach(var  role in appRoles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
