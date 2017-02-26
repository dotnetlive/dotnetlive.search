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
                new ConfigNode { Port=9200, Uri="http://localhost" }
            };
        }
    }
}
