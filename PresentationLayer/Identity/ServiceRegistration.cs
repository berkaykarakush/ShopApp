using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime;

namespace PresentationLayer.Identity
{
    public static class ServiceRegistration
    {
        public static void AddPresentationLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Server=DESKTOP-IBNN2BI\\SQLEXPRESS;Database=ShopAppDb;User Id=sa;Password=Q19F25g;TrustServerCertificate=True;"));
            serviceCollection.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            //identity settings
            serviceCollection.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //username
                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = true;

            });
            //cookie settings
            serviceCollection.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accesdenied";
                options.SlidingExpiration = true;//her click'te 20dakika uzatir
                options.ExpireTimeSpan = TimeSpan.FromDays(365);//default yerine 365 gun ayarla
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie"
                };
            });
        }
    }
}
