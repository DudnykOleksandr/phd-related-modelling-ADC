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
    public partial class IntegralUnlinearity : Form
    {
        PointPairList[] unLinearityCurve;
        GraphPane paneCode;

        public IntegralUnlinearity(PointPairList[] unLinearityCurve)
        {
            InitializeComponent();

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
            paneCode.XAxis.Title.Text = "Номер такту";
            paneCode.YAxis.Title.Text = "Абсолютне значення";

            //LineItem curveSignal = paneCode.AddCurve("До калібрування", unLinearityCurve[0], Color.Green, SymbolType.Circle);
            //curveSignal.Line.StepType = ZedGraph.StepType.NonStep;
            //curveSignal.Symbol.Size = 2;

            LineItem curveSignalCalibarted = paneCode.AddCurve("Після калібрування", unLinearityCurve[1], Color.Red, SymbolType.Circle);
            curveSignalCalibarted.Line.StepType = ZedGraph.StepType.NonStep;
            curveSignalCalibarted.Symbol.Size = 2;

            zedGraphUnlinearity.AxisChange();
            zedGraphUnlinearity.Invalidate();
        }

        void CalculateCharacteristic()
        {
            double[] masY = unLinearityCurve[0].PointPairListGetY();
            textBoxMean.Text = MasFunctions.CalculateMean(masY).ToString();
            textBoxMax.Text = MasFunctions.GetMaxAbs(masY).ToString();

            double[] masYClibrated = unLinearityCurve[1].PointPairListGetY();

            textBoxMeanCalibrated.Text = MasFunctions.CalculateMean(masYClibrated).ToString();
            textBoxMaxCalibrated.Text = MasFunctions.GetMaxAbs(masYClibrated).ToString();
        }

        private void розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double stepInl = 0.05;
            GetQuantedObject InlDo =
                new GetQuantedObject(stepInl, unLinearityCurve[0]);
            GetQuantedObject InlPislya =
                new GetQuantedObject(stepInl, unLinearityCurve[1]);

            double[] RozpodilInlDoY = InlDo.GetMasY();
            double[] RozpodilInlDoX = InlDo.GetMasX();
            double[] RozpodilInlPislyaY = InlPislya.GetMasY();
            double[] RozpodilInlPislyaX = InlPislya.GetMasX();

            DrawCharOfTrasfADCForPorivnyannya(RozpodilInlDoX, RozpodilInlDoY,
                RozpodilInlPislyaX, RozpodilInlPislyaY);
        }
        void DrawCharOfTrasfADCForPorivnyannya(double[] RozpodilXnlDoX, double[] RozpodilXnlDoY,
            double[] RozpodilXnlPislyaX, double[] RozpodilXnlPislyaY)
        {

            paneCode.CurveList.Clear();

            paneCode.YAxis.Cross = 0;
            paneCode.YAxis.Cross = 0;

            paneCode.Title.Text = "Розподіл щільності імовірності інтегральної нелінійності";
            paneCode.XAxis.Title.Text = "Абсолютне значення похибки";
            paneCode.YAxis.Title.Text = "Щільність імовірності";

            LineItem myCurveDo = paneCode.AddCurve("До калібрування",
              RozpodilXnlDoX, RozpodilXnlDoY, Color.DarkGreen);

            LineItem myCurvePislya = paneCode.AddCurve("Після калібрування",
                RozpodilXnlPislyaX, RozpodilXnlPislyaY, Color.DarkRed);

            myCurveDo.Symbol.Size = 0;
            myCurvePislya.Symbol.Size = 0;
            myCurveDo.Line.Width = 2;
            myCurvePislya.Line.Width = 2;

            myCurveDo.Line.StepType = ZedGraph.StepType.ForwardStep;
            myCurvePislya.Line.StepType = ZedGraph.StepType.ForwardStep;

            zedGraphUnlinearity.AxisChange();
            zedGraphUnlinearity.Invalidate();
        }
    }
}
