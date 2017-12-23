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

namespace Modelling.Forms
{
    public partial class DACCharacteristicOfTransformationFullComb : Form
    {
        GraphPane paneCode;
        DAC dac;
        bool isStraightCombinations;

        public DACCharacteristicOfTransformationFullComb(DAC dac)
        {
            InitializeComponent();

            this.dac = dac;

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

            paneCode.CurveList.Clear();
            paneCode.GraphObjList.Clear();
            List<PointPairList>[] characteristicOfTransformation = dac.GetCharacteristicOfTransformationFullComb();

            foreach (var list in characteristicOfTransformation[0])
            {
                LineItem curveCodeBits = paneCode.AddCurve("", list, Color.Green, SymbolType.None);

                if (chkbxStepping.Checked)
                    curveCodeBits.Line.StepType = ZedGraph.StepType.ForwardStep;
            }
            foreach (var list in characteristicOfTransformation[1])
            {
                LineItem curveCodeBits = paneCode.AddCurve("", list, Color.Green, SymbolType.None);
                curveCodeBits.Line.StepType = ZedGraph.StepType.NonStep;
                curveCodeBits.Line.Style = DashStyle.Dash;
            }
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();

        }
    }
}
