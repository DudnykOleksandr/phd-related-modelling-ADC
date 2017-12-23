using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;


namespace Utils.RamDevice
{
    public static partial class RAM
    {
        public static class TrackingCombinations
        {
            static Hashtable hshUp;
            //static public int[] lastCombination { get;  private set; }

            static TrackingCombinations()
            {
                hshUp = new Hashtable();
            }
            public static void ClearTrackingCombinations()
            {
                lock (hshUp)
                {
                    hshUp.Clear();
                }
            }
            public static void AddCombination(int key, int[] value)
            {
                lock (hshUp)
                {
                    //lastCombination = value.Clone() as int[];
                    hshUp.Add(key, value.Clone());
                }
            }
            public static int[] GetCombination(int key)
            {
                lock (hshUp)
                {
                    if (hshUp.ContainsKey(key))
                        return hshUp[key] as int[];
                    else
                        throw new Exception();
                }
            }
        }
    }
}
