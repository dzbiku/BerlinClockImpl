using System;

namespace BerlinClock.Classes
{
    public interface IBerlinClockLamps
    {
        string SwitchOnOffLampsInRowAndSetCorrectState(int onStateInLamps, int numberOfLampsInRow, bool onlyRedLampsInRow);
        string ReturnClockState();
    }
}
