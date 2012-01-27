using System;
using System.Linq;

namespace Phone
{
    class Battery
    {
        public enum BatteryType
        {
            LiIon,
            NiMH,
            NiCd,
        }
        public string model { get; set; }
        public TimeSpan hoursIdle { get; set; }
        public TimeSpan hoursTalk { get; set; }

        private BatteryType batteryType;

        public BatteryType TypeBattery
        {
            get
            {
                return batteryType;
            }
            set
            {
                batteryType = value;
            }
        }

        public Battery(string model, TimeSpan hoursIdle, TimeSpan hoursTalk, BatteryType batteryType, BatteryType typeBattery)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
            this.TypeBattery = typeBattery;
        }

        public Battery(string model, TimeSpan hoursIdle, TimeSpan hoursTalk)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public Battery(string model)
        {
            this.model = model;
        }
    }
}