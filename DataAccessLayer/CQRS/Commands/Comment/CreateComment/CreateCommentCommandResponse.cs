namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCommentCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string? Url { get; set; }
    }
}