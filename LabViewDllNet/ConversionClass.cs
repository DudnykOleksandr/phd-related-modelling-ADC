using System;
using System.Collections.Generic;
using System.Text;

namespace LabViewDllNet
{
    public class ConversionClass
    {
        int sizeOfBuffer;
        List<int> resArray;
        int elementsChanged;

        public ConversionClass(int sizeOfBuffer)
        {

            this.sizeOfBuffer = sizeOfBuffer;
            elementsChanged=0;
            resArray = new List<int>(sizeOfBuffer);
            for (int i = 0; i < sizeOfBuffer; i++)
            {
                resArray.Add(0);

            }
        }
        public int Conversion(byte[] bytes, uint numOfBytesToReadLong, bool errorCorrection, ref int errorsNumber)
        {
            try
            {
                var numOfBytesToRead = (int)numOfBytesToReadLong;
                byte flagConst = 128;
                int lastAddedCode = -1;
                bool errorDetected = false;

                var oldSize = resArray.Count;

                for (int i = 0; i < numOfBytesToRead - 3; i++)
                {
                    if (bytes[i] < flagConst &&
                            bytes[i + 1] < flagConst &&
                            bytes[i + 2] >= flagConst)
                    {
                        bytes[i + 2] -= flagConst;

                        var convertedCode = (bytes[i + 2] << 14) | (bytes[i + 1] << 7) | bytes[i];

                        if (errorCorrection)
                        {
                            if (errorDetected)
                            {
                                var preprelastValue = resArray[resArray.Count - 2];

                                resArray[resArray.Count - 1] =lastAddedCode= (int)((convertedCode + preprelastValue) / 2);

                                errorDetected = false;
                            }
                            if (lastAddedCode != -1 && Math.Abs(lastAddedCode - convertedCode) > 1)
                            {
                                errorDetected = true;
                            }
                        }
                        resArray.Add(convertedCode);
                        lastAddedCode = convertedCode;
                        elementsChanged++;
                        i += 2;
                    }
                    else
                    {
                        errorsNumber++;
                    }
                }

                if(resArray.Count>sizeOfBuffer)
                {
                    resArray.RemoveRange(0, resArray.Count - sizeOfBuffer);
                }

                return elementsChanged;
            }
            catch (Exception ex)
            {
                int exRes = -1;
                return exRes;
            }
        }

        public int[] Read(int shiftSize, int frameSize)
        {
            var result = new List<double>();
            try
            {
                var rangeArray = resArray.GetRange(resArray.Count - shiftSize - frameSize - 1, frameSize);

                //foreach (var item in rangeArray)
                //{
                //    if (item != 0)
                //    {
                //        result.Add((item - voltageOffset) * voltagePerPoint);
                //    }
                //    else
                //    {
                //        result.Add(0);
                //    }
                //}

                elementsChanged = 0;

                return rangeArray.ToArray();
            }
            catch (Exception ex)
            {
                int[] res = { -1 };
                return res;
            }
        }
    }
}
