using Carontinho.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Carontinho
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Services
                .GetRequiredService<Startup>()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<Startup>();
                services.AddSingleton<IReader, Reader>();
            });
    }
}
