using System;
using System.Collections.Generic;
using System.Text;

namespace cnblogs.import.Core
{
    public interface ISerializer
    {
        IEnumerable<T> JsonToEntities<T>(string json);

        string Serialize<T>(T value);
    }
}
