using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZedGraph;
using PFI.ADCConv;
using Utils.SignalGenerator;
using Utils.Statistics;
using Algorithm.CalibrationWeights;
using Algorithm.UsefulMethods.Extensions;

namespace Utils.GlobalGathering
{
    public static class DACCharacteristicHelper
    {
        public static PointPairList[] GetDiagramOfTransformation(GlobalUnit unit, StrategyEnums strategyType)
        {
            PointPairList[] graphArrays = new PointPairList[2];

            unit.SetDACNewWeights();
            graphArrays[0] = unit.dacInst.GetCharacteristicOfTransformationStraitComb();
            unit.CalibrationsOfDAC(strategyType);
            graphArrays[1] = unit.dacInst.GetCharacteristicOfTransformationStraitComb();

            return graphArrays;
        }
        public static PointPairList[] GetDiagramOfTransformationOfAllStrategies(GlobalUnit unit)
        {
            PointPairList[] graphArrays = new PointPairList[4];

            unit.SetDACNewWeights();
            graphArrays[0] = unit.dacInst.GetCharacteristicOfTransformationStraitComb();
            unit.CalibrationsOfDAC(StrategyEnums.First);
            graphArrays[1] = unit.dacInst.GetCharacteristicOfTransformationStraitComb();
            unit.CalibrationsOfDAC(StrategyEnums.Second);
            graphArrays[2] = unit.dacInst.GetCharacteristicOfTransformationStraitComb();
            unit.CalibrationsOfDAC(StrategyEnums.Third);
            graphArrays[3] = unit.dacInst.GetCharacteristicOfTransformationStraitComb();

            return graphArrays;
        }
        public static Dictionary<UnLinearityType, Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>>> GetStatisticsOfDiagramOfTransformation(GlobalUnit unit, int numbers)
        {
            Dictionary<UnLinearityType, Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>>> result =
                new Dictionary<UnLinearityType, Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>>>(2);
            Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>> dictIntegralUnLinearity =
                new Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>>(4);
            Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>> dictDiferentialUnLinearity =
                new Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>>(4);

            double[][] integral = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                integral[i] = new double[numbers];
            }

            double[][] differential = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                differential[i] = new double[numbers];
            }

            CharacteristoOfTransformationParametrs param =
                new CharacteristoOfTransformationParametrs(int.MaxValue, 1,
                    new AnalogSignal(TypesOfSignalEnum.KxB, new LineParametrs(1.0, 0.0)));

            for (int index = 0; index < numbers; index++)
            {
                PointPairList[] graphArrays = GetDiagramOfTransformationOfAllStrategies(unit);
                // graphArrays.Length==4 без калібрування + 3 стратегії
                for (int i = 0; i < graphArrays.Length; i++)
                {
                    PointPairList integralUnLinearityCurve = Nonlinearity.CalculateIntegralUnLinearity(graphArrays[i]);
                    PointPairList diferentialUnLinearityCurve = Nonlinearity.CalculateDifferentialUnLinearity(graphArrays[i]);

                    CalculateStatisticsForOneParametr(integralUnLinearityCurve, ref integral[i][index]);
                    CalculateStatisticsForOneParametr(diferentialUnLinearityCurve, ref differential[i][index]);
                }
            }

            dictIntegralUnLinearity.Add(ModellingDataTypeWithStrategies.Simple, MakeLowestDictionary(integral[0]));
            dictIntegralUnLinearity.Add(ModellingDataTypeWithStrategies.CalibratedWithFirstStrategy, MakeLowestDictionary(integral[1]));
            dictIntegralUnLinearity.Add(ModellingDataTypeWithStrategies.CalibratedWithSecondStrategy, MakeLowestDictionary(integral[2]));
            dictIntegralUnLinearity.Add(ModellingDataTypeWithStrategies.CalibratedWithThirdStrategy, MakeLowestDictionary(integral[3]));

            dictDiferentialUnLinearity.Add(ModellingDataTypeWithStrategies.Simple, MakeLowestDictionary(differential[0]));
            dictDiferentialUnLinearity.Add(ModellingDataTypeWithStrategies.CalibratedWithFirstStrategy, MakeLowestDictionary(differential[1]));
            dictDiferentialUnLinearity.Add(ModellingDataTypeWithStrategies.CalibratedWithSecondStrategy, MakeLowestDictionary(differential[2]));
            dictDiferentialUnLinearity.Add(ModellingDataTypeWithStrategies.CalibratedWithThirdStrategy, MakeLowestDictionary(differential[3]));

            result.Add(UnLinearityType.Integral, dictIntegralUnLinearity);
            result.Add(UnLinearityType.Differential, dictDiferentialUnLinearity);

            return result;

        }
        static void CalculateStatisticsForOneParametr(PointPairList unLinearityCurve, ref double result)
        {

            double[] mas = unLinearityCurve.PointPairListGetY();
            //для оцінювання береться максимальне значення нелінійності на ХП
            result = MasFunctions.GetMaxAbs(mas);
        }
        static Dictionary<StatisticParametrType, double> MakeLowestDictionary(double[] mas)
        {
            Dictionary<StatisticParametrType, double> result = new Dictionary<StatisticParametrType, double>(2);
            result.Add(StatisticParametrType.Mean, MasFunctions.CalculateMean(mas));
            result.Add(StatisticParametrType.Variation, MasFunctions.CalculateVariation(mas));

            return result;
        }
    }
}
