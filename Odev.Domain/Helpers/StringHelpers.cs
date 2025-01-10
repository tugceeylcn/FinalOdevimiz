using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Odev.Domain.Helpers
{
    public static class StringHelpers
    {
        public static string ToSeoUrl(this string url)
        {

            if (string.IsNullOrEmpty(url)) return "";
            url = url.ToLower();
            url = url.Trim();
            if (url.Length > 100)
            {
                url = url.Substring(0, 100);
            }

            url = url.Replace("İ", "I");
            url = url.Replace("ı", "i");
            url = url.Replace("ğ", "g");
            url = url.Replace("Ğ", "G");
            url = url.Replace("ç", "c");
            url = url.Replace("Ç", "C");
            url = url.Replace("ö", "o");
            url = url.Replace("Ö", "O");
            url = url.Replace("ş", "s");
            url = url.Replace("Ş", "S");
            url = url.Replace("ü", "u");
            url = url.Replace("Ü", "U");
            url = url.Replace("'", "");
            url = url.Replace("\"", "");

            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();

            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (url.Contains(strChr))
                {
                    url = url.Replace(strChr, string.Empty);
                }
            }
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            url = r.Replace(url, "-");
            while (url.IndexOf("--") > -1)
                url = url.Replace("--", "-");
            return url;
        }

        public static string TurkishCharReplace(this string pString)
        {
            pString = pString.Replace("&Ccedil;", "Ç");
            pString = pString.Replace("&ccedil;", "ç");
            pString = pString.Replace("&#231;", "ç");
            pString = pString.Replace("&#199;", "Ç");
            pString = pString.Replace("&#286;", "Ğ");
            pString = pString.Replace("&#287;", "ğ");
            pString = pString.Replace("&#304;", "İ");
            pString = pString.Replace("&#305;", "ı");
            pString = pString.Replace("&Ouml;", "Ö");
            pString = pString.Replace("&#214;", "Ö");
            pString = pString.Replace("&ouml;", "ö");
            pString = pString.Replace("&#246;", "ö");
            pString = pString.Replace("&#350;", "Ş");
            pString = pString.Replace("&#351;", "ş");
            pString = pString.Replace("&Uuml;", "Ü");
            pString = pString.Replace("&#220;", "Ü");
            pString = pString.Replace("&uuml;", "ü");
            pString = pString.Replace("&#252;", "ü");
            pString = pString.Replace("&nbsp;", " ");

            return pString;
        }

        public static string HtmlToPlainText(this string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }
    }
}
