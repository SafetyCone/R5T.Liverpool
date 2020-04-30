using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool
{
    public static class IServiceBuilderExtensions
    {
        public static TServiceBuilder UseHostedServiceProgram<TServiceBuilder, THostedServiceProgram>(this TServiceBuilder serviceBuilder)
            where TServiceBuilder: IServiceBuilder
            where THostedServiceProgram: class, IHostedService
        {
            serviceBuilder.AddConfigureServices(services =>
            {
                services.AddHostedService<THostedServiceProgram>();
            });

            return serviceBuilder;
        }
    }
}
