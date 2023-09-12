using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminCreateProductQueryHandler : IRequestHandler<AdminCreateProductQueryRequest, AdminCreateProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminCreateProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminCreateProductQueryResponse> Handle(AdminCreateProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = _unitOfWork.Categories.GetAll();
                var categories2 = _unitOfWork.Categories2.GetAll();
                var brands = _unitOfWork.Brands.GetAll();

                if (categories == null && brands == null)
                    return Task.FromResult(new AdminCreateProductQueryResponse() { IsSuccess = false});

                return Task.FromResult(new AdminCreateProductQueryResponse() { Categories = categories, Categories2 = categories2, Brands = brands, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminCreateProductQueryResponse() { IsSuccess  = false});
        }
    }
}
