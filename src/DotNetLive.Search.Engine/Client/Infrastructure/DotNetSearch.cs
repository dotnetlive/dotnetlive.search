using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLive.Search.Engine.Client
{
   public partial class DotNetSearch
    {
        /// <summary>
        /// 删除某个索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteIndex(string index)
        {
            IDeleteIndexResponse response = _builder.Client.DeleteIndex(index);
            return response.Acknowledged;
        }

        /// <summary>
        /// 删除某个索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<bool> DeleteIndexAsync(string index)
        {
            IDeleteIndexResponse response = await _builder.Client.DeleteIndexAsync(index);
            return response.Acknowledged;
        }
    }
}
