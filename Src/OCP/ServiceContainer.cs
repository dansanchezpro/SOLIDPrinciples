using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace OCP
{
    static class ServiceContainer
    {
        static IServiceProvider ServiceProvider;
        public static void ConfigureServices(
            Action<IServiceCollection> configureServices)
        {
            IServiceCollection Services = new ServiceCollection();
            configureServices(Services);
            ServiceProvider = Services.BuildServiceProvider();
        }

        public static T GetService<T>() => ServiceProvider.GetService<T>();

        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
