namespace DataAccessLayer.CQRS.Queries
{
    public class LoginQueryResponse
    {
        public string? ReturnUrl { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}