using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;
using System.Collections;
using Algorithm.UsefulMethods;
using Algorithm.UsefulMethods.Extensions;
using System.Diagnostics;


namespace Utils.RamDevice
{
    public static partial class RAM
    {
        public static class CletchingCombinations
        {
            public static List<KeyValuePair<int[], int[]>> masOfCletchingCombinations { get; private set; }
            static int activeItem = 0;

            static CletchingCombinations()
            {
                masOfCletchingCombinations = new List<KeyValuePair<int[], int[]>>();
            }

            public static void ClearCletchingCombinations()
            {
                masOfCletchingCombinations.Clear();
                activeItem = 0;
            }
            /// <summary>
            /// AddCletchingCombination assuming that combinations is added from lowest to highest
            /// </summary>
            /// <param name="valueHigh">key</param>
            /// <param name="valueLow">value</param>
            public static void AddCletchingCombination(int[] valueHigh, int[] valueLow)
            {
                masOfCletchingCombinations.Add(new KeyValuePair<int[], int[]>(valueHigh, valueLow));
            }

            public static int[] CheckAndGetCletchingCombinationUp(int[] toFind)
            {
                if (activeItem != masOfCletchingCombinations.Count)
                {
                    var valueToFind = PolinomValueCalibrated(toFind);
                    var activeValue = PolinomValueCalibrated(masOfCletchingCombinations[activeItem].Value);

                    if (activeValue <= valueToFind)
                    {
                        var cletchingCombination = masOfCletchingCombinations[activeItem];
                        activeItem++;

                        //Trace.WriteLine(string.Format("High {0} Low {1}", ArrayToString.Convert(cletchingCombination.Key), ArrayToString.Convert(toFind)));
                        return cletchingCombination.Key;
                    }
                }
                return null;

            }
            public static int[] CheckAndGetCletchingCombinationsDown(int[] toFind)
            {
                if (activeItem == masOfCletchingCombinations.Count)
                {
                    activeItem--;
                }
                if (activeItem != 0)
                {
                    var valueToFind = PolinomValueCalibrated(toFind);
                    var activeValue = PolinomValueCalibrated(masOfCletchingCombinations[activeItem].Key);

                    if (activeValue > valueToFind)
                    {
                        var cletchingCombination = masOfCletchingCombinations[activeItem];
                        activeItem--;

                        //Trace.WriteLine(string.Format("High {0} Low {1}", ArrayToString.Convert(cletchingCombination.Key), ArrayToString.Convert(toFind)));
                        return cletchingCombination.Value;
                    }
                }
                return null;
                
            }

            static double PolinomValueCalibrated(int[] toFind)
            {
                double valueToFind = 0;
                for (int i = toFind.Length - 1; i >= 0; i--)
                {
                    valueToFind += toFind[i] * RAM.Weights.calibratedWeights[i];
                }
                return valueToFind;
            }

        }
    }
}
