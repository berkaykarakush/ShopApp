using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteBrandCommandRequest: IRequest<DeleteBrandCommandResponse>
    {
        public double BrandId { get; set; }
    }
}