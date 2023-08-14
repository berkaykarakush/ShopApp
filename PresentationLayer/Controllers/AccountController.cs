﻿using BusinessLayer.Abstract;
using Iyzipay.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PresentationLayer.EmailServices;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;
using System;
using System.Net;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ICartService _cartService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, ICartService cartService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "The information you entered is incorrect, please check and try again!");
                return View(model);
            }

            if (! await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Please confirm your account!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false , false);
            if (result.Succeeded)
            {
                TempData["UserId"] = user.Id;
                //user.UserDetails.LastLoginDate = DateTime.Now.ToString("yyyy/MM//dd HH:mm:ss");
                //send mail if you sign in on new device
                if (user.IpAddress != GetPublicIPAddress.GetIPAddress())
                {
                    user.IpAddress = GetPublicIPAddress.GetIPAddress();

                    await _userManager.UpdateAsync(user);

                    await _emailSender.SendEmailAsync(model.Email, "Your account was signed in from a new device", $"Hello {user.FirstName}. </br> We have detected that your account has been logged in");

                    return Redirect(model.ReturnUrl ?? "~/");
                }

                await _userManager.UpdateAsync(user);
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("", "The information you entered is incorrect, please check and try again!");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
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
                await _userManager.AddToRoleAsync(user, "Customer");

                //generate token
                string generateToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string url = Url.Action("ConfirmEmail", "Account", new 
                {
                    userId = user.Id,
                    token = generateToken
                });

                //confirmed email
                await _emailSender.SendEmailAsync(model.Email,"Confirm your account",$"Please click on the <a href='https://localhost:7087{url}'>link</a> to confirm your e-mail account!");

                //send mail saying welcome
                await _emailSender.SendEmailAsync(model.Email, "Welcome to ShopApp", $"Hello, {user.UserName} </br> Welcome to the ShopApp!");
                return RedirectToAction("Login","Account");
            }
            
            ModelState.AddModelError("", "This email address is already in use!");
            return View(model);
        }

        [HttpGet]
        public  IActionResult Manage()
        {
            //TODO manage get method
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageModel model)
        {
            //TODO manage post method
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            string userId = TempData["UserId"].ToString();
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.LastLogoutDate = DateTime.Now.ToString("yyyy/mm/dd HH:mm:ss");
                await _userManager.UpdateAsync(user);

                await _signInManager.SignOutAsync();

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Logged Out",
                    Message = "Your account has been securely closed.",
                    AlertType = AlertTypeEnum.Success
                });
                return RedirectToAction("Index", "Home");
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Error",
                Message = "Failed to log out",
                AlertType = AlertTypeEnum.Danger
            });
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error",
                    Message = "Invalid Token",
                    AlertType = AlertTypeEnum.Danger
                });
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Warning",
                    Message = "Please enter an e-mail address",
                    AlertType = AlertTypeEnum.Warning
                });
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error",
                    Message = "User not found",
                    AlertType = AlertTypeEnum.Danger
                });
                return View();
            }

            var generateToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (generateToken == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Warning",
                    Message = "Please try again in few minutes",
                    AlertType = AlertTypeEnum.Warning
                });
                return View();
            }

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = generateToken
            });

            await _emailSender.SendEmailAsync(model.Email, "Reset Your Password ", $"Please click the <a href='https://localhost:7087{url}'>link</a> to reset your password.");
            TempData.Put("message", new AlertMessage()
            {
                Title = "Transaction Successfull",
                Message = "Password reset request sent, please check your e-mail.",
                AlertType = AlertTypeEnum.Success
            });
            
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Warning",
                    Message = "Please try again in few minutes",
                    AlertType = AlertTypeEnum.Warning
                });
                return View();
            }

            var model = new ResetPasswordModel { Password = token };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Warning",
                    Message = "Please check to information and try again.",
                    AlertType = AlertTypeEnum.Warning
                });
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error",
                    Message = "The e-mail address entered was not found.",
                    AlertType = AlertTypeEnum.Danger
                });
                return View(model);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            string changedTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Transaction Successfull",
                    Message = "Password change completed successfully.",
                    AlertType = AlertTypeEnum.Success
                });

                user.ResetPasswordDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                await _userManager.UpdateAsync(user);

                //send email saying reset password
                await _emailSender.SendEmailAsync(model.Email,"Your password has been changed",$"Your password has been changed on {changedTime}.");
                return RedirectToAction("Login", "Account");

            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Error",
                Message = "An unexpected error occured, please try again later.",
                AlertType = AlertTypeEnum.Danger
            });
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
