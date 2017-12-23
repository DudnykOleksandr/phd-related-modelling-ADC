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
    public partial class StatisticalUnlinearity : Form
    {
        PointPairList unLinearityCurve;
        GraphPane paneCode;
        double inl;

        public StatisticalUnlinearity(PointPairList unLinearityCurve, double inl)
        {
            InitializeComponent();

            this.inl = inl;
            this.unLinearityCurve = unLinearityCurve;
            paneCode = zedGraphUnlinearity.GraphPane;

            FontSpec fnt9 = new FontSpec("arial", 12, Color.Black, false, false, false);
            Border bdr = new Border(false, Color.Black, 1);
            fnt9.Border = bdr;

            FontSpec fnt12 = new FontSpec("arial", 11, Color.Black, false, false, false);
            fnt12.Border = bdr;

            paneCode.Title.FontSpec = fnt12;

            paneCode.XAxis.Title.FontSpec = fnt9;
            paneCode.XAxis.Scale.FontSpec = fnt9;
            FontSpec fnt9Ver = new FontSpec(fnt9);
            fnt9Ver.Angle = 180;
            paneCode.YAxis.Title.FontSpec = fnt9Ver;
            paneCode.YAxis.Scale.FontSpec = fnt9Ver;

            Draw();
        }
        void Draw()
        {
            CalculateCharacteristic();

            paneCode.CurveList.Clear();

            paneCode.Title.Text = "Нелінійність по діапазону";
            paneCode.XAxis.Title.Text = "Код";
            paneCode.YAxis.Title.Text = "Абсолютне значення";

            LineItem curveSignalCalibarted = paneCode.AddCurve("", unLinearityCurve, Color.Red, SymbolType.Circle);
            curveSignalCalibarted.Line.StepType = ZedGraph.StepType.NonStep;
            curveSignalCalibarted.Symbol.Size = 2;

            zedGraphUnlinearity.AxisChange();
            zedGraphUnlinearity.Invalidate();
        }

        void CalculateCharacteristic()
        {
            double[] masY = unLinearityCurve.PointPairListGetY();
            textBoxDnlMean.Text = MasFunctions.CalculateMean(masY).ToString();
            textBoxDnlMax.Text = MasFunctions.GetMaxAbs(masY).ToString();

            textBoxInl.Text = inl.ToString();
        }
    }
}
