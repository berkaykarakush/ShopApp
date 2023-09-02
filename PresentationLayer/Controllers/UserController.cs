using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> CreateAddress(ManageModel model)
        {
            var userAddressModel = model.UserAddressModel;
            if (userAddressModel == null)
            {

                _notyfService.Error(NotfyMessageEnum.Error);
                return RedirectToAction("Manage", "Account");
            }

            var user = await _userManager.FindByIdAsync(userAddressModel.UserId);
            userAddressModel.User = user;
            if (user == null)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return RedirectToAction("Manage", "Account");
            }


            user.UserAddresses.Add(_mapper.Map<UserAddress>(userAddressModel));
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Manage","Account");
        }
    }
}
