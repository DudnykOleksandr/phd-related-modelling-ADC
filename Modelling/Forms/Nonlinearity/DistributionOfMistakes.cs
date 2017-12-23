using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Utils.DeviationGenerator;

namespace Modelling.Forms.Nonlinearity
{
    public partial class DistributionOfMistakes : Form
    {
        GraphPane pane;
        List<KeyValuePair<double,double>> listOfDatas;

        public DistributionOfMistakes(List<KeyValuePair<double,double>> listOfDatas)
        {
            InitializeComponent();

            this.listOfDatas=listOfDatas;

            zedGraphControl1.AutoScaleMode = AutoScaleMode;
            pane = zedGraphControl1.GraphPane;

            pane.XAxis.Cross = 0;
            pane.YAxis.Cross = 0;

            pane.CurveList.Clear();

            pane.Title.Text = "Розподіл похибок";
            pane.XAxis.Title.Text = "Абсолютне значення похибки";
            pane.YAxis.Title.Text = "Кількість значень";

            FontSpec fnt9 = new FontSpec("arial", 9, Color.Black, false, false, false);
            Border bdr = new Border(false, Color.Black, 1);
            fnt9.Border = bdr;
            FontSpec fnt12 = new FontSpec("arial", 8, Color.Black, false, false, false);
            fnt12.Border = bdr;

            pane.Title.FontSpec = fnt12;
            pane.XAxis.Title.FontSpec = fnt9;
            pane.XAxis.Scale.FontSpec = fnt9;
            FontSpec fnt9Ver = new FontSpec(fnt9);
            fnt9Ver.Angle = 180;
            pane.YAxis.Title.FontSpec = fnt9Ver;
            pane.YAxis.Scale.FontSpec = fnt9Ver;
            pane.Legend.FontSpec = fnt9;
        }

        private void CheckCheckBoxesAndDraw()
        {
            pane.CurveList.Clear();

            var normGenerator = new NormalDistributionGetGraphArray();

            if (ckbWithOut.Checked)
            {
                var myCurveDo = pane.AddCurve("До калібрування",
                    normGenerator.GetGraphArrayByParameters(listOfDatas[0].Key, listOfDatas[0].Value),
                    Color.DarkGreen);
                
                myCurveDo.Symbol.Size = 1;
                myCurveDo.Line.Width = 2;
                
            }

            if (ckbTracking.Checked)
            {
                var myCurveTracking = pane.AddCurve("Таблиця перетворення",
                    normGenerator.GetGraphArrayByParameters(listOfDatas[1].Key, listOfDatas[1].Value),
                    Color.Red);

                myCurveTracking.Symbol.Size = 1;
                myCurveTracking.Line.Width = 2;
            }

            if (ckbCletching.Checked)
            {
                var myCurveCletching = pane.AddCurve("Межові КК",
                    normGenerator.GetGraphArrayByParameters(listOfDatas[2].Key, listOfDatas[2].Value),
                    Color.Blue);

                myCurveCletching.Symbol.Size = 1;
                myCurveCletching.Line.Width = 2;
            }

            ReDraw();
        }

        private void ReDraw()
        {
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void ckb_Click(object sender, EventArgs e)
        {
            CheckCheckBoxesAndDraw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckCheckBoxesAndDraw();
        }
    }
}
