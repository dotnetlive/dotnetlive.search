using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cnblogs.import.Core
{
    public interface IFileManager
    {
        /// <summary>
        /// 读取文件，获取文件内容
        /// </summary>
        /// <param name="fileHandler"></param>
        void HandleFile(Func<string,string,bool> fileHandler);
    }
}
