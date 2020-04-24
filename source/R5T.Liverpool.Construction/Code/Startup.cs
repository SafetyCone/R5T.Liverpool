using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Richmond;


namespace R5T.Liverpool.Construction
{
    public class Startup : StartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            base.ConfigureServicesBody(services);

            services.AddSingleton<IHelloWorldSayer, ConsoleHelloWorldSayer>();
        }
    }
}
