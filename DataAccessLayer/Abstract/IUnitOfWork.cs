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
        ICategory2Repository Categories2 { get; }
        IStoreRepository Stores { get; }
        void Save();
    }
}
