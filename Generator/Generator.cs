using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.SignalGenerator
{
    public abstract class Generator
    {
        public abstract double GetY(double x);
    }
}
