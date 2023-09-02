using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Seller.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ICartService _cartService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IEmailSender emailSender, ICartService cartService, IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult SellerRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SellerRegister(SellerRegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName = NameEditExtensions.NameEdit(model.FirstName),
                LastName = NameEditExtensions.NameEdit(model.LastName),
                UserName = $"{model.FirstName}{model.LastName}",
                PhoneNumber = model.Phone,
                Email = model.Email,
                IpAddress = GetPublicIPAddress.GetIPAddress(),
                RegistrationDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var seller = new IdentityRole();
                seller.Name = "Seller";
                seller.NormalizedName = "SELLER";

                await _roleManager.CreateAsync(seller);
                await _userManager.AddToRoleAsync(user, seller.Name);

                //generate token
                await SendConfirmMail(user.Id);

                //send mail saying welcome
                await _emailSender.SendEmailAsync(model.Email, "Welcome to ShopApp", $"Hello, {user.UserName} </br> Welcome to the ShopApp!");
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "This email address is already in use!");
            return View(model);
        }

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
    }
}
