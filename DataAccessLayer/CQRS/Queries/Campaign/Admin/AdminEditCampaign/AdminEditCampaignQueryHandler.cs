using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditCampaignQueryHandler : IRequestHandler<AdminEditCampaignQueryRequest, AdminEditCampaignQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditCampaignQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditCampaignQueryResponse> Handle(AdminEditCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campign == null)
                    return Task.FromResult(new AdminEditCampaignQueryResponse() { IsSuccess = false});


                return Task.FromResult(new AdminEditCampaignQueryResponse() 
                {
                    CampaignId = campign.CampaignId,
                    Name = campign.Name,
                    Description = campign.Description,
                    Code = campign.Code,
                    CampaignImage = campign.CampaignImage,
                    IsApproved = campign.IsApproved,
                    IsSuccess = true
                });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminEditCampaignQueryResponse() { IsSuccess = false});
        }
    }
}
