using AspNetCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
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
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> SellerRegister(SellerRegisterQueryRequest sellerRegisterQueryRequest)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            sellerRegisterQueryRequest.SellerId = user.Id;
            sellerRegisterQueryRequest.SellerFirstName = user.FirstName;
            sellerRegisterQueryRequest.SellerLastName = user.LastName;
            sellerRegisterQueryRequest.SellerEmail = user.Email;
            sellerRegisterQueryRequest.SellerPhone = user.PhoneNumber;

            SellerRegisterQueryResponse response = await _mediator.Send(sellerRegisterQueryRequest);
            SellerRegisterModel sellerRegisterModel = _mapper.Map<SellerRegisterModel>(response);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            return View(sellerRegisterModel);
        }

        [HttpPost]
        public async Task<IActionResult> SellerRegister(SellerRegisterCommandRequest sellerRegisterCommandRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            await _userManager.AddToRoleAsync(user, "Seller");

            SellerRegisterCommandResponse response = await _mediator.Send(sellerRegisterCommandRequest);
            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Your application has been received!");

            return Redirect("/");
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
            _notyfService.Error(NotyfMessageEnum.Error);
            return RedirectToAction("ListUser", "User");
        }
    }
}
