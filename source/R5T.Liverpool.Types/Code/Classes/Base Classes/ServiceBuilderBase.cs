using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace R5T.Liverpool
{
    public abstract class ServiceBuilderBase<TService> : IServiceBuilder<TService>
    {
        protected List<Action<IConfigurationBuilder, IServiceProvider>> ConfigureConfigurationActions { get; } = new List<Action<IConfigurationBuilder, IServiceProvider>>();
        protected List<Action<IServiceCollection>> ConfigureServicesActions { get; } = new List<Action<IServiceCollection>>();
        protected List<Action<IServiceProvider>> ConfigureActions { get; } = new List<Action<IServiceProvider>>();


        public void AddConfigureConfiguration(Action<IConfigurationBuilder, IServiceProvider> configureConfigurationAction)
        {
            this.ConfigureConfigurationActions.Add(configureConfigurationAction);
        }

        public void AddConfigureServices(Action<IServiceCollection> configureServicesAction)
        {
            this.ConfigureServicesActions.Add(configureServicesAction);
        }

        public void AddConfigure(Action<IServiceProvider> configureAction)
        {
            this.ConfigureActions.Add(configureAction);
        }

        public abstract TService Build(IServiceProvider configurationServiceProvider);
    }
}
