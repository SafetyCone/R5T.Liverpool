using System;

using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Hosting;

using R5T.Dacia;

using R5T.Liverpool.Startup;


namespace R5T.Liverpool.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program.ServiceProviderExample();
            //Program.HostExample();
            //Program.WebHostExample();
            ProgramAsAService.Run<HostedServiceProgram>(args);
        }

        private static void WebHostExample()
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var host = WebHostServiceBuilder.New()
                .UseWebStartup<WebStartup>()
                .Build(emptyServiceProvider);

            host.Run();
        }

        private static void HostExample()
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var host = HostServiceBuilder.New()
                .UseStartup<Startup>()
                .Build(emptyServiceProvider);

            //host.Run(); // Runs host, but without a service to order host shutdown, no joy.
        }

        private static void ServiceProviderExample()
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var serviceProvider = ServiceProviderServiceBuilder.New()
                .UseStartup<Startup>()
                .Build(emptyServiceProvider);
        }
    }
}
