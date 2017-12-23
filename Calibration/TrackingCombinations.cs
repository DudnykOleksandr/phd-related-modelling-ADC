using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Calibration
{
    class TrackingCombinations
    {

        void CalibrateTrackingCombinations()
        {
            RAM.TrackingCombinations.ClearCletchingCombinations();
            this.reg.SetPolinomNull();

            for (int ik = 0; !this.reg.isMaxValueInRegister(); ik++)
            {
                RAM.TrackingCombinations.AddCombination(reg.polinom.Clone() as int[]);
                this.reg.AddOne();
            }

        }
        public int[] Convert(BinaryRegister binaryReg)
        {
            this.reg.SetPolinomNull();

            double signal = ZnachenyaIBinary(binaryReg);

            for (int ik1 = this.reg.n - 1; ik1 >= 0; ik1--)
            {
                if (ZnachenyaC(this.reg.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    this.reg.AddBitValue(ik1, 0);
            }
            return this.reg.polinom;
        }
        public double ZnachenyaC(Register reg)
        {
            double ekv = 0;
            for (int i = this.reg.n - 1; i >= 0; i--)
            {
                ekv += reg.polinom[i] * RAM.Weights.calibratedWeights[i];
            }
            return ekv;
        }
        public double ZnachenyaIBinary(BinaryRegister reg)
        {
            double ekv = 0;
            for (int i = this.reg.binarySys.n - 1; i >= 0; i--)
            {
                ekv += reg.polinom[i] * this.reg.binarySys.ideal[i];
            }
            return ekv;
        }
    }
}
