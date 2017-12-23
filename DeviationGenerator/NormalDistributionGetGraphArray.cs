using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Utils.DeviationGenerator
{
    public class NormalDistributionGetGraphArray
    {
        public PointPairList GetGraphArrayByParameters(double mean, double serkvad)
        {
            int k = 200;

            var PislyaCalibruvannyaX =new double[k];
            var PislyaCalibruvannyaY =new double[k];

            var myp = mean - 3.5F * serkvad;
            var ktoch = ((7 * serkvad) / k);
            for (int p = 0; p < k; p++)
            {
                PislyaCalibruvannyaX[p] = myp;
                PislyaCalibruvannyaY[p] = PNorm(myp, mean, serkvad);
                myp += ktoch;
            }

            return new PointPairList(PislyaCalibruvannyaX, PislyaCalibruvannyaY);
        }
        private double PNorm(double xx, double mean2, double SerKvadVidx2)
        {
            double mean = mean2;
            double SerKvadVidx = SerKvadVidx2;
            double x = xx;

            double step = (-Math.Pow(x - mean, 2) / (2 * Math.Pow(SerKvadVidx, 2)));
            double res = (1 / (SerKvadVidx * Math.Sqrt(2 * Math.PI))) * (Math.Pow(Math.E, step));
            // float res1 = (float)res*1000000;
            return res;

        }
    }
}
