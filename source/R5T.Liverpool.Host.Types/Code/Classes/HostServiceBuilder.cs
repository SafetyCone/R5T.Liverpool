using System;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool
{
    public class HostServiceBuilder : ServiceBuilderBase<IHost>
    {
        #region Static

        public static HostServiceBuilder New()
        {
            var output = new HostServiceBuilder();
            return output;
        }

        #endregion


        public override IHost Build(IServiceProvider configurationServiceProvider)
        {
            var hostBuilder = new HostBuilder();

            // Configure configuration.
            hostBuilder.ConfigureAppConfiguration(configurationBuilder =>
            {
                this.ConfigureConfigurationActions.ForEach(configureConfigurationAction => configureConfigurationAction(configurationBuilder, configurationServiceProvider));
            });

            // Configure services.
            hostBuilder.ConfigureServices(services =>
            {
                this.ConfigureServicesActions.ForEach(servicesAction => servicesAction(services));
            });

            // Configure actual (singleton) service instances.
            var host = hostBuilder.Build();

            this.ConfigureActions.ForEach(configureAction => configureAction(host.Services));

            return host;
        }
    }
}
