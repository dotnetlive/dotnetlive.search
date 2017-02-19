using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Cnblogs.Rss
{
    public class RssBlogDoc
    {
        private string _id;
        public string id
        {
            set
            {
                var arr = value.Split('/');
                var idarr = arr[arr.Length - 1].Split('.');
                if (idarr.Length == 2)
                {
                    _id = idarr[0];
                }
                else
                {
                    _id = DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }
            get
            {

                return _id;
            }
        }
        public string link
        {
            get; set;
        }
        public string title { get; set; }
        public string summary { get; set; }
        public DateTime published { get; set; }
        public DateTime updated { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string content { get; set; }
    }
}
