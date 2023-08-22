using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public IActionResult GetOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = _orderService.GetOrders(userId);

            var orderListModel = new List<OrderListModel>();
            OrderListModel orderModel;

            foreach (var order in orders)
            {
                orderModel = new OrderListModel();

                orderModel.OrderId = order.OrderId;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.Phone = order.Phone;
                orderModel.Address = order.Address;
                orderModel.City = order.City;
                orderModel.Email = order.Email;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.PaymentType = order.PaymentType;
                orderModel.OrderState = order.OrderState;

                orderModel.OrderItems = order.OrderItems.Select(o => new OrderItemModel() 
                {
                    OrderItemId = o.OrderItemId,
                    Name = o.Product.Name,
                    Price = (double)o.Price,
                    Quantity = o.Quantity,
                    ProductImage = o.Product.ProductImage
                }).ToList();

                orderListModel.Add(orderModel);
            }

            return View(orderListModel);
        }
    }
}
