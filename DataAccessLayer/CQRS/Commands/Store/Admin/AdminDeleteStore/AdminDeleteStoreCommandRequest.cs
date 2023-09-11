using MediatR;

namespace DataAccessLayer.CQRS.Commands 
{
    public class AdminDeleteStoreCommandRequest : IRequest<AdminDeleteStoreCommandResponse>
    {
        public double StoreId { get; set; }
    }
}