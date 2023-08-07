using DataAccessLayer.Concrete.EFCore;
using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var username = Configuration._configuration.GetSection("Data:AdminUser:username").Value;
            var password = Configuration._configuration.GetSection("Data:AdminUser:password").Value;
            var email = Configuration._configuration.GetSection("Data:AdminUser:email").Value;
            var role = Configuration._configuration.GetSection("Data:AdminUser:role").Value;

            if (await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new User() 
                {
                    UserName = username,
                    Email = email,
                    FirstName = "shopapp",
                    LastName = "admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user,password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
