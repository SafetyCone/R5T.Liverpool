using System;using R5T.T0064;


namespace R5T.Liverpool.Construction
{[ServiceImplementationMarker]
    public class ConsoleHelloWorldSayer : IHelloWorldSayer,IServiceImplementation
    {
        public void SayHelloWorld()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
