using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.DeviationGenerator;


namespace PFI.SCHVN
{
    public class NotationSystem
    {

            public double alpha { get; private set; }
            public int n { get; private set; }
            public double[] ideal { get; private set; }
            public double[] real { get; set; }
            public int kilTochnux { get; private set; }

            public double delta { get; set; }
            GaussianRandom norm;
            bool weightByHands;

            public NotationSystem(int quantity, double alphaf, double delta1)
            {
                delta = delta1;
                n = quantity;
                alpha = alphaf;


                ideal = new double[n];
                real = new double[n];

                norm = new GaussianRandom();

                if (alphaf != -1.0)
                {
                    for (int i = 0; i < n; i++)
                        ideal[i] = Math.Pow(alpha, i);
                }
                else
                {
                    alpha = 1.618;
                    for (int i = 0; i < n; i++)
                        ideal[i] = Fibonachi.GetNFibonachi(i);
                }

                for (int i = 0; i < n; i++)
                    if (ideal[i] * delta / 100 < ideal[0] / 2)
                        kilTochnux++;

                weightByHands = false;
                ReCountRealWeigths();
            }
            public void SetRealWeigths(double[] mas)
            {
                mas.CopyTo(real, 0);
                weightByHands = true;
            }
            public bool ReCountRealWeigths()
            {
                if (!weightByHands)
                {
                    for (int i = 0; i < n; i++)
                    {
                        double po = norm.NextGaussian(0, 0.3);
                        real[i] = ideal[i] + ((po * delta * ideal[i]) / 100);
                    }
                }
                return !weightByHands;
            }
            public double GetBitIdeal(int i)
            {
                return ideal[i];
            }
            public double GetBitReal(int i)
            {
                return real[i];
            }
            public double GetMaxReal()
            {
                double ekv = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    ekv += real[i];
                }
                return ekv;
            }
            public double GetMaxIdeal()
            {
                double ekv = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    ekv += ideal[i];
                }
                return ekv;
            }
            public int GetNumberOfCombinations()
            {
                return Convert.ToInt32(Math.Pow(2, n));
            }
            
           
    }
}
