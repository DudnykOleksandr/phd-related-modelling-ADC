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
    public class CalibratorOfWeights
    {
        ADC adcInst;
        public CalibratorOfWeights(ADC adcInst)
        {
            this.adcInst = adcInst;
        }
        public void CalibrateWeights(StrategyEnums numOfStrategy)
        {
            switch (numOfStrategy)
            {
                case StrategyEnums.Tracking:
                    CalibrateTrackingStrategy();
                    break;
                case StrategyEnums.First:
                    CalibrateFirstStrategy();
                    break;
                case StrategyEnums.Second:
                    CalibrateSecondStrategy();
                    break;
                case StrategyEnums.Third:
                    CalibrateThirdStrategy();
                    break;
                default:
                    break;
            }
        }

        public double GetAkalTrackingStrategy(int i)
        {
            return adcInst.dac.schvn.GetBitReal(i);
        }
        public double GetReverseAkalTrackingStrategy(int i)
        {
            var result = default(double);

            for (int j = i-1; j >=0; j--)
            {
                result += adcInst.dac.schvn.GetBitReal(j);
            }

            return result;
        }
        public double GetAkalFirstDtrategy(int i)
        {
            return adcInst.dac.schvn.GetBitIdeal(i) * (1 + adcInst.dac.schvn.delta / 100);
        }
        public double GetAkalSecondDtrategy(int i)
        {
            adcInst.reg.SetPolinomNull();
            adcInst.reg.polinom[i] = 1;
            double weightsOfI = adcInst.dac.Convert(adcInst.reg);

            if (adcInst.reg as SCHVNRegister != null)
            {
                ((SCHVNRegister)adcInst.reg).UCollapse(i);
                double weightsOfICollpased = adcInst.dac.Convert(adcInst.reg);
                return weightsOfI > weightsOfICollpased ? weightsOfI : weightsOfICollpased;
            }
            else
            {
                throw new Exception("Not supported operation in GetAkalSecondDtrategy()");
            }

        }

        void CalibrateTrackingStrategy()
        {
            RAM.Weights.InitRAMWeights(adcInst.dac.schvn);

            int kilToch = adcInst.dac.schvn.kilTochnux;

            for (int ik = kilToch; ik < adcInst.dac.schvn.n; ik++)
            {
                double q = adcInst.dac.ZnachenyaC(adcInst.SARAnalogSignalR(GetAkalTrackingStrategy(ik), ik));

                var reg = adcInst.SARAnalogSignalReverseR(GetReverseAkalTrackingStrategy(ik), ik);

                double qreverse = adcInst.dac.ZnachenyaC(reg.NegatePolinom(ik));

                q = (q + qreverse) / 2;

                RAM.Weights.SetCalibratedTracking(ik, q);
            }
        }
        void CalibrateFirstStrategy()
        {
            RAM.Weights.InitRAMWeights(adcInst.dac.schvn);

            int kilToch = adcInst.dac.schvn.kilTochnux;

            for (int ik = kilToch; ik < adcInst.dac.schvn.n; ik++)
            {
                double q1 = adcInst.dac.ZnachenyaC(adcInst.ConvertBySARMethod(GetAkalFirstDtrategy(ik)));
                double q2 = adcInst.dac.ZnachenyaC(adcInst.ConvertBySARMethod(GetAkalFirstDtrategy(ik), ik));
                RAM.Weights.SetCalibrated(ik, q2 - q1);
            }
        }
        void CalibrateSecondStrategy()
        {
            RAM.Weights.InitRAMWeights(adcInst.dac.schvn);

            int kilToch = adcInst.dac.schvn.kilTochnux;

            for (int ik = kilToch; ik < adcInst.dac.schvn.n; ik++)
            {
                double q1 = adcInst.dac.ZnachenyaC(adcInst.ConvertBySARMethod(GetAkalSecondDtrategy(ik)));
                double q2 = adcInst.dac.ZnachenyaC(adcInst.ConvertBySARMethod(GetAkalSecondDtrategy(ik), ik));
                RAM.Weights.SetCalibrated(ik, q2 - q1);
            }
        }
        void CalibrateThirdStrategy()
        {
            RAM.Weights.InitRAMWeights(adcInst.dac.schvn);

            int kilToch = adcInst.dac.schvn.kilTochnux;

            for (int ik = kilToch; ik < adcInst.dac.schvn.n; ik++)
            {
                RAM.Weights.SetCalibrated(ik, CalibrateThirdStrategyLogic(ik));
            }
        }
        double CalibrateThirdStrategyLogic(int bitNum)
        {
            RAM.Weights.InitRAMWeights(adcInst.dac.schvn);

            int k = (int)(bitNum / 2);
            double res = 0;

            SCHVNRegister adcReg = adcInst.reg as SCHVNRegister;
            if (adcReg != null)
            {
                adcReg.polinom[bitNum] = 1;
                double aKalSuper = adcInst.dac.Convert(adcReg);

                for (int i = 0; i < k; i++)
                {
                    double q1 = adcInst.dac.ZnachenyaC(adcInst.ConvertBySARMethod(aKalSuper));
                    adcReg.UCollapse(bitNum - i);
                    double aKalCollapsed = adcInst.dac.Convert(adcReg);

                    double q2 = adcInst.dac.ZnachenyaC(adcInst.ConvertBySARMethod(aKalSuper > aKalCollapsed ? aKalSuper : aKalCollapsed, bitNum));
                    res += q1 - q2;
                }
                return res / k;
            }
            else
                throw new Exception("Not supported operation in CalibrateThirdStrategyLogic()");
        }
    }
}
