using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize()]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public OrderController(IOrderService orderService, UserManager<User> userManager, IMediator mediator, IMapper mapper)
        {
            _orderService = orderService;
            _userManager = userManager;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetOrders(GetOrdersCommandRequest getOrdersCommandRequest)
        {
            var userId = _userManager.GetUserId(User);
            getOrdersCommandRequest.UserId = userId;

            GetOrdersCommandResponse response = await _mediator.Send(getOrdersCommandRequest);
            OrderListModel orderListModel = _mapper.Map<OrderListModel>(response);

            return View(orderListModel);
        }
    }
}
