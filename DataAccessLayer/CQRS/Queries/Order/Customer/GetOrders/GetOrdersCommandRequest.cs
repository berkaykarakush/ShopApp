using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class GetOrdersCommandRequest: IRequest<GetOrdersCommandResponse>
    {
        public string UserId { get; set; }
    }
}