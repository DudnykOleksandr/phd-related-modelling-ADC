using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.ADCConv;
using PFI.DAConv;
using PFI.SCHVN;
using PFI.RegisterDevice;
using Utils.RamDevice;
using Algorithm.CalibrationWeights;
using UsbAdcReader;
using System.Threading;

namespace Utils.GlobalGathering
{
    public class GlobalUnit
    {
        public bool IsWeightsByHands { get; set; }
        public ADC adcInst { get; set; }
        public DAC dacInst { get; set; }

        public UsbAdcReaderController usbContr { get; set; }

        public GlobalUnit()
        {
            IsWeightsByHands = false;
        }

        #region ADC
        
        public void SetAdcNewWeights()
        {
            if (IsWeightsByHands)
            {
                SetAdcWeightsByHand();
                RAM.Weights.InitRAMWeights(this.adcInst.dac.schvn);
            }
            else
            {
                adcInst.SetNewWeights();
                RAM.Weights.InitRAMWeights(this.adcInst.dac.schvn);
            }
            this.adcInst.isTrackingCalibrated = false;
            this.adcInst.isCletchingCalibrated = false;
            this.adcInst.dac.isCalibrated = false;
        }
        public void CalibrationsOfADC(CalibrationType typeOfCalibration)
        {
            if (adcInst.reg is SCHVNRegister)
            {
                switch (typeOfCalibration)
                {
                    case CalibrationType.Tracking :
                        CalibrateAdcWeights(StrategyEnums.Tracking);
                        this.adcInst.dac.isCalibrated = false;
                        CalibrateAdcTrack();
                        return;

                    case CalibrationType.Cletching:
                        CalibrateAdcWeights(StrategyEnums.Tracking);
                        this.adcInst.dac.isCalibrated = false;
                        CalibrateAdcCletch();
                        return;

                    default:
                        return;
                }
                
            }
        }
        private void CalibrateAdcTrack()
        {
            var calibrator = new CalibratorOfTrackingCombinations(this.adcInst);
            calibrator.CalibrateTrackingCombinationsFirstStrategy();
            this.adcInst.isTrackingCalibrated = true;
            this.adcInst.isCletchingCalibrated = false;
        }
        private void CalibrateAdcCletch()
        {
            var calibrator = new CalibratorOfCletchingCombinations(this.adcInst);
            calibrator.CalibrateCletchingCombinations();
            this.adcInst.isTrackingCalibrated = false;
            this.adcInst.isCletchingCalibrated = true;
        }
        private void CalibrateAdcWeights(StrategyEnums strategyType)
        {
            CalibratorOfWeights calibrator = new CalibratorOfWeights(this.adcInst);
            calibrator.CalibrateWeights(strategyType);
        }
        public void SetAdcWeightsByHand()
        { 
            this.adcInst.dac.schvn.SetRealWeigths(WeightsByHand_Numbers.Get_Weights());
        }

        public void CalibrateADCsDAC(StrategyEnums strategyType)
        {
            CalibrateAdcWeights(strategyType);
            this.adcInst.dac.isCalibrated = true;
        }

        public void ReadDataFromUsbAdc(int adcResolution)
        {
            var readingThread = new Thread(new ThreadStart(usbContr.ReadData));
            readingThread.Priority = ThreadPriority.Normal;
            readingThread.Start();
        }

        #endregion ADC

        #region DAC
        public void SetDACNewWeights()
        {
            if (IsWeightsByHands)
            {
                SetDacWeightsByHand();
                this.dacInst.isCalibrated = false;
                RAM.Weights.InitRAMWeights(this.dacInst.schvn);
            }
            else
            {
                this.dacInst.schvn.ReCountRealWeigths();
                this.dacInst.isCalibrated = false;
                RAM.Weights.InitRAMWeights(this.dacInst.schvn);
            }
            
        }
        public void CalibrationsOfDAC(StrategyEnums strategyType)
        {
            this.adcInst = new ADC(this.dacInst.schvn);
            CalibrateAdcWeights(strategyType);
            CalibrateAdcTrack();
            dacInst.isCalibrated = true;
        }
        public void SetDacWeightsByHand()
        {
            this.dacInst.schvn.SetRealWeigths(WeightsByHand_Numbers.Get_Weights());
            dacInst.isCalibrated = false;
        }
        #endregion DAC
    }
}
