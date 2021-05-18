using System;
using System.Threading.Tasks;

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
            var configurationServiceProvider = ServiceProviderHelper.GetNewEmptyServiceProvider();

            var task = HostedServiceProgram.RunAsync<THostedServiceProgram, TStartup>(configurationServiceProvider);
            return task;
        }

        public static Task RunAsync<THostedServiceProgram, TStartup>(IServiceProvider configurationServiceProvider)
            where THostedServiceProgram : class, IHostedService
            where TStartup : class, IStartup
        {
            var host = HostServiceBuilder.New()
                .UseHostedServiceProgram<THostedServiceProgram>()
                .UseStartup<TStartup>()
                .Build(configurationServiceProvider)
                ;

            var task = host.RunAsync();
            return task;
        }

        public static void Run<THostedServiceProgram, TStartup>()
            where THostedServiceProgram : class, IHostedService
            where TStartup : class, IStartup
        {
            var configurationServiceProvider = ServiceProviderHelper.GetNewEmptyServiceProvider();

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

        public static void Run<THostedServiceProgram>()
            where THostedServiceProgram: HostedServiceProgramBase
        {
            var emptyServiceProvider = ServiceProviderHelper.GetNewEmptyServiceProvider();

            var host = HostServiceBuilder.New()
                .UseHostedServiceProgram<THostedServiceProgram>()
                .Build(emptyServiceProvider)
                ;

            host.Run();
        }

        public static Task RunAsync<THostedServiceProgram>()
            where THostedServiceProgram : AsyncHostedServiceProgramBase
        {
            var emptyServiceProvider = ServiceProviderHelper.GetNewEmptyServiceProvider();

            var host = HostServiceBuilder.New()
                .UseHostedServiceProgram<THostedServiceProgram>()
                .Build(emptyServiceProvider)
                ;

            var task  = host.RunAsync();
            return task;
        }
    }
}
