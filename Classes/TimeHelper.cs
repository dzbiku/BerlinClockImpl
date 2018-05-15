using System;

namespace BerlinClock.Classes
{
    static class TimeHelper
    {
        public static int[] SplitOn(this string inputString)
        {
            var arrOfTimeText = inputString.Split(':');
            int[] arrOfTimeAfterParseToInt = Array.ConvertAll(arrOfTimeText, s => int.Parse(s));
            return arrOfTimeAfterParseToInt;
        }
    }
}
