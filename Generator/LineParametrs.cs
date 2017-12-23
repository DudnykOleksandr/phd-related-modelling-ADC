using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.SignalGenerator
{
    public class LineParametrs : SignalParametrs
    {
        public double k {get;private set;}
        public double b { get; private set; }
        public LineParametrs(double k, double b)
        {
            this.b = b;
            this.k = k;
        }
    }
}
