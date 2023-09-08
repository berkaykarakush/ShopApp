using AspNetCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.CQRS.Commands;
using Iyzipay.Model.V2.Subscription;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly INotyfService _notyfService;
        private readonly ICartService _cartService;
        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IEmailSender emailSender, INotyfService notyfService, ICartService cartService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _notyfService = notyfService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View(new AdminRegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> AdminRegister(AdminRegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return View(model);
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                NormalizedUserName = $"{model.FirstName}{model.LastName}".ToUpper(),
                Email = model.Email,
                IpAddress = GetPublicIPAddress.GetIPAddress(),
                NormalizedEmail = $"{model.Email}".ToUpper(),
                UserName = $"{model.FirstName}{model.LastName}".ToLower(),
                RegistrationDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                PhoneNumber = model.Phone
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");

                //generate token
                await SendConfirmMail(user.Id);
                
                //send welcome mail
                await _emailSender.SendEmailAsync(model.Email, "Welcome to ShopApp", $"Hello, {user.FirstName} </br>Welcome to ShopApp!");
                return RedirectToAction("ListUser", "User");
            }
            ModelState.AddModelError("", "This e-mail address in used!");
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendConfirmMail(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                string generateToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = generateToken
                });

                //confirmed email
                await _emailSender.SendEmailAsync(user.Email, "Confirm your account", $"Please click on the <a href='https://localhost:7087{url}'>link</a> to confirm your e-mail account!");

                return RedirectToAction("ListUser", "User");
            }
            _notyfService.Error(NotfyMessageEnum.Error);
            return RedirectToAction("ListUser", "User");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                _notyfService.Error("Error  - Invalid Token");

                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    _cartService.InitilazeCart(user.Id);
                    user.ConfirmEmailDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    await _userManager.UpdateAsync(user);
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Transaction Successful",
                        Message = "Your account has been confirmed",
                        AlertType = AlertTypeEnum.Success
                    });
                    return View();
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Error",
                Message = "Your account has not been confirmed",
                AlertType = AlertTypeEnum.Danger
            });
            return View();
        }
    }
}
