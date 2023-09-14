using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Enums;
using PresentationLayer.Identity;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        private readonly UserManager<User> _userManager;
        public OrderController(IMediator mediator, IMapper mapper, INotyfService notyfService, UserManager<User> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ListOrder(SellerListOrderQueryRequest sellerListOrderQueryRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            sellerListOrderQueryRequest.UserId = user.Id;
            SellerListOrderQueryResponse response = await _mediator.Send(sellerListOrderQueryRequest);
            SellerListOrderVM sellerListOrderVM = _mapper.Map<SellerListOrderVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(sellerListOrderVM);
        }
    }
}
