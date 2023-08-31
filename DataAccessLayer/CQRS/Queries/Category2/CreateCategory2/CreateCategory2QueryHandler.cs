using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class CreateCategory2QueryHandler : IRequestHandler<CreateCategory2QueryRequest, CreateCategory2QueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategory2QueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CreateCategory2QueryResponse> Handle(CreateCategory2QueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var allCategories = _unitOfWork.Categories.GetAll();
                return Task.FromResult(new CreateCategory2QueryResponse() { Categories = allCategories, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new CreateCategory2QueryResponse() { IsSuccess = false });
        }
    }
}
