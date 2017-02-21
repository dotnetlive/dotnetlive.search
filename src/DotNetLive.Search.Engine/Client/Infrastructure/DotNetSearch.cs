using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Engine.Client
{
   public partial class DotNetSearch
    {
        /// <summary>
        /// 删除某个索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteIndex(string index=null)
        {
            IDeleteIndexResponse response = _builder.Client.DeleteIndex(index ?? _defaultIndex);
            return response.Acknowledged;
        }
    }
}
