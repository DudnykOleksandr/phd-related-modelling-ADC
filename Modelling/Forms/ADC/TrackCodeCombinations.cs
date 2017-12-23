using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Algorithm.UsefulMethods;

namespace Modelling.Forms
{
    public partial class TrackCodeCombinations : Form
    {
        public TrackCodeCombinations(Dictionary<int, int[]> regTrack)
        {
            InitializeComponent();

            foreach (var item in regTrack)
                dataGridView1.Rows.Add(new string[] { item.Key.ToString(), ArrayToString.Convert(item.Value as int[]) });

            dataGridView1.AutoResizeColumns();
            dataGridView1.Invalidate();
        }
    }
}
