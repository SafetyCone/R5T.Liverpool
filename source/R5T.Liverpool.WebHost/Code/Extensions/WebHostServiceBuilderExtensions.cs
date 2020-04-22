using System;

using R5T.Dover;


namespace R5T.Liverpool
{
    public static class WebHostServiceBuilderExtensions
    {
        public static WebHostServiceBuilder UseWebStartup<TStartup>(this WebHostServiceBuilder webHostServiceBuilder)
            where TStartup : class, IWebStartup
        {
            R5T.Liverpool.Web.Startup.IWebServiceBuilderExtensions.UseWebStartup<TStartup>(webHostServiceBuilder);

            return webHostServiceBuilder;
        }
    }
}
