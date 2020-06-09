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
            var task = Task.Run(async () =>
            {
                try
                {
                    await this.SubMainAsync();
                }
                catch(Exception ex)
                {
                    // Prevent the exception from bubbling upwards.
                    Console.WriteLine(ex.Message);

                    //throw ex;
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

        protected abstract Task SubMainAsync();
    }
}
