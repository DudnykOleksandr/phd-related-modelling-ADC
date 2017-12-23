using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utils.Statistics;

namespace UsbAdcReader
{
    public class UsbAdcReaderController
    {
        //out - read data of full range (from max to min)
        //in - binary adc resolution

        public UsbAdcReader adcReader;
        int adcResolution;
        public int errorCount;
        public int minCode;
        public int maxCode;

        public List<int> adcTrack { get; private set;}

        public delegate void ReadingFinishedEventHandler(object sender, EventArgs e);
        public event ReadingFinishedEventHandler ReadingFinished;

        byte flagConst = 128;

        public UsbAdcReaderController(int adcResolution)
        {
            this.adcResolution = adcResolution;
            errorCount = 0;

            adcReader = new UsbAdcReader(CalculateNumberOfBytesToRead());
        }
        public UsbAdcReaderController(int adcResolution,int hitsPerCode,int minCode,int maxCode)
        {
            this.minCode = minCode;
            this.maxCode = maxCode;
            this.adcResolution = adcResolution;
            errorCount = 0;

            var numberPerDiapason = CalculateNumberOfBytesToRead();

            adcReader = new UsbAdcReader(numberPerDiapason * hitsPerCode);
        }
        public void ReadData()
        {
            adcReader.Read();

            adcTrack = ProcessRawBytesFromUsb(adcReader.ReadBytes);

            if (ReadingFinished != null)
                ReadingFinished(this, new EventArgs());

        }
        List<int> ProcessRawBytesFromUsb(List<byte> bytes)
        {
            int lastAddedCode = -1;
            bool errorDetected = false;
                
            var res = new List<int>();

            for (int i = 0; i < bytes.Count-3; i++)
            {
                if (bytes[i] < flagConst &&
                        bytes[i + 1] < flagConst &&
                        bytes[i + 2] >= flagConst)
                {
                    bytes[i+2]-= flagConst;
                    var adcCode=(bytes[i + 2] << 14) | (bytes[i + 1] << 7) | bytes[i];

                    if (errorDetected)
                    {
                        var preprelastValue = res[res.Count - 2];

                        res[res.Count - 1] = lastAddedCode = (int)((adcCode + preprelastValue) / 2);

                        errorDetected = false;
                    }
                    if (lastAddedCode != -1 && Math.Abs(lastAddedCode - adcCode) > 1)
                    {
                        errorDetected = true;
                    }

                    i += 2;
                    res.Add(adcCode);
                    lastAddedCode = adcCode;
                }
                else
                {
                    errorCount++;
                }
            }

            var indexMin = ListFunctions.GetMinIndex(res);
            var indexMax = ListFunctions.GetMaxIndexAfterMin(res, indexMin);

            res=res.GetRange(indexMin, indexMax - indexMin);

            return res;
        }
        int CalculateNumberOfBytesToRead()
        {
            int res=0;

            int outputResolutionInBytes = 3;

            int numOfBitCombinations = (int)Math.Pow(2, adcResolution) - 1;

            res = numOfBitCombinations*outputResolutionInBytes*2;

            return res;
        }
        
    }
}
