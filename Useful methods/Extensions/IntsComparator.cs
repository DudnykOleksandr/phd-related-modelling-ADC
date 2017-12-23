using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.UsefulMethods.Extensions
{
    public static class IntsComparatorExtension
    {
        public static bool CompareInts(this int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length == secondArray.Length)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        return false; 
                    }
                }
                return true;
            }
            return false;
        }
    }
}
