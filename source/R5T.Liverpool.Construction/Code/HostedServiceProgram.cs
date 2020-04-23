using System;

using Microsoft.Extensions.Hosting;


namespace R5T.Liverpool.Construction
{
    public class HostedServiceProgram : HostedServiceProgramBase
    {
        public HostedServiceProgram(IApplicationLifetime applicationLifetime)
            : base(applicationLifetime)
        {
        }

        protected override void SubMain()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
