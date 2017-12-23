using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;
using Utils.RamDevice;
namespace PFI.RegisterDevice
{
    public class SCHVNRegister : Register
    {
        BinaryRegister binaryReg;
        public NotationSystem binarySys { get; private set; }
        NotationSystem schvnSys;
        int CollapsingNumberOfBits;

        public SCHVNRegister(NotationSystem notSystem)
            : base(notSystem)
        {
            this.schvnSys = notSystem;
            double binaryNDouble = Math.Log(notSystem.alpha, Math.E) * this.n / Math.Log(2, Math.E);
            int binaryNInt = (int)Math.Ceiling(binaryNDouble);

            this.Diapason = Math.Pow(2, binaryNDouble) - 1;

            binarySys = new NotationSystem(binaryNInt, 2, 0);
            binaryReg = new BinaryRegister(binarySys);

            CollapsingNumberOfBits = GetCollapsingNumberOfBits();

        }
        private int GetCollapsingNumberOfBits()
        {
            double sum = 0;
            int collapsingNumberOfBits=-1;
            for (int i = 0; i < polinom.Length-1; i++)
            {
                sum += schvnSys.ideal[i];
                if(Math.Round(sum,2)==Math.Round(schvnSys.ideal[i+1],2))
                {
                    collapsingNumberOfBits=i+1;
                    break;
                }
            }
            return collapsingNumberOfBits;
        }

        #region Add(Dec) calibrated region

        public override int[] AddOneCalibrated()
        {
            binaryReg.AddOne();
            this.SetPolinom(RAM.TrackingCombinations.GetCombination(binaryReg.GetBinaryValue()));
            return this.polinom;
        }
        public override int[] DecOneCalibrated()
        {
            binaryReg.DecOne();
            this.SetPolinom(RAM.TrackingCombinations.GetCombination(binaryReg.GetBinaryValue()));
            return this.polinom;
        }

        #endregion Add(Dec) calibrated region

        #region Add(Dec) not calibrated region

        public override int[] AddOne()
        {
            int i = 0;

            do
            {
                if (polinom[i] == 0)
                {
                    polinom[i] = 1;
                    break;
                }
                else if (polinom[i + 1] == 0)
                {
                    polinom[i + 1] = 1;
                    polinom[i] = 0;
                    break;
                }
                else
                {
                    CollapsePolinom();
                }
            }
            while (true);

            return this.polinom;
        }
        private void CollapsePolinom()
        {
            CollapseNewMethod();
            return;

            if (CollapsingNumberOfBits == -1)
            {
                throw new Exception();
            }
            else
            {
                int numberOfOnes = 0;
                for (int indexFirst = 0; indexFirst < polinom.Length-1; indexFirst++)
                {
                    if (polinom[indexFirst] == 1)
                    {
                        numberOfOnes++;
                        if (numberOfOnes == CollapsingNumberOfBits)
                        {
                            this.polinom[indexFirst + 1] = 1;
                            for (int indexBack = indexFirst; indexBack > indexFirst - CollapsingNumberOfBits; indexBack--)
                            {
                                polinom[indexBack] = 0;
                            }
                            break;
                            //CollapsePolinom();
                        }
                    }
                    else
                    {
                        numberOfOnes = 0;
                    }
                }
                //return;
            }
        }
        void CollapseNewMethod()
        {
            var ekv = RegZnachenyaC(this);

            this.SetPolinomNull();

            for (int ik1 = this.n - 1; ik1 >= 0; ik1--)
            {
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                if (RegZnachenyaC(this.AddBitValue(ik1, 1)) <= ekv)
                { }
                else
                    this.AddBitValue(ik1, 0);
            }
        }
        double RegZnachenyaC(Register reg)
        {
            double ekv = 0;
            for (int i = this.n - 1; i >= 0; i--)
            {
                ekv += reg.polinom[i] * RAM.Weights.calibratedWeights[i];
            }
            return ekv;
        }
        public override int[] DecOne()
        {
            bool isDecremented = false;
            while (!isDecremented)
            {
                for (int i = 0; i < this.polinom.Length; i++)
                {
                    if (this.polinom[i] == 1)
                    {
                        if (i == 0)
                        {
                            this.polinom[i] = 0;
                            isDecremented = true;
                            break;
                        }
                        if (i == 1)
                        {
                            this.polinom[i] = 0;
                            this.polinom[i - 1] = 1;
                            isDecremented = true;
                            break;
                        }
                        UCollapse(i);
                        break;
                    }
                }
            }

            return this.polinom;
        }
        private bool TestForUnCollapse(int numberOfBit)
        {
            if (this.polinom[numberOfBit] == 1)
            {
                for (int i = numberOfBit - 1; i >= numberOfBit - CollapsingNumberOfBits; i--)
                {
                    if (polinom[i] != 0)
                        return false;
                }
            }
            return true;
        }
        public void UCollapse(int numberOfBit)
        {
            if (TestForUnCollapse(numberOfBit))
            {
                this.polinom[numberOfBit] = 0;
                for (int i = numberOfBit - 1; i >= numberOfBit - CollapsingNumberOfBits; i--)
                {
                    polinom[i] = 1;
                }
            }
        }

        #endregion Add(Dec) not calibrated region


        public override void SetPolinomNull()
        {
            binaryReg.SetPolinomNull();
            for (int i = 0; i < polinom.Length; i++)
                polinom[i] = 0;
        }
        public override Register Clone()
        {
            Register reg = new SCHVNRegister(schvnSys);
            this.polinom.CopyTo(reg.polinom, 0);
            return reg;
        }
        public override bool isMaxValueInRegister()
        {
            return binaryReg.isNullValueInRegister();
        }
        public override bool isNullValueInRegister()
        {
            return binaryReg.isNullValueInRegister();
        }
    }
}
