using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace cnblogs.import.Core
{
    public class FileManager : IFileManager
    {

        public IFileProvider FileProvider { get; private set; }

        public FileManager(IFileProvider fileProvider)
        {
            this.FileProvider = fileProvider;
        }

        public void HandleFile(Func<string,string,bool> fileHandler)
        {
            //通过FileProvider读取文件，遍历
            foreach (var fileInfo in this.FileProvider.GetDirectoryContents(""))
            {
                //读取文件内容（json）
                string result = ReadAllTextAsync(fileInfo.Name).Result;
                //执行处理
                var handleResult = fileHandler(fileInfo.Name, result);
                if (handleResult){
                    //导入成功之后，将该文件移动到其他文件夹
                    //File(fileInfo.PhysicalPath);
                    File.Delete(fileInfo.PhysicalPath);
                }
            }


        }

        private async Task<string> ReadAllTextAsync(string path)
        {
            byte[] buffer;
            using (Stream readStream = this.FileProvider.GetFileInfo(path).CreateReadStream())
            {
                buffer = new byte[readStream.Length];
                await readStream.ReadAsync(buffer, 0, buffer.Length);
            }
            //这里要用utf-8 做数据采集的时候，保存为utf-8 编码类型
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
