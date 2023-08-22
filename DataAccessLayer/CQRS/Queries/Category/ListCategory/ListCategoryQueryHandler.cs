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

        public async Task<ListCategoryQueryResponse> Handle(ListCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            List<Category> allCategories = new List<Category>();

            try
            {
                allCategories = _unitOfWork.Categories.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);     
            }

            return new ListCategoryQueryResponse() { IsSuccess = true, Categories = allCategories };
        }
    }
}
