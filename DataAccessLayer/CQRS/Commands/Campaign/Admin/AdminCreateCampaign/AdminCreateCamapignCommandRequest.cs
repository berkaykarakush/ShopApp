using EntityLayer;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminCreateCamapignCommandRequest: IRequest<AdminCreateCamapignCommandResponse>
    {
        public string? Name { get; set; }
        public int DiscountPercentage { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool IsApproved { get; set; }
        public string? CampaignImage { get; set; }
    }
}