using System;

namespace Framework.Application
{
    public static class Date
    {
        public static string[] MonthNames =
            {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"};

        public static string[] DayNames = {"شنبه", "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه"};
        public static string[] DayNamesG = {"یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه"};


        public static string ToFarsi(this DateTime? date)
        {
            try
            {
                if (date != null) return date.Value.ToFarsi();
            }
            catch (Exception)
            {
                return "";
            }

            return "";
        }

        public static string ToFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new System.Globalization.PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";

        }

        public static string GetTime(this DateTime date)
        {
            return $"_{date.Hour:00}_{date.Minute:00}_{date.Second:00}";
        }

        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new System.Globalization.PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }

        public static string ToFarsi(this DateTime date, DateConvertType convertDate)
        {
            var pc = new System.Globalization.PersianCalendar();
            return convertDate == DateConvertType.Short
                ? $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}"
                : $"{DayNamesG[(int) pc.GetDayOfWeek(date)]} {pc.GetDayOfMonth(date)} {MonthNames[pc.GetMonth(date) - 1]} {pc.GetYear(date)}";
        }

        public static string ToFarsi(this DateTime date, DateConvertType convertDate, DateAndTimeConvertType dateTime)
        {
            var pc = new System.Globalization.PersianCalendar();

            switch (dateTime)
            {
                case DateAndTimeConvertType.Date:
                    if (convertDate == DateConvertType.Short)
                        return
                            $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
                    else
                        return
                            $"{DayNamesG[(int) pc.GetDayOfWeek(date)]} {pc.GetDayOfMonth(date)} {MonthNames[pc.GetMonth(date)]} {pc.GetYear(date)}";


                case DateAndTimeConvertType.Time:
                    if (convertDate == DateConvertType.Short)
                        return date.TimeOfDay.ToString();
                    else
                        return string.Format("ساعت {4}:{5} {6}", date.TimeOfDay.Hours, date.TimeOfDay.Minutes,
                            date.TimeOfDay.TotalHours > 12 ? "عصر" : "صبح");
                case DateAndTimeConvertType.Both:
                    if (convertDate == DateConvertType.Short)
                        return
                            $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.TimeOfDay.ToString()}";
                    else
                        return
                            $"{DayNamesG[(int) pc.GetDayOfWeek(date)]} {pc.GetDayOfMonth(date)} {MonthNames[pc.GetMonth(date)]} {pc.GetYear(date)} ساعت {date.TimeOfDay.Hours}:{date.TimeOfDay.Minutes} {(date.TimeOfDay.TotalHours > 12 ? "عصر" : "صبح")}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime, null);
            }
        }

        private static readonly string[] Pn = {"۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹"};
        private static readonly string[] En = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public static string ToEnglishNumber(this string strNum)
        {
            var cash = strNum;
            for (var i = 0; i < 10; i++)
                cash = cash.Replace(Pn[i], En[i]);
            return cash;
        }

        public static string ToPersianNumber(this int intNum)
        {
            var chash = intNum.ToString();
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(En[i], Pn[i]);
            return chash;
        }

        public static DateTime? FromFarsiDate(this string InDate)
        {
            if (string.IsNullOrEmpty(InDate))
                return null;

            var spited = InDate.Split('/');
            if (spited.Length < 3)
                return null;

            if (!int.TryParse(spited[0].ToEnglishNumber(), out var year))
                return null;

            if (!int.TryParse(spited[1].ToEnglishNumber(), out var month))
                return null;

            if (!int.TryParse(spited[2].ToEnglishNumber(), out var day))
                return null;
            var c = new System.Globalization.PersianCalendar();
            return c.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
    }
}