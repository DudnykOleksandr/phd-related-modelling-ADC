using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.SignalGenerator
{
    public class YkxGenerator:Generator
    {
        public LineParametrs param { get; private set; }
        public YkxGenerator(SignalParametrs param)
        {
            this.param = param as LineParametrs;
        }
        override public double GetY(double x)
        {
            return param.k * x + param.b;
        }
    }
}
