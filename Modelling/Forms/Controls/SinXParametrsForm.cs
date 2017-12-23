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
    public partial class SinXParametrsForm : UserControl,IParamable
    {
        double k;
        double b;
        double z;
        public SinXParametrsForm()
        {
            InitializeComponent();
        }
        void ReadValues()
        {
            try
            {
                k = Convert.ToDouble(textBoxK.Text);
                b = Convert.ToDouble(textBoxB.Text);
                z = Convert.ToDouble(textBoxZ.Text);
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
        public double GetZvalue()
        {
            ReadValues();
            return z;
        }
        public SignalParametrs GetParametrs()
        {
            return new SinXParemetrs(GetKvalue(), GetBvalue(), GetZvalue());
        }

    }
}
