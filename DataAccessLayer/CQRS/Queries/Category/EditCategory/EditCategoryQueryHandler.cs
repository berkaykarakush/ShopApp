using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategoryQueryHandler : IRequestHandler<EditCategoryQueryRequest, EditCategoryQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditCategoryQueryResponse> Handle(EditCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Category entity = new Category();
            try
            {
                entity = _unitOfWork.Categories.GetByIdWithProducts(request.Id);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new EditCategoryQueryResponse() { IsSuccess = false };
            }

            return new EditCategoryQueryResponse() { 
                IsSuccess = true,
                Name = entity.Name,
                CategoryId = entity.CategoryId,
                Products = entity.ProductCategories.Select(p => p.Product).ToList(),
                Url = entity.Url
            };
        }
    }
}
