using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = new Brand()
                {
                    Name = request.Name,
                    Url = request.Url,
                    Products = _unitOfWork.Products.GetAll(),
                    CreatedDate = DateTime.Now.ToString(),
                };

                if (brand == null)
                    return Task.FromResult(new CreateBrandCommandResponse() { IsSuccess = false });

                _unitOfWork.Brands.Create(brand);
                _unitOfWork.Save();
                return Task.FromResult(new CreateBrandCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new CreateBrandCommandResponse() { IsSuccess = false });
        }
    }
}
