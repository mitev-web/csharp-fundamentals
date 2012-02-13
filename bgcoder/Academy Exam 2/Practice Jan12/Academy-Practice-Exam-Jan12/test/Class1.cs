using System;
using System.Collections.Generic;
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

    class Call
    {
        public DateTime CallDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string DialedPhone { get; set; }

        public Call(DateTime callDate, TimeSpan duration, string dialedPhone)
        {
            this.CallDate = callDate;
            this.Duration = duration;
            this.DialedPhone = dialedPhone;
        }
    }

    class Display
    {
        public double size { get; set; }
        public uint numberColors { get; set; }

        public Display(double size)
        {
            this.size = size;
        }

        public Display(double size, uint numberColors)
        {
            this.size = size;
            this.numberColors = numberColors;
        }
    }

    class GSM
    {
        public string model { get; set; }
        public string manufacturer { get; set; }
        public decimal price { get; set; }
        public string owner { get; set; }
        public static string iphone4S = "this is expensive shit";
        private Display display { get; set; }
        private Battery battery { get; set; }
        public List<Call> CallHistory { get; set; }

        public GSM(string model, string manufacturer, decimal price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Display display, Battery battery)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.display = display;
            this.battery = battery;
        }

        public bool RemoveCall(Call call)
        {
            return CallHistory.Remove(call);
        }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public void ClearCallsHistory()
        {
            CallHistory.Clear();
        }

        public decimal TotalCallsPrice(decimal pricePerMinute)
        {
            TimeSpan time = new TimeSpan();

            foreach (Call c in CallHistory)
            {
                time += c.Duration;
            }

            return time.Minutes * pricePerMinute;
        }

        public string GetInfo()
        {
            string text = model + Environment.NewLine + this.manufacturer;
            return text;
        }

        public override string ToString()
        {
            string text = model + Environment.NewLine + this.manufacturer;
            return text;
        }

        class GSMCallHistoryTest
        {
            public GSMCallHistoryTest()
            {
                GSM gsm = new GSM("Galaxy S2", "Samsung");

                Call call1 = new Call(new DateTime(2012, 1, 22), new TimeSpan(0, 22, 30), "+35932423224");
                Call call2 = new Call(new DateTime(2012, 1, 23), new TimeSpan(0, 15, 11), "+35932413324");
                Call call3 = new Call(new DateTime(2012, 1, 24), new TimeSpan(0, 7, 30), "+3593243424");

                List<Call> callHistory = new List<Call>();
                callHistory.Add(call1);
                callHistory.Add(call2);
                callHistory.Add(call3);

                gsm.CallHistory = callHistory;

                Console.WriteLine(gsm.TotalCallsPrice(0.37M));

                //TODO:
                //Remove the longest call from the history and calculate the total price again.

                gsm.ClearCallsHistory();
            }
        }
    }

    class GSMTest
    {
        public GSMTest()
        {
            GSM[] gsms = { new GSM("Galaxy S2", "Samsung"), new GSM("Iphone 4S", "Apple"), new GSM("N95", "Nokia") };

            Console.WriteLine(GSM.iphone4S);

            foreach (var gsm in gsms)
            {
                Console.WriteLine(gsm.GetInfo());
            }
        }
    }
}