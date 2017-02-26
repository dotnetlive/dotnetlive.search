using System;
using System.Collections.Generic;
using System.Text;
using DotNetLive.Search.Entities.CnBlogs;
using DotNetLive.Search.Entities.Page;
using DotNetLive.Search.Services.Interface.CnBlogs;
using Microsoft.Extensions.Logging;
using DotNetLive.Search.Engine.Model;
using DotNetLive.Search.Services.Factory;

namespace DotNetLive.Search.Services.Classes.CnBlogs
{
    public class BlogService : ICnBlogsService
    {
        private readonly string searchIndex = "cnblogs";

        private readonly Engine.Client.DotNetSearch search;

        public BlogService(ILoggerFactory loggerFactory, ISearchFactory factory)
        {

            var logger = loggerFactory.CreateLogger<BlogService>();
            //创建查询客户端

            search = factory.CreateSearchClient(searchIndex, logger);
        }

        public ElasticPager<Blog> QueryByPage(int pageIndex = 1, int pageSize = 20, string keyWord = null)
        {
            var keys = new string[] { "title", "summary" };
            //查询参数构造
            IPageParam pageParams = new PageParamWithSearch
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                KeyWord = keyWord,
                Operator = Nest.Operator.Or,
                SearchKeys = keys,
                Highlight = new HighlightParam
                {
                    Keys = keys,
                    PostTags = "</strong>",
                    PreTags = "<strong>"
                }
            };

            //返回查询结果
            IQueryResult<Blog> result = search.Query<Blog>(pageParams);
            //返回客户端想要的结果
            return new ElasticPager<Blog>
            {
                KeyWord = keyWord,
                Took = result.Took,
                List = result.List,
                PageData = new Entities.Page.PageParam
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalCount = result.Total
                }
            };
        }
    }
}
