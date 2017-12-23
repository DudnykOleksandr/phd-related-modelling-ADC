using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.SignalGenerator
{
    public class AnalogSignal
    {
        double currentX;
        Generator gen;
        public AnalogSignal(TypesOfSignalEnum type_of_signal, SignalParametrs signalParam)
        {
            currentX = 0.0;

            switch (type_of_signal)
            {
                case TypesOfSignalEnum.KxB:
                    gen = new YkxGenerator(signalParam);
                    break;
                case TypesOfSignalEnum.SinX:
                    gen = new SinXGenerator(signalParam);
                    break;
                default:
                    break;
            }


        }
        public double NextValue()
        {
            double res = gen.GetY(currentX);
            currentX++;
            return res;
        }
        public void Reset()
        {
            currentX = 0.0;
        }

    }
}
