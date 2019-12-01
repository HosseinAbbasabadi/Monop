using System;
using System.Linq;

namespace Framework.Application
{
    public enum DateConvertType
    {
        Short
    }

    public enum DateAndTimeConvertType
    {
        Date,
        Time,
        Both
    }

    public static class Tools
    {
        public static string GetJustDate(this DateTime date)
        {
            return $"{date.Year:0000}/{date.Day:00}/{date.Month:00}";
        }

        public static string ToFileName(this DateTime date)
        {
            return
                $"{date.Year.ToString():0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";
        }

        public static string Nums2Farsi(this string OriginalString)
        {
            var s = OriginalString;
            var rt = "";
            foreach (var t in s)
                if ("0123456789".Contains(t))
                    rt += (char) ((ushort) t - (ushort) '0' + (ushort) '۰');
                else
                    rt += t;

            return rt;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateSlug(this string phrase)
        {
            var randText = RandomString(5);
            var str = phrase; //phrase.RemoveAccent().ToLower();
            str = System.Text.RegularExpressions.Regex.Replace(str,
                @"[^a-z0-9\s-\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]", ""); // Remove all non valid chars          
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ")
                .Trim(); // convert multiple spaces into one space  
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
            return (string.IsNullOrEmpty(str) ? randText : str);
        }

        public static bool ValidateUrlXss(string inputParameter)
        {
            if (string.IsNullOrEmpty(inputParameter))
                return true;
            return !System.Text.RegularExpressions.Regex.IsMatch(inputParameter, @"(javascript:|<\s*script.*?\s*>)");
        }
    }
}