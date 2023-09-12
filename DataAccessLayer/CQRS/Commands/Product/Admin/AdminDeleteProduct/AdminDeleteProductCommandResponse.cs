namespace DataAccessLayer.CQRS.Commands
{
    public class AdminDeleteProductCommandResponse
    {
        public string? Name { get; set; }
        public bool IsSuccess { get; set; }
    }
}