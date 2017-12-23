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
using Utils.GlobalGathering;
using Modelling.Forms.Nonlinearity;

namespace Modelling.Forms
{
    public partial class StatisticsADC : Form
    {
        GlobalUnit unit;
        Dictionary<UnLinearityType, Dictionary<ModellingDataType, Dictionary<StatisticParametrType, double>>> data;
        DataGridView[] gridViews;
        public StatisticsADC(GlobalUnit unit)
        {
            InitializeComponent();
            this.unit = unit;

            gridViews = new DataGridView[6];
            gridViews[0] = dataGridView1;
            gridViews[1] = dataGridView2;
            gridViews[2] = dataGridView2_1;

            gridViews[3] = dataGridView3;
            gridViews[4] = dataGridView4;
            gridViews[5] = dataGridView4_1;
        }

        int ReadFromFields()
        {
            try
            {
                return Convert.ToInt32(txtBxNumberOfTimes.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                           "Введіть корректні дані");
                return 0;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;

            if(ReadFromFields()!=0)
            {
                data = ADCCharacteristicHelper.GetStatisticsOfDiagramOfTransformation(unit, ReadFromFields());
                Draw();
            }

            btnCalculate.Enabled = true;
        }

        void Draw()
        {
            int gridViewsIndex = 0;

            foreach (var valuesTypesOfUnlinearity in data.Values)
            {
                foreach (var valuesModellingDataType in valuesTypesOfUnlinearity.Values)
                {
                    string[] values = Array.ConvertAll<double, string>(valuesModellingDataType.Values.ToArray<double>(), Convert.ToString);
                    gridViews[gridViewsIndex].Rows.Add(values);
                    gridViewsIndex++;

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var item in gridViews)
            {
                item.Rows.Clear();
            }
        }

        private void Integral_Unlinearity_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                var rowIndex = e.RowIndex;

                var parameters= new List<KeyValuePair<double,double>>();

                parameters.Add(GetMeanAndDeviationByGridViewAndRow(gridViews[0],rowIndex));
                parameters.Add(GetMeanAndDeviationByGridViewAndRow(gridViews[1],rowIndex));
                parameters.Add(GetMeanAndDeviationByGridViewAndRow(gridViews[2],rowIndex));

                new DistributionOfMistakes(parameters).Show();
            }
        }

        private void Differential_Unlinearity_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                var rowIndex = e.RowIndex;

                var parameters = new List<KeyValuePair<double, double>>();

                parameters.Add(GetMeanAndDeviationByGridViewAndRow(gridViews[3], rowIndex));
                parameters.Add(GetMeanAndDeviationByGridViewAndRow(gridViews[4], rowIndex));
                parameters.Add(GetMeanAndDeviationByGridViewAndRow(gridViews[5], rowIndex));

                new DistributionOfMistakes(parameters).Show();

            }
        }
        /// <summary>
        /// GetMeanAndDeviationByGridViewAndRow
        /// </summary>
        /// <param name="dgrd"></param>
        /// <param name="rowIndex"></param>
        /// <returns>Key - mean, Value - deviation</returns>
        private KeyValuePair<double,double> GetMeanAndDeviationByGridViewAndRow(DataGridView dgrd,int rowIndex)
        {
            string meanCellValue=dgrd.Rows[rowIndex].Cells[0].Value.ToString();
            string deviationCellValue=dgrd.Rows[rowIndex].Cells[1].Value.ToString();

            double mean=default(double);
            double deviation=default(double);

            if (double.TryParse(meanCellValue, out mean))
            {
            }
            if (double.TryParse(deviationCellValue, out deviation))
            {
            }

            return new KeyValuePair<double, double>(mean, deviation);
        }
    }
}
