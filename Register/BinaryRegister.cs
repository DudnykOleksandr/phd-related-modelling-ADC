using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;

namespace PFI.RegisterDevice
{
    public class BinaryRegister:Register
    {
        public BinaryRegister(NotationSystem notSystem)
            : base(notSystem)
        { }
        public BinaryRegister(int n)
            : base(n)
        { }

        #region Add(Dec) not calibrated region

        public override int[] AddOne()
        {
            if (!isMaxValueInRegister())
            {
                for (int i = 0; i < polinom.Length; i++)
                {
                    if (polinom[i] == 0)
                    {
                        polinom[i] = 1;
                        break;
                    }
                    else
                        polinom[i] = 0;
                }
                return polinom;
            }
            else
            {
                this.SetPolinomNull();
                return this.polinom;
            }
        }
        public override int[] DecOne()
        {
            if (!isNullValueInRegister())
            {
            for (int i = 0; i < polinom.Length; i++)
            {
                if (polinom[i] == 1)
                {
                    polinom[i] = 0;
                    break;
                }
                else
                    polinom[i] = 1;
            }
            return polinom;
            }
            else
                throw new Exception();
        }

        #endregion Add(Dec) not calibrated region

        #region Add(Dec) calibrated region

        public override int[] AddOneCalibrated()
        {
            throw new NotImplementedException();
        }
        public override int[] DecOneCalibrated()
        {
            throw new NotImplementedException();
        }
        #endregion Add(Dec) calibrated region

        public int GetBinaryValue()
        {
            int res=0;
            for (int i = 0; i < polinom.Length; i++)
            {
                res += polinom[i] * (int)Math.Pow(2, i);
            }
            return res;
        }
        public override Register Clone()
        {
            Register reg = new BinaryRegister(this.n);
            this.polinom.CopyTo(reg.polinom, 0);
            return reg;
        }
        public override bool isMaxValueInRegister()
        {
            for (int i = 0; i < polinom.Length; i++)
            {
                if (polinom[i] == 0)
                    return false;
            }
            return true;
        }
        public override bool isNullValueInRegister()
        {
            for (int i = 0; i < polinom.Length; i++)
            {
                if (polinom[i] == 1)
                    return false;
            }
            return true;
        }
    }
}
