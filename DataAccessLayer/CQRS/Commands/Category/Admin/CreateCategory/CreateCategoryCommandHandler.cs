using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var category = new Category()
                {
                    Name = request.Name,
                    Url = request.Url,
                };

                if (category == null)
                    return Task.FromResult(new CreateCategoryCommandResponse() { IsSuccess = false});

                _unitOfWork.Categories.Create(category);
                _unitOfWork.Save();
                return Task.FromResult(new CreateCategoryCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return Task.FromResult(new CreateCategoryCommandResponse() { IsSuccess = false });
            
        }
    }
}
