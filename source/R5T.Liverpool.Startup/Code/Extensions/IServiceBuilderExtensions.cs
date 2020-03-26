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
    }
}
