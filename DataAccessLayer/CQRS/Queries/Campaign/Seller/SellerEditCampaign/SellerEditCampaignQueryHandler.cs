using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerEditCampaignQueryHandler : IRequestHandler<SellerEditCampaignQueryRequest, SellerEditCampaignQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerEditCampaignQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerEditCampaignQueryResponse> Handle(SellerEditCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new SellerEditCampaignQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerEditCampaignQueryResponse() 
                {
                    IsSuccess = true,
                    CampaignId = campaign.CampaignId,
                    Name = campaign.Name,
                    Description = campaign.Description,
                    Code = campaign.Code,
                    CampaignImage = campaign.CampaignImage,
                    IsApproved = campaign.IsApproved
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerEditCampaignQueryResponse() { IsSuccess = false });
        }
    }
}
