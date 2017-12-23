using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.SignalGenerator
{
    public class SinXGenerator:Generator
    {
        SinXParemetrs param;
        public SinXGenerator(SignalParametrs param)
        {
            this.param = param as SinXParemetrs;
        }
        override public double GetY(double x)
        {
            return param.z * (Math.Sin(param.k * x)+1) + param.b;
        }
    }
}
