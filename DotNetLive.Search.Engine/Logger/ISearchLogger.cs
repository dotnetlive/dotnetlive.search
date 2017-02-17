using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Search.Engine.Logger
{
    public interface ISearchLogger
    {
        void Info(string message);
        void Info(string message, Exception ex);
        void Info(string message, params object[] args);
        void Warn(string message);
        void Warn(string message, Exception ex);
        void Warn(string message, params object[] args);
       
        void Debug(string message);
        void Debug(string message, Exception ex);
        void Debug(string message, params object[] args);
        void Error(string message);
        void Error(string message, params object[] args);
        void Error(string message, Exception ex);

    }
}
