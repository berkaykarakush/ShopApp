﻿using DataAccessLayer.Concrete.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.EmailServices;
using System.Reflection;

namespace PresentationLayer.Identity
{
    public static class ServiceRegistration
    {
        public static void AddPresentationLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEmailSender, EmailSender>(i=> new EmailSender
                (
                    Configuration._configuration.GetSection("EmailSender:Host").Value,
                    Configuration._configuration.GetSection("EmailSender:Port").Value,
                    Configuration._configuration.GetSection("EmailSender:EnableSSl").Value,
                    Configuration._configuration.GetSection("EmailSender:Username").Value,
                    Configuration._configuration.GetSection("EmailSender:Password").Value
                )
            );

            serviceCollection.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration._configuration.GetSection("ConnectionStrings:MsSQLConnection").Value));
            serviceCollection.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            //AutoMapper
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());   

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
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            //cookie settings
            serviceCollection.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
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
