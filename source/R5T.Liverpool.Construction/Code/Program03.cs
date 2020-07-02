using System;

using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool.Construction
{
    public class Program03 : AsyncHostedServiceProgramBase
    {
        public Program03(IApplicationLifetime applicationLifetime)
            : base(applicationLifetime)
        {
        }

        protected override async Task SubMainAsync()
        {
            await Task.Delay(1000);

            Console.WriteLine("Hello world (async)!");

            await Task.Delay(1000);
        }
    }
}
