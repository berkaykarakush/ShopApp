using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategory2QueryHandler : IRequestHandler<EditCategory2QueryRequest, EditCategory2QueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCategory2QueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EditCategory2QueryResponse> Handle(EditCategory2QueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);
                var categories = _unitOfWork.Categories.GetAll();

                if (category2 == null && categories == null)
                    return Task.FromResult(new EditCategory2QueryResponse() { IsSuccess = false });

                return Task.FromResult(new EditCategory2QueryResponse() 
                {
                    IsSuccess = true,
                    Category = category2.Category,
                    CategoryId = (double)category2.CategoryId,
                    Category2Id = category2.Category2Id,
                    Name = category2.Name,
                    Url = category2.Url,
                    Categories = categories
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new EditCategory2QueryResponse() { IsSuccess = false });
        }
    }
}
