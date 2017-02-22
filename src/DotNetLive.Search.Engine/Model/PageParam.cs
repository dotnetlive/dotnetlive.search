using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Engine.Model
{
    public interface IPageParam
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string KeyWord { get; set; }
        int From { get; }
        Nest.Operator Operator { get; set; }
        HighlightParam Highlight { get; set; }
    }
    /// <summary>
    /// 普通查询结果
    /// </summary>
    public class PageParam : IPageParam
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string KeyWord { get; set; }
        public int From
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }
        public Nest.Operator Operator { get; set; } = Nest.Operator.And;

        public HighlightParam Highlight { get; set; }
    }
    /// <summary>
    /// 指定Field查询
    /// </summary>
    public class PageParamWithSearch : PageParam
    {
        public string[] SearchKeys { get; set; }
    }
}
