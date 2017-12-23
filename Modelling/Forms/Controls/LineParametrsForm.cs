using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils.SignalGenerator;

namespace Modelling.Controls
{
    public partial class LineParametrsForm : UserControl,IParamable
    {
        double k;
        double b;
        public LineParametrsForm()
        {
            InitializeComponent();
        }
        void ReadValues()
        {
            try
            {
                k = Convert.ToDouble(textBoxK.Text);
                b = Convert.ToDouble(textBoxB.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Програма моделювання похибок самокалібрування! \n" +
                           "Введіть корректні дані");
            }
        }
        public double GetKvalue()
        {
            ReadValues();
            return k;
        }
        public double GetBvalue()
        {
            ReadValues();
            return b;
        }
        public SignalParametrs GetParametrs()
        {
            return new LineParametrs(GetKvalue(), GetBvalue());
        }

    }
}
