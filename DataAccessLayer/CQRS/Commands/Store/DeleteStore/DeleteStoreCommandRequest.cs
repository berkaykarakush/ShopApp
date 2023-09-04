using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteStoreCommandRequest: IRequest<DeleteStoreCommandResponse>
    {
        public double StoreId { get; set; }
    }
}