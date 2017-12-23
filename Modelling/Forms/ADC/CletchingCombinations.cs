using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Algorithm.UsefulMethods;
using Utils.RamDevice;

namespace Modelling.Forms
{
    public partial class CletchingCombinations : Form
    {
        public CletchingCombinations()
        {
            InitializeComponent();

            DrawCletchingCodeCombinations();
        }

        void DrawCletchingCodeCombinations()
        {
            if (RAM.CletchingCombinations.masOfCletchingCombinations != null)
            {
                foreach (var item in RAM.CletchingCombinations.masOfCletchingCombinations)
                    dataGridView1.Rows.Add(new string[] { ArrayToString.Convert(item.Key), item.Value.ToString() });

                dataGridView1.AutoResizeColumns();
                dataGridView1.Invalidate();
            }
        }
    }
}
