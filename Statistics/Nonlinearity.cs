using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using ZedGraph;
using Utils.SignalGenerator;

namespace Utils.Statistics
{
    public static class Nonlinearity
    {
        static double Distance(PointPair p1, PointPair p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        static int GetSingOfDistance(PointPair point, double k, double b)
        {
            //визначає з якої сторони прямої знаходиться точка

            return Math.Sign(point.Y - (k * point.X + b));

        }
        public static PointPairList CalculateStatisticalUnLinearities(List<int> track,int minCode, int maxCode,ref double inl)
        {
            var result = new PointPairList();

            var trackArray=track.ToArray<int>();
            FixTrack(track,minCode,maxCode);

            double theoreticalProbabilityOfCode = track.Count / (maxCode - minCode);

            foreach(var code in track)
            {
                var hitsOfCode=MasFunctions.HowNanyInThisInterval(code, code, trackArray);
                var dnl = (hitsOfCode / theoreticalProbabilityOfCode) - 1;
                inl += dnl;
                result.Add(code, dnl);
            }

            return result;
        }

        private static void FixTrack(List<int> track, int minCode, int maxCode)
        {
            track.RemoveAll(code => code == minCode);
            track.RemoveAll(code => code == maxCode);
        }
        public static PointPairList[] CalculateIntegralUnLinearity(PointPairList graphArraysWithOutCalibration, PointPairList graphArraysWithCalibration)
        {
            PointPairList[] res = new PointPairList[2];
            res[0] = CalculateIntegralUnLinearity(graphArraysWithOutCalibration);
            res[1] = CalculateIntegralUnLinearity(graphArraysWithCalibration);
            return res;
        }
        public static PointPairList CalculateIntegralUnLinearity(PointPairList outputSignal)
        {
            PointPairList listOfAdcSignal = outputSignal;

            PointPair p1 = listOfAdcSignal[0];
            PointPair p2 = listOfAdcSignal[listOfAdcSignal.Count - 1];
            double k=(p2.Y-p1.Y)/(p2.X-p1.X);
            double b=(p1.Y*(p1.X-p2.X)-p1.X*(p1.Y-p2.Y))/(p2.X-p1.X);
            YkxGenerator gen = new YkxGenerator(new LineParametrs(k, b));

            PointPairList res = new PointPairList();

            foreach (PointPair item in listOfAdcSignal)
            {
                PointPair pLine=new PointPair(item.X,gen.GetY(item.X));
                double d = Distance(item, pLine) * Math.Cos(Math.Atan(gen.param.k));

                if (GetSingOfDistance(item, k, b) < 0)
                {
                    d *= -1;
                }

                res.Add(item.X, d);
            }
            return res;
        }
        public static PointPairList[] CalculateDifferentialUnLinearity(PointPairList graphArraysWithOutCalibration, PointPairList graphArraysWithCalibration)
        {
            PointPairList[] res=new PointPairList[2];
            res[0] = CalculateDifferentialUnLinearity(graphArraysWithOutCalibration);
            res[1] = CalculateDifferentialUnLinearity(graphArraysWithCalibration);
            return res;
        }
        public static PointPairList CalculateDifferentialUnLinearity(PointPairList graphArrays)
        {
            PointPairList listOfAdcSignal = graphArrays;
            PointPairList res = new PointPairList();

            int i=0;
            while(i<listOfAdcSignal.Count-2)
            {
                double d = Math.Abs(listOfAdcSignal[i + 2].Y - listOfAdcSignal[i].Y);
                //Console.WriteLine(Math.Abs(listOfAdcSignal[i + 2].Y - listOfAdcSignal[i].Y));
                i += 2;
                res.Add(listOfAdcSignal[i].X, d);
            }
            //Console.WriteLine("///////////////////////////////////////////");
            return res;
        }
    }
}
