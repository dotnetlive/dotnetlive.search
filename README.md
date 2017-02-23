# DotNetLive.Search
### 项目基于ASP.NET Core + 分布式搜索引擎 ElasticSearch 实现
### ElasticSearch 客户端基于 NEST 
### 项目Demo是基于博客园找找看搜索页面实现（python采集数据）

#### 注册搜索服务，核心查询代码在项目 DotNetLive.Search.Engine.DotNetSearch 类中
``` C#
	 public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //Add search Service
            services.AddTransient<Services.Interface.CnBlogs.ICnBlogsService, Services.Classes.CnBlogs.BlogService>();
        }

#### 效果图：
![](http://images2015.cnblogs.com/blog/841545/201702/841545-20170223235351648-1569692084.png) 

