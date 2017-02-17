using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLive.Search.Engine.Client
{
    internal static class TypeExtension
    {
        public static string SearchName(this Type type)
        {
            StringBuilder str = new StringBuilder();
            foreach (char i in type.Name)
            {
                if (char.IsLower(i))
                {
                    str.Append(i);
                }
                else
                {
                    if (str.Length > 0)
                    {
                        str.Append("_");
                    }
                    str.Append(char.ToLower(i));
                }
            }
            return str.ToString();
        }
    }
}
