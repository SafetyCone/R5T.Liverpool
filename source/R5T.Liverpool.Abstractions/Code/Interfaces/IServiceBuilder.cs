using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace R5T.Liverpool
{
    public interface IServiceBuilder
    {
        void AddConfigureConfiguration(Action<IConfigurationBuilder, IServiceProvider> configureConfigurationAction);
        void AddConfigureServices(Action<IServiceCollection> configureServicesAction);
        void AddConfigure(Action<IServiceProvider> configureAction);
    }


    public interface IServiceBuilder<out TService> : IServiceBuilder
    {
        TService Build(IServiceProvider configurationServiceProvider);
    }
}
