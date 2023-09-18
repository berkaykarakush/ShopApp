using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCampaignCommandHandler : IRequestHandler<EditCampaignCommandRequest, EditCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCampaignCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EditCampaignCommandResponse> Handle(EditCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new EditCampaignCommandResponse() { IsSuccess = false});

                campaign.Name = request.Name;
                campaign.IsHome = request.IsHome;
                campaign.Code = request.Code;
                campaign.Description = request.Description;
                campaign.UpdatedDate = DateTime.Now;
                campaign.CampaignImage = request.CampaignImage;
                //campaign.ImageUrls = request.ImageUrls;

                _unitOfWork.Campaigns.Update(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new EditCampaignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new EditCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
