using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Hosting;

using R5T.Herulia.Extensions;


namespace R5T.Liverpool
{
    public class WebHostServiceBuilder : WebServiceBuilderBase<IWebHost>
    {
        #region Static

        public static WebHostServiceBuilder New()
        {
            var output = new WebHostServiceBuilder();
            return output;
        }

        #endregion


        public override IWebHost Build(IServiceProvider configurationServiceProvider)
        {
            // Default web host.
            var webHostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseDefaultContentRoot()
                .UseIISIntegration()
                ;

            // Configure configuration.
            webHostBuilder.ConfigureAppConfiguration(configurationBuilder =>
            {
                this.ConfigureConfigurationActions.ForEach(configureConfigurationAction => configureConfigurationAction(configurationBuilder, configurationServiceProvider));
            });

            // Configure services.
            webHostBuilder.ConfigureServices(services =>
            {
                this.ConfigureServicesActions.ForEach(configureServicesAction => configureServicesAction(services));
            });

            webHostBuilder.Configure(applicationBuilder =>
            {
                this.ConfigureActions.ForEach(configureAction => configureAction(applicationBuilder.ApplicationServices));

                this.ApplicationConfigureActions.ForEach(applicationConfigureAction => applicationConfigureAction(applicationBuilder));
            });

            var webHost = webHostBuilder.Build();
            return webHost;
        }
    }
}
