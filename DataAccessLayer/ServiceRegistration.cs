using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
            serviceCollection.AddScoped<IProductRepository, EFCoreProductRepository>();
            serviceCollection.AddScoped<IOrderRepository, EFCoreOrderRepository>();
            serviceCollection.AddScoped<ICartRepository, EFCoreCartRepository>();
        }
    }
}
