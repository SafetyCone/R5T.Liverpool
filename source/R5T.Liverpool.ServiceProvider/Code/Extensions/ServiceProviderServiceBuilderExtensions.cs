using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Richmond;


namespace R5T.Liverpool
{
    public static class ServiceProviderServiceBuilderExtensions
    {
        public static ServiceProviderServiceBuilder UseStartup<TStartup>(this ServiceProviderServiceBuilder serviceProviderServiceBuilder)
            where TStartup : class, IStartup
        {
            R5T.Liverpool.Startup.IServiceBuilderExtensions.UseStartup<TStartup>(serviceProviderServiceBuilder);

            return serviceProviderServiceBuilder;
        }

        public static ServiceProvider UseStartupAndBuild<TStartup>(this ServiceProviderServiceBuilder serviceProviderServiceBuilder, IServiceProvider configurationServiceProvider)
            where TStartup : class, IStartup
        {
            var serviceProvider = R5T.Liverpool.Startup.IServiceBuilderExtensions.UseStartupAndBuild<ServiceProvider, TStartup>(serviceProviderServiceBuilder, configurationServiceProvider);
            return serviceProvider;
        }

        public static ServiceProvider UseStartupAndBuild<TStartup>(this ServiceProviderServiceBuilder serviceProviderServiceBuilder, Func<IServiceProvider> configurationServiceProviderConstructor)
            where TStartup : class, IStartup
        {
            var serviceProvider = R5T.Liverpool.Startup.IServiceBuilderExtensions.UseStartupAndBuild<ServiceProvider, TStartup>(serviceProviderServiceBuilder, configurationServiceProviderConstructor);
            return serviceProvider;
        }

        public static ServiceProvider UseStartupAndBuild<TStartup>(this ServiceProviderServiceBuilder serviceProviderServiceBuilder)
            where TStartup : class, IStartup
        {
            var serviceProvider = serviceProviderServiceBuilder.UseStartupAndBuild<TStartup>(ServiceProviderHelper.GetNewEmptyServiceProvider());
            return serviceProvider;
        }
    }
}
