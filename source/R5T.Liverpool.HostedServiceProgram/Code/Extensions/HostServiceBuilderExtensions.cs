using System;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool
{
    public static class HostServiceBuilderExtensions
    {
        public static HostServiceBuilder UseHostedServiceProgram<THostedServiceProgram>(this HostServiceBuilder serviceBuilder)
            where THostedServiceProgram : class, IHostedService
        {
            serviceBuilder.UseHostedServiceProgram<HostServiceBuilder, THostedServiceProgram>();

            return serviceBuilder;
        }
    }
}
