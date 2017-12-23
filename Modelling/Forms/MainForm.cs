using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PFI.SCHVN;
using PFI.DAConv;
using PFI.ADCConv;
using PFI.RegisterDevice;
using Utils.GlobalGathering;

namespace Modelling.Forms
{
    public struct comboParametrs
    {
        public double alpha;
        public int quantity;
        public double delta;
        public comboParametrs(double alpha, int quantity, double delta)
        {
            this.alpha = alpha;
            this.delta = delta;
            this.quantity = quantity;
        }
    }
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програма моделювання ЦАП із ВН! \n" +
            "Розробив Дудник О.В. під керівництвом Азарова О.Д."
            , "Information");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        comboParametrs ReadDataFromFields()
        {

            double alpha;
            int quantity;
            double delta;
            try
            {
                
                if (Radix.SelectedIndex == 2)
                    alpha = -1.0;
                else
                    alpha = Convert.ToDouble(Radix.Text);

                quantity = Convert.ToInt32(BitsNumber.Text);
                delta = Convert.ToDouble(Tolerance.Text);

                return new comboParametrs(alpha, quantity, delta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                           "Введіть корректні дані");
            }
            return new comboParametrs();
        }
        private void цАПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();

            GlobalUnit unit = new GlobalUnit();
            unit.dacInst = new DAC(par.quantity, par.alpha, par.delta);

            if (chkbxWeightsByHands.Checked)
                unit.SetDacWeightsByHand();

            DACCharacteristicOfTransformationFullComb form = new DACCharacteristicOfTransformationFullComb(unit.dacInst);
            form.Show();
        }

        private void діаграмаРоботиАЦПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();
            GlobalUnit unit = new GlobalUnit();

            unit.adcInst = new PFI.ADCConv.ADC(par.quantity, par.alpha, par.delta);

                if (chkbxWeightsByHands.Checked)
                    unit.IsWeightsByHands = true;

                ADCTimeDiagram form = new ADCTimeDiagram(unit);
                form.Show();
        }

        private void ParametrsByHands_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();

                WeightsByHand_Numbers.SetBitQuatity(par.quantity);

                WeightsByHand weights = new WeightsByHand(par.alpha, par.quantity, par.delta);
                weights.Show();

        }

        private void послідовнийПеребірToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();

            GlobalUnit unit = new GlobalUnit();
            unit.dacInst = new DAC(par.quantity, par.alpha, par.delta);

            if (chkbxWeightsByHands.Checked)
                unit.SetDacWeightsByHand();

            DACCharacteristicOfTransformationStraightComb form = new DACCharacteristicOfTransformationStraightComb(unit);
            form.Show();
        }

        private void рохрахуватиСтатистикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();
            GlobalUnit unit = new GlobalUnit();
            NotationSystem schvn;

            unit.adcInst = new PFI.ADCConv.ADC(par.quantity, par.alpha, par.delta);

            if (chkbxWeightsByHands.Checked)
                unit.IsWeightsByHands = true;

            StatisticsADC form = new StatisticsADC(unit);
            form.Show();
        }

        private void рохрахуватиСтатистикуЦАПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();
            GlobalUnit unit = new GlobalUnit();

            unit.dacInst = new DAC(par.quantity, par.alpha, par.delta);

            if (chkbxWeightsByHands.Checked)
                unit.IsWeightsByHands = true;

            StatisticsDAC form = new StatisticsDAC(unit);
            form.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();
            GlobalUnit unit = new GlobalUnit();

            unit.adcInst = new PFI.ADCConv.ADC(par.quantity, par.alpha, par.delta);

            if (chkbxWeightsByHands.Checked)
                unit.IsWeightsByHands = true;

            var form = new StatisticsGKS(unit);
            form.Show();
        }

        private void XPGKS_Click(object sender, EventArgs e)
        {
            comboParametrs par = ReadDataFromFields();
            GlobalUnit unit = new GlobalUnit();

            unit.adcInst = new PFI.ADCConv.ADC(par.quantity, par.alpha, par.delta);

            if (chkbxWeightsByHands.Checked)
                unit.IsWeightsByHands = true;

            var form = new GKSharacteristicOfTransformationStraightComb(unit);
            form.Show();
        }
   }
}
