using DataAccessLayer.Abstract;
using EntityLayer;
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

        public  Task<CreateCamapignCommandResponse> Handle(CreateCamapignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = new Campaign()
                {
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    CampaignImage = request.CampaignImage,
                    //ImageUrls = request.ImageUrls,
                    IsHome = request.IsHome
                };

                if (campaign == null)
                    return Task.FromResult(new CreateCamapignCommandResponse() { IsSuccess = false });

                _unitOfWork.Campaigns.Create(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new CreateCamapignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new CreateCamapignCommandResponse() { IsSuccess = false });

        }
    }
}
