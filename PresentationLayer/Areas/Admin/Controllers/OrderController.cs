using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;
using PresentationLayer.Enums;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public OrderController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }


        //[Route("Admin/Order/ListOrder")]
        [HttpGet]
        public async Task<IActionResult> ListOrder(AdminListOrderQueryRequest adminListOrderQueryRequest)
        {
            AdminListOrderQueryResponse response = await _mediator.Send(adminListOrderQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return View();
            }

            AdminListOrderVM orderVM = _mapper.Map<AdminListOrderVM>(response);
            return View(orderVM);
        }

        //[Route("Admin/Order/EditOrder?OrderId")]
        [HttpGet]
        public async Task<IActionResult> EditOrder(AdminEditOrderQueryRequest adminEditOrderQueryRequest)
        {
            AdminEditOrderQueryResponse response = await _mediator.Send(adminEditOrderQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotfyMessageEnum.Error);
                return View();
            }

            AdminOrderVM adminOrderVM = _mapper.Map<AdminOrderVM>(response);
            return View(adminOrderVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(AdminEditOrderCommandRequest adminEditOrderCommandRequest)
        {
            AdminEditOrderCommandResponse response = await _mediator.Send(adminEditOrderCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Order Updated!");

            return RedirectToAction("EditOrder", "Order", new AdminEditOrderQueryRequest() { OrderId = adminEditOrderCommandRequest.OrderId});
        }

        //[Route("Admin/Order/DeleteOrder")]
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(AdminDeleteOrderCommandRequest adminDeleteOrderCommandRequest)
        {
            AdminDeleteOrderCommandResponse response = await _mediator.Send(adminDeleteOrderCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Order Deleted!");

            return RedirectToAction("ListOrder", "Order");
        }

    }
}
