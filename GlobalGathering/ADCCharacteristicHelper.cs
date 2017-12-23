using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZedGraph;
using PFI.ADCConv;
using Utils.SignalGenerator;
using Utils.Statistics;
using Algorithm.UsefulMethods.Extensions;
using Algorithm.CalibrationWeights;

namespace Utils.GlobalGathering
{
    public static class ADCCharacteristicHelper
    {
        public static PointPairList[] GetDiagramOfTransformation(GlobalUnit unit, CharacteristoOfTransformationParametrs param, CalibrationType typeOfCalibration, out Dictionary<int, int[]> regTrackWithout, out Dictionary<int, int[]> regTrackWith)
        {
            PointPairList[] graphArrays = new PointPairList[3];

            unit.SetAdcNewWeights();
            //unit.CalibrateADCsDAC(StrategyEnums.Tracking);

            PointPairList[] res = unit.adcInst.GetDiagramOfTransformation(param, out regTrackWithout);

            graphArrays[0] = res[0].Clone();
            graphArrays[1] = res[1].Clone();

            unit.CalibrationsOfADC(typeOfCalibration);

            res = unit.adcInst.GetDiagramOfTransformation(param, out regTrackWith);

            graphArrays[2] = res[1].Clone();

            return graphArrays;
        }

        public static PointPairList[] GetDiagramOfTransformationGKS(GlobalUnit unit, CharacteristoOfTransformationParametrs param, CalibrationType typeOfCalibration, out Dictionary<int, double> regTrackWithout, out Dictionary<int, double> regTrackWith)
        {
            PointPairList[] graphArrays = new PointPairList[3];

            unit.SetAdcNewWeights();
            //unit.CalibrateADCsDAC(StrategyEnums.Tracking);

            PointPairList[] res = unit.adcInst.GetDiagramOfTransformationGKS(param, out regTrackWithout);

            graphArrays[0] = res[0].Clone();
            graphArrays[1] = res[1].Clone();

            unit.CalibrationsOfADC(typeOfCalibration);

            res = unit.adcInst.GetDiagramOfTransformationGKS(param, out regTrackWith);

            graphArrays[2] = res[1].Clone();

            return graphArrays;
        }

        public static Dictionary<UnLinearityType, Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>> GetStatisticsOfDiagramOfTransformation(GlobalUnit unit, int numbers)
        {
            var result =
                new Dictionary<UnLinearityType, Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>>(2);

            Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>> dictIntegralUnLinearity =
                new Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>(3);
            Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>> dictDiferentialUnLinearity =
                new Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>(3);

            Dictionary<int, int[]> regTrackWithoutCalibration;
            Dictionary<int, int[]> regTrackWithCalibration;

            var simpleIntegral = new double[numbers];
            //0- tracking
            //1- cletching
            var calibratedIntegral = new double[2][];
            calibratedIntegral[0] = new double[numbers];
            calibratedIntegral[1] = new double[numbers];

            var simpleDifferential = new double[numbers];
            //0- tracking
            //1- cletching
            var calibratedDifferential = new double[2][];
            calibratedDifferential[0] = new double[numbers];
            calibratedDifferential[1] = new double[numbers];

            CharacteristoOfTransformationParametrs param =
                new CharacteristoOfTransformationParametrs(int.MaxValue, 1,
                    new AnalogSignal(TypesOfSignalEnum.KxB, new LineParametrs(1.0, 0.0)));

            for (int index = 0; index < numbers; index++)
            {
                var graphArraysTracking = GetDiagramOfTransformation(unit, param, CalibrationType.Tracking, out regTrackWithoutCalibration, out regTrackWithCalibration);
                var graphArraysCletching = GetDiagramOfTransformation(unit, param, CalibrationType.Cletching, out regTrackWithoutCalibration, out regTrackWithCalibration);

                var res = new PointPairList [] { graphArraysTracking[1], graphArraysTracking[2], graphArraysCletching[2] };

                GetValueForCurve(Nonlinearity.CalculateDifferentialUnLinearity(res[0]), ref simpleIntegral[index]);
                GetValueForCurve(Nonlinearity.CalculateDifferentialUnLinearity(res[1]), ref calibratedDifferential[0][index]);
                GetValueForCurve(Nonlinearity.CalculateDifferentialUnLinearity(res[2]), ref calibratedDifferential[1][index]);

                GetValueForCurve(Nonlinearity.CalculateIntegralUnLinearity(res[0]), ref simpleDifferential[index]);
                GetValueForCurve(Nonlinearity.CalculateIntegralUnLinearity(res[1]), ref calibratedIntegral[0][index]);
                GetValueForCurve(Nonlinearity.CalculateIntegralUnLinearity(res[2]), ref calibratedIntegral[1][index]);
            }

            dictIntegralUnLinearity.Add(ModellingDataType.Simple, MakeLowestDictionary(simpleIntegral));
            dictIntegralUnLinearity.Add(ModellingDataType.CalibratedTracking, MakeLowestDictionary(calibratedIntegral[0]));
            dictIntegralUnLinearity.Add(ModellingDataType.CalibratedCletching, MakeLowestDictionary(calibratedIntegral[1]));

            dictDiferentialUnLinearity.Add(ModellingDataType.Simple, MakeLowestDictionary(simpleDifferential));
            dictDiferentialUnLinearity.Add(ModellingDataType.CalibratedTracking, MakeLowestDictionary(calibratedDifferential[0]));
            dictDiferentialUnLinearity.Add(ModellingDataType.CalibratedCletching, MakeLowestDictionary(calibratedDifferential[1]));

            result.Add(UnLinearityType.Integral, dictIntegralUnLinearity);
            result.Add(UnLinearityType.Differential, dictDiferentialUnLinearity);

            return result;

        }
        public static Dictionary<UnLinearityType, Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>> GetStatisticsOfDiagramOfTransformationGKS(GlobalUnit unit, int numbers)
        {
            var result =
                new Dictionary<UnLinearityType, Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>>(2);

            Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>> dictIntegralUnLinearity =
                new Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>(3);
            Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>> dictDiferentialUnLinearity =
                new Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>(3);

            Dictionary<int, double> regTrackWithoutCalibration;
            Dictionary<int, double> regTrackWithCalibration;

            var simpleIntegral = new double[numbers];
            //0- tracking
            //1- cletching
            var calibratedIntegral = new double[2][];
            calibratedIntegral[0] = new double[numbers];
            calibratedIntegral[1] = new double[numbers];

            var simpleDifferential = new double[numbers];
            //0- tracking
            //1- cletching
            var calibratedDifferential = new double[2][];
            calibratedDifferential[0] = new double[numbers];
            calibratedDifferential[1] = new double[numbers];

            CharacteristoOfTransformationParametrs param =
                new CharacteristoOfTransformationParametrs(int.MaxValue, 1,
                    new AnalogSignal(TypesOfSignalEnum.KxB, new LineParametrs(1.0, 0.0)));

            for (int index = 0; index < numbers; index++)
            {
                var graphArraysTracking = GetDiagramOfTransformationGKS(unit, param, CalibrationType.Tracking, out regTrackWithoutCalibration, out regTrackWithCalibration);
                var graphArraysCletching = GetDiagramOfTransformationGKS(unit, param, CalibrationType.Cletching, out regTrackWithoutCalibration, out regTrackWithCalibration);

                var res = new PointPairList[] { graphArraysTracking[1], graphArraysTracking[2], graphArraysCletching[2] };

                GetValueForCurve(Nonlinearity.CalculateDifferentialUnLinearity(res[0]), ref simpleIntegral[index]);
                GetValueForCurve(Nonlinearity.CalculateDifferentialUnLinearity(res[1]), ref calibratedDifferential[0][index]);
                GetValueForCurve(Nonlinearity.CalculateDifferentialUnLinearity(res[2]), ref calibratedDifferential[1][index]);

                GetValueForCurve(Nonlinearity.CalculateIntegralUnLinearity(res[0]), ref simpleDifferential[index]);
                GetValueForCurve(Nonlinearity.CalculateIntegralUnLinearity(res[1]), ref calibratedIntegral[0][index]);
                GetValueForCurve(Nonlinearity.CalculateIntegralUnLinearity(res[2]), ref calibratedIntegral[1][index]);
            }

            dictIntegralUnLinearity.Add(ModellingDataType.Simple, MakeLowestDictionary(simpleIntegral));
            dictIntegralUnLinearity.Add(ModellingDataType.CalibratedTracking, MakeLowestDictionary(calibratedIntegral[0]));
            dictIntegralUnLinearity.Add(ModellingDataType.CalibratedCletching, MakeLowestDictionary(calibratedIntegral[1]));

            dictDiferentialUnLinearity.Add(ModellingDataType.Simple, MakeLowestDictionary(simpleDifferential));
            dictDiferentialUnLinearity.Add(ModellingDataType.CalibratedTracking, MakeLowestDictionary(calibratedDifferential[0]));
            dictDiferentialUnLinearity.Add(ModellingDataType.CalibratedCletching, MakeLowestDictionary(calibratedDifferential[1]));

            result.Add(UnLinearityType.Integral, dictIntegralUnLinearity);
            result.Add(UnLinearityType.Differential, dictDiferentialUnLinearity);

            return result;

        }
        static void GetValueForCurve(PointPairList unLinearityCurve, ref double value)
        {
            double[] mas = unLinearityCurve.PointPairListGetY();
            //для оцінювання береться максимальне значення нелінійності на ХП
            value = MasFunctions.GetMaxAbs(mas);
        }
        static Dictionary<StatisticParametrType, double> MakeLowestDictionary(double[] mas)
        {
            Dictionary<StatisticParametrType, double> result = new Dictionary<StatisticParametrType, double>(2);
            result.Add(StatisticParametrType.Mean, MasFunctions.CalculateMean(mas));
            result.Add(StatisticParametrType.Variation, MasFunctions.CalculateVariation(mas));

            return result;
        }

        public static PointPairList[] GetDiagramOfTransformationOfRealData(List<int> track)
        {
            var graphArrays = new PointPairList[3];
            var trackList = new PointPairList();

            for (int i=0;i<track.Count;i++)
            {
                trackList.Add(i, track[i]);
            }

            graphArrays[0] = trackList;
            graphArrays[1] = trackList;
            graphArrays[2] = trackList;

            return graphArrays;
        }
    }
}
