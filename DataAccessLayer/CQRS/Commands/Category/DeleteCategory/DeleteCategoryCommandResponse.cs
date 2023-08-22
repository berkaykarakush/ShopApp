namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCategoryCommandResponse
    {
        public string Name { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}