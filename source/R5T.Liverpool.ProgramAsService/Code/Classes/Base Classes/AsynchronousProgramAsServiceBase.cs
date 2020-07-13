using System;
using System.Threading.Tasks;


namespace R5T.Liverpool.ProgramAsService
{
    public abstract class AsynchronousProgramAsServiceBase
    {
        protected abstract Task SubMainAsync();
    }
}
