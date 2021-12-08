using System;

namespace CalculosPlusvalias.Infrastructure
{
    public static class StringExtensions
    {
        public static DateTime ToDateTimeFormatted(this string s, string format)
         => format switch
         {
             "dd/mm/yyyy" => ToDateTime(s.Split('/'), 2, 1, 0),
             "mm/dd/yyyy" => ToDateTime(s.Split('/'), 2, 0, 1),
             "yyyy/mm/dd" => ToDateTime(s.Split('/'), 0, 1, 2),
             "dd-mm-yyyy" => ToDateTime(s.Split('-'), 2, 1, 0),
             "mm-dd-yyyy" => ToDateTime(s.Split('-'), 2, 0, 1),
             "yyyy-mm-dd" => ToDateTime(s.Split('-'), 0, 1, 2),
             "dd.mm.yyyy" => ToDateTime(s.Split('.'), 2, 1, 0),
             "mm.dd.yyyy" => ToDateTime(s.Split('.'), 2, 0, 1),
             "yyyy.mm.dd" => ToDateTime(s.Split('.'), 0, 1, 2),
             _ => throw new ArgumentException($"Invalid format"),
         };

        private static DateTime ToDateTime(string[] splittedString, int yearIndex, int monthIndex, int dayIndex)
            =>  new DateTime(int.Parse(splittedString[yearIndex]), int.Parse(splittedString[monthIndex]), int.Parse(splittedString[dayIndex]));

        public static DateTime ToTime(this string s)
         => new DateTime();
    }
}
