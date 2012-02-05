using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone
{
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
            CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Display display, Battery battery)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.display = display;
            this.battery = battery;
            CallHistory = new List<Call>();
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
    }
}