using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DotNetLive.Cnblogs.Rss
{
    public class RssHandler
    {
        private ILogger _logger;
        public RssHandler(ILogger logger) {
            _logger = logger;
        }
        //private const string RssUrl = "http://feed.cnblogs.com/blog/sitehome/rss";
        private const string RssUrl = "http://feed.cnblogs.com/blog/picked/rss";
        private const string RssDocNodeName = "entry";
        public IEnumerable<RssBlogDoc> XmlParse(string xml=null)
        {
            try
            {
                _logger.LogInformation("正在读取RSS...");
                var stream = RequestUtility.Get(RssUrl);
                _logger.LogInformation("正在解析RSS...");
                XDocument document = XDocument.Load(stream);

                var root = document.Root;
                List<RssBlogDoc> docs = new List<RssBlogDoc>();

                root.Elements().ForEach(x =>
                {
                    if (x.Name.LocalName == RssDocNodeName)
                    {
                        var model = new RssBlogDoc();
                        OperateElement(x, model);
                        _logger.LogInformation("解析成功，ID=" + model.id);
                        docs.Add(model);
                    }
                });
               
                return docs;
            }
            catch (Exception ex) {
                //记录日志
                _logger.LogDebug("解析RSS", ex, "解析异常");
                return null;
            }
        }

        Type rssType = typeof(RssBlogDoc);

        private void OperateElement(XElement ele,RssBlogDoc model)
        {
            if (ele.HasElements)
            {
                ele.Elements().ForEach(x =>
                {
                    OperateElement(x,model);
                });
            }
            else {
                object val;
               
                var property = rssType.GetProperty(ele.Name.LocalName);
                var type = property.PropertyType;
                string value = ele.Value;
                if (value == "") {
                    value = ele.Attribute("href").Value;
                }
                if (type.Equals(typeof(DateTime)))
                {
                    val = Convert.ToDateTime(value);
                }
                else
                {
                    val = value;
                }
                property.SetMethod?.Invoke(model, new object[] { val });//2012
            }
        }

    }
}
