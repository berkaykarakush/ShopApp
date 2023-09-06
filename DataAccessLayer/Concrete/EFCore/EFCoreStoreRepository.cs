﻿using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreStoreRepository : EFCoreGenericRepository<Store>, IStoreRepository
    {
        public EFCoreStoreRepository(ShopContext context) : base(context)
        {
        }

        private ShopContext ShopContext { get { return _context as ShopContext; } }
        public Store GetByIdWithImageUrls(double id)
        {
            return ShopContext.Stores
                            .Where(s => s.StoreId == id)
                            .Include(s => s.ImageUrls)
                            .FirstOrDefault();
        }
    }
}