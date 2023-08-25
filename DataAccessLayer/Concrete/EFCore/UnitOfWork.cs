using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;

        public UnitOfWork(ShopContext context)
        {
            _context = context;
        }
        private EFCoreCartRepository _cartRepository;
        private EFCoreCategoryRepository _categoryRepository;
        private EFCoreOrderRepository _orderRepository;
        private EFCoreProductRepository _productRepository;
        private EFCoreCampaignRepository _campaignRepository;
        private EFCoreBrandRepository _brandRepository;
        public ICartRepository Carts => _cartRepository = _cartRepository ?? new EFCoreCartRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EFCoreCategoryRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new EFCoreOrderRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new EFCoreProductRepository(_context);

        public ICampaignRepository Campaigns => _campaignRepository = _campaignRepository ?? new EFCoreCampaignRepository(_context);
        public IBrandRepository Brands => _brandRepository = _brandRepository ?? new EFCoreBrandRepository(_context);
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
