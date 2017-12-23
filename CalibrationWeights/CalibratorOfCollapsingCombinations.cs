using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PFI.ADCConv;
using PFI.DAConv;
using PFI.SCHVN;
using PFI.RegisterDevice;
using Utils.RamDevice;
using Utils.BinaryToSchvnCodeConverter;

namespace Algorithm.CalibrationWeights
{
    public class CalibratorOfCollapsingCombinations
    {
        ADC adcInst;
        SCHVNRegister registerUnCollapsed;

        public CalibratorOfCollapsingCombinations(ADC adcInst)
        {
            this.adcInst = adcInst;
            registerUnCollapsed = (SCHVNRegister)this.adcInst.reg.Clone();
            registerUnCollapsed.SetPolinomNull();

            registerUnCollapsed.AddBitValue(0, 1);
            registerUnCollapsed.AddBitValue(1, 1);

        }
        public void CalibrateCollapsingCombinations()
        {
            RAM.CollapsingCombinations.ClearCollapsingCombinations();

            do
            {
                var valueInReg = this.adcInst.dac.ZnachenyaC(registerUnCollapsed);

                var registerCollapsed = this.adcInst.ConvertBySARMethod(valueInReg);

                RAM.CollapsingCombinations.AddCollapsingCombination((int[])registerCollapsed.polinom.Clone(), (int[])registerUnCollapsed.polinom.Clone());
            }
            while (NextValueOfRegister());

        }
        bool NextValueOfRegister()
        {
            for (int i = 0; i < registerUnCollapsed.polinom.Length; i++)
            {
                if (registerUnCollapsed.polinom[i] == 1)
                {
                    if (i + 2 != registerUnCollapsed.polinom.Length)
                    {
                        registerUnCollapsed.polinom[i] = 0;
                        registerUnCollapsed.polinom[i+2] = 1;

                        return true;
                    }
                }
            }
            return false;
        }
    }

}
