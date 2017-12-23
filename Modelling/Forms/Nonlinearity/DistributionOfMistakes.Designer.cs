namespace Modelling.Forms.Nonlinearity
{
    partial class DistributionOfMistakes
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ckbWithOut = new System.Windows.Forms.CheckBox();
            this.ckbTracking = new System.Windows.Forms.CheckBox();
            this.ckbCletching = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl1.ForeColor = System.Drawing.Color.Coral;
            this.zedGraphControl1.IsAutoScrollRange = true;
            this.zedGraphControl1.IsShowCursorValues = true;
            this.zedGraphControl1.IsShowHScrollBar = true;
            this.zedGraphControl1.IsShowVScrollBar = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 61);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(690, 636);
            this.zedGraphControl1.TabIndex = 6;
            // 
            // ckbWithOut
            // 
            this.ckbWithOut.AutoSize = true;
            this.ckbWithOut.Checked = true;
            this.ckbWithOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbWithOut.Location = new System.Drawing.Point(12, 21);
            this.ckbWithOut.Name = "ckbWithOut";
            this.ckbWithOut.Size = new System.Drawing.Size(145, 21);
            this.ckbWithOut.TabIndex = 7;
            this.ckbWithOut.Text = "Без калібрування";
            this.ckbWithOut.UseVisualStyleBackColor = true;
            this.ckbWithOut.Click += new System.EventHandler(this.ckb_Click);
            // 
            // ckbTracking
            // 
            this.ckbTracking.AutoSize = true;
            this.ckbTracking.Checked = true;
            this.ckbTracking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTracking.Location = new System.Drawing.Point(175, 21);
            this.ckbTracking.Name = "ckbTracking";
            this.ckbTracking.Size = new System.Drawing.Size(184, 21);
            this.ckbTracking.TabIndex = 7;
            this.ckbTracking.Text = "Таблиця перетворення";
            this.ckbTracking.UseVisualStyleBackColor = true;
            this.ckbTracking.Click += new System.EventHandler(this.ckb_Click);
            // 
            // ckbCletching
            // 
            this.ckbCletching.AutoSize = true;
            this.ckbCletching.Checked = true;
            this.ckbCletching.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCletching.Location = new System.Drawing.Point(382, 21);
            this.ckbCletching.Name = "ckbCletching";
            this.ckbCletching.Size = new System.Drawing.Size(97, 21);
            this.ckbCletching.TabIndex = 7;
            this.ckbCletching.Text = "Межові КК";
            this.ckbCletching.UseVisualStyleBackColor = true;
            this.ckbCletching.Click += new System.EventHandler(this.ckb_Click);
            // 
            // DistributionOfMistakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 708);
            this.Controls.Add(this.ckbCletching);
            this.Controls.Add(this.ckbTracking);
            this.Controls.Add(this.ckbWithOut);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "DistributionOfMistakes";
            this.Text = "Distibution of mistakes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.CheckBox ckbWithOut;
        private System.Windows.Forms.CheckBox ckbTracking;
        private System.Windows.Forms.CheckBox ckbCletching;
    }
}