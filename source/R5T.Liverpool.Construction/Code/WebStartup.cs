using System;

using Microsoft.Extensions.Logging;

using R5T.Dover;


namespace R5T.Liverpool
{
    public class WebStartup : WebStartupBase
    {
        public WebStartup(ILogger<WebStartup> logger)
            : base(logger)
        {
        }
    }
}
