using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool
{
    public abstract class HostedServiceProgramBase: IHostedService
    {
        private IApplicationLifetime ApplicationLifetime { get; }


        public HostedServiceProgramBase(IApplicationLifetime applicationLifetime)
        {
            this.ApplicationLifetime = applicationLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var task = Task.Run(() =>
            {
                try
                {
                    this.SubMain();
                }
                catch
                {
                    // Empty catch-block to prevent exception from bubbling upwards. (No stops in hosted service program infrastructure during debugging.)
                }
                finally
                {
                    this.ApplicationLifetime.StopApplication();
                }
            });

            return task;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected abstract void SubMain();
    }
}
