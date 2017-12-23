using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.ADCConv;
using PFI.DAConv;
using PFI.SCHVN;
using PFI.RegisterDevice;
using Utils.RamDevice;

namespace Algorithms.CalibrationOfWeights
{
    class MethodOfCalibrationOfWeights
    {
        ADC adcInst;
        DAC dacInst;
        NotationSystem shchvnInst;
        public MethodOfCalibrationOfWeights(ADC adcInst)
        {
            this.adcInst = adcInst;
            this.dacInst = adcInst.dac;
            this.shchvnInst = adcInst.dac.schvn;

            RAM.InitRAM(shchvnInst);
        }
        public double GetAkal(int i)
        {

            return shchvnInst.GetBitIdeal(i) * (1 + shchvnInst.delta / 100);
        }
        void Calibrate()
        {
            int kilToch = shchvnInst.kilTochnux;

            for (int ik = kilToch; ik < shchvnInst.n; ik++)
            {
                double q1 = dacInst.ZnachenyaC(adcInst.SARAnalogSignal(GetAkal(ik)));
                double q2 = dacInst.ZnachenyaC(adcInst.SARAnalogSignal(GetAkal(ik),ik));
                RAM.SetCalibrated(ik, q2 - q1);
            }
        }
    }
}
