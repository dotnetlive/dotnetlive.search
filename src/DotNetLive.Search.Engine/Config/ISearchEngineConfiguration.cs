using DotNetLive.Search.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Search.Engine.Config
{
    public interface ISearchEngineConfiguration
    {
        IEnumerable<ConfigNode> GetConfig();
    }
}
