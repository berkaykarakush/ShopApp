using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListCampaignQueryHandler : IRequestHandler<AdminListCampaignQueryRequest, AdminListCampaignQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminListCampaignQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminListCampaignQueryResponse> Handle(AdminListCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
               var allCampaings = _unitOfWork.Campaigns.GetAll();

                if (allCampaings == null)
                    return Task.FromResult(new AdminListCampaignQueryResponse() { IsSuccess = false});

                return Task.FromResult(new AdminListCampaignQueryResponse() { IsSuccess = true, Campaigns = allCampaings});

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminListCampaignQueryResponse() { IsSuccess = false });
        }
    }
}
