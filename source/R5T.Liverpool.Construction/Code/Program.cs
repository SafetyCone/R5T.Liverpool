using System;

using R5T.Dacia;


namespace R5T.Liverpool.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            var emptyServiceProvider = ServiceProviderHelper.EmptyServiceProvider.Value;

            var serviceProvider = ServiceProviderServiceBuilder.New()
                .UseStartup<Startup>()
                .Build(emptyServiceProvider);
        }
    }
}
