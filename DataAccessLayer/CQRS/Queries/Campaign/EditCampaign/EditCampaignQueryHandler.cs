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

        public Task<EditCampaignQueryResponse> Handle(EditCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campign = _unitOfWork.Campaigns.GetById(request.CampaignId);

                if (campign == null)
                    return Task.FromResult(new EditCampaignQueryResponse() { IsSuccess = false});


                return Task.FromResult(new EditCampaignQueryResponse() 
                {
                    CampaignId = campign.CampaignId,
                    Name = campign.Name,
                    Description = campign.Description,
                    Code = campign.Code,
                    IsHome = campign.IsHome,
                    CreatedDate = campign.CreatedDate,
                    UpdatedDate = campign.UpdatedDate,
                    CampaignImage = campign.CampaignImage,
                    //ImageUrls = campign.ImageUrls,
                    IsSuccess = true
                });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new EditCampaignQueryResponse() { IsSuccess = false});
        }
    }
}
