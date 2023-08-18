using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Extensions;
using System.Net;

namespace PresentationLayer.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICartService cartService)
        {
            var roles = Configuration._configuration.GetSection("Data:Roles").GetChildren().Select(r => r.Value).ToArray();
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            var users = Configuration._configuration.GetSection("Data:Users");
            foreach (var section in users.GetChildren())
            {
                var username = section.GetValue<string>("username");
                var password = section.GetValue<string>("password");
                var email = section.GetValue<string>("email");
                var role = section.GetValue<string>("role");
                var firstName = section.GetValue<string>("firstName");
                var lastName = section.GetValue<string>("lastName");

                if (await userManager.FindByNameAsync(username) == null)
                {
                    var user = new User()
                    {
                        UserName = username,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        EmailConfirmed = true,
                        PhoneNumber = "5435432323",
                        IpAddress = GetPublicIPAddress.GetIPAddress(),
                        RegistrationDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                        FirstOrderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                };
                user.UserDetails.Add(new UserDetail
                {
                    UserId = user.Id,
                    LastOrderDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    LastLoginDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    LastLogoutDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                });
                user.UserAddresses.Add(new UserAddress 
                {
                    UserId = user.Id,
                    Country = "Germany",
                    City = "Berlin",
                    Address = "Straße des 17. Juni 135",
                    ZipCode = "10623"
                });

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                    cartService.InitilazeCart(user.Id);
                }
                }
            }
        }
    }
}
