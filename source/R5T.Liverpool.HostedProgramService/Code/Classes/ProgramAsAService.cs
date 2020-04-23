using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.Dacia;


namespace R5T.Liverpool
{
    public static class ProgramAsAService
    {
        public static void Run<THostedServiceProgram>(string[] args)
            where THostedServiceProgram: HostedServiceProgramBase
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var hostServiceBuilder = HostServiceBuilder.New();

            hostServiceBuilder
                .AddConfigureServices(services =>
                {
                    services.AddHostedService<THostedServiceProgram>();
                });

            var host = hostServiceBuilder
                .Build(emptyServiceProvider);

            host.Run();
        }
    }
}
