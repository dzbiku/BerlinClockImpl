using System;
using System.Collections.Generic;

namespace BerlinClock.Classes
{
    public class BerlinClockLamps : IBerlinClockLamps
    {
        internal int Hours;
        internal int Minutes;
        internal int Seconds;
        private string _singleRowsSate;
        private string _sFinalStateOfClock;
        readonly Dictionary<string, string> _lampState = new Dictionary<string, string>()
        {
            {"Red", "R"},
            {"Yellow", "Y"},
            {"Off", "O"}
        };

        public BerlinClockLamps(string inputTime)
        {
            if(inputTime.SplitOn()[0] >24 || inputTime.SplitOn()[0] < 0)
                throw new ArgumentOutOfRangeException(nameof(Hours));
            if (inputTime.SplitOn()[1] > 59 || inputTime.SplitOn()[1] < 0)
                throw new ArgumentOutOfRangeException(nameof(Minutes));
            if (inputTime.SplitOn()[2] > 59 || inputTime.SplitOn()[2] < 0)
                throw new ArgumentOutOfRangeException(nameof(Seconds));
            Hours = inputTime.SplitOn()[0];
            Minutes = inputTime.SplitOn()[1];
            Seconds = inputTime.SplitOn()[2];
        }
        
        #region Lamp State On/Off
        public string SwitchOnOffLampsInRowAndSetCorrectState(int onStateInLamps, int numberOfLampsInRow, bool onlyRedLampsInRow)
        {
            _singleRowsSate = String.Empty;
            SingleRowStateOn(onStateInLamps, numberOfLampsInRow, onlyRedLampsInRow);
            SingleRowStateOff(numberOfLampsInRow - onStateInLamps);
            return _singleRowsSate;
        }

        private void SingleRowStateOn(int onStateInLamps, int numberOfLampsInRow, bool onlyRedLampsInRow)
        {
            for (int i = 1; i < onStateInLamps + 1; i++)
            {
                if ((numberOfLampsInRow > 4 && i % 3 == 0) || onlyRedLampsInRow)
                    _singleRowsSate += _lampState["Red"];
                else
                    _singleRowsSate += _lampState["Yellow"];
            }
        }

        private void SingleRowStateOff(int offStateLampsInRowCount)
        {
            for (int i = 0; i < offStateLampsInRowCount; i++)
                _singleRowsSate += _lampState["Off"];
        }
        #endregion

        #region Fill entire rows in Clock
        private void SetHourRows()
        {
            _sFinalStateOfClock += '\n' + SwitchOnOffLampsInRowAndSetCorrectState(Hours / 5, 4, true);
            _sFinalStateOfClock += '\n' + SwitchOnOffLampsInRowAndSetCorrectState(Hours % 5, 4, true);
        }
        private void SetMinutesRows()
        {
            _sFinalStateOfClock += '\n' + SwitchOnOffLampsInRowAndSetCorrectState(Minutes / 5, 11, false);
            _sFinalStateOfClock += '\n' + SwitchOnOffLampsInRowAndSetCorrectState(Minutes % 5, 4, false);
        }
        private void SetMinutesRow()
        {
            _sFinalStateOfClock = Seconds % 2 == 0 ? "Y" : "O";
        }
        #endregion

        public string ReturnClockState()
        {
            SetMinutesRow();
            SetHourRows();
            SetMinutesRows();
            return _sFinalStateOfClock;
        }
    }
}
