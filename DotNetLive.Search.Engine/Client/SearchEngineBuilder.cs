using DotNetLive.Search.Engine.Config;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Search.Engine.Client
{
    /// <summary>
    /// 创建Client
    /// </summary>
    internal class SearchEngineBuilder
    {
        private ElasticClient _client;
        private ISearchEngineConfiguration _configuration;
        private static object _lock = new object();

        public SearchEngineBuilder()
        {
            _configuration = new SearchEngineDefaultConfiguration();
        }
        public ElasticClient Client
        {
            get
            {
                if (_client == null)
                {
                    lock (_lock)
                    {
                        if (_client == null)
                        {
                            var config = _configuration.GetConfig();
                            if (config == null) throw new ArgumentException("error config");

                            var nodes = config.Select(x => new Uri(x.ToString()));

                            var pool = new StaticConnectionPool(nodes);
                            var settings = new ConnectionSettings(pool);
                            var client = new ElasticClient(settings);

                            _client = client;
                        }

                    }
                }
                return _client;
            }
        }
    }
}
