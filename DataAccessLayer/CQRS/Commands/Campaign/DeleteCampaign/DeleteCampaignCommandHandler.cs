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

        public async Task<DeleteCampaignCommandResponse> Handle(DeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = _unitOfWork.Campaigns.GetById(request.CampaignId);
                _unitOfWork.Campaigns.Delete(campaign);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return new DeleteCampaignCommandResponse() { IsSuccess = true };
        }
    }
}
