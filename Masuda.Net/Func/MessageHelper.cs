using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Masuda.Net
{
    public static class MessageHelper
    {
        public static long ToMillisecond(this DateTime dateTime)
        {
            return (dateTime.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks) / TimeSpan.TicksPerMillisecond;
        }

        public static string GetPureMessage(string content)
        {
            return Regex.Replace(content, "<(@|#).+?>", "").Trim();
        }
    }
}
