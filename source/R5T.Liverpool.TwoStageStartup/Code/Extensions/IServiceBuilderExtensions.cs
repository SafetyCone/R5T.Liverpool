using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Liverpool.Startup;
using R5T.Richmond;


namespace R5T.Liverpool.TwoStageStartup
{
    public static class IServiceBuilderExtensions
    {
        public static TService UseStartupAndBuild<TService, TStartup, TConfigurationStartup>(this IServiceBuilder<TService> serviceBuilder, IServiceProvider configurationConfigurationServiceProvider)
            where TStartup: class, IStartup
            where TConfigurationStartup: class, IStartup
        {
            // Get the configuration service provider.
            var configurationServiceProvider = ServiceProviderServiceBuilder.New()
                .UseStartupAndBuild<ServiceProvider, TConfigurationStartup>(configurationConfigurationServiceProvider)
                ;

            // Use the configuration service provider.
            var service = serviceBuilder.UseStartupAndBuild<TService, TStartup>(configurationServiceProvider);
            return service;
        }

        public static TService UseStartupAndBuild<TService, TStartup, TConfigurationStartup>(this IServiceBuilder<TService> serviceBuilder, Func<IServiceProvider> configurationConfigurationServiceProviderConstructor)
            where TStartup : class, IStartup
            where TConfigurationStartup : class, IStartup
        {
            // Get the configuration configuration service provider.
            var configurationConfigurationServiceProvider = configurationConfigurationServiceProviderConstructor();

            // Use the configuration configuration service provider.
            var service = serviceBuilder.UseStartupAndBuild<TService, TStartup, TConfigurationStartup>(configurationConfigurationServiceProvider);
            return service;
        }

        public static TService UseStartupAndBuild<TService, TStartup, TConfigurationStartup>(this IServiceBuilder<TService> serviceBuilder)
            where TStartup : class, IStartup
            where TConfigurationStartup : class, IStartup
        {
            var service = serviceBuilder.UseStartupAndBuild<TService, TStartup, TConfigurationStartup>(ServiceProviderHelper.GetNewEmptyServiceProvider);
            return service;
        }
    }
}
