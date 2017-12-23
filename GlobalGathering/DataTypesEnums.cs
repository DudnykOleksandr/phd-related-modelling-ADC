using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.GlobalGathering
{
    public enum UnLinearityType : byte { Integral, Differential };
    public enum ModellingDataType : byte { Simple, CalibratedTracking, CalibratedCletching };
    public enum ModellingDataTypeWithStrategies : byte
    {
        Simple,
        CalibratedWithFirstStrategy,
        CalibratedWithSecondStrategy,
        CalibratedWithThirdStrategy
    };
    public enum StatisticParametrType : byte { Mean, Variation };
    public enum CalibrationType : byte { Tracking, Cletching};
}
