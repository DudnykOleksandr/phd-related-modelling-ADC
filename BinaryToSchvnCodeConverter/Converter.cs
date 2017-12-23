using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.RegisterDevice;
using PFI.SCHVN;
using PFI.DAConv;
using PFI.ADCConv;

// stanAlone version of BinaryToSchvn converter
// inside version you can find in SCHVNRegister class
namespace Utils.BinaryToSchvnCodeConverter
{
    public class Converter
    {
        DAC bivaryDac;
        DAC shcvnDac;
        SCHVNRegister regSchvn;

        public Converter(NotationSystem binaryNotSyst, NotationSystem schvnNotSyst)
        {
            bivaryDac = new DAC(binaryNotSyst);
            shcvnDac = new DAC(schvnNotSyst);
            regSchvn = RegisterFactory.Create(schvnNotSyst) as SCHVNRegister;

        }
        public SCHVNRegister ConvertI(BinaryRegister regBinary)
        {
            // цей метод не може бути замінений ADC.SARAnalogSignal(...
            // оскільки оперує чисто цифровими значеннями ваг розрядів 
            regSchvn.SetPolinomNull();
            double signal = bivaryDac.ZnachenyaI(regBinary);

            for (int ik1 = shcvnDac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                if (shcvnDac.ZnachenyaI(regSchvn.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    regSchvn.AddBitValue(ik1, 0);
            }

            return regSchvn;
        }
        public SCHVNRegister ConvertC(BinaryRegister regBinary)
        {
            // цей метод не може бути замінений ADC.SARAnalogSignal(...
            // оскільки оперує чисто цифровими значеннями ваг розрядів 
            regSchvn.SetPolinomNull();
            double signal = bivaryDac.ZnachenyaI(regBinary);

            for (int ik1 = shcvnDac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                if (shcvnDac.ZnachenyaC(regSchvn.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    regSchvn.AddBitValue(ik1, 0);
            }

            return regSchvn;
        }
        //public SCHVNRegister Convert(BinaryRegister regBinary, List<int> bannedBits)
        //{
        //    // цей метод не може бути замінений ADC.SARAnalogSignal(...
        //    // оскільки оперує чисто цифровими значеннями ваг розрядів 
        //    regSchvn.SetPolinomNull();
        //    double signal = bivaryDac.ZnachenyaI(regBinary);

        //    for (int ik1 = shcvnDac.schvn.n - 1; ik1 >= 0; ik1--)
        //    {
        //        if (shcvnDac.ZnachenyaC(regSchvn.AddBitValue(ik1, 1)) <= signal && !bannedBits.Contains(ik1))
        //        { }
        //        else
        //            regSchvn.AddBitValue(ik1, 0);
        //    }

        //    return regSchvn;
        //}
    }
}
