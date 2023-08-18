using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListRole()
        {
            return View(_roleManager.Roles);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{model.Name} isimli role basariyla olusturuldu.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListRole", "Role");
                }
                else
                {
                    var erros = result.Errors;
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarisiz!",
                        Message = $"{erros}",
                        AlertType = AlertTypeEnum.Danger
                    });
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Islem Basarisiz!",
                Message = $"Role olusturulamadi. Lutfen tekrar deneyiniz.",
                AlertType = AlertTypeEnum.Danger
            });
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }

                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Islem Basarili",
                    Message = $"{role.Name} isimli role basariyla silinmistir.\n",
                    AlertType = AlertTypeEnum.Success
                });
            }
            else
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Islem Basarisiz",
                    Message = $"{role.Name} isimli role silinemedi. Lutfen daha sonra tekrar deneyiniz.\n",
                    AlertType = AlertTypeEnum.Danger
                });
            }

            return RedirectToAction("ListRole", "Role");
        }
    }
}
