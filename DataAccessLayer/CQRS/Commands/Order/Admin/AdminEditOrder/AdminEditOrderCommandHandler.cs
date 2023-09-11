using DataAccessLayer.Abstract;
using MediatR;
using Serilog;
using System.Reflection.Metadata;
using System.Xml;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminEditOrderCommandHandler : IRequestHandler<AdminEditOrderCommandRequest, AdminEditOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditOrderCommandResponse> Handle(AdminEditOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _unitOfWork.Orders.GetByOrderWithOrderItems(request.OrderId);

                if (order == null)
                    return Task.FromResult(new AdminEditOrderCommandResponse() { IsSuccess = false });

                order.OrderId = request.OrderId;
                order.OrderNumber = request.OrderNumber;
                order.OrderDate = request.OrderDate;
                order.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                order.Note = request.Note;
                order.ConversationId = request.ConversationId;
                order.PaymentId = request.PaymentId;
                order.PaymentType = request.PaymentType;
                order.OrderState = request.OrderState;

                order.UserId = request.UserId;
                order.FirstName = request.FirstName;
                order.LastName = request.LastName;
                order.Email = request.Email;
                order.Phone = request.Phone;

                order.Address = request.Address;
                order.City = request.City;
                order.Country = request.Country;

                _unitOfWork.Orders.Update(order);
                _unitOfWork.Save();
                return Task.FromResult(new AdminEditOrderCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminEditOrderCommandResponse() { IsSuccess = false });
        }
    }
}
