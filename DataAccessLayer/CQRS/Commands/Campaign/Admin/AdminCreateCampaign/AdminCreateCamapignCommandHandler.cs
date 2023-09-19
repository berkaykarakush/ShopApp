using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminCreateCamapignCommandHandler : IRequestHandler<AdminCreateCamapignCommandRequest, AdminCreateCamapignCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminCreateCamapignCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<AdminCreateCamapignCommandResponse> Handle(AdminCreateCamapignCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var campaign = new Campaign()
                {
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    CampaignImage = request.CampaignImage,
                    IsApproved = request.IsApproved
                };

                if (campaign == null)
                    return Task.FromResult(new AdminCreateCamapignCommandResponse() { IsSuccess = false });

                _unitOfWork.Campaigns.Create(campaign);
                _unitOfWork.Save();
                return Task.FromResult(new AdminCreateCamapignCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminCreateCamapignCommandResponse() { IsSuccess = false });

        }
    }
}
