namespace Modelling.Forms
{
    partial class GKSharacteristicOfTransformationStraightComb
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
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.chkbxStepping = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.інтегральнаНелінійністьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диференційнаНелінійністьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chbxAfterCalibration = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.cmbxStrategyType = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.zedGraphControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl3.ForeColor = System.Drawing.Color.Coral;
            this.zedGraphControl3.IsAutoScrollRange = true;
            this.zedGraphControl3.IsShowCursorValues = true;
            this.zedGraphControl3.IsShowHScrollBar = true;
            this.zedGraphControl3.IsShowVScrollBar = true;
            this.zedGraphControl3.Location = new System.Drawing.Point(15, 142);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(997, 716);
            this.zedGraphControl3.TabIndex = 1;
            // 
            // chkbxStepping
            // 
            this.chkbxStepping.AutoSize = true;
            this.chkbxStepping.Checked = true;
            this.chkbxStepping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxStepping.Location = new System.Drawing.Point(271, 4);
            this.chkbxStepping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkbxStepping.Name = "chkbxStepping";
            this.chkbxStepping.Size = new System.Drawing.Size(109, 21);
            this.chkbxStepping.TabIndex = 2;
            this.chkbxStepping.Text = "Сходинками";
            this.chkbxStepping.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.інтегральнаНелінійністьToolStripMenuItem,
            this.диференційнаНелінійністьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1028, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // інтегральнаНелінійністьToolStripMenuItem
            // 
            this.інтегральнаНелінійністьToolStripMenuItem.Name = "інтегральнаНелінійністьToolStripMenuItem";
            this.інтегральнаНелінійністьToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.інтегральнаНелінійністьToolStripMenuItem.Text = "Інтегральна нелінійність";
            this.інтегральнаНелінійністьToolStripMenuItem.Click += new System.EventHandler(this.інтегральнаНелінійністьToolStripMenuItem_Click);
            // 
            // диференційнаНелінійністьToolStripMenuItem
            // 
            this.диференційнаНелінійністьToolStripMenuItem.Name = "диференційнаНелінійністьToolStripMenuItem";
            this.диференційнаНелінійністьToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.диференційнаНелінійністьToolStripMenuItem.Text = "Диференційна нелінійність";
            this.диференційнаНелінійністьToolStripMenuItem.Click += new System.EventHandler(this.диференційнаНелінійністьToolStripMenuItem_Click);
            // 
            // chbxAfterCalibration
            // 
            this.chbxAfterCalibration.AutoSize = true;
            this.chbxAfterCalibration.Checked = true;
            this.chbxAfterCalibration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAfterCalibration.Location = new System.Drawing.Point(538, 41);
            this.chbxAfterCalibration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbxAfterCalibration.Name = "chbxAfterCalibration";
            this.chbxAfterCalibration.Size = new System.Drawing.Size(269, 21);
            this.chbxAfterCalibration.TabIndex = 3;
            this.chbxAfterCalibration.Text = "Показувати після самокалібрування";
            this.chbxAfterCalibration.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 588F));
            this.tableLayoutPanel1.Controls.Add(this.buttonStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkbxStepping, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbxAfterCalibration, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbxStrategyType, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(996, 68);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(4, 4);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 25);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Вивести";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // cmbxStrategyType
            // 
            this.cmbxStrategyType.FormattingEnabled = true;
            this.cmbxStrategyType.Location = new System.Drawing.Point(538, 4);
            this.cmbxStrategyType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbxStrategyType.Name = "cmbxStrategyType";
            this.cmbxStrategyType.Size = new System.Drawing.Size(160, 24);
            this.cmbxStrategyType.TabIndex = 5;
            // 
            // GKSharacteristicOfTransformationStraightComb
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 873);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.zedGraphControl3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GKSharacteristicOfTransformationStraightComb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CharacteristicOfTransformation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.CheckBox chkbxStepping;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem інтегральнаНелінійністьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диференційнаНелінійністьToolStripMenuItem;
        private System.Windows.Forms.CheckBox chbxAfterCalibration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox cmbxStrategyType;
    }
}