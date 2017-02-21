using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetLive.Search.Engine.Client
{
    internal static class TypeExtension
    {
        /// <summary>
        /// 转换成小写带下划线的type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SearchName(this Type type)
        {
            return type.Name.PascalToHyphen();
        }

        /// <summary>
        /// 将字符串转为带下划线的字符串
        /// ArticleInfo => article_info
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string PascalToHyphen(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(input, @"([A-Z]+)([A-Z][a-z])", "$1-$2"), @"([a-z\d])([A-Z])", "$1-$2")
                , @"[-\s]+", "_").TrimEnd('_').ToLower();
        }

    }
}
