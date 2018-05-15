using System;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private BerlinClockLamps _bClock;
        public string ConvertTime(string aTime)
        {
            _bClock = new BerlinClockLamps(aTime);
            return _bClock.ReturnClockState();
        }
    }
}