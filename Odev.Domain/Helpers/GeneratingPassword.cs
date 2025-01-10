using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Helpers
{
    public static class GeneratingPassword
    {
        public static string CreatePassword(int size)
        {
            char[] cr = "0123456789ABCÇDEFGĞHIİJKLMNOÖPQRSTUÜCWXYZabcçdefgğhıijklmnoöpqrstuücwxyz.".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                result += cr[r.Next(0, cr.Length - 1)].ToString();
            }

            return result;
        }
    }
}