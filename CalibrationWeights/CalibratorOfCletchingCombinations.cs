using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.ADCConv;
using PFI.DAConv;
using PFI.SCHVN;
using PFI.RegisterDevice;
using Utils.RamDevice;

namespace Algorithm.CalibrationWeights
{
    public class CalibratorOfCletchingCombinations
    {
       ADC adcInst;
        //NotationSystem binarySys;
        //NotationSystem schvnSys;
        BinaryRegister binaryReg;

        public CalibratorOfCletchingCombinations(ADC adcInst)
        {
            this.adcInst = adcInst;
        }
        public void CalibrateCletchingCombinations()
        {
            RAM.CletchingCombinations.ClearCletchingCombinations();

            int kilToch = adcInst.dac.schvn.kilTochnux;

            for (int ik = kilToch; ik < adcInst.dac.schvn.n; ik++)
            {
                var valueLow=(int[])adcInst.ConvertBySARMethod(GetAkalLow(ik), ik).polinom.Clone();

                var valueHigh = (int[])adcInst.ConvertBySARMethod(GetAkalHigh(ik)).polinom.Clone();

                RAM.CletchingCombinations.AddCletchingCombination(valueHigh, valueLow);
            }
        }

        private double GetAkalLow(int i)
        {
            return RAM.Weights.calibratedWeights[i];
            //return this.adcInst.dac.schvn.real[i];
        }
        private double GetAkalHigh(int i)
        {
            return GetAkalLow(i) + GetAkalLow(0);
        }
    }
}
