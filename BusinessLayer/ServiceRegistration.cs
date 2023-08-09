using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IOrderService, OrderManager>();
            serviceCollection.AddScoped<ICartService, CartManager>();
        }
    }
}
