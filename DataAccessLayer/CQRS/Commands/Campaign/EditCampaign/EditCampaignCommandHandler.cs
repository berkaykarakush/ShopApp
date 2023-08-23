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

        public async Task<EditCampaignCommandResponse> Handle(EditCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);
                campaign.Name = request.Name;
                campaign.IsHome = request.IsHome;
                campaign.Code = request.Code;
                campaign.Description = request.Description;
                campaign.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                campaign.CampaignImage = request.CampaignImage;
                campaign.ImageUrls = request.ImageUrls;

                _unitOfWork.Campaigns.Update(campaign);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return new EditCampaignCommandResponse() { IsSuccess = true};
        }
    }
}
