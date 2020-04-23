using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool
{
    public abstract class AsyncHostedServiceProgramBase : IHostedService
    {
        private IApplicationLifetime ApplicationLifetime { get; }


        public AsyncHostedServiceProgramBase(IApplicationLifetime applicationLifetime)
        {
            this.ApplicationLifetime = applicationLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                await this.SubMain();

                this.ApplicationLifetime.StopApplication();
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected abstract Task SubMain();
    }
}
