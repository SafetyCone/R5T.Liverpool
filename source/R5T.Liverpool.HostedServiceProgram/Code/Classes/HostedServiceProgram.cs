using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.Dacia;
using R5T.Richmond;


namespace R5T.Liverpool
{
    public static class HostedServiceProgram
    {
        public static Task RunAsync<THostedServiceProgram, TStartup>()
            where THostedServiceProgram : class, IHostedService
            where TStartup : class, IStartup
        {
            var configurationServiceProvider = ServiceProviderHelper.EmptyServiceProvider.Value;

            var task = HostedServiceProgram.RunAsync<THostedServiceProgram, TStartup>(configurationServiceProvider);
            return task;
        }

        public static Task RunAsync<THostedServiceProgram, TStartup>(IServiceProvider configurationServiceProvider)
            where THostedServiceProgram : class, IHostedService
            where TStartup : class, IStartup
        {
            var task = HostServiceBuilder.New()
                .UseStartup<TStartup>()
                .UseHostedServiceProgram<THostedServiceProgram>()
                .Build(configurationServiceProvider)
                .RunAsync()
                ;

            return task;
        }

        public static void Run<THostedServiceProgram, TStartup>()
            where THostedServiceProgram : class, IHostedService
            where TStartup : class, IStartup
        {
            var configurationServiceProvider = ServiceProviderHelper.EmptyServiceProvider.Value;

            HostedServiceProgram.Run<THostedServiceProgram, TStartup>(configurationServiceProvider);
        }

        public static void Run<THostedServiceProgram, TStartup>(IServiceProvider configurationServiceProvider)
            where THostedServiceProgram: class, IHostedService
            where TStartup: class, IStartup
        {
            HostServiceBuilder.New()
                .UseStartup<TStartup>()
                .UseHostedServiceProgram<THostedServiceProgram>()
                .Build(configurationServiceProvider)
                .Run()
                ;
        }

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

        public static void RunAsync<THostedServiceProgram>(string[] args)
            where THostedServiceProgram : AsyncHostedServiceProgramBase
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
