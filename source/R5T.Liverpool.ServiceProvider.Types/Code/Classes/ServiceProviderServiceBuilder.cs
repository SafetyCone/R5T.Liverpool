using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Chamavia;


namespace R5T.Liverpool
{
    public class ServiceProviderServiceBuilder : ServiceBuilderBase<ServiceProvider>
    {
        #region Static

        public static ServiceProviderServiceBuilder New()
        {
            var output = new ServiceProviderServiceBuilder();
            return output;
        }

        #endregion


        public override ServiceProvider Build(IServiceProvider configurationServiceProvider)
        {
            // Build the configuration using the services provided by input configuration service provider.
            var configurationBuilder = new ConfigurationBuilder();

            this.ConfigureConfigurationActions.ForEach(action => action(configurationBuilder, configurationServiceProvider));

            var configuration = configurationBuilder.Build();

            // Build the service provider by configuring all services, including addition of the configuration.
            var services = new ServiceCollection();

            services.AddConfiguration(configuration);

            this.ConfigureServicesActions.ForEach(action => action(services));

            var serviceProvider = services.BuildServiceProvider();

            // Configure actual service instances (singletons).
            this.ConfigureActions.ForEach(action => action(serviceProvider));

            // Return the service provider.
            return serviceProvider;
        }
    }
}
