using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return new LoginQueryResponse()
                {
                     ReturnUrl = request.ReturnUrl,
                     IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new LoginQueryResponse()
                {
                    IsSuccess = false
                };
            }
        }
    }
}
