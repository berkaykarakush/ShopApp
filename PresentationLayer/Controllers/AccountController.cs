using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PresentationLayer.EmailServices;
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
        
        //TODO hesabiniza giris yapildi maili gonder
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
                ModelState.AddModelError("", "Girdiginiz bilgiler yanlis lutfen kontrol ederek tekrar deneyiniz.");
                return View(model);
            }

            if (! await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lutfen hesabinizi onaylayiniz.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false , false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("", "Girilen email ya da parola hatalidir. Lutfen kontrol ederek tekrar deneyiniz.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        //TODO hosgeldiniz maili gonder
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
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName =model.UserName,
                Email =model.Email
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
                await _emailSender.SendEmailAsync(model.Email,"Hesabinizi onaylayiniz",$"Lutfen email hesabinizi onaylamak icin <a href='https://localhost:7087{url}'>Link'e tiklayiniz.</a>");

                return RedirectToAction("Login","Account");
            }
            
            ModelState.AddModelError("", "Bu email adresi zaten kullanilmaktadir.");
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
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title = "Cikis Yapildi",
                Message = "Hesabiniz guvenli bir sekilde kapatildi.",
                AlertType = AlertTypeEnum.Info
            });
            return RedirectToAction("Index","Home");  
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hata",
                    Message = "Gecersiz token",
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
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = "Hesabiniz onaylandi",
                        AlertType = AlertTypeEnum.Success
                    });
                    return View();
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Hata",
                Message = "Hesabiniz onaylanmadi",
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
                    Title = "Uyari",
                    Message = "Lutfen bir email adresi giriniz",
                    AlertType = AlertTypeEnum.Warning
                });
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hata",
                    Message = "Kullanici bulunamadi",
                    AlertType = AlertTypeEnum.Danger
                });
                return View();
            }

            var generateToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (generateToken == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uyari",
                    Message = "Lutfen daha sonra tekrar deneyiniz.",
                    AlertType = AlertTypeEnum.Warning
                });
                return View();
            }

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = generateToken
            });

            await _emailSender.SendEmailAsync(model.Email, "Parolanizi sifirlayin", $"Parolanizi sifirlamak icin lutfen <a href='https://localhost:7087{url}'>linke tiklayiniz.</a>");
            TempData.Put("message", new AlertMessage()
            {
                Title = "Islem Basarili",
                Message = "Parola sifirlama istegi gonderildi lutfen mail adresinizi kontrol ediniz",
                AlertType = AlertTypeEnum.Success
            });

            return View();
        }

        //TODO kullaniciya hesabiniz sifresi degistirildi diye mail gonder
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uyari",
                    Message = "Lutfen daha sonra tekrar deneyiniz",
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
                    Title = "Uyari",
                    Message = "Girilen bilgileri kontrol ederek tekrar deneyiniz.",
                    AlertType = AlertTypeEnum.Warning
                });
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hata",
                    Message = "Girilen email adresi bulunamadi",
                    AlertType = AlertTypeEnum.Danger
                });
                return View(model);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Islem Basarili",
                    Message = "Parola degistirme islemi basariyla tamamlanmistir",
                    AlertType = AlertTypeEnum.Success
                });
                return RedirectToAction("Login", "Account");
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Hata",
                Message = "Beklenmeyen bir hata olustu lutfen daha sonra tekrar deneyiniz.",
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
