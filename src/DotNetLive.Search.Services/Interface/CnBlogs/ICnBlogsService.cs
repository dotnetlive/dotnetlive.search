using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Services.Interface.CnBlogs
{
    public interface ICnBlogsService
    {
        /// <summary>
        /// 博客列表分页查询，根据关键字
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数默认20</param>
        /// <param name="keyWord">关键字</param>
        /// <returns>返回查询实体及其他必须参数</returns>
        Entities.Page.ElasticPager<Entities.CnBlogs.Blog> QueryByPage(int pageIndex = 1, int pageSize = 20, string keyWord = null);
    }
}
