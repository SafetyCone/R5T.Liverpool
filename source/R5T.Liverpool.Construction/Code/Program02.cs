using System;
using System.Threading;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool.Construction
{
    public class Program02 : HostedServiceProgramBase
    {
        public Program02(IApplicationLifetime applicationLifetime)
            : base(applicationLifetime)
        {
        }

        protected override void SubMain()
        {
            Thread.Sleep(1000);

            Console.WriteLine("Hello world!");

            Thread.Sleep(1000);
        }
    }
}
