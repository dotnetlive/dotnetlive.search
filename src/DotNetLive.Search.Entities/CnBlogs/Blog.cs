using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Search.Entities.CnBlogs
{
    /*
     {"author": "老马说编程", 
     "comment_num": "0", 
     "title": "计算机程序的思维逻辑 (67) - 线程的基本协作机制 (上)", 
     "view_num": "5", 
     "summary": "\n    本节和下节介绍线程的基本协作机制wait/notify，本节介绍协作的场景，wait/notify的基本用法和原理，以及如何实现生产者/消费者模式 ... ...\r\n    ",
     "href": "http://www.cnblogs.com/swiftma/p/6421803.html",
     "create_time": "2017-02-21 07:00 ",
     "author_url": "http://www.cnblogs.com/swiftma/"}
         */
    public class Blog
    {

        public string id
        {
            get
            {

                //if (!string.IsNullOrEmpty(href))
                //{
                //    var lastArr = href.Split('/');
                //    var result = lastArr[lastArr.Length - 1].Split('.')[0];
                //    return result;
                //}
                return Guid.NewGuid().ToString();
            }
        }
        public string author { get; set; }
        public string title { get; set; }
        public int view_num { get; set;}
        public int comment_num { get; set; }
        public int goods_num { get; set; }
        public string summary { get; set; }
        public string href { get; set; }
        public DateTime create_time { get; set; }
        public string author_url { get; set; }
       
    }
}
