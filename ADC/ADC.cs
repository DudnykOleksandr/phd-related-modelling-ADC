using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Threading;
using PFI.DAConv;
using PFI.RegisterDevice;
using PFI.SCHVN;
using Utils.SignalGenerator;
using Utils.RamDevice;

namespace PFI.ADCConv
{
    public class ADC
    {
        public DAC dac { get; private set; }
        public Register reg { get; private set; }
        double currentSignal;
        public bool isTrackingCalibrated { get; set; }
        public bool isCletchingCalibrated { get; set; }
        int index;

        public ADC(int quantity, double alphaf, double delta1) :
            this(new NotationSystem(quantity, alphaf, delta1))
        {
        }
        public ADC(NotationSystem schvn)
        {
            dac = new DAC(schvn);
            reg = RegisterFactory.Create(schvn);
            isTrackingCalibrated = false;
            isCletchingCalibrated = false;

            RAM.Weights.InitRAMWeights(schvn);
        }
        public void SetNewWeights()
        {
            this.dac.schvn.ReCountRealWeigths();
        }

        private void AddOne()
        {
            if (isTrackingCalibrated)
            {
                reg.AddOneCalibrated();
            }
            else
            {
                reg.AddOne();
            }
        }
        private void DecOne()
        {
            if (isTrackingCalibrated)
            {
                reg.DecOneCalibrated();
            }
            else
            {
                reg.DecOne();
            }
        }
        bool CalibationRevisionUp()
        {
            if (isCletchingCalibrated)
            {
                var valueHigh = RAM.CletchingCombinations.CheckAndGetCletchingCombinationUp(reg.polinom);
                if (valueHigh != null)
                {
                    this.reg.SetPolinom(valueHigh);
                    return true;
                }
            }
            return false;
        }
        bool CalibationRevisionDown()
        {
            if (isCletchingCalibrated)
            {
                var valueLow = RAM.CletchingCombinations.CheckAndGetCletchingCombinationsDown(reg.polinom);
                if (valueLow != null)
                {
                    this.reg.SetPolinom(valueLow);
                    return true;
                }
            }
            return false;
        }
        void TrackingSignal(PointPairList adcRes, int beatTime)
        {
            int n = 0;
            while (n < beatTime)
            {
                var dacValue = dac.Convert(reg);

                if (dacValue > currentSignal)
                {
                    if (!CalibationRevisionDown())
                    {
                        this.DecOne();
                    }

                }
                else if (dacValue < currentSignal)
                {
                    if (!CalibationRevisionUp())
                    {
                        this.AddOne();
                    }
                }

                dacValue = dac.Convert(reg);

                adcRes.Add(index, dacValue);
                index++;
                adcRes.Add(index, dacValue);
                n++;
            }
        }
        public PointPairList[] GetDiagramOfTransformation(CharacteristoOfTransformationParametrs parametrs, out Dictionary<int, int[]> regTrack)
        {
            reg.SetPolinomNull();

            parametrs.signalSource.Reset();
            currentSignal = 0.0;
            index = 0;

            PointPairList signalGraph = new PointPairList();
            PointPairList adcRes = new PointPairList();
            regTrack = new Dictionary<int, int[]>();

            double AdcDmax = this.reg.GetDmax();

            for (int i = 0; i < parametrs.time && AdcDmax > currentSignal; i++)
            {
                currentSignal = parametrs.signalSource.NextValue();
                //Console.WriteLine(currentSignal);
                signalGraph.Add(index, currentSignal);
                TrackingSignal(adcRes, parametrs.beatTime);
                regTrack.Add(index, this.reg.polinom.Clone() as int[]);
            }
            return new PointPairList[] { signalGraph, adcRes };

        }
        public PointPairList[] GetDiagramOfTransformationGKS(CharacteristoOfTransformationParametrs parametrs, out Dictionary<int, double> regTrack)
        {
            reg.SetPolinomNull();
            currentSignal = 0;
            index = 0;

            PointPairList signalGraph = new PointPairList();
            regTrack = new Dictionary<int, double>();

            double dMax = this.reg.GetDmax();

            for (int i = 0; i < parametrs.time && dMax > currentSignal; i++)
            {
                this.reg.AddOne();
                currentSignal = this.dac.Convert(reg);
                signalGraph.Add(i, currentSignal);
                regTrack.Add(i, currentSignal);
            }
            return new PointPairList[] { signalGraph, signalGraph };

        }
        public Register ConvertBySARMethod(double signal)
        {
            reg.SetPolinomNull();

            for (int ik1 = dac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                if (dac.ZnachenyaC(reg.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    reg.AddBitValue(ik1, 0);
            }

            return reg.Clone();
        }
        public Register ConvertBySARMethod(double signal, int bannedBit)
        {
            reg.SetPolinomNull();

            for (int ik1 = dac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                if (dac.ZnachenyaC(reg.AddBitValue(ik1, 1)) <= signal && ik1 != bannedBit)
                { }
                else
                    reg.AddBitValue(ik1, 0);
            }
            return reg.Clone();
        }
        public Register SARAnalogSignalR(double signal)
        {
            reg.SetPolinomNull();

            for (int ik1 = dac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                if (dac.Convert(reg.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    reg.AddBitValue(ik1, 0);
            }

            return reg.Clone();
        }
        public Register SARAnalogSignalR(double signal, int bannedBit)
        {
            reg.SetPolinomNull();

            for (int ik1 = dac.schvn.n - 1; ik1 >= 0; ik1--)
            {
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                if (dac.Convert(reg.AddBitValue(ik1, 1)) <= signal && ik1 != bannedBit)
                { }
                else
                    reg.AddBitValue(ik1, 0);
            }
            return reg.Clone();
        }
        public Register SARAnalogSignalReverseR(double signal, int startbit)
        {
            reg.SetPolinomNull();

            for (int ik1 = startbit; ik1 >= 0; ik1--)
            {
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                if (dac.Convert(reg.AddBitValue(ik1, 1)) <= signal)
                { }
                else
                    reg.AddBitValue(ik1, 0);
            }
            return reg.Clone();
        }
    }
}
