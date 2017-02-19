using DotNetLive.Search.Engine.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace DotNetLive.Cnblogs.Rss
{
    class Program
    {
        static void Main(string[] args)
        {

            //避免乱码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ILogger logger = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider()
                .GetService<ILoggerFactory>()
                .AddConsole(true)
                .CreateLogger<Program>();

            RssHandler handler = new RssHandler(logger);
            var result = handler.XmlParse();

            if (result != null)
            {
                //
                DotNetSearch search = new DotNetSearch().UseIndex("dnl_rss").UseLogger(logger);

               bool deleteResult = search.DeleteIndex();
                logger.LogInformation(deleteResult ? "删除索引成功" : "删除索引失败");

                var bulkResult = search.Bulk<RssBlogDoc>(result);
                logger.LogInformation($"导入ElasticSearch的数据有：{bulkResult} 条");
            }
            Console.Read();
        }
    }
}