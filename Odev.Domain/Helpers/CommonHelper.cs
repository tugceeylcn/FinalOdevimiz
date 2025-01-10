using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Odev.Domain.Helpers
{
    public static class CommonHelper
    {
        /// <summary>The mask credit card.</summary>
        /// <param name="cardNumber">The card number. </param>
        /// <returns>The <see cref="string"/>. </returns>
        public static string MaskCreditCard(string cardNumber)
        {
            return (!string.IsNullOrEmpty(cardNumber) && cardNumber.Length >= 15)
                       ? string.Format(
                           "{0}{1}{2}{3}",
                           cardNumber.Substring(0, 4),
                           cardNumber.Substring(4, 2),
                           string.Empty.PadLeft(cardNumber.Length - 10, '*'),
                           cardNumber.Substring(cardNumber.Length - 4))
                       : string.Empty;
        }

        /// <summary> The get credit card bin number. </summary>
        /// <param name="cardNumber"> The card number. </param>
        /// <param name="len"> The len. </param>
        /// <returns> The <see cref="string"/>. </returns>
        public static string GetCreditCardBinNumber(string cardNumber, int len)
        {
            return string.IsNullOrEmpty(cardNumber) ? string.Empty : cardNumber.Substring(0, len);
        }

        /// <summary>The get bin.</summary>
        /// <param name="maskCardNumber">The mask card number. </param>
        /// <returns>The <see cref="string"/>. </returns>
        public static string GetBin(this string maskCardNumber)
        {
            return (!string.IsNullOrEmpty(maskCardNumber) && maskCardNumber.Length > 7) ? maskCardNumber.Substring(0, 6) : string.Empty;
        }

        /// <summary>The repeat.</summary>
        /// <param name="text">The text. </param>
        /// <param name="level">The level. </param>
        /// <returns>The <see cref="string"/>. </returns>
        public static string Repeat(string text, int level)
        {
            if (level == 0)
            {
                return string.Empty;
            }

            var retval = new StringBuilder();

            for (int i = 0; i < level; i++)
            {
                retval.Append(text);
            }

            return retval.ToString();
        }

        /// <summary>The to mobile format.</summary>
        /// <param name="source">The source. </param>
        /// <returns>The <see cref="string"/>. </returns>
        public static string ToMobileFormat(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            source = source.Replace(" ", string.Empty);
            string result = "+90 (";
            if (source.StartsWith("0"))
            {
                source = source.Substring(1, source.Length - 1);
            }

            result += source.Substring(0, 3) + ") - ";
            result += source.Substring(3, 3) + " - ";
            result += source.Substring(6, 4);

            return result;
        }

        /// <summary> The clear masked phone number.  </summary>
        /// <param name="phoneNumber"> The phone number.  </param>
        /// <param name="length"> The length. </param>
        /// <param name="startFromBegin"> The start From Begin. </param>
        /// <returns> The <see cref="string"/>.  </returns>
        public static string ClearMaskedPhoneNumber(string phoneNumber, int length = 10, bool startFromBegin = false)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return null;
            }

            const string Pattern = @"^(\+)|\D";
            const RegexOptions Options = RegexOptions.Multiline;
            var regex = new Regex(Pattern, Options);
            var regres = regex.Replace(phoneNumber, string.Empty);

            if (regres.Length > length)
            {
                if (startFromBegin)
                {
                    regres = regres.Substring(0, length);
                }
                else
                {
                    regres = regres.Substring(regres.Length - length, length);
                }
            }

            if (string.IsNullOrWhiteSpace(regres))
            {
                return null;
            }

            return regres;
        }

        /// <summary>The ıs ıdentity number valid.</summary>
        /// <param name="identityNumber">The identity number.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsIdentityNumberValid(string identityNumber)
        {
            if (string.IsNullOrEmpty(identityNumber))
            {
                return true;
            }

            var returnvalue = false;
            try
            {
                if (identityNumber.Length == 11)
                {
                    var tcNo = long.Parse(identityNumber);

                    var atcNo = tcNo / 100;
                    var btcNo = tcNo / 100;

                    var c1 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c2 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c3 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c4 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c5 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c6 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c7 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c8 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var c9 = atcNo % 10;
                    atcNo = atcNo / 10;
                    var q1 = (10 - ((((c1 + c3 + c5 + c7 + c9) * 3) + (c2 + c4 + c6 + c8)) % 10)) % 10;
                    var q2 = (10 - (((((c2 + c4 + c6 + c8) + q1) * 3) + (c1 + c3 + c5 + c7 + c9)) % 10)) % 10;

                    returnvalue = (btcNo * 100) + (q1 * 10) + q2 == tcNo;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return returnvalue;
        }

        /// <summary>The get random string.</summary>
        /// <param name="size">The size. </param>
        /// <param name="isIntegerOnly">The is integer only. </param>
        /// <returns>The <see cref="string"/>. </returns>
        public static string GetRandomString(int size, bool isIntegerOnly = false)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (isIntegerOnly)
            {
                chars = "0123456789";
            }

            var random = new Random();
            var sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }

            return sb.ToString();
        }

        /// <summary>The is valid date.</summary>
        /// <param name="year">The year. </param>
        /// <param name="month">The month. </param>
        /// <param name="day">The day. </param>
        /// <returns>The <see cref="bool"/>. </returns>
        public static bool IsValidDate(int year, int month, int day)
        {
            if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            return day > 0 && day <= DateTime.DaysInMonth(year, month);
        }

        /// <summary>Verifies that a string is in valid e-mail format</summary>
        /// <param name="email">Email to verify</param>
        /// <returns>true if the string is a valid e-mail address and false if it's not</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            email = email.Trim();
            bool result = Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return result;
        }

        /// <summary> The clear masked phone number only number.  </summary>
        /// <param name="phoneNumber"> The phone number.  </param>
        /// <param name="length"> The length. </param>
        /// <param name="startFromBegin"> The start From Begin. </param>
        /// <returns> The <see cref="string"/>.  </returns>
        public static string ClearMaskedOnlyNumber(string phoneNumber, int length = 20, bool startFromBegin = false)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return null;
            }

            const string Pattern = @"[^0-9]";
            var regres = Regex.Replace(phoneNumber, Pattern, string.Empty);

            if (regres.Length > length)
            {
                if (startFromBegin)
                {
                    regres = regres.Substring(0, length);
                }
                else
                {
                    regres = regres.Substring(regres.Length - length, length);
                }
            }

            return regres;
        }
    }
}
