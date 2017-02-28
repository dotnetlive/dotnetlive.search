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
        //例如 title 高亮值赋值给 h_title
        public string PrefixOfKey { get; set; } = string.Empty;
        //是否替换原来的值，默认为true
        public bool ReplaceAuto { get; set; } = true;
    }
}
