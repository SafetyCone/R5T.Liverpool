using System;

using R5T.Dover;

using R5T.Liverpool.Startup;
using R5T.Liverpool.Web.Startup.Core;


namespace R5T.Liverpool.Web.Startup
{
    public static class IWebServiceBuilderExtensions
    {
        public static IWebServiceBuilder UseWebStartup<TStartup>(this IWebServiceBuilder webServiceBuilder)
            where TStartup : class, IWebStartup
        {
            var startup = webServiceBuilder.GetStartupInstance<TStartup>();

            webServiceBuilder.UseWebStartup(startup);

            return webServiceBuilder;
        }
    }
}
