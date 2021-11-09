using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;

using SmallsOnline.IntuneLAPS.AzFunctions.Services;

namespace SmallsOnline.IntuneLAPS.AzFunctions
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(
                    (service) =>
                    {
                        service.AddSingleton<IKeyVaultService, KeyVaultService>();
                    }
                )
                .Build();

            host.Run();
        }
    }
}