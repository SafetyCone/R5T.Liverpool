using System;

using Microsoft.AspNetCore.Builder;


namespace R5T.Liverpool
{
    public interface IWebServiceBuilder : IServiceBuilder
    {
        void AddConfigure(Action<IApplicationBuilder> configureAction);
    }


    public interface IWebServiceBuilder<out TService> : IServiceBuilder<TService>, IWebServiceBuilder
    {
    }
}
