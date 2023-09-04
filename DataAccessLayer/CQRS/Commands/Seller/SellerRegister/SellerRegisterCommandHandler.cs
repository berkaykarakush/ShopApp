using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerRegisterCommandHandler : IRequestHandler<SellerRegisterCommandRequest, SellerRegisterCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerRegisterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SellerRegisterCommandResponse> Handle(SellerRegisterCommandRequest request, CancellationToken cancellationToken)
        {
			try
			{
                var store = new Store()
                {
                    SellerId = request.SellerId,
                    SellerFirstName = request.SellerFirstName,
                    SellerLastName = request.SellerLastName,
                    SellerEmail = request.SellerEmail,
                    SellerPhone = request.SellerPhone,
                    StoreName = request.StoreName,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                };

                if (store == null)
                    return Task.FromResult(new SellerRegisterCommandResponse() { IsSuccess = false });

                _unitOfWork.Stores.Create(store);
                _unitOfWork.Save();
                return Task.FromResult(new SellerRegisterCommandResponse() { IsSuccess = true});
			}
			catch (Exception ex)
			{
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
			}
            return Task.FromResult(new SellerRegisterCommandResponse() { IsSuccess = false });
        }
    }
}
