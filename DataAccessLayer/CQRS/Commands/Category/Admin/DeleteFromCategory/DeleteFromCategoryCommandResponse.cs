namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteFromCategoryCommandResponse
    {
        public double categoryId { get; set; }
        public bool IsSuccess { get; set; }     
    }
}