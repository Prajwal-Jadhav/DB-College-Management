using System;

namespace DB_College_Management.Utils
{
    public static class Age
    {
        public static int Calculate(DateTime birthDay)
        {
            var currentYear = DateTime.Now.Year;

            var age = currentYear - birthDay.Year;

            return age;
        }
    }
}