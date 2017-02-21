using cnblogs.import.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace cnblogs.import
{
   public class Start
    {
        public static IServiceProvider RegisterServices() {

            string folder = DateTime.Now.ToString("yyyy-MM-dd");
            var service = new ServiceCollection()
                //定位到文件夹，当前日期
               .AddSingleton<IFileProvider>(new PhysicalFileProvider($@"D:\{folder}"))
               .AddSingleton<IFileManager, FileManager>()
               //序列化器 
               .AddSingleton<ISerializer,CnBlogsSerializer>()
               .BuildServiceProvider();
            return service;
               
        }
    }
}
