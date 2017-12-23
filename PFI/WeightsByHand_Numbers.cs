using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFI.SCHVN
{
    public static class WeightsByHand_Numbers
    {
        static private bool WeightsByHand_flag;
        static private double[] WeightsByHand;
        static int BitQuat;

        static public void SetBitQuatity(int n)
        {
            if (BitQuat != n)
            {
                WeightsByHand_flag = false;
                WeightsByHand = new double[n];
                BitQuat = n;
            }
        }
        static public bool Get_Flag()
        {
            return WeightsByHand_flag;
        }
        static public void Set_Flag()
        {
            WeightsByHand_flag=true;
        }
        static public void Reset_Flag()
        {
            WeightsByHand_flag = false;
        }
        static public void Reset_Weights()
        {
            for (int i = 0; i < BitQuat; i++)
                WeightsByHand[i] = 0;
        }
        static public bool Set_Weights(double [] mas)
        { 
            for (int i = 0; i < mas.Length; i++)
                WeightsByHand[i] = mas[i];
            Set_Flag();
            return true;
        }
        static public double[] Get_Weights()
        {
            return WeightsByHand;
        }
    }
}
