using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IOrderService, OrderManager>();
        }
    }
}
