using System;

using R5T.Richmond;


namespace R5T.Liverpool
{
    public static class ServiceProviderServiceBuilderExtensions
    {
        public static ServiceProviderServiceBuilder UseStartup<TStartup>(this ServiceProviderServiceBuilder serviceProviderServiceBuilder)
            where TStartup: class, IStartup
        {
            R5T.Liverpool.Startup.IServiceBuilderExtensions.UseStartup<TStartup>(serviceProviderServiceBuilder);

            return serviceProviderServiceBuilder;
        }
    }
}
