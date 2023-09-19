using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerEditCampaignCommandHandler : IRequestHandler<SellerEditCampaignCommandRequest, SellerEditCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerEditCampaignCommandHandler(IUnitOfWork unitOfWork)
            =>  _unitOfWork = unitOfWork;

        public Task<SellerEditCampaignCommandResponse> Handle(SellerEditCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new SellerEditCampaignCommandResponse() { IsSuccess = false });

                campaign.Name = request.Name;
                campaign.Code = request.Code;
                campaign.Description = request.Description;
                campaign.CampaignImage = request.CampaignImage;
                campaign.UpdatedDate = DateTime.Now;

                _unitOfWork.Campaigns.Update(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new SellerEditCampaignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerEditCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
