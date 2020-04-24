using System;


namespace R5T.Liverpool.Construction
{
    public class ConsoleHelloWorldSayer : IHelloWorldSayer
    {
        public void SayHelloWorld()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
