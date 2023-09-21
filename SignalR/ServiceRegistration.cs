using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Hubs;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using SignalR.HubServices;

namespace SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IChatHubService, ChatHubService>();
            serviceCollection.AddSignalR();
        }
    }
}
