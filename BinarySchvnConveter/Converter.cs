using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.RegisterDevice;
using PFI.SCHVN;
using PFI.DAConv;

namespace PFI.BinarySchvnConveter
{
    public class Converter
    {
        DAC bivaryDac;
        DAC shcvnDac;

        public Converter(NotationSystem binaryNotSyst, NotationSystem schvnNotSyst)
        {
            bivaryDac = new DAC(binaryNotSyst);
            shcvnDac = new DAC(schvnNotSyst);

        }
        public SCHVNRegister Convert(BinaryRegister regBinary)
        {
            SCHVNRegister regSchvn = RegisterFactory.Create(schvnNotSyst);

            double signal = bivaryDac.ZnachenyaI(regBinary);

            for (int ik1 = shcvnDac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                if (shcvnDac.ZnachenyaC(regSchvn.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    shcvnDac.AddBitValue(ik1, 0);
            }
            return regSchvn;
        }
    }
}
