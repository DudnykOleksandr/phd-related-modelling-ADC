using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZedGraph;

namespace Algorithm.UsefulMethods.Extensions
{
    public static class PointPairListExtension
    {
        public static double[] PointPairListGetY(this PointPairList list)
        {
            var mas = from item in list.AsQueryable()
                      where true
                      select item.Y;

            return mas.ToArray<double>();
        }
    }
}
