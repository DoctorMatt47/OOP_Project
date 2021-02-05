using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextWave.Domain.Extensions
{
    public static class StringExtension
    {
        public static string CleanOfNonDigits(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            string cleaned = new string(str.Where(x=> char.IsDigit(x) || x == '.').ToArray());
            return cleaned;
        }

        public static string CutOffEnd(this string str, int countOfChars)
        {
            if (string.IsNullOrEmpty(str)) return str;
            string cleaned = new string(str.Substring(0, str.Length - countOfChars).ToArray());
            return cleaned;
        }

    }
}
