using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Engine.Model
{
    public class HighlightParam
    {
        public string[] Keys { get; set; }
        public string PreTags { get; set; } = "<em>";
        public string PostTags { get; set; } = "</em>";
       // public Action<IDictionary<string, string>,object> HandleHighlightResult { get; set; }
    }
}
