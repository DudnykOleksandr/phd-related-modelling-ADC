namespace Modelling.Forms
{
    partial class DACCharacteristicOfTransformationFullComb
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.chkbxStepping = new System.Windows.Forms.CheckBox();
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
            this.zedGraphControl3.Location = new System.Drawing.Point(11, 25);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0;
            this.zedGraphControl3.ScrollMaxX = 0;
            this.zedGraphControl3.ScrollMaxY = 0;
            this.zedGraphControl3.ScrollMaxY2 = 0;
            this.zedGraphControl3.ScrollMinX = 0;
            this.zedGraphControl3.ScrollMinY = 0;
            this.zedGraphControl3.ScrollMinY2 = 0;
            this.zedGraphControl3.Size = new System.Drawing.Size(748, 582);
            this.zedGraphControl3.TabIndex = 1;
            // 
            // chkbxStepping
            // 
            this.chkbxStepping.AutoSize = true;
            this.chkbxStepping.Checked = true;
            this.chkbxStepping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxStepping.Location = new System.Drawing.Point(11, 4);
            this.chkbxStepping.Name = "chkbxStepping";
            this.chkbxStepping.Size = new System.Drawing.Size(88, 17);
            this.chkbxStepping.TabIndex = 2;
            this.chkbxStepping.Text = "Сходинками";
            this.chkbxStepping.UseVisualStyleBackColor = true;
            // 
            // DACCharacteristicOfTransformationFullComb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 620);
            this.Controls.Add(this.chkbxStepping);
            this.Controls.Add(this.zedGraphControl3);
            this.Name = "DACCharacteristicOfTransformationFullComb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CharacteristicOfTransformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.CheckBox chkbxStepping;
    }
}