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
using PFI.SCHVN;
using PFI.ADCConv;
using PFI.RegisterDevice;
using Utils.SignalGenerator;
using Utils.Statistics;
using Utils.GlobalGathering;
using Modelling.Controls;
using UsbAdcReader;

namespace Modelling.Forms
{
    public partial class ADCTimeDiagram : Form
    {
        GraphPane paneCode;
        GlobalUnit unit;
        UserControl parametrForm;
        PointPairList[] graphArrays;
        Dictionary<int, int[]> regTrackWithoutCalibration;
        Dictionary<int, int[]> regTrackWithCalibration;

        delegate void SetPersentageCallback(int persentage);
        delegate void SetErrosNumberCallback(string errorsNumber);
        delegate void SetGraphCallback();

        public ADCTimeDiagram(GlobalUnit unit)
        {
            this.unit = unit;

            InitializeComponent();

            cmbSignalType.DataSource = Enum.GetNames(typeof(TypesOfSignalEnum));
            cmbSignalType.SelectedIndex = 0;

            cmdMethodOfCalibration.DataSource=Enum.GetNames(typeof(CalibrationType));
            cmdMethodOfCalibration.SelectedIndex=0;

            paneCode = zedGraphControl1.GraphPane;

            FontSpec fnt9 = new FontSpec("arial", 9, Color.Black, false, false, false);
            Border bdr = new Border(false, Color.Black, 1);
            fnt9.Border = bdr;

            FontSpec fnt12 = new FontSpec("arial", 8, Color.Black, false, false, false);
            fnt12.Border = bdr;

            zedGraphControl1.AutoScaleMode = AutoScaleMode;

            paneCode.Title.FontSpec = fnt12;
            paneCode.Title.Text = "Діаграма врівноваження АЦП";
            paneCode.XAxis.Title.FontSpec = fnt9;
            paneCode.XAxis.Title.Text = "Номер такту";
            paneCode.XAxis.Scale.FontSpec = fnt9;
            FontSpec fnt9Ver = new FontSpec(fnt9);
            fnt9Ver.Angle = 180;
            paneCode.YAxis.Title.FontSpec = fnt9Ver;
            paneCode.YAxis.Title.Text = "Аналоговий сигнал";
            paneCode.YAxis.Scale.FontSpec = fnt9Ver;

            paneCode.CurveList.Clear();
        }

        void adcReader_CalculatorChanged(object sender, ReaderEventArgs e)
        {
            SetPercentageProgress(e.persentage);
        }
        private void SetPercentageProgress(int p)
        {
            if (this.usbReadingDataProgress.InvokeRequired)
            {
                var d = new SetPersentageCallback(SetPercentageProgress);
                this.Invoke(d, new object[] { p });
            }
            else
            {
                this.usbReadingDataProgress.Value = p;
            }
        }
        private void SetErrorsNumber(string errorNumber)
        {
            if (this.lblErrorsNumber.InvokeRequired)
            {
                var d = new SetErrosNumberCallback(SetErrorsNumber);
                this.Invoke(d, new object[] { errorNumber });
            }
            else
            {
                this.lblErrorsNumber.Text = errorNumber;
            }
        }
        private void SetGraph()
        {
            if (this.zedGraphControl1.InvokeRequired)
            {
                var d = new SetGraphCallback(SetGraph);
                this.Invoke(d);
            }
            else
            {
                DrawGraphOfRealData();
            }
        }
        void usbContr_ReadingForCTFinished(object sender, EventArgs e)
        {
            //
            var adcTrack = unit.usbContr.adcTrack;
            var errorsNumber = unit.usbContr.errorCount;

            graphArrays=ADCCharacteristicHelper.GetDiagramOfTransformationOfRealData(adcTrack);

            SetErrorsNumber(errorsNumber.ToString());

            SetGraph();
        }
        void usbContr_ReadingForTestingFinished(object sender, EventArgs e)
        {
            //
            var adcTrack = unit.usbContr.adcTrack;
            var errorsNumber = unit.usbContr.errorCount;
            double inl=0;
            StatisticalUnlinearity frm =
                new StatisticalUnlinearity(Utils.Statistics.Nonlinearity.CalculateStatisticalUnLinearities(adcTrack, unit.usbContr.minCode, unit.usbContr.maxCode, ref inl), inl);
            frm.Show();

            SetErrorsNumber(errorsNumber.ToString());

        }
        CharacteristoOfTransformationParametrs ReadDataFromFields()
        {
            int time;
            int beatTime;
            IParamable parametrFormInst;

            try
            {
                if (comboBoxTimeValue.Text == "max")
                    time = int.MaxValue;
                else
                    time = int.Parse(comboBoxTimeValue.Text);

                beatTime = int.Parse(txtBxBeatTime.Text);
                parametrFormInst = parametrForm as IParamable;

                TypesOfSignalEnum selectedTypesOfSignal = (TypesOfSignalEnum)Enum.Parse(typeof(TypesOfSignalEnum),cmbSignalType.SelectedValue.ToString());

                return new CharacteristoOfTransformationParametrs(time, beatTime,
                    new AnalogSignal(selectedTypesOfSignal, parametrFormInst.GetParametrs()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                           ex.Message);
                return null;
            }

        }
        void DrawGraph()
        {
            bntStart.Enabled = false;

            paneCode.CurveList.Clear();
            paneCode.GraphObjList.Clear();

            if (chkbxAnalogSignal.Checked)
            {
                LineItem curveInputSignal = paneCode.AddCurve("Вхідний сигнал", graphArrays[0], Color.Green, SymbolType.Circle);
                curveInputSignal.Line.StepType = ZedGraph.StepType.NonStep;
                curveInputSignal.Symbol.Size = 1;
            }

            if (chkBxShowReal.Checked)
            {
                LineItem curveOutputSignal = paneCode.AddCurve("Без калібрування", graphArrays[1], Color.Blue, SymbolType.None);
                curveOutputSignal.Line.StepType = ZedGraph.StepType.NonStep;
            }

            if (chkBxShowCalibrated.Checked)
            {
                LineItem curveOutputCalibratedSignal = paneCode.AddCurve("З калібруванням", graphArrays[2], Color.Red, SymbolType.None);
                curveOutputCalibratedSignal.Line.StepType = ZedGraph.StepType.NonStep;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            bntStart.Enabled = true;
        }
        void DrawGraphOfRealData()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();

            LineItem curveInputSignal = zedGraphControl1.GraphPane.AddCurve("Вхідний сигнал", graphArrays[0], Color.Green, SymbolType.Circle);
            curveInputSignal.Line.StepType = ZedGraph.StepType.NonStep;
            curveInputSignal.Symbol.Size = 1;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void bntStart_Click(object sender, EventArgs e)
        {
            bntStart.Enabled = false;

            CharacteristoOfTransformationParametrs param = ReadDataFromFields();

            CalibrationType selectedTypesOfClaibration = (CalibrationType)Enum.Parse(typeof(CalibrationType), cmdMethodOfCalibration.SelectedValue.ToString()); 

            if (param != null)
            {
                graphArrays = ADCCharacteristicHelper.GetDiagramOfTransformation(unit, param, selectedTypesOfClaibration, out regTrackWithoutCalibration, out regTrackWithCalibration);
                DrawGraph();
            }

            bntStart.Enabled = true;
        }

        private void cmbSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypesOfSignalEnum selectedTypesOfSignal = (TypesOfSignalEnum)Enum.Parse(typeof(TypesOfSignalEnum), cmbSignalType.SelectedValue.ToString());

            panelParamOfSignal.Controls.Clear();

            if (selectedTypesOfSignal == TypesOfSignalEnum.KxB)
            {
                parametrForm = new LineParametrsForm();
                panelParamOfSignal.Controls.Add(parametrForm);
            }
            else if (selectedTypesOfSignal == TypesOfSignalEnum.SinX)
            {
                parametrForm = new SinXParametrsForm();
                panelParamOfSignal.Controls.Add(parametrForm);
            }
        }

        private void нелінійністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphArrays != null)
            {
                IntegralUnlinearity frm = new IntegralUnlinearity(Utils.Statistics.Nonlinearity.CalculateIntegralUnLinearity(graphArrays[1], graphArrays[2]));
                frm.Show();
            }
            else
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                          "Спочатку натисніть .Моделювати. !");
            }

        }

        private void диференціальнаНелінійністьПоДіапазонуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphArrays != null)
            {
                DiffentialUnlinearity frm = new DiffentialUnlinearity(Utils.Statistics.Nonlinearity.CalculateDifferentialUnLinearity(graphArrays[1], graphArrays[2]));
                frm.Show();
            }
            else
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                          "Спочатку натисніть .Моделювати. !");
            }
        }

        private void show_regTrackWithoutCalibration(object sender, EventArgs e)
        {
            if (regTrackWithoutCalibration != null)
            {
                TrackCodeCombinations frm = new TrackCodeCombinations(this.regTrackWithoutCalibration);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                          "Спочатку натисніть .Моделювати. !");
            }
        }

        private void show_regTrackWithCalibration(object sender, EventArgs e)
        {
            if (regTrackWithCalibration != null)
            {
                TrackCodeCombinations frm = new TrackCodeCombinations(this.regTrackWithCalibration);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                          "Спочатку натисніть .Моделювати. !");
            }
        }

        private void межовіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((CalibrationType)Enum.Parse(typeof(CalibrationType), cmdMethodOfCalibration.SelectedValue.ToString()) == CalibrationType.Cletching)
            {
                new CletchingCombinations().Show();
            }
        }

        private void показатиВагиРозрядівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Weights(this.unit.adcInst.dac.schvn.real).Show();
        }

        private void btnReadUsbData_Click(object sender, EventArgs e)
        {
            btnReadUsbData.Enabled = false;
            btnLinearityTest.Enabled = false;

            int res = 0;
            try
            {
                res = Convert.ToInt32(txtAdcRes.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                        "Неправильна розрядність!");
            }
            if (res != 0)
            {
                
                unit.usbContr = new UsbAdcReaderController(res);
                unit.usbContr.ReadingFinished += new UsbAdcReaderController.ReadingFinishedEventHandler(usbContr_ReadingForCTFinished);
                unit.usbContr.adcReader.CalculatorChanged += new UsbAdcReader.UsbAdcReader.ReaderChangedEventHandler(adcReader_CalculatorChanged);

                unit.ReadDataFromUsbAdc(res);
            }

            btnReadUsbData.Enabled = true;
            btnLinearityTest.Enabled = true;
        }

        private void btnLinearityTest_Click(object sender, EventArgs e)
        {
            btnReadUsbData.Enabled = false;
            btnLinearityTest.Enabled = false;

            int res = 0;
            int minCode = 0;
            int maxCode = 0;
            int hitsPerCode = 0;

            try
            {
                res = Convert.ToInt32(txtAdcRes.Text);

                minCode = Convert.ToInt32(txtZeroCode.Text);
                maxCode = Convert.ToInt32(txtMaxCode.Text);
                hitsPerCode = Convert.ToInt32(txtHitsPerCode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                                        "Неправильна розрядність!");
            }
            if (res != 0)
            {

                unit.usbContr = new UsbAdcReaderController(res, hitsPerCode,minCode,maxCode);
                unit.usbContr.ReadingFinished += new UsbAdcReaderController.ReadingFinishedEventHandler(usbContr_ReadingForTestingFinished);
                unit.usbContr.adcReader.CalculatorChanged += new UsbAdcReader.UsbAdcReader.ReaderChangedEventHandler(adcReader_CalculatorChanged);

                unit.ReadDataFromUsbAdc(res);
            }

            btnReadUsbData.Enabled = true;
            btnLinearityTest.Enabled = true;
        }
    }
}
