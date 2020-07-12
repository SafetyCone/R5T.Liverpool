using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool
{
    public abstract class AsyncHostedServiceProgramBase : IHostedService
    {
        private IApplicationLifetime ApplicationLifetime { get; }

        private CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
        private Task RunningProgram { get; set; }


        public AsyncHostedServiceProgramBase(IApplicationLifetime applicationLifetime)
        {
            this.ApplicationLifetime = applicationLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.RunningProgram = Task.Run(async () =>
            {
                try
                {
                    await this.SubMainAsync();
                }
                finally
                {
                    this.ApplicationLifetime.StopApplication();
                }
            }, this.CancellationTokenSource.Token);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.CancellationTokenSource.Cancel();

            return Task.CompletedTask;
            //await this.RunningProgram();
        }

        protected abstract Task SubMainAsync();
    }
}
