using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Hosting;

using R5T.Dacia;


namespace R5T.Liverpool.Construction
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Program.HostedServiceProgramExampleAsync();

            //await Task.CompletedTask; // Yes, this works.
        }

        // Don't use this async-Main() method signature since it does not allow placing a breakpoint after all program execution. The Main() method returns the task immediately, leaving running the task up to the .NET runtime.
        //static Task Main(string[] args)
        //{
        //    return Program.HostedServiceProgramExampleAsync();
        //}

        //static void Main(string[] args)
        //{
        //    //Program.ServiceProviderExample();
        //    //Program.HostExample();
        //    //Program.WebHostExample();
        //    Program.HostedServiceProgramExample();
        //}

        private static Task HostedServiceProgramExampleAsync()
        {
            //var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            //await HostServiceBuilder.New()
            //    .UseStartup<Startup>()
            //    .UseHostedServiceProgram<Program04>()
            //    .Build(emptyServiceProvider)
            //    .RunAsync()
            //    ;

            var task = HostedServiceProgram.RunAsync<Program04, Startup>();
            return task;
        }

        private static void HostedServiceProgramExample()
        {
            //HostedServiceProgram.Run<Program02>(args);
            //HostedServiceProgram.RunAsync<Program03>(args);

            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var host = HostServiceBuilder.New()
                .UseStartup<Startup>()
                .UseHostedServiceProgram<Program04>()
                .Build(emptyServiceProvider);

            host.Run();
        }

        private static void WebHostExample()
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var host = WebHostServiceBuilder.New()
                .UseWebStartup<WebStartup>()
                .Build(emptyServiceProvider);

            host.Run();
        }

        private static void HostExample()
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var host = HostServiceBuilder.New()
                .UseStartup<Startup>()
                .Build(emptyServiceProvider);

            //host.Run(); // Runs host, but without a service to order host shutdown, no joy.
        }

        private static void ServiceProviderExample()
        {
            var emptyServiceProvider = ServiceProviderHelper.GetEmptyServiceProvider();

            var serviceProvider = ServiceProviderServiceBuilder.New()
                .UseStartup<Startup>()
                .Build(emptyServiceProvider);
        }
    }
}
