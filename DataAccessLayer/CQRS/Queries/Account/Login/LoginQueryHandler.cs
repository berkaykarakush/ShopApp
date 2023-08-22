using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            return new LoginQueryResponse()
            {
                    ReturnUrl = request.ReturnUrl,
                    IsSuccess = true,
            };
        }
    }
}
