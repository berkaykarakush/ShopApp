using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
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
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Login(LoginQueryRequest loginQueryRequest)
        {
            LoginQueryResponse response = await _mediator.Send(loginQueryRequest);
            LoginModel loginModel = _mapper.Map<LoginModel>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(loginModel);
        }
        
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
                user.UserDetails.Add(new UserDetail
                {
                    UserId = user.Id,
                    LastLoginDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                });

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
                var customer = new IdentityRole();
                customer.Name = "Customer";
                customer.NormalizedName = "CUSTOMER";
                await _roleManager.CreateAsync(customer);
                await _userManager.AddToRoleAsync(user, customer.Name);

                //generate token
                await SendConfirmMail(user.Id);

                //send mail saying welcome
                await _emailSender.SendEmailAsync(model.Email, "Welcome to ShopApp", $"Hello, {user.UserName} </br> Welcome to the ShopApp!");
                return RedirectToAction("Login","Account");
            }
               
            ModelState.AddModelError("", "This email address is already in use!");
            return View(model);
        }
        #region Seller

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
        #endregion

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            string userId = _userManager.GetUserId(User);
            User user = await _userManager.FindByIdAsync(userId);
            ManageModel manageModel = new ManageModel();
            manageModel.UserDetailsModel = new UserDetailsModel() 
            {
                UserId = userId,
                UserDetailId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                EmailConfirmed = user.EmailConfirmed
            };
            manageModel.UserAddressModels.AddRange(_mapper.Map<List<UserAddressModel>>(user.UserAddresses));

            return View(manageModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.UserDetails.Add(new UserDetail
                {
                    UserId = user.Id,
                    LastLogoutDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                });
                await _userManager.UpdateAsync(user);

                await _signInManager.SignOutAsync();

                _notyfService.Success("Logged Out - Your account has been securely closed.");

                return RedirectToAction("Index", "Home");
            }

            _notyfService.Error("Error  - Failed to log out");
            return RedirectToAction("Index", "Home");
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
                _notyfService.Warning("Warning - Please enter an e-mail address");
                return View();
            }

            await SendForgotPassword(model.Email);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
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
                _notyfService.Warning("Warning - Please check to information and try again.");
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _notyfService.Error("Error - The e-mail address entered was not found.");
                return View(model);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Transaction Successfull",
                    Message = "Password change completed successfully.",
                    AlertType = AlertTypeEnum.Success
                });

                user.UserDetails.Add(new UserDetail() 
                { 
                    Id = user.Id,
                    ResetPasswordDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                });

                await _userManager.UpdateAsync(user);

                //send email saying reset password
                await _emailSender.SendEmailAsync(model.Email,"Your password has been changed",$"Your password has been changed on {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.");
                return RedirectToAction("Login", "Account");
            }

            _notyfService.Error(NotfyMessageEnum.Error);
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
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

                return RedirectToAction("ListUser","User");
            }
            _notyfService.Error(NotfyMessageEnum.Error);
            return RedirectToAction("ListUser","User");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _notyfService.Error("Error - User not found.");
                return View();
            }

            var generateToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (generateToken == null)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return View();
            }

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = generateToken
            });

            await _emailSender.SendEmailAsync(email, "Reset Your Password ", $"Please click the <a href='https://localhost:7087{url}'>link</a> to reset your password.");

            TempData.Put("message", new AlertMessage()
            {
                Title = "Transaction Successfull",
                Message = "Password reset request sent, please check your e-mail.",
                AlertType = AlertTypeEnum.Success
            });

            return RedirectToAction("ListUser", "User");
        }
    }
}
