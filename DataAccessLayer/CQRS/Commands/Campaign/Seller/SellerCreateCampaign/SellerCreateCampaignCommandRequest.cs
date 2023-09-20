using EntityLayer;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerCreateCampaignCommandRequest: IRequest<SellerCreateCampaignCommandResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public int DiscountPercentage { get; set; }
        public string? CampaignImage { get; set; }
    }
}