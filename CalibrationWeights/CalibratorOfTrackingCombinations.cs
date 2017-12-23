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
    public class CalibratorOfTrackingCombinations
    {
        ADC adcInst;
        //NotationSystem binarySys;
        //NotationSystem schvnSys;
        Converter bToSchvnConv;
        BinaryRegister binaryReg;

        public CalibratorOfTrackingCombinations(ADC adcInst)
        {
            this.adcInst = adcInst;

            int binaryN = (int)Math.Ceiling(Math.Log(adcInst.dac.schvn.alpha, Math.E) * adcInst.dac.schvn.n / Math.Log(2, Math.E));
            NotationSystem binarySys = new NotationSystem(binaryN, 2, 0);
            binaryReg = new BinaryRegister(binarySys);

            bToSchvnConv = new Converter(binarySys, adcInst.dac.schvn);
        }
        public void CalibrateTrackingCombinationsFirstStrategy()
        {
            //Дає ДНЛ на рівні 1,8 та ІНЛ на рівні 1,0

            RAM.TrackingCombinations.ClearTrackingCombinations();

            binaryReg.SetPolinomNull();
            int ik;
            SCHVNRegister schvnReg;

            var leastSignificantBit= RAM.Weights.calibratedWeights[0];
            var countingReg = this.adcInst.reg.Clone();
            countingReg.SetPolinomNull();

            double countValue=default(double);

            for (ik = 0; !binaryReg.isMaxValueInRegister(); ik++, binaryReg.AddOne(), countValue += leastSignificantBit)
            {
                //schvnReg = bToSchvnConv.ConvertC(binaryReg);
                countingReg = this.adcInst.ConvertBySARMethod(countValue);
                countValue = this.adcInst.dac.ZnachenyaC(countingReg);
                //countValue -= (countValue - sarredValue);

                RAM.TrackingCombinations.AddCombination(binaryReg.GetBinaryValue(), countingReg.polinom as int[]);
            }
            //schvnReg = bToSchvnConv.ConvertC(binaryReg);

            RAM.TrackingCombinations.AddCombination(binaryReg.GetBinaryValue(), countingReg.polinom as int[]);
        }
        //public void CalibrateTrackingCombinationsSecondStrategy()
        //{
        //    RAM.TrackingCombinations.ClearTrackingCombinations();

        //    binaryReg.SetPolinomNull();
        //    int ik;
        //    SCHVNRegister schvnReg, schvnRegUnCollapsed, prevoiusReg;
        //    double prevoiusRegValue;

        //    prevoiusReg = null;

        //    List<int> bannedBits = new List<int>();
        //    Dictionary<SCHVNRegister, double> combibationCandidates = new Dictionary<SCHVNRegister, double>();

        //    for (ik = 0; true; ik++, binaryReg.AddOne())
        //    {
        //        bannedBits.Clear();
        //        combibationCandidates.Clear();

        //        schvnReg = (SCHVNRegister)bToSchvnConv.Convert(binaryReg).Clone();
        //        double tempA = adcInst.dac.ZnachenyaC(schvnReg);
        //        combibationCandidates.Add(schvnReg, Math.Abs(adcInst.dac.ZnachenyaC(schvnReg)));

        //        bannedBits.Add(schvnReg.GetNumberOfFirstBitWithOne());
        //        schvnRegUnCollapsed = (SCHVNRegister)bToSchvnConv.Convert(binaryReg, bannedBits).Clone();
        //        double tempB = adcInst.dac.ZnachenyaC(schvnRegUnCollapsed);
        //        combibationCandidates.Add(schvnRegUnCollapsed, Math.Abs(adcInst.dac.ZnachenyaC(schvnRegUnCollapsed)));
                
        //        //також пробував тільки для ik>4 - результат той же самий
        //        if (prevoiusReg != null)
        //        {

        //            prevoiusRegValue = adcInst.dac.ZnachenyaC(prevoiusReg);

        //            //гарна ідея та тільки не приносить покращення оскільки однієї тільки відстані між сусідніми кодовими комбінаціями замало для
        //            // для калібрування. Дає ДНЛ на рівні 2 та ІНЛ на рівні 1,2
        //            var query = from combibationCandidate in combibationCandidates
        //                        orderby Math.Abs(combibationCandidate.Value - prevoiusRegValue)
        //                        select combibationCandidate;

        //            prevoiusReg = query.First().Key;
        //        }
        //        else
        //            prevoiusReg = schvnReg;

        //        //Trace.WriteLine(query.First().Value - prevoiusRegValue);

        //        RAM.TrackingCombinations.AddCombination(binaryReg.GetBinaryValue(), prevoiusReg.polinom as int[]);

        //        if (binaryReg.isMaxValueInRegister())
        //            break;
        //    }
        //}
    }

}
