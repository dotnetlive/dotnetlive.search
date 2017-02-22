using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Engine.Model
{
    public interface IQueryResult<T>
    {
        /// <summary>
        /// 查询的总条数
        /// </summary>
        long Total { get; set; }
        /// <summary>
        /// 查询占用时间
        /// </summary>
        long Took { get; set; }

        IEnumerable<T> List { get; }
    }

    public class CustomQueryResult<T> : IQueryResult<T>
    {
        public long Total { get; set; }
        public long Took { get; set; }

        public IEnumerable<T> List { get; set; }
    }
}
