using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        private readonly UserManager<User> _userManager;

        public StoreController(IMediator mediator, IMapper mapper, INotyfService notyfService, UserManager<User> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
            _userManager = userManager;
        }

        //[Route("Seller/Store/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(SellerStoreIndexQueryRequest sellerStoreIndexQueryRequest)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return View();
            }

            sellerStoreIndexQueryRequest.UserId = user.Id;
            SellerStoreIndexQueryResponse response = await _mediator.Send(sellerStoreIndexQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return View();
            }

            StoreIndexVM indexVM = _mapper.Map<StoreIndexVM>(response);
            return View(indexVM);
        }

        //[Route("Seller/EditStore")]
        [HttpPost]
        public async Task<IActionResult> EditStore(SellerEditStoreCommandRequest sellerEditStoreCommandRequest, IFormFile file)
        {
            if (!string.IsNullOrEmpty(sellerEditStoreCommandRequest.StoreName))
            {
                sellerEditStoreCommandRequest.StoreUrl = UrlNameEditExtensions.UrlNameEdit(sellerEditStoreCommandRequest.StoreName);
                var storeImage = await ImageNameEditExtensions.ImageNameEdit(file, sellerEditStoreCommandRequest.StoreUrl);
                sellerEditStoreCommandRequest.StoreImage = storeImage;
            }

            SellerEditStoreCommandResponse response = await _mediator.Send(sellerEditStoreCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Store Updated!");

            if (!string.IsNullOrEmpty(sellerEditStoreCommandRequest.SellerId))
                return RedirectToAction("Index", "Store", new SellerStoreIndexQueryRequest() { UserId = sellerEditStoreCommandRequest.SellerId});

            return RedirectToAction("Index","Store");
        }
    }
}
