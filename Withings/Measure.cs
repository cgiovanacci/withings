using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Withings
{
    public class Measure
    {
        public MeasureType type { get; set; }
        public long value { get; set; }
        public int unit { get; set; } // power of 10 to multiply the value by

    }

}

