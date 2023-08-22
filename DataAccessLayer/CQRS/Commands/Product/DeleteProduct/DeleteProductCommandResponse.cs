namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteProductCommandResponse
    {
        public string Name { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}