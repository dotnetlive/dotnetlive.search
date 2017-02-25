using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetLive.Search.Services.Interface.CnBlogs;

namespace DotNetLive.SerachWeb.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// blogService接口
        /// </summary>
        private ICnBlogsService cnblogService;

        public HomeController(ICnBlogsService service)
        {
            cnblogService = service;
        }

        /// <summary>
        /// 搜索首页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IActionResult Index(int pageIndex = 1, string keyword = null)
        {
            var model = cnblogService.QueryByPage(pageIndex, keyWord: keyword);
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
