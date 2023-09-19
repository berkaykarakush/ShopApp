using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminDeleteCampaignCommandHandler : IRequestHandler<AdminDeleteCampaignCommandRequest, AdminDeleteCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminDeleteCampaignCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<AdminDeleteCampaignCommandResponse> Handle(AdminDeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new AdminDeleteCampaignCommandResponse() { IsSuccess = false});

                _unitOfWork.Campaigns.Delete(campaign);
                _unitOfWork.Save();

                return Task.FromResult(new AdminDeleteCampaignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminDeleteCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
