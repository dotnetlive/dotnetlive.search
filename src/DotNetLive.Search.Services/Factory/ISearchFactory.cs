using DotNetLive.Search.Engine.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Services.Factory
{
    public interface ISearchFactory
    {
        DotNetSearch CreateSearchClient();
        DotNetSearch CreateSearchClient(string index, ILogger logger);
    }
}
