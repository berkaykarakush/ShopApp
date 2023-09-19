using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDeleteCampaignCommandHandler : IRequestHandler<SellerDeleteCampaignCommandRequest, SellerDeleteCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerDeleteCampaignCommandHandler(IUnitOfWork unitOfWork)
            =>    _unitOfWork = unitOfWork;

        public Task<SellerDeleteCampaignCommandResponse> Handle(SellerDeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new SellerDeleteCampaignCommandResponse() { IsSuccess = false });

                _unitOfWork.Campaigns.Delete(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new SellerDeleteCampaignCommandResponse() { IsSuccess = true });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerDeleteCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
