namespace Modelling.Forms
{
    partial class IntegralUnlinearity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zedGraphUnlinearity = new ZedGraph.ZedGraphControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMean = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaxCalibrated = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMeanCalibrated = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphUnlinearity
            // 
            this.zedGraphUnlinearity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.zedGraphUnlinearity.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphUnlinearity.ForeColor = System.Drawing.Color.Coral;
            this.zedGraphUnlinearity.IsAutoScrollRange = true;
            this.zedGraphUnlinearity.IsShowCursorValues = true;
            this.zedGraphUnlinearity.IsShowHScrollBar = true;
            this.zedGraphUnlinearity.IsShowVScrollBar = true;
            this.zedGraphUnlinearity.Location = new System.Drawing.Point(25, 159);
            this.zedGraphUnlinearity.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.zedGraphUnlinearity.Name = "zedGraphUnlinearity";
            this.zedGraphUnlinearity.ScrollGrace = 0D;
            this.zedGraphUnlinearity.ScrollMaxX = 0D;
            this.zedGraphUnlinearity.ScrollMaxY = 0D;
            this.zedGraphUnlinearity.ScrollMaxY2 = 0D;
            this.zedGraphUnlinearity.ScrollMinX = 0D;
            this.zedGraphUnlinearity.ScrollMinY = 0D;
            this.zedGraphUnlinearity.ScrollMinY2 = 0D;
            this.zedGraphUnlinearity.Size = new System.Drawing.Size(1149, 641);
            this.zedGraphUnlinearity.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxMax);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.textBoxMean);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(27, 55);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1144, 47);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(4, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "До самокалібрування";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(224, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Максимальне значення";
            // 
            // textBoxMax
            // 
            this.textBoxMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMax.Location = new System.Drawing.Point(440, 4);
            this.textBoxMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(132, 28);
            this.textBoxMax.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(580, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Середнє значення";
            // 
            // textBoxMean
            // 
            this.textBoxMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMean.Location = new System.Drawing.Point(755, 4);
            this.textBoxMean.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMean.Name = "textBoxMean";
            this.textBoxMean.Size = new System.Drawing.Size(132, 28);
            this.textBoxMean.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.textBoxMaxCalibrated);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.textBoxMeanCalibrated);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(25, 110);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1144, 47);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Після самокалібрування";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(249, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Максимальне значення";
            // 
            // textBoxMaxCalibrated
            // 
            this.textBoxMaxCalibrated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaxCalibrated.Location = new System.Drawing.Point(465, 4);
            this.textBoxMaxCalibrated.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMaxCalibrated.Name = "textBoxMaxCalibrated";
            this.textBoxMaxCalibrated.Size = new System.Drawing.Size(132, 28);
            this.textBoxMaxCalibrated.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(605, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Середнє значення";
            // 
            // textBoxMeanCalibrated
            // 
            this.textBoxMeanCalibrated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMeanCalibrated.Location = new System.Drawing.Point(780, 4);
            this.textBoxMeanCalibrated.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMeanCalibrated.Name = "textBoxMeanCalibrated";
            this.textBoxMeanCalibrated.Size = new System.Drawing.Size(132, 28);
            this.textBoxMeanCalibrated.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1189, 30);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem
            // 
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem.Name = "розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem";
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem.Size = new System.Drawing.Size(383, 26);
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem.Text = "Розподіл щільності імовірності по діапазону";
            this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem.Click += new System.EventHandler(this.розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem_Click);
            // 
            // IntegralUnlinearity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 814);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.zedGraphUnlinearity);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IntegralUnlinearity";
            this.Text = "IntegralUnlinearity";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphUnlinearity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMean;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaxCalibrated;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMeanCalibrated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem розподілЩільностіІмовірностіПоДіапазонуToolStripMenuItem;
    }
}