using System;

using R5T.Richmond;


namespace R5T.Liverpool
{
    public static class HostServiceBuilderExtensions
    {
        public static HostServiceBuilder UseStartup<TStartup>(this HostServiceBuilder hostServiceBuilder)
            where TStartup : class, IStartup
        {
            R5T.Liverpool.Startup.IServiceBuilderExtensions.UseStartup<TStartup>(hostServiceBuilder);

            return hostServiceBuilder;
        }
    }
}
