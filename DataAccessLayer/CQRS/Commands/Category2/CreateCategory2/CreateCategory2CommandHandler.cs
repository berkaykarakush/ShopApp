using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCategory2CommandHandler : IRequestHandler<CreateCategory2CommandRequest, CreateCategory2CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategory2CommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CreateCategory2CommandResponse> Handle(CreateCategory2CommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _unitOfWork.Categories.GetById(request.CategoryId);

                if (category == null) 
                    return Task.FromResult(new CreateCategory2CommandResponse() { IsSuccess = false });

                var category2 = new Category2()
                {
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    Name = request.Name,
                    Url = request.Url,
                    Category = category,
                    CategoryId = category.CategoryId
                };

                _unitOfWork.Categories2.Create(category2);
                _unitOfWork.Save();
                return Task.FromResult(new CreateCategory2CommandResponse() { IsSuccess = true });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new CreateCategory2CommandResponse() { IsSuccess = false });
        }
    }
}
