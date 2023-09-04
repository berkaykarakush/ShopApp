using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries  
{
    public class SellerRegisterQueryHandler : IRequestHandler<SellerRegisterQueryRequest, SellerRegisterQueryResponse>
    {
        public Task<SellerRegisterQueryResponse> Handle(SellerRegisterQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(new SellerRegisterQueryResponse()
                {
                    SellerId = request.SellerId,
                    SellerFirstName = request.SellerFirstName,
                    SellerLastName = request.SellerLastName,
                    SellerEmail = request.SellerEmail,
                    SellerPhone = request.SellerPhone,
                    IsSuccess = true
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerRegisterQueryResponse() { IsSuccess = false });
        }
    }
}
