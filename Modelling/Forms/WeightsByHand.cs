using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PFI.SCHVN;
using Utils.DeviationGenerator;

namespace Modelling.Forms
{
    public partial class WeightsByHand : Form
    {
        double alpha,dopysk;
        int KilRozryadiv;
        double[] Weights;

        public WeightsByHand(double alpha_,int KilRozryadiv_,double dopysk_)
        {
            InitializeComponent();
            alpha = alpha_;
            KilRozryadiv = KilRozryadiv_;
            dopysk = dopysk_;
            Weights=WeightsByHand_Numbers.Get_Weights();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] mas = new double[KilRozryadiv];

            for (int i = 0; i < KilRozryadiv; i++)
            {
                mas[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);
            }
            if (WeightsByHand_Numbers.Set_Weights(mas))
                toolStripStatusLabel1.Text = "Введено!";
        }

        private void WeightsByHand_Load(object sender, EventArgs e)
        {
            GridView2Filling(Weights);

        }
         void GridView2Filling(double[] mas_Weights)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            dataGridView2.ColumnCount = 2;
            Font font1 = new Font(DefaultFont.ToString(), 10);

            dataGridView2.Font = font1;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView2.Font, FontStyle.Bold);

            dataGridView2.Name = "dataGridView2";

            dataGridView2.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView2.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView2.GridColor = Color.Black;
            dataGridView2.RowHeadersVisible = false;

            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView2.Columns[0].Name = "№";
            dataGridView2.Columns[1].Name = "Реальна";



            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            string[] temp;
            for (int num = 0; num < KilRozryadiv; num++)
            {

                temp = new string[]{(num).ToString(), 
                    Math.Round(mas_Weights[num],3).ToString()};

                dataGridView2.Rows.Add(temp);
            }

            dataGridView2.AutoResizeColumns();
        }
        double GetIdeal(int i)
        {
            if (alpha != -1.0)
                return Math.Pow(alpha, i);
            else
                return Fibonachi.GetNFibonachi(i);
            
        }
        double GetReal(int i)
        {
            GaussianRandom norm = new GaussianRandom();
            double po = Math.Abs(norm.NextGaussian(0, 0.3));
            return GetIdeal(i)*( 1 + ((po * dopysk ) / 100));
        }
        double GetIdealPlusDelta(int i)
        {
            double res = Math.Pow(alpha, i);
            return res+res*dopysk/100;
        }
        double GetIdealMinusDelta(int i)
        {
            double res = Math.Pow(alpha, i);
            return res - res * dopysk/100;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double[] ideal_Weights = new double[KilRozryadiv];

            for (int i = 0; i < KilRozryadiv; i++)
            {
                ideal_Weights[i] = GetIdeal(i);
            }
            
            GridView2Filling(ideal_Weights);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] mas = new double[KilRozryadiv];
            for (int i = 0; i < KilRozryadiv; i++)
                mas[i] = 0;
            WeightsByHand_Numbers.Set_Weights(mas);
            mas = WeightsByHand_Numbers.Get_Weights();
            GridView2Filling(mas);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GridView2Filling(Weights);
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            toolStripStatusLabel1.Text = "Не введено!";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            double[] ideal_Weights = new double[KilRozryadiv];

            for (int i = 0; i < KilRozryadiv; i++)
            {
                ideal_Weights[i] = GetReal(i);
            }

            GridView2Filling(ideal_Weights);
        }


    }
}
