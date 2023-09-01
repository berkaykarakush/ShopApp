using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommandRequest, DeleteCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCampaignCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<DeleteCampaignCommandResponse> Handle(DeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campaign == null)
                    return Task.FromResult(new DeleteCampaignCommandResponse() { IsSuccess = false});

                _unitOfWork.Campaigns.Delete(campaign);
                _unitOfWork.Save();

                return Task.FromResult(new DeleteCampaignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
