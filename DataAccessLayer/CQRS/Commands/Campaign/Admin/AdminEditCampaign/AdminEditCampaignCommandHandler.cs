using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminEditCampaignCommandHandler : IRequestHandler<AdminEditCampaignCommandRequest, AdminEditCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditCampaignCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditCampaignCommandResponse> Handle(AdminEditCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new AdminEditCampaignCommandResponse() { IsSuccess = false});

                campaign.Name = request.Name;
                campaign.Code = request.Code;
                campaign.Description = request.Description;
                campaign.UpdatedDate = DateTime.Now;
                campaign.CampaignImage = request.CampaignImage;
                campaign.IsApproved = request.IsApproved;

                _unitOfWork.Campaigns.Update(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new AdminEditCampaignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminEditCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
