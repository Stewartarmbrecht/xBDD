using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public static class Extensions
    {
        public static string Quote(this string value)
        {
            return "'" + value + "'";
        }
    }
}
