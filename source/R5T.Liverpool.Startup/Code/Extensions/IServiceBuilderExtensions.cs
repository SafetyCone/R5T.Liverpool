using System;

using R5T.Dacia;
using R5T.Exeter;
using R5T.Richmond;

using R5T.Liverpool.Startup.Core;


namespace R5T.Liverpool.Startup
{
    public static class IServiceBuilderExtensions
    {
        public static TStartup GetStartupInstance<TStartup>(this IServiceBuilder serviceBuilder)
            where TStartup : class, IStartup
        {
            var startup = ServiceProviderHelper.New().GetInstance<TStartup>();
            return startup;
        }

        public static IServiceBuilder UseStartup<TStartup>(this IServiceBuilder serviceBuilder)
            where TStartup: class, IStartup
        {
            var startup = serviceBuilder.GetStartupInstance<TStartup>();

            serviceBuilder.UseStartup(startup);

            return serviceBuilder;
        }

        public static TService UseStartupAndBuild<TService, TStartup>(this IServiceBuilder<TService> serviceBuilder, IServiceProvider configurationServiceProvider)
            where TStartup : class, IStartup
        {
            serviceBuilder.UseStartup<TStartup>(); // Bind to the startup class.

            // Now build the service using the provided 
            var service = serviceBuilder.Build(configurationServiceProvider);
            return service;
        }

        public static TService UseStartupAndBuild<TService, TStartup>(this IServiceBuilder<TService> serviceBuilder, Func<IServiceProvider> configurationServiceProviderConstructor)
            where TStartup : class, IStartup
        {
            var configurationServiceProvider = configurationServiceProviderConstructor();

            var service = serviceBuilder.UseStartupAndBuild<TService, TStartup>(configurationServiceProvider);
            return service;
        }

        public static TService UseStartupAndBuild<TService, TStartup>(this IServiceBuilder<TService> serviceBuilder)
            where TStartup : class, IStartup
        {
            var service = serviceBuilder.UseStartupAndBuild<TService, TStartup>(ServiceProviderHelper.EmptyServiceProvider.Value);
            return service;
        }
    }
}
