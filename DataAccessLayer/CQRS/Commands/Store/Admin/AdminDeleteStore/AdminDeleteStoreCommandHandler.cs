using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminDeleteStoreCommandHandler : IRequestHandler<AdminDeleteStoreCommandRequest, AdminDeleteStoreCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminDeleteStoreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminDeleteStoreCommandResponse> Handle(AdminDeleteStoreCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetById(request.StoreId);

                if (store == null)
                    return Task.FromResult(new AdminDeleteStoreCommandResponse() { IsSuccess = false });

                _unitOfWork.Stores.Delete(store);
                _unitOfWork.Save();
                return Task.FromResult(new AdminDeleteStoreCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminDeleteStoreCommandResponse() { IsSuccess = false });
        }
    }
}
