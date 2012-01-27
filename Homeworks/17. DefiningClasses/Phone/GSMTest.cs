using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone
{
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
