using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Odev.Domain.Helpers
{
    public class SiteLanguages
    {
        public static List<Language> AvailableLanguage => new List<Language>
        {
            new Language { LangFullName = "tr-TR", LangCultureName = "tr-TR" },
            new Language { LangFullName = "en", LangCultureName = "en" },
            new Language { LangFullName = "fr", LangCultureName = "fr" },
        };

        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguage.Where(x => x.LangFullName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguage[0].LangCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                {
                    lang = GetDefaultLanguage();
                }
                else
                {
                    var cultureInfo = new CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                    HttpCookie langCookie = new HttpCookie("culture", lang);
                    langCookie.Expires = DateTime.Now.AddYears(1);
                    HttpContext.Current.Response.Cookies.Add(langCookie);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class Language
    {
        public string LangFullName { get; set; }
        public string LangCultureName { get; set; }
    }
}