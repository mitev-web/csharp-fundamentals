using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phone
{
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
}
