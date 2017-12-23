using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.UsefulMethods
{
    public static class ArrayToString
    {
        public static string Convert(int[] array)
        {
            StringBuilder srt = new StringBuilder();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == 1)
                    srt.Append(1);
                else
                    srt.Append(0);

            }
            return srt.ToString();
        }
    }
}
