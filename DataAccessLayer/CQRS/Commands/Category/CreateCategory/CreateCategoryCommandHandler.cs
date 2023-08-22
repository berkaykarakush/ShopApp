using DataAccessLayer.Abstract;
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

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.Categories.Create(new EntityLayer.Category() 
                {
                    Name = request.Name,
                    Url = request.Url,
                });
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new CreateCategoryCommandResponse(){ IsSuccess = true };
            
        }
    }
}
