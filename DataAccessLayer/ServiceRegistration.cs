using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using DataAccessLayer.CQRS.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ShopContext>(options => options.UseSqlServer(Configuration._configuration.GetSection("ConnectionStrings:MsSQLConnection").Value));

            //serviceCollection.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
            //serviceCollection.AddScoped<IProductRepository, EFCoreProductRepository>();
            //serviceCollection.AddScoped<IOrderRepository, EFCoreOrderRepository>();
            //serviceCollection.AddScoped<ICartRepository, EFCoreCartRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<CreateProductCommandHandler>();
        }
    }
}
