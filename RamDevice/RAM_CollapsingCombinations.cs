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
        public static class CollapsingCombinations
        {
            public static List<KeyValuePair<int[], int[]>> masOfCollapsingCombinations { get; private set; }

            static CollapsingCombinations()
            {
                masOfCollapsingCombinations = new List<KeyValuePair<int[], int[]>>();
            }

            public static void ClearCollapsingCombinations()
            {
                masOfCollapsingCombinations.Clear();
            }
            /// <summary>
            /// AddCletchingCombination assuming that combinations is added from lowest to highest
            /// </summary>
            /// <param name="valueHigh">key</param>
            /// <param name="valueLow">value</param>
            public static void AddCollapsingCombination(int[] valueHigh, int[] valueLow)
            {
                masOfCollapsingCombinations.Add(new KeyValuePair<int[], int[]>(valueHigh, valueLow));
            }

            public static int[] CheckAndGetCollapsingCombinationUp(int[] toFind)
            {
                foreach (var collapsingCombination in masOfCollapsingCombinations)
                {
                    if (collapsingCombination.Value.CompareInts(toFind))
                    {
                        //Trace.WriteLine(string.Format("High {0} Low {1}", ArrayToString.Convert(collapsingCombination.Key), ArrayToString.Convert(toFind)));
                        return collapsingCombination.Key;
                    }
                }
                return null;

            }
            public static int[] CheckAndGetCollapsingCombinationsDown(int[] toFind)
            {
                foreach (var collapsingCombination in masOfCollapsingCombinations)
                {
                    if (collapsingCombination.Key.CompareInts(toFind))
                    {
                        return collapsingCombination.Value;
                    }
                }
                return null;
            }

        }
    }
}
