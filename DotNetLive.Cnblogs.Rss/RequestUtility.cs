using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLive.Cnblogs.Rss
{
    public class RequestUtility
    {
        public static Stream Get(string url)
        {
            WebRequest myRequest = WebRequest.Create(url);
            myRequest.ContentType = "application/xml";
            WebResponse response = myRequest.GetResponseAsync().Result;
            Stream rssStream = response.GetResponseStream();
            return rssStream;
        }
    }
}
