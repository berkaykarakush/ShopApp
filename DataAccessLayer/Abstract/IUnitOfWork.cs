namespace DataAccessLayer.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        ICartRepository Carts { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ICampaignRepository Campaigns { get; }
        IBrandRepository Brands { get; }
        ICommentRepository Comments { get; }
        void Save();
    }
}
