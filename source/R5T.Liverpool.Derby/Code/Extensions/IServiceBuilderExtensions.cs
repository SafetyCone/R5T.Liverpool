using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Derby;
using R5T.Richmond;

using R5T.Liverpool.Startup;


namespace R5T.Liverpool.Derby
{
    public static class IServiceBuilderExtensions
    {
        public static TService UseStartupAndBuildWithDerbyConfiguration<TService, TStartup>(this IServiceBuilder<TService> serviceBuilder)
            where TStartup: class, IStartup
        {
            ServiceProvider GetConfigurationConfigurationServiceProvider()
            {
                var configurationConfigurationServiceProvider = ServiceProviderServiceBuilder.New()
                    .UseStartupAndBuild<ApplicationConfigurationConfigurationStartup>()
                    ;

                return configurationConfigurationServiceProvider;
            }

            ServiceProvider GetConfigurationServiceProvider()
            {
                var configurationServiceProvider = ServiceProviderServiceBuilder.New()
                    .UseStartupAndBuild<ApplicationConfigurationStartup>(GetConfigurationConfigurationServiceProvider)
                    ;

                return configurationServiceProvider;
            }

            TService GetService()
            {
                var service = serviceBuilder.UseStartupAndBuild<TService, TStartup>(GetConfigurationServiceProvider);
                return service;
            }

            var output = GetService();
            return output;
        }
    }
}
