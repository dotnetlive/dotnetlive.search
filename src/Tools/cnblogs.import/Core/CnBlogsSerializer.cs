using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace cnblogs.import.Core
{
    class CnBlogsSerializer : ISerializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public IEnumerable<T> JsonToEntities<T>(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return result;
            }
            catch (JsonSerializationException ex) {
                Console.WriteLine(ex);
                return null;
            }
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
