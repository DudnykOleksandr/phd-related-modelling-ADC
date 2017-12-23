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
    public partial class Weights : Form
    {
        double[] weights;

        public Weights(double[] mas)
        {
            InitializeComponent();

            this.weights = mas;
        }

        private void WeightsByHand_Load(object sender, EventArgs e)
        {
            GridView2Filling(weights);
        }
         void GridView2Filling(double[] mas_Weights)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            dataGridView2.ColumnCount = mas_Weights.Length+1;
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
            for (int num = this.weights.Length-1; num >=0 ; num--)
            {
                dataGridView2.Columns[this.weights.Length-1-num + 1].Name = (num).ToString();
            }

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            var temp = new List<string>();
            temp.Add("Реальна вага");

            for (int num = this.weights.Length-1; num >=0 ; num--)
            {
                temp.Add(Math.Round(mas_Weights[num], 3).ToString());
            }

            dataGridView2.Rows.Add(temp.ToArray<string>());

            dataGridView2.AutoResizeColumns();
        }

    }
}
