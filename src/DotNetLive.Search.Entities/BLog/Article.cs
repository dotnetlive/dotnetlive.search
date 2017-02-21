using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Entities.BLog
{
    public class Article : Base.LongBaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set;}
        public string Content { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
