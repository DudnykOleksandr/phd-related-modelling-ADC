using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;

namespace PFI.RegisterDevice
{
    public abstract class Register
    {
        public int[] polinom { get; private set; }
        public int n { get; private set; }
        public double Diapason { get; protected set; }

        public Register(NotationSystem notSystem)
        {
            this.n = notSystem.n;
            polinom = new int[n];

            Diapason=Math.Pow(2, this.n) - 1;
        }
        public Register(int n)
        {
            this.n = n;
            polinom = new int[n];
        }
        public Register NegatePolinom()
        {
            for (int i = 0; i < polinom.Length; i++)
            {
                if (polinom[i] == 1)
                {
                    polinom[i] = 0;
                }
                else if (polinom[i] == 0)
                {
                    polinom[i] = 1;
                }
            }
            return this;
        }
        public Register NegatePolinom(int stopBit)
        {
            for (int i = 0; i <= stopBit; i++)
            {
                if (polinom[i] == 1)
                {
                    polinom[i] = 0;
                }
                else if (polinom[i] == 0)
                {
                    polinom[i] = 1;
                }
            }
            return this;
        }
        public string GetPolinom()
        {
            string res = "";
            for (int i = 0; i < polinom.Length; i++)
                res += polinom[polinom.Length - i - 1];
            return res;
        }
        public void SetPolinom(int[] value)
        {
            if (polinom.Length == value.Length)
                value.CopyTo(polinom, 0);
            else
                throw new Exception();
        }
        public Register AddBitValue(int bitNum, int value)
        {
            polinom[bitNum] = value;
            return this;
        }
        private void Zero()
        {
            for (int i = 0; i < n; i++)
                polinom[i] = 0;
        }
        public int[] IncPolinom()
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
        public int[] DecPolinom()
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
        public string polinomToString()
        {
            StringBuilder srt = new StringBuilder();
            for (int i = this.polinom.Length - 1; i >= 0; i--)
            {
                if (this.polinom[i] == 1)
                    srt.Append(1);
                else
                    srt.Append(0);

            }
            return srt.ToString();
        }
        public double GetDmax()
        {
            return this.Diapason;
        }
        public int GetNumberOfFirstBitWithOne()
        {
            for (int i = polinom.Length-1; i >=0; i--)
            {
                if (polinom[i] == 1)
                    return i;
            }
            return -1;
        }
        public virtual void SetPolinomNull()
        {
            for (int i = 0; i < polinom.Length; i++)
                polinom[i] = 0;
        }
        public abstract bool isMaxValueInRegister();
        public abstract bool isNullValueInRegister();
        public abstract int[] AddOne();
        public abstract int[] DecOne();
        public abstract int[] AddOneCalibrated();
        public abstract int[] DecOneCalibrated();
        public abstract Register Clone();


    }
}
