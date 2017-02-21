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
            //获取的不正确
            //IConfiguration configuration = new ConfigurationBuilder()
            //    .AddJsonFile("search.json")
            //    .Build().GetSection("ElasticSetting");

            //IServiceCollection services = new ServiceCollection();

            //IOptions<ElasticSetting> optionsAccessor = services.AddOptions()
            //    .Configure<ElasticSetting>(configuration)
            //    .BuildServiceProvider()
            //    .GetService<IOptions<ElasticSetting>>();
            //return optionsAccessor.Value?.Nodes;
            return new List<ConfigNode> {
                 new ConfigNode { Port=9200, Uri="****" }
            };
        }
    }
}
