using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;


namespace R5T.Liverpool
{
    public abstract class WebServiceBuilderBase<TService> : ServiceBuilderBase<TService>, IWebServiceBuilder<TService>
    {
        protected List<Action<IApplicationBuilder>> ApplicationConfigureActions { get; } = new List<Action<IApplicationBuilder>>();


        public void AddConfigure(Action<IApplicationBuilder> configureAction)
        {
            this.ApplicationConfigureActions.Add(configureAction);
        }
    }
}
