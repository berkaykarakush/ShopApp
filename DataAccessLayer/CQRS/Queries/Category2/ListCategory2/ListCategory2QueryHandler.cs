using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCategory2QueryHandler : IRequestHandler<ListCategory2QueryRequest, ListCategory2QueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListCategory2QueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ListCategory2QueryResponse> Handle(ListCategory2QueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var allCategories2 = _unitOfWork.Categories2.GetAll();

                if (allCategories2 == null)
                    return Task.FromResult(new ListCategory2QueryResponse() { IsSuccess = false });

                return Task.FromResult(new ListCategory2QueryResponse() { IsSuccess = true, Categories2 = allCategories2 });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ListCategory2QueryResponse() { IsSuccess = false });
        }
    }
}
