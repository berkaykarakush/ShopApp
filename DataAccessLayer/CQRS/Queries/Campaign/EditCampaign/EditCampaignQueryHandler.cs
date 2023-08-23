using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCampaignQueryHandler : IRequestHandler<EditCampaignQueryRequest, EditCampaignQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCampaignQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditCampaignQueryResponse> Handle(EditCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            EditCampaignQueryResponse response = new EditCampaignQueryResponse();
            try
            {
                var campign = _unitOfWork.Campaigns.GetById(request.CampaignId);
                response.CampaignId = campign.CampaignId;
                response.Name = campign.Name;
                response.Description = campign.Description;
                response.Code = campign.Code;
                response.IsHome = campign.IsHome;
                response.CreatedDate = campign.CreatedDate;
                response.UpdatedDate = campign.UpdatedDate;
                response.CampaignImage = campign.CampaignImage;
                response.ImageUrls = campign.ImageUrls;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return response;
        }
    }
}
