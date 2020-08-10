using System;
using System.Threading.Tasks;

using R5T.Coventry;


namespace R5T.Liverpool.ProgramAsService
{
    public static class IProgramAsServiceExtensions
    {
        public static async Task RunAsync<TProgram, TStartup>(this IProgramAsService programAsService)
            where TProgram: AsynchronousProgramAsServiceBase
            where TStartup: StartupBase
        {
            var configurationConfigurationServiceProvider = ServiceProviderServiceBuilder.New().UseStartupAndBuild<DefaultStartupConfigurationConfiguration>();
            var configurationServiceProvider = ServiceProviderServiceBuilder.New().UseStartupAndBuild<DefaultStartupConfiguration>(configurationConfigurationServiceProvider);

            await ProgramAsService.RunAsync<TProgram, TStartup>(configurationServiceProvider);
        }
    }
}
