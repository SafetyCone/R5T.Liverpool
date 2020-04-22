using System;

using R5T.Dover;

using R5T.Liverpool.Startup.Core;


namespace R5T.Liverpool.Web.Startup.Core
{
    public static class IWebServiceBuilderExtensions
    {
        public static IWebServiceBuilder UseWebStartup(this IWebServiceBuilder webServiceBuilder, IWebStartup webStartup)
        {
            webServiceBuilder.UseStartup(webStartup);

            webServiceBuilder.AddConfigure(webStartup.Configure);

            return webServiceBuilder;
        }
    }
}
