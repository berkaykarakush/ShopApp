using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        public Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new LoginQueryResponse() { ReturnUrl = request.ReturnUrl });
        }
    }
}
