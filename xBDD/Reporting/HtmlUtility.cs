﻿using System.Globalization;
using System.Text;
using System.Net;

namespace xBDD.Reporting
{
    internal static class HtmlUtility
    {
        internal static string HtmlEncode(this string text)
        {
            return System.Net.WebUtility.HtmlEncode(text);
            // if (text == null)
            //     return null;

            // StringBuilder sb = new StringBuilder(text.Length);

            // int len = text.Length;
            // for (int i = 0; i < len; i++)
            // {
            //     switch (text[i])
            //     {

            //         case '<':
            //             sb.Append("&lt;");
            //             break;
            //         case '>':
            //             sb.Append("&gt;");
            //             break;
            //         case '"':
            //             sb.Append("&quot;");
            //             break;
            //         case '&':
            //             sb.Append("&amp;");
            //             break;
            //         default:
            //             if (text[i] > 159)
            //             {
            //                 // decimal numeric entity
            //                 sb.Append("&#");
            //                 sb.Append(((int)text[i]).ToString(CultureInfo.InvariantCulture));
            //                 sb.Append(";");
            //             }
            //             else
            //                 sb.Append(text[i]);
            //             break;
            //     }
            // }
            // return sb.ToString();
        }
    }
}
