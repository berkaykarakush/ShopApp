using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCategoryQueryHandler : IRequestHandler<ListCategoryQueryRequest, ListCategoryQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public ListCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ListCategoryQueryResponse> Handle(ListCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var allCategories = _unitOfWork.Categories.GetAll();

                if (allCategories == null)
                    return Task.FromResult(new ListCategoryQueryResponse() { IsSuccess =false});

                return Task.FromResult(new ListCategoryQueryResponse() { IsSuccess = true, Categories = allCategories});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");     
            }

            return Task.FromResult(new ListCategoryQueryResponse() { IsSuccess = false});
        }
    }
}
