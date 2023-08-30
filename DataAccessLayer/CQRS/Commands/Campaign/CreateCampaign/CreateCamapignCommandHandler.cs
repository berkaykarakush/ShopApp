using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCamapignCommandHandler : IRequestHandler<CreateCamapignCommandRequest, CreateCamapignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCamapignCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCamapignCommandResponse> Handle(CreateCamapignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.Campaigns.Create(new EntityLayer.Campaign
                {
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    CampaignImage = request.CampaignImage,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    //ImageUrls = request.ImageUrls,
                    IsHome = request.IsHome
                });
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return new CreateCamapignCommandResponse() {IsSuccess = true };

        }
    }
}
