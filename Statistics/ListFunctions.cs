using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Statistics
{
    public static class ListFunctions
    {
        public static int GetMinIndex(List<int> mas)
        {
            int res = 0;
            int min = mas[res];
            for (int i = res; i < mas.Count; i++)
            {
                if (mas[i] < min)
                {
                    min = mas[i];
                    res = i;
                }
            }
            return res;
        }
        public static int GetMaxIndex(List<int> mas)
        {
            int res = 0;
            int max = mas[res];
            for (int i = res; i < mas.Count; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                    res = i;
                }
            }
            return res;
        }

        public static int GetMaxIndexAfterMin(List<int> mas, int indexMin)
        {
            int res = indexMin;
            int max = mas[res];
            for (int i = res; i < mas.Count; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                    res = i;
                }
            }
            return res;
        }
    }
}
