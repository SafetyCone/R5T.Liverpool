using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool.Construction
{
    public class Program04 : AsyncHostedServiceProgramBase
    {
        private IHelloWorldSayer HelloWorldSayer { get; }


        public Program04(IApplicationLifetime applicationLifetime,
            IHelloWorldSayer helloWorldSayer)
            : base(applicationLifetime)
        {
            this.HelloWorldSayer = helloWorldSayer;
        }

        protected override async Task SubMainAsync()
        {
            await Task.Delay(1000);

            this.HelloWorldSayer.SayHelloWorld();

            await Task.Delay(1000);

            this.HelloWorldSayer.SayHelloWorld();

            await Task.Delay(1000);
        }
    }
}
