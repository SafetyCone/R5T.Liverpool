using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Richmond;

using R5T.Liverpool.Startup;


namespace R5T.Liverpool.ProgramAsService
{
    public class ProgramAsService : IProgramAsService
    {
        #region Static

        public static IProgramAsService New()
        {
            var programAsServiceInstance = new ProgramAsService();
            return programAsServiceInstance;
        }

        public static void Run<TProgramAsService, TStartup>(IServiceProvider configurationServiceProvider)
            where TProgramAsService: ProgramAsServiceBase
            where TStartup: class, IStartup
        {
            var serviceProvider = ServiceProviderServiceBuilder.New()
                .AddProgramAsService<ServiceProvider, TProgramAsService>()
                .UseStartup<ServiceProvider, TStartup>()
                .Build(configurationServiceProvider);

            using (serviceProvider)
            {
                var program = serviceProvider.GetRequiredService<TProgramAsService>();

                program.SubMain();
            }
        }

        public static void Run<TProgramAsService, TStartup>()
            where TProgramAsService : ProgramAsServiceBase
            where TStartup : class, IStartup
        {
            var configurationServiceProvider = ServiceProviderHelper.EmptyServiceProvider.Value;

            ProgramAsService.Run<TProgramAsService, TStartup>(configurationServiceProvider);
        }

        public static async Task RunAsync<TAsynchronousProgramAsService, TStartup>(IServiceProvider configurationServiceProvider)
            where TAsynchronousProgramAsService : AsynchronousProgramAsServiceBase
            where TStartup : class, IStartup
        {
            var serviceProvider = ServiceProviderServiceBuilder.New()
                .AddAsynchronousProgramAsService<ServiceProvider, TAsynchronousProgramAsService>()
                .UseStartup<ServiceProvider, TStartup>()
                .Build(configurationServiceProvider);

            using (serviceProvider)
            {
                var program = serviceProvider.GetRequiredService<TAsynchronousProgramAsService>();

                await program.SubMainAsync();
            }
        }

        public static Task RunAsync<TAsynchronousProgramAsService, TStartup>()
            where TAsynchronousProgramAsService : AsynchronousProgramAsServiceBase
            where TStartup : class, IStartup
        {
            var configurationServiceProvider = ServiceProviderHelper.EmptyServiceProvider.Value;

            var task = ProgramAsService.RunAsync<TAsynchronousProgramAsService, TStartup>(configurationServiceProvider);
            return task;
        }

        #endregion
    }
}
