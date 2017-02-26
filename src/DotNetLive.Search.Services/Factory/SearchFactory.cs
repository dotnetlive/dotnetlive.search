using DotNetLive.Search.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using DotNetLive.Search.Engine.Client;
using Microsoft.Extensions.Logging;

namespace DotNetLive.Search.Services.Factory
{
    public class SearchFactory : ISearchFactory
    {

        private IOptions<ElasticSetting> _setting;

        public SearchFactory(IOptions<ElasticSetting> setting)
        {
            _setting = setting;
        }

        public DotNetSearch CreateSearchClient()
        {
            DotNetSearch search = new DotNetSearch(_setting.Value);
            return search;
        }

        public DotNetSearch CreateSearchClient(string index, ILogger logger)
        {
            return CreateSearchClient().UseIndex(index).UseLogger(logger);
        }
    }
}
