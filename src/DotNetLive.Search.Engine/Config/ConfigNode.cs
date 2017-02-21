using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Search.Config
{
    /// <summary>
    /// 配置ES服务器节点
    /// </summary>
    public class ConfigNode
    {
        public string Uri { get; set; }
        public uint Port { get; set; }

        public override string ToString()
        {
            var result = $"{Uri}:{Port}".ToLowerInvariant();

            if (result.IndexOf("http") > -1)
            {
                return result;
            }
            else {
                return $"http://{result}";
            }
        }
    }
}
