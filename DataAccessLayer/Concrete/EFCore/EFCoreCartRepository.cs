using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCartRepository : EFCoreGenericRepository<Cart>, ICartRepository
    {
        public EFCoreCartRepository(ShopContext context) : base(context)
        {

        }
        private ShopContext ShopContext
        {
            get { return _context as ShopContext; }
        }
        public void ClearCart(double cartId)
        {
            var cmd = @"delete from CartItems where CartId=@p0";
            ShopContext.Database.ExecuteSqlRaw(cmd, cartId);
        }

        public void DeleteFromCart(double cartId, double productId)
        {
            var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, cartId, productId);
        }

        public Cart GetByUserId(string userId)
        {
            return ShopContext.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .FirstOrDefault(c => c.UserId == userId);
        }

        public override void Update(Cart entity)
        {
            ShopContext.Carts.Update(entity);
        }
    }
}
