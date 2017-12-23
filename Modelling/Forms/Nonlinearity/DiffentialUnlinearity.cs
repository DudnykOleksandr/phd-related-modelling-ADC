using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Utils.Statistics;
using Algorithm.UsefulMethods.Extensions;

namespace Modelling.Forms
{
    public partial class DiffentialUnlinearity : Form
    {
        PointPairList[] unLinearityCurve;
        GraphPane paneCode;

        public DiffentialUnlinearity(PointPairList[] unLinearityCurve)
        {
            InitializeComponent();
            this.unLinearityCurve = unLinearityCurve;
            paneCode = zedGraphUnlinearity.GraphPane;

            FontSpec fnt9 = new FontSpec("arial", 12, Color.Black, false, false, false);
            Border bdr = new Border(false, Color.Black, 1);
            fnt9.Border = bdr;

            FontSpec fnt12 = new FontSpec("arial", 11, Color.Black, false, false, false);
            fnt12.Border = bdr;

            zedGraphUnlinearity.AutoScaleMode = AutoScaleMode;

            paneCode.Title.FontSpec = fnt12;
            paneCode.Title.Text = "Нелінійність по діапазону";
            paneCode.XAxis.Title.FontSpec = fnt9;
            paneCode.XAxis.Title.Text = "Номер такту";
            paneCode.XAxis.Scale.FontSpec = fnt9;
            FontSpec fnt9Ver = new FontSpec(fnt9);
            fnt9Ver.Angle = 180;
            paneCode.YAxis.Title.FontSpec = fnt9Ver;
            paneCode.YAxis.Title.Text = "Абсолютне значення";
            paneCode.YAxis.Scale.FontSpec = fnt9Ver;

            paneCode.CurveList.Clear();

            Draw();
        }
        void Draw()
        {
            CalculateCharacteristic();

            LineItem curveSignal = paneCode.AddCurve("До самокалібрування", unLinearityCurve[0], Color.Green, SymbolType.Circle);
            curveSignal.Line.StepType = ZedGraph.StepType.NonStep;
            curveSignal.Symbol.Size = 2;

            LineItem curveSignalCalibrated = paneCode.AddCurve("До самокалібрування", unLinearityCurve[1], Color.Red, SymbolType.Circle);
            curveSignalCalibrated.Line.StepType = ZedGraph.StepType.NonStep;
            curveSignalCalibrated.Symbol.Size = 2;

            zedGraphUnlinearity.AxisChange();
            zedGraphUnlinearity.Invalidate();
        }
        void CalculateCharacteristic()
        {
            double[] masY = unLinearityCurve[0].PointPairListGetY();
            textBoxMean.Text = MasFunctions.CalculateMean(masY).ToString();
            textBoxMax.Text = MasFunctions.GetMaxAbs(masY).ToString();

            double[] masYCalibrated = unLinearityCurve[1].PointPairListGetY();
            textBoxMeanCalibrated.Text = MasFunctions.CalculateMean(masYCalibrated).ToString();
            textBoxMaxCalibrated.Text = MasFunctions.GetMaxAbs(masYCalibrated).ToString();
        }
    }
}
