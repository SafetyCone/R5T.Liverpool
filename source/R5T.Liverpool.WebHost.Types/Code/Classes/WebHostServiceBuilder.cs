using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Hosting;

using R5T.Herulia.Extensions;


namespace R5T.Liverpool
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Because an <see cref="IWebHostBuilder"/> constructor function can be provided (not an <see cref="IWebHostBuilder"/> instance), the <see cref="WebHostServiceBuilder.Build(IServiceProvider)"/> method can be called multiple times.
    /// </remarks>
    public class WebHostServiceBuilder : WebServiceBuilderBase<IWebHost>
    {
        #region Static

        public static WebHostServiceBuilder New()
        {
            var output = new WebHostServiceBuilder();
            return output;
        }

        public static IWebHostBuilder GetDefaultWebHostBuilder()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseDefaultContentRoot()
                .UseIISIntegration()
                ;

            return webHostBuilder;
        }

        #endregion


        private Func<IWebHostBuilder> WebHostBuilderConstructor { get; }


        public WebHostServiceBuilder(Func<IWebHostBuilder> webHostBuilderConstructor)
        {
            this.WebHostBuilderConstructor = webHostBuilderConstructor;
        }

        public WebHostServiceBuilder()
            : this(WebHostServiceBuilder.GetDefaultWebHostBuilder)
        {
        }

        public override IWebHost Build(IServiceProvider configurationServiceProvider)
        {
            // Get new web host builder instance.
            var webHostBuilder = this.WebHostBuilderConstructor();

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
