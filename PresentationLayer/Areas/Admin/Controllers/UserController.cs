using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly INotyfService  _notyfService;
        private readonly IMapper _mapper;
        public UserController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, INotyfService notyfService, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _notyfService = notyfService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListUser()
        {
            return View(_userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(r => r.Name);
                ViewBag.Roles = roles;
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }

            _notyfService.Error(NotfyMessageEnum.Error);
            return RedirectToAction("ListUser", "User");
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetailsModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        _notyfService.Success("Transaction Successfull - User data updated.");
                        return RedirectToAction("ListUser", "User");
                    }
                }
                return RedirectToAction("ListUser", "User");
            }
            var roles = _roleManager.Roles.Select(r => r.Name);
            ViewBag.Roles = roles;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(ManageModel model)
        {
            var userDetailsModel = model.UserDetailsModel;
            var user = await _userManager.FindByIdAsync(userDetailsModel.UserId);

            if (user == null)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return RedirectToAction("Manage", "Account");
            }

            user.FirstName = NameEditExtensions.NameEdit(userDetailsModel.FirstName);
            user.LastName = NameEditExtensions.NameEdit(userDetailsModel.LastName);
            user.Email = userDetailsModel.Email;
            user.PhoneNumber = userDetailsModel.PhoneNumber;
            user.EmailConfirmed = userDetailsModel.EmailConfirmed;

            await _userManager.UpdateAsync(user);

            _notyfService.Success("Trantaction Successfull - User information updated!");
            return RedirectToAction("Manage", "Account");
        }

        //TODO User delete
    }
}
