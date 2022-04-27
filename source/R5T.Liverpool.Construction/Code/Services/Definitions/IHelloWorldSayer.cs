using System;using R5T.T0064;


namespace R5T.Liverpool.Construction
{[ServiceDefinitionMarker]
    public interface IHelloWorldSayer:IServiceDefinition
    {
        void SayHelloWorld();
    }
}
