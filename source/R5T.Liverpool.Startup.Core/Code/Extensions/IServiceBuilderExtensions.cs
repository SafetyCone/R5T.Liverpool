using System;

using R5T.Richmond;


namespace R5T.Liverpool.Startup.Core
{
    public static class IServiceBuilderExtensions
    {
        public static IServiceBuilder UseStartup(this IServiceBuilder serviceBuilder, IStartup startup)
        {
            serviceBuilder.AddConfigureConfiguration(startup.ConfigureConfiguration);

            serviceBuilder.AddConfigureServices(startup.ConfigureServices);

            serviceBuilder.AddConfigure(startup.Configure);

            return serviceBuilder;
        }
    }
}
