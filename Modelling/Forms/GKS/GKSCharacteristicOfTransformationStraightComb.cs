using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ZedGraph;

using PFI.DAConv;
using Utils.Statistics;
using Utils.GlobalGathering;
using Algorithm.CalibrationWeights;
using PFI.ADCConv;
using Utils.SignalGenerator;

namespace Modelling.Forms
{
    public partial class GKSharacteristicOfTransformationStraightComb : Form
    {
        GraphPane paneCode;
        GlobalUnit unit;
        PointPairList[] graphArrays;

        public GKSharacteristicOfTransformationStraightComb(GlobalUnit unit)
        {
            InitializeComponent();

            cmbxStrategyType.DataSource = Enum.GetNames(typeof(CalibrationType));
            cmbxStrategyType.SelectedIndex = 0;

            this.unit = unit;
            graphArrays=new PointPairList[2];

            paneCode = zedGraphControl3.GraphPane;

            FontSpec fnt9 = new FontSpec("arial", 12, Color.Black, false, false, false);
            Border bdr = new Border(false, Color.Black, 1);
            fnt9.Border = bdr;

            FontSpec fnt12 = new FontSpec("arial", 11, Color.Black, false, false, false);
            fnt12.Border = bdr;

            zedGraphControl3.AutoScaleMode = AutoScaleMode;

            paneCode.Title.FontSpec = fnt12;
            paneCode.Title.Text = "Характеристика перетворення ЦАП";
            paneCode.XAxis.Title.FontSpec = fnt9;
            paneCode.XAxis.Title.Text = "Цифровий еквівалент";
            paneCode.XAxis.Scale.FontSpec = fnt9;
            FontSpec fnt9Ver = new FontSpec(fnt9);
            fnt9Ver.Angle = 180;
            paneCode.YAxis.Title.FontSpec = fnt9Ver;
            paneCode.YAxis.Title.Text = "Аналоговий сигнал";
            paneCode.YAxis.Scale.FontSpec = fnt9Ver;

            paneCode.CurveList.Clear();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            paneCode.CurveList.Clear();
            paneCode.GraphObjList.Clear();


            //StrategyEnums selectedTypesOfStrategy = (StrategyEnums)Enum.Parse(typeof(StrategyEnums), cmbxStrategyType.SelectedValue.ToString());
            CalibrationType selectedTypesOfClaibration = (CalibrationType)Enum.Parse(typeof(CalibrationType), cmbxStrategyType.SelectedValue.ToString());
            var dic1=new Dictionary<int,double>();
            var dic2=new Dictionary<int,double>();
            graphArrays = ADCCharacteristicHelper.GetDiagramOfTransformationGKS(unit, new CharacteristoOfTransformationParametrs(int.MaxValue, 0,
                new Utils.SignalGenerator.AnalogSignal(Utils.SignalGenerator.TypesOfSignalEnum.KxB, new LineParametrs(0,0))), selectedTypesOfClaibration, out dic1, out dic2);

            DrawWithOutCalibrations();
            DrawWithCalibrations();

            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
        }
        void DrawWithOutCalibrations()
        {
            LineItem curveCodeBits = paneCode.AddCurve("Без калібрування", graphArrays[0], Color.Green, SymbolType.None);

            if (chkbxStepping.Checked)
                curveCodeBits.Line.StepType = ZedGraph.StepType.ForwardStep;
        }
        void DrawWithCalibrations()
        {
            if (chbxAfterCalibration.Checked)
            {
                LineItem curveCodeBits = paneCode.AddCurve("З калібруванням", graphArrays[2], Color.Red, SymbolType.None);

                if (chkbxStepping.Checked)
                    curveCodeBits.Line.StepType = ZedGraph.StepType.ForwardStep;
            }
        }
        private void інтегральнаНелінійністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphArrays != null)
            {
                IntegralUnlinearity frm = new IntegralUnlinearity(Utils.Statistics.Nonlinearity.CalculateIntegralUnLinearity(graphArrays[0], graphArrays[2]));
                frm.Show();
            }
            else
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                          "Спочатку натисніть .Моделювати. !");
            }
        }

        private void диференційнаНелінійністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphArrays != null)
            {
                DiffentialUnlinearity frm = new DiffentialUnlinearity(Utils.Statistics.Nonlinearity.CalculateDifferentialUnLinearity(graphArrays[0], graphArrays[2]));
                frm.Show();
            }
            else
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                          "Спочатку натисніть .Моделювати. !");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
