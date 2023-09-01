using DataAccessLayer.Abstract;
using MediatR;
using Microsoft.Identity.Client;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListBrandQueryHandler : IRequestHandler<ListBrandQueryRequest, ListBrandQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListBrandQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ListBrandQueryResponse> Handle(ListBrandQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brands = _unitOfWork.Brands.GetAll();

                if (brands == null)
                    return Task.FromResult(new ListBrandQueryResponse() { IsSuccess = false});

                return Task.FromResult(new ListBrandQueryResponse() { IsSuccess = true, Brands = brands });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new ListBrandQueryResponse() { IsSuccess = false });
        }
    }
}
