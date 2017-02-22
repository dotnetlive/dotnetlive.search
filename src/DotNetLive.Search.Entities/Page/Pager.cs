using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Entities.Page
{

    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParam
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 20;
        public long TotalCount { get; set; }
        public long TotalPage
        {
            get
            {
                long res = TotalCount % PageSize;
                return res == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;
            }
        }
    }

    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pager<T> where T:class
    {
        public PageParam PageData { get; set; }
       
        public IEnumerable<T> List { get; set; }

    }
    /// <summary>
    /// Elastic分页结果，带关键词
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ElasticPager<T> : Pager<T> where T:class
    {
        public long Took { get; set; }
        public string KeyWord { get; set; }
    }

}
