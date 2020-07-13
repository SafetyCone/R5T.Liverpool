using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.Liverpool.ProgramAsService
{
    public static class IServiceBuilderExtensions
    {
        /// <summary>
        /// Adds the <typeparamref name="TProgramAsService"/> service implementation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceBuilder<TService> AddProgramAsService<TService, TProgramAsService>(this IServiceBuilder<TService> serviceBuilder)
            where TProgramAsService: ProgramAsServiceBase
        {
            serviceBuilder.AddConfigureServices(services =>
            {
                services.AddSingleton<TProgramAsService>();
            });

            return serviceBuilder;
        }

        /// <summary>
        /// Adds the <typeparamref name="TAsynchronousProgramAsService"/> service implementation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceBuilder<TService> AddAsynchronousProgramAsService<TService, TAsynchronousProgramAsService>(this IServiceBuilder<TService> serviceBuilder)
            where TAsynchronousProgramAsService : AsynchronousProgramAsServiceBase
        {
            serviceBuilder.AddConfigureServices(services =>
            {
                services.AddSingleton<TAsynchronousProgramAsService>();
            });

            return serviceBuilder;
        }
    }
}
