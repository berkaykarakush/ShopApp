namespace DataAccessLayer.CQRS.Commands
{
    public class AddToCartCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string? Url { get; set; }
    }
}