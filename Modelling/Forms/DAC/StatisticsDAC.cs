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

namespace Modelling.Forms
{
    public partial class StatisticsDAC : Form
    {
        GlobalUnit unit;
        Dictionary<UnLinearityType, Dictionary<ModellingDataTypeWithStrategies, Dictionary<StatisticParametrType, double>>> data;
        DataGridView[] gridViews;
        public StatisticsDAC(GlobalUnit unit)
        {
            InitializeComponent();
            this.unit = unit;

            gridViews = new DataGridView[8];
            for(int i=0;i<8;i++)
            {
                gridViews[i] = (DataGridView)(this.Controls.Find("dataGridView1" + i.ToString(),true)[0]);
            }
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
                data = DACCharacteristicHelper.GetStatisticsOfDiagramOfTransformation(unit, ReadFromFields());
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
    }
}
