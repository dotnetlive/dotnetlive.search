using DotNetLive.Framework.DependencyManagement;
using DotNetLive.Search.Config;
using DotNetLive.Search.Services.Classes.CnBlogs;
using DotNetLive.Search.Services.Factory;
using DotNetLive.Search.Services.Interface.CnBlogs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.SearchWeb.DependencyRegister
{
    public class SearchDependencyRegister : IDependencyRegister
    {
        //public ExecuteOrderType ExecuteOrder => ExecuteOrderType.Normal;

        public void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            //Add config options
            services.Configure<ElasticSetting>(configuration.GetSection("ElasticSetting"))
            //Add search factory
            .AddSingleton<ISearchFactory, SearchFactory>()
            //Add search Service
            .AddTransient<ICnBlogsService, BlogService>();
        }
    }
}
