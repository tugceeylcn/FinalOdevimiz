using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Odev.Domain.Helpers
{
    public static class HtmlCleaner
    {
        public static string RemoveHtmlTags(this string input)
        {
            string pattern = "<.*?>";
            return Regex.Replace(input, pattern, string.Empty);
        }
    }
}
