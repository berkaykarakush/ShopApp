using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCartRepository : EFCoreGenericRepository<Cart, ShopContext>, ICartRepository
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new ShopContext())
            {
                return context.Carts
                    .Include(c => c.CartItems)
                    .ThenInclude(c => c.Product)
                    .FirstOrDefault(c => c.UserId == userId);
            }
        }

        public override void Update(Cart entity)
        {
            using (var context = new ShopContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
