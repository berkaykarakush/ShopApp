using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class GetOrdersCommandHandler : IRequestHandler<GetOrdersCommandRequest, GetOrdersCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<GetOrdersCommandResponse> Handle(GetOrdersCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = _unitOfWork.Orders.GetOrders(request.UserId);
                var orderList = new List<Order>();
                Order o;
                foreach (var order in orders)
                {
                    o = new Order();

                    o.OrderId = order.OrderId;
                    o.OrderNumber = order.OrderNumber;
                    o.OrderDate = order.OrderDate;
                    o.Phone = order.Phone;
                    o.Address = order.Address;
                    o.City = order.City;
                    o.Email = order.Email;
                    o.FirstName = order.FirstName;
                    o.LastName = order.LastName;
                    o.PaymentType = order.PaymentType;
                    o.OrderState = order.OrderState;

                    o.OrderItems = order.OrderItems.Select(o => new OrderItem()
                    {
                        OrderItemId = o.OrderItemId,
                        Name = o.Product.Name,
                        Price = o.Price,
                        Quantity = o.Quantity,
                        ProductImage = o.Product.ProductImage
                    }).ToList();

                    orderList.Add(o);
                }
                return Task.FromResult(new GetOrdersCommandResponse() { IsSuccess = true, Orders = orderList});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new GetOrdersCommandResponse() { IsSuccess = false});
        }
    }
}
