using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCampaignQueryHandler : IRequestHandler<ListCampaignQueryRequest, ListCampaignQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListCampaignQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ListCampaignQueryResponse> Handle(ListCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            List<Campaign> allCampaings = new List<Campaign>();
            try
            {
                allCampaings = _unitOfWork.Campaigns.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return new ListCampaignQueryResponse() { Campaigns = allCampaings, IsSuccess = true };
        }
    }
}
