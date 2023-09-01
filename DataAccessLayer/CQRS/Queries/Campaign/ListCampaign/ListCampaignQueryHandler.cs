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

        public Task<ListCampaignQueryResponse> Handle(ListCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
               var allCampaings = _unitOfWork.Campaigns.GetAll();

                if (allCampaings == null)
                    return Task.FromResult(new ListCampaignQueryResponse() { IsSuccess = false});

                return Task.FromResult(new ListCampaignQueryResponse() { IsSuccess = true, Campaigns = allCampaings});

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ListCampaignQueryResponse() { IsSuccess = false });
        }
    }
}
