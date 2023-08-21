using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class LoginQueryRequest: IRequest<LoginQueryResponse>
    {
        public string? ReturnUrl { get; set; }
    }
}