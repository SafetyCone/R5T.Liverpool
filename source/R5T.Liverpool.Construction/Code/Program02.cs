using System;

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
            Console.WriteLine("Hello world!");
        }
    }
}
