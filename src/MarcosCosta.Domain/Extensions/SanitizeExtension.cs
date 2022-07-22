using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Extensions
{
    public static class SanitizeExtension
    {
        public static string Unescape(this string content)
        {
            return content.Replace("&quot;", "").Replace("&Atilde;", "").Replace("&copy;", "")
                                    .Replace("&acirc;", "").Replace("&euro;", "").Replace("&trade;", "")
                                    .Replace("&acirc;", "").Replace("&ldquo;", "").Replace("&oelig;", "")
                                    .Replace("&#65533;", "").Replace("&ldquo;", "").Replace("&oelig;", "");
        }
    }
}
