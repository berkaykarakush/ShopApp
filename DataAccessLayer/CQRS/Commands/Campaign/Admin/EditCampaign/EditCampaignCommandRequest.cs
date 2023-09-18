using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCampaignCommandRequest: IRequest<EditCampaignCommandResponse>
    {
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool IsHome { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CampaignImage { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
    }
}