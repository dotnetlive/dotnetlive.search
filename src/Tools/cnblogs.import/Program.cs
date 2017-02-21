using cnblogs.import.Core;
using DotNetLive.Search.Engine.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Text;

namespace cnblogs.import
{
    class Program
    {
        static void Main(string[] args)
        {



            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            DotNetSearch search = new DotNetSearch().UseIndex("cnblogs");

            var provider = Start.RegisterServices();

            var manager = provider.GetService<IFileManager>();
            var serializer = provider.GetService<ISerializer>();

            //遍历已经搜集好的json文档
            manager.HandleFile(json =>
            {
                //反序列化得到实体
                var entities = serializer.JsonToEntities<DotNetLive.Search.Entities.CnBlogs.Blog>(json);
                //批量添加到ES中
                int result = search.IndexMany(entities);

                Console.WriteLine("加入" + result + "数据");
            });

            Console.Read();
        }
    }
}