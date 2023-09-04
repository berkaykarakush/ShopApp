namespace DataAccessLayer.CQRS.Commands
{
    public class EditStoreCommandResponse
    {
        public bool IsSuccess { get; set; }
        public double StoreId { get; set; }
    }
}