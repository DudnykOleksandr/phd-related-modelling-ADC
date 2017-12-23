namespace Modelling.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BitsNumber = new System.Windows.Forms.ComboBox();
            this.Radix = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tolerance = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.хПАЦПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рохрахуватиСтатистикуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хПЦАПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прямийПеребірToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.послідовнийПеребірToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.рохрахуватиСтатистикуЦАПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnterWeights = new System.Windows.Forms.Button();
            this.chkbxWeightsByHands = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.XPGKS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BitsNumber
            // 
            this.BitsNumber.FormattingEnabled = true;
            this.BitsNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.BitsNumber.Location = new System.Drawing.Point(109, 155);
            this.BitsNumber.Margin = new System.Windows.Forms.Padding(4);
            this.BitsNumber.Name = "BitsNumber";
            this.BitsNumber.Size = new System.Drawing.Size(160, 24);
            this.BitsNumber.TabIndex = 7;
            this.BitsNumber.Text = "15";
            // 
            // Radix
            // 
            this.Radix.FormattingEnabled = true;
            this.Radix.Items.AddRange(new object[] {
            "1,618",
            "1,84",
            "Фібоначчі",
            "2"});
            this.Radix.Location = new System.Drawing.Point(111, 18);
            this.Radix.Margin = new System.Windows.Forms.Padding(4);
            this.Radix.Name = "Radix";
            this.Radix.Size = new System.Drawing.Size(160, 24);
            this.Radix.TabIndex = 8;
            this.Radix.Text = "1,618";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "розрядів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "К-сть";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Основа СЧ";
            // 
            // Tolerance
            // 
            this.Tolerance.FormattingEnabled = true;
            this.Tolerance.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.Tolerance.Location = new System.Drawing.Point(109, 202);
            this.Tolerance.Margin = new System.Windows.Forms.Padding(4);
            this.Tolerance.Name = "Tolerance";
            this.Tolerance.Size = new System.Drawing.Size(160, 24);
            this.Tolerance.TabIndex = 10;
            this.Tolerance.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Допуск";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.хПАЦПToolStripMenuItem,
            this.рохрахуватиСтатистикуToolStripMenuItem,
            this.XPGKS,
            this.toolStripMenuItem1,
            this.рохрахуватиСтатистикуЦАПToolStripMenuItem,
            this.хПЦАПToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(941, 26);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // хПАЦПToolStripMenuItem
            // 
            this.хПАЦПToolStripMenuItem.Name = "хПАЦПToolStripMenuItem";
            this.хПАЦПToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.хПАЦПToolStripMenuItem.Text = "ХП АЦП";
            this.хПАЦПToolStripMenuItem.Click += new System.EventHandler(this.діаграмаРоботиАЦПToolStripMenuItem_Click);
            // 
            // рохрахуватиСтатистикуToolStripMenuItem
            // 
            this.рохрахуватиСтатистикуToolStripMenuItem.Name = "рохрахуватиСтатистикуToolStripMenuItem";
            this.рохрахуватиСтатистикуToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.рохрахуватиСтатистикуToolStripMenuItem.Text = "Рохрахувати статистику АЦП";
            this.рохрахуватиСтатистикуToolStripMenuItem.Click += new System.EventHandler(this.рохрахуватиСтатистикуToolStripMenuItem_Click);
            // 
            // хПЦАПToolStripMenuItem
            // 
            this.хПЦАПToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прямийПеребірToolStripMenuItem1,
            this.послідовнийПеребірToolStripMenuItem1});
            this.хПЦАПToolStripMenuItem.Name = "хПЦАПToolStripMenuItem";
            this.хПЦАПToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.хПЦАПToolStripMenuItem.Text = "ХП ЦАП";
            // 
            // прямийПеребірToolStripMenuItem1
            // 
            this.прямийПеребірToolStripMenuItem1.Name = "прямийПеребірToolStripMenuItem1";
            this.прямийПеребірToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.прямийПеребірToolStripMenuItem1.Text = "Прямий перебір";
            this.прямийПеребірToolStripMenuItem1.Click += new System.EventHandler(this.цАПToolStripMenuItem_Click);
            // 
            // послідовнийПеребірToolStripMenuItem1
            // 
            this.послідовнийПеребірToolStripMenuItem1.Name = "послідовнийПеребірToolStripMenuItem1";
            this.послідовнийПеребірToolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.послідовнийПеребірToolStripMenuItem1.Text = "Послідовний перебір";
            this.послідовнийПеребірToolStripMenuItem1.Click += new System.EventHandler(this.послідовнийПеребірToolStripMenuItem_Click);
            // 
            // рохрахуватиСтатистикуЦАПToolStripMenuItem
            // 
            this.рохрахуватиСтатистикуЦАПToolStripMenuItem.Name = "рохрахуватиСтатистикуЦАПToolStripMenuItem";
            this.рохрахуватиСтатистикуЦАПToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.рохрахуватиСтатистикуЦАПToolStripMenuItem.Text = "Рохрахувати статистику ЦАП";
            this.рохрахуватиСтатистикуЦАПToolStripMenuItem.Click += new System.EventHandler(this.рохрахуватиСтатистикуЦАПToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.infoToolStripMenuItem.Text = "Інфо";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
            this.exitToolStripMenuItem.Text = "Вихід";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.BitsNumber);
            this.panel1.Controls.Add(this.Tolerance);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(16, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 256);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEnterWeights);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkbxWeightsByHands);
            this.panel2.Controls.Add(this.Radix);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 123);
            this.panel2.TabIndex = 13;
            // 
            // btnEnterWeights
            // 
            this.btnEnterWeights.Location = new System.Drawing.Point(167, 82);
            this.btnEnterWeights.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnterWeights.Name = "btnEnterWeights";
            this.btnEnterWeights.Size = new System.Drawing.Size(100, 28);
            this.btnEnterWeights.TabIndex = 12;
            this.btnEnterWeights.Text = "Ввести";
            this.btnEnterWeights.UseVisualStyleBackColor = true;
            this.btnEnterWeights.Click += new System.EventHandler(this.ParametrsByHands_Click);
            // 
            // chkbxWeightsByHands
            // 
            this.chkbxWeightsByHands.AutoSize = true;
            this.chkbxWeightsByHands.Location = new System.Drawing.Point(44, 89);
            this.chkbxWeightsByHands.Margin = new System.Windows.Forms.Padding(4);
            this.chkbxWeightsByHands.Name = "chkbxWeightsByHands";
            this.chkbxWeightsByHands.Size = new System.Drawing.Size(18, 17);
            this.chkbxWeightsByHands.TabIndex = 11;
            this.chkbxWeightsByHands.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ввести ваги вручну";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.toolStripMenuItem1.Text = "Статистика ГКмС";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // XPGKS
            // 
            this.XPGKS.Name = "XPGKS";
            this.XPGKS.Size = new System.Drawing.Size(80, 22);
            this.XPGKS.Text = "ХП ГКмС";
            this.XPGKS.Click += new System.EventHandler(this.XPGKS_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BitsNumber;
        private System.Windows.Forms.ComboBox Radix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Tolerance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkbxWeightsByHands;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEnterWeights;
        private System.Windows.Forms.ToolStripMenuItem хПАЦПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хПЦАПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прямийПеребірToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem послідовнийПеребірToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem рохрахуватиСтатистикуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рохрахуватиСтатистикуЦАПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem XPGKS;
    }
}

