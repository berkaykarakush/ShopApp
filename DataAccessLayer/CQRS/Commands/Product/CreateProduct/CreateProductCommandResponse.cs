namespace DataAccessLayer.CQRS.Commands
{
    public class CreateProductCommandResponse
    {
        public double ProductId { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}
