using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries  
{
    public class AdminEditOrderQueryHandler : IRequestHandler<AdminEditOrderQueryRequest, AdminEditOrderQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditOrderQueryResponse> Handle(AdminEditOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _unitOfWork.Orders.GetByOrderWithOrderItems(request.OrderId);

                if (order == null)
                    return Task.FromResult(new AdminEditOrderQueryResponse() { IsSuccess = false });

                return Task.FromResult(new AdminEditOrderQueryResponse() 
                { 
                    IsSuccess = true,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    ConversationId = order.ConversationId,
                    CreatedDate = order.CreatedDate,
                    Note = order.Note,
                    OrderId = order.OrderId,
                    OrderItems = order.OrderItems,
                    OrderState = order.OrderState,
                    PaymentId = order.PaymentId,
                    PaymentType = order.PaymentType,
                    UpdatedDate = order.UpdatedDate,

                    UserId = order.UserId,
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    Email = order.Email,
                    Phone = order.Phone,

                    Address = order.Address,
                    City = order.City,
                    Country = order.Country
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminEditOrderQueryResponse() { IsSuccess = false });
        }
    }
}
