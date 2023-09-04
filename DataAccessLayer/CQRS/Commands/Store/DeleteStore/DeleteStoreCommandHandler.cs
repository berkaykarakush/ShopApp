using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommandRequest, DeleteStoreCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<DeleteStoreCommandResponse> Handle(DeleteStoreCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetById(request.StoreId);

                if (store == null)
                    return Task.FromResult(new DeleteStoreCommandResponse() { IsSuccess = false });

                _unitOfWork.Stores.Delete(store);
                _unitOfWork.Save();
                return Task.FromResult(new DeleteStoreCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteStoreCommandResponse() { IsSuccess = false });
        }
    }
}
