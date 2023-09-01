using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategoryQueryHandler : IRequestHandler<EditCategoryQueryRequest, EditCategoryQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EditCategoryQueryResponse> Handle(EditCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Categories.GetByIdWithProducts(request.Id);

                if (entity == null)
                    return Task.FromResult(new EditCategoryQueryResponse() { IsSuccess = false} );

                return Task.FromResult(new EditCategoryQueryResponse() 
                {
                    IsSuccess = true,
                    Name = entity.Name,
                    CategoryId = entity.CategoryId,
                    //Products = entity.ProductCategories.Select(p => p.Product).ToList(),
                    Url = entity.Url
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new EditCategoryQueryResponse() { IsSuccess = false});
        }
    }
}
