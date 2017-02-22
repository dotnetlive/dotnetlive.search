using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetLive.Search.Entities.BLog;

namespace DotNetLive.Search.UnitTest
{
    [TestClass]
    public class SearchEngineUnitTest
    {
        

        [TestMethod]
        public void Index()
        {
            Engine.Client.DotNetSearch search = new Engine.Client.DotNetSearch().UseIndex("test");
           var result = search.Index<Article>(new Article
            {
                Id = 1,
                Author = "fyp",
                Content = "this is an article",
                Title = "test article"
            });
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Update()
        {
            Engine.Client.DotNetSearch search = new Engine.Client.DotNetSearch().UseIndex("test");
            var result = search.Update<Article>(new Article
            {
                Id = 1,
                Author = "zhangsan",
                Content = "this is an article",
                Title = "test article"
            });
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void Get()
        {
            Engine.Client.DotNetSearch search = new Engine.Client.DotNetSearch().UseIndex("test");
            var result = search.Query<Article>(1);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("zhangsan", result.Author);
        }
        [TestMethod]
        public void Delete()
        {
            Engine.Client.DotNetSearch search = new Engine.Client.DotNetSearch().UseIndex("test");
            var result = search.Delete<Article>(1);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void DeleteIndex()
        {
            Engine.Client.DotNetSearch search = new Engine.Client.DotNetSearch().UseIndex("test");
            bool result = search.DeleteIndex("test");
            Assert.IsTrue(result);
        }


    }
}
