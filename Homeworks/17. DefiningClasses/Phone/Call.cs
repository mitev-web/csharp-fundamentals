using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone
{
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
}
