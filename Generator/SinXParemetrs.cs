using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.SignalGenerator
{
    public class SinXParemetrs : SignalParametrs
    {
        public double k {get;private set;}
        public double b { get; private set; }
        public double z { get; private set; }
        public SinXParemetrs(double k, double b, double z)
        {
            this.b = b;
            this.k = k;
            this.z = z;
        }
    }
}
