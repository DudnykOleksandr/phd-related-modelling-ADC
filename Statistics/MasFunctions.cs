using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Statistics
{
    public static class MasFunctions
    {
        public static double GetMin(double[] mas)
        {
            double res = mas[0];
            for (int i = 1; i < mas.Length; i++)
                if (mas[i] < res)
                    res = mas[i];
            return res;
        }
        public static double GetMax(double[] mas)
        {
            double res = mas[0];
            for (int i = 1; i < mas.Length; i++)
                if (mas[i] > res)
                    res = mas[i];
            return res;
        }
        public static double GetMaxAbs(double[] mas)
        {
            double res = mas[0];
            for (int i = 1; i < mas.Length; i++)
                if (Math.Abs(mas[i]) > res)
                    res = Math.Abs(mas[i]);
            return res;
        }
        public static int HowNanyInThisInterval(double First, double Second, double[] mas)
        {
            int res = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if ((mas[i] <= Second) && (mas[i] >= First))
                    res++;
            }
            return res;
        }
        public static int HowNanyInThisInterval(int First, int Second, int[] mas)
        {
            int res = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if ((mas[i] <= Second) && (mas[i] >= First))
                    res++;
            }
            return res;
        }
        static public double CalculateMean(double[] mas)
        {
            double res = 0, sum = 0;
            for (int i = 0; i < mas.Length; i++)
                sum += mas[i];
            res = sum / mas.Length;
            return res;
        }
        static public double CalculateVariation(double[] mas)
        {
            double mean = CalculateMean(mas);
            double res = 0, sum = 0;
            for (int i = 0; i < mas.Length; i++)
                sum += Math.Pow(mas[i] - mean, 2);
            res = Math.Sqrt(sum / (mas.Length - 1));
            return res;
        }
    }
}
