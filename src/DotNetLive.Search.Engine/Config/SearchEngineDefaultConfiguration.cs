using System;
using System.Collections.Generic;
using DotNetLive.Search.Config;

namespace DotNetLive.Search.Engine.Config
{
    internal class SearchEngineDefaultConfiguration : ISearchEngineConfiguration
    {

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConfigNode> GetConfig()
        {
            return new List<ConfigNode> {
                new ConfigNode { Port=0, Uri="http://es.dotnet.live" }
            };
        }
    }
}
