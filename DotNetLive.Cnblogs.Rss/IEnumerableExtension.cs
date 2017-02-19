using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLive.Cnblogs.Rss
{
    internal static class IEnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> handler)
        {
            foreach (var item in list) {
                handler(item);
            }

        }
    }
}
