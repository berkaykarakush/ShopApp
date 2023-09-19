using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListCampaignQueryHandler : IRequestHandler<SellerListCampaignQueryRequest, SellerListCampaignQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerListCampaignQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerListCampaignQueryResponse> Handle(SellerListCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaigns = _unitOfWork.Campaigns.GetAll();

                if (campaigns == null)
                    return Task.FromResult(new SellerListCampaignQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerListCampaignQueryResponse() { IsSuccess = true, Campaigns = campaigns });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new SellerListCampaignQueryResponse() { IsSuccess = false });
        }
    }
}
