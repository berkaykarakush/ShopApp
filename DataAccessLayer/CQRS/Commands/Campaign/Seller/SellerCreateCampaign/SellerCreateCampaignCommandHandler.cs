using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerCreateCampaignCommandHandler : IRequestHandler<SellerCreateCampaignCommandRequest, SellerCreateCampaignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerCreateCampaignCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerCreateCampaignCommandResponse> Handle(SellerCreateCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = new Campaign() 
                {
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    CampaignImage = request.CampaignImage
                };

                if (campaign == null)
                    return Task.FromResult(new SellerCreateCampaignCommandResponse() { IsSuccess = false });

                _unitOfWork.Campaigns.Create(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new SellerCreateCampaignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerCreateCampaignCommandResponse() { IsSuccess = false });
        }
    }
}
