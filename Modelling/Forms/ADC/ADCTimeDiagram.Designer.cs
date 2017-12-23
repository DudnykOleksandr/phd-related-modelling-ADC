namespace Modelling.Forms
{
    partial class ADCTimeDiagram
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.нелінійністьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиКодовіКомбінаціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.безКалібруванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зКалібруваннямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.межовіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиВагиРозрядівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxBeatTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSignalType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelParamOfSignal = new System.Windows.Forms.Panel();
            this.comboBoxTimeValue = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbxAnalogSignal = new System.Windows.Forms.CheckBox();
            this.chkBxShowReal = new System.Windows.Forms.CheckBox();
            this.chkBxShowCalibrated = new System.Windows.Forms.CheckBox();
            this.bntStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdMethodOfCalibration = new System.Windows.Forms.ComboBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabModdelingPage = new System.Windows.Forms.TabPage();
            this.tabRealEstimate = new System.Windows.Forms.TabPage();
            this.lblErrorsNumber = new System.Windows.Forms.Label();
            this.btnLinearityTest = new System.Windows.Forms.Button();
            this.btnReadUsbData = new System.Windows.Forms.Button();
            this.usbReadingDataProgress = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHitsPerCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZeroCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdcRes = new System.Windows.Forms.TextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabModdelingPage.SuspendLayout();
            this.tabRealEstimate.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.Location = new System.Drawing.Point(0, 769);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1088, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нелінійністьToolStripMenuItem,
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem,
            this.показатиКодовіКомбінаціїToolStripMenuItem,
            this.показатиВагиРозрядівToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1088, 26);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // нелінійністьToolStripMenuItem
            // 
            this.нелінійністьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.нелінійністьToolStripMenuItem.Name = "нелінійністьToolStripMenuItem";
            this.нелінійністьToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.нелінійністьToolStripMenuItem.Text = "Інтегральна нелінійність по діапазону";
            this.нелінійністьToolStripMenuItem.Click += new System.EventHandler(this.нелінійністьToolStripMenuItem_Click);
            // 
            // диференціальнаНелінійністьПоДіапазонуToolStripMenuItem
            // 
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem.Name = "диференціальнаНелінійністьПоДіапазонуToolStripMenuItem";
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem.Text = "Диференціальна нелінійність по діапазону";
            this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem.Click += new System.EventHandler(this.диференціальнаНелінійністьПоДіапазонуToolStripMenuItem_Click);
            // 
            // показатиКодовіКомбінаціїToolStripMenuItem
            // 
            this.показатиКодовіКомбінаціїToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.безКалібруванняToolStripMenuItem,
            this.зКалібруваннямToolStripMenuItem,
            this.межовіToolStripMenuItem});
            this.показатиКодовіКомбінаціїToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.показатиКодовіКомбінаціїToolStripMenuItem.Name = "показатиКодовіКомбінаціїToolStripMenuItem";
            this.показатиКодовіКомбінаціїToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.показатиКодовіКомбінаціїToolStripMenuItem.Text = "Показати кодові комбінації";
            // 
            // безКалібруванняToolStripMenuItem
            // 
            this.безКалібруванняToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.безКалібруванняToolStripMenuItem.Name = "безКалібруванняToolStripMenuItem";
            this.безКалібруванняToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.безКалібруванняToolStripMenuItem.Text = "Без калібрування";
            this.безКалібруванняToolStripMenuItem.Click += new System.EventHandler(this.show_regTrackWithoutCalibration);
            // 
            // зКалібруваннямToolStripMenuItem
            // 
            this.зКалібруваннямToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.зКалібруваннямToolStripMenuItem.Name = "зКалібруваннямToolStripMenuItem";
            this.зКалібруваннямToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.зКалібруваннямToolStripMenuItem.Text = "З калібруванням";
            this.зКалібруваннямToolStripMenuItem.Click += new System.EventHandler(this.show_regTrackWithCalibration);
            // 
            // межовіToolStripMenuItem
            // 
            this.межовіToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.межовіToolStripMenuItem.Name = "межовіToolStripMenuItem";
            this.межовіToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.межовіToolStripMenuItem.Text = "Межові";
            this.межовіToolStripMenuItem.Click += new System.EventHandler(this.межовіToolStripMenuItem_Click);
            // 
            // показатиВагиРозрядівToolStripMenuItem
            // 
            this.показатиВагиРозрядівToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.показатиВагиРозрядівToolStripMenuItem.Name = "показатиВагиРозрядівToolStripMenuItem";
            this.показатиВагиРозрядівToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.показатиВагиРозрядівToolStripMenuItem.Text = "Показати ваги розрядів";
            this.показатиВагиРозрядівToolStripMenuItem.Click += new System.EventHandler(this.показатиВагиРозрядівToolStripMenuItem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtBxBeatTime, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbSignalType, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.panelParamOfSignal, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxTimeValue, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.chkbxAnalogSignal, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.chkBxShowReal, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.chkBxShowCalibrated, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.bntStart, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdMethodOfCalibration, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 15;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(158, 700);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Час розрахунку (тактів)";
            // 
            // txtBxBeatTime
            // 
            this.txtBxBeatTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBxBeatTime.Location = new System.Drawing.Point(4, 229);
            this.txtBxBeatTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxBeatTime.Name = "txtBxBeatTime";
            this.txtBxBeatTime.Size = new System.Drawing.Size(132, 24);
            this.txtBxBeatTime.TabIndex = 4;
            this.txtBxBeatTime.Text = "1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Перевірок на такт";
            // 
            // cmbSignalType
            // 
            this.cmbSignalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSignalType.FormattingEnabled = true;
            this.cmbSignalType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbSignalType.Location = new System.Drawing.Point(4, 159);
            this.cmbSignalType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSignalType.Name = "cmbSignalType";
            this.cmbSignalType.Size = new System.Drawing.Size(150, 26);
            this.cmbSignalType.TabIndex = 3;
            this.cmbSignalType.SelectedIndexChanged += new System.EventHandler(this.cmbSignalType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип сигналу";
            // 
            // panelParamOfSignal
            // 
            this.panelParamOfSignal.AutoSize = true;
            this.panelParamOfSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelParamOfSignal.Location = new System.Drawing.Point(4, 190);
            this.panelParamOfSignal.Margin = new System.Windows.Forms.Padding(4);
            this.panelParamOfSignal.Name = "panelParamOfSignal";
            this.panelParamOfSignal.Size = new System.Drawing.Size(0, 0);
            this.panelParamOfSignal.TabIndex = 5;
            // 
            // comboBoxTimeValue
            // 
            this.comboBoxTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTimeValue.FormattingEnabled = true;
            this.comboBoxTimeValue.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "max"});
            this.comboBoxTimeValue.Location = new System.Drawing.Point(4, 97);
            this.comboBoxTimeValue.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTimeValue.Name = "comboBoxTimeValue";
            this.comboBoxTimeValue.Size = new System.Drawing.Size(150, 26);
            this.comboBoxTimeValue.TabIndex = 7;
            this.comboBoxTimeValue.Text = "max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Виводити:";
            // 
            // chkbxAnalogSignal
            // 
            this.chkbxAnalogSignal.AutoSize = true;
            this.chkbxAnalogSignal.Checked = true;
            this.chkbxAnalogSignal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxAnalogSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkbxAnalogSignal.Location = new System.Drawing.Point(4, 291);
            this.chkbxAnalogSignal.Margin = new System.Windows.Forms.Padding(4);
            this.chkbxAnalogSignal.Name = "chkbxAnalogSignal";
            this.chkbxAnalogSignal.Size = new System.Drawing.Size(134, 22);
            this.chkbxAnalogSignal.TabIndex = 11;
            this.chkbxAnalogSignal.Text = "Вхідний сигнал";
            this.chkbxAnalogSignal.UseVisualStyleBackColor = true;
            // 
            // chkBxShowReal
            // 
            this.chkBxShowReal.AutoSize = true;
            this.chkBxShowReal.Checked = true;
            this.chkBxShowReal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxShowReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkBxShowReal.Location = new System.Drawing.Point(4, 377);
            this.chkBxShowReal.Margin = new System.Windows.Forms.Padding(4);
            this.chkBxShowReal.Name = "chkBxShowReal";
            this.chkBxShowReal.Size = new System.Drawing.Size(147, 22);
            this.chkBxShowReal.TabIndex = 9;
            this.chkBxShowReal.Text = "До калібрування";
            this.chkBxShowReal.UseVisualStyleBackColor = true;
            // 
            // chkBxShowCalibrated
            // 
            this.chkBxShowCalibrated.AutoSize = true;
            this.chkBxShowCalibrated.Checked = true;
            this.chkBxShowCalibrated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxShowCalibrated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkBxShowCalibrated.Location = new System.Drawing.Point(4, 334);
            this.chkBxShowCalibrated.Margin = new System.Windows.Forms.Padding(4);
            this.chkBxShowCalibrated.Name = "chkBxShowCalibrated";
            this.chkBxShowCalibrated.Size = new System.Drawing.Size(150, 22);
            this.chkBxShowCalibrated.TabIndex = 8;
            this.chkBxShowCalibrated.Text = "Після калібрування";
            this.chkBxShowCalibrated.UseVisualStyleBackColor = true;
            // 
            // bntStart
            // 
            this.bntStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bntStart.Location = new System.Drawing.Point(4, 420);
            this.bntStart.Margin = new System.Windows.Forms.Padding(4);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(150, 36);
            this.bntStart.TabIndex = 0;
            this.bntStart.Text = "Моделювати";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Метод калібрування";
            // 
            // cmdMethodOfCalibration
            // 
            this.cmdMethodOfCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdMethodOfCalibration.FormattingEnabled = true;
            this.cmdMethodOfCalibration.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "max"});
            this.cmdMethodOfCalibration.Location = new System.Drawing.Point(4, 35);
            this.cmdMethodOfCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMethodOfCalibration.Name = "cmdMethodOfCalibration";
            this.cmdMethodOfCalibration.Size = new System.Drawing.Size(150, 26);
            this.cmdMethodOfCalibration.TabIndex = 7;
            this.cmdMethodOfCalibration.Text = "max";
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tab.Controls.Add(this.tabModdelingPage);
            this.tab.Controls.Add(this.tabRealEstimate);
            this.tab.Location = new System.Drawing.Point(0, 31);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(172, 735);
            this.tab.TabIndex = 11;
            // 
            // tabModdelingPage
            // 
            this.tabModdelingPage.Controls.Add(this.tableLayoutPanel2);
            this.tabModdelingPage.Location = new System.Drawing.Point(4, 25);
            this.tabModdelingPage.Name = "tabModdelingPage";
            this.tabModdelingPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabModdelingPage.Size = new System.Drawing.Size(164, 706);
            this.tabModdelingPage.TabIndex = 0;
            this.tabModdelingPage.Text = "Комп";
            this.tabModdelingPage.UseVisualStyleBackColor = true;
            // 
            // tabRealEstimate
            // 
            this.tabRealEstimate.Controls.Add(this.lblErrorsNumber);
            this.tabRealEstimate.Controls.Add(this.btnLinearityTest);
            this.tabRealEstimate.Controls.Add(this.btnReadUsbData);
            this.tabRealEstimate.Controls.Add(this.usbReadingDataProgress);
            this.tabRealEstimate.Controls.Add(this.label9);
            this.tabRealEstimate.Controls.Add(this.txtHitsPerCode);
            this.tabRealEstimate.Controls.Add(this.label8);
            this.tabRealEstimate.Controls.Add(this.txtMaxCode);
            this.tabRealEstimate.Controls.Add(this.label7);
            this.tabRealEstimate.Controls.Add(this.txtZeroCode);
            this.tabRealEstimate.Controls.Add(this.label6);
            this.tabRealEstimate.Controls.Add(this.txtAdcRes);
            this.tabRealEstimate.Location = new System.Drawing.Point(4, 25);
            this.tabRealEstimate.Name = "tabRealEstimate";
            this.tabRealEstimate.Padding = new System.Windows.Forms.Padding(3);
            this.tabRealEstimate.Size = new System.Drawing.Size(164, 706);
            this.tabRealEstimate.TabIndex = 1;
            this.tabRealEstimate.Text = "Фіз";
            this.tabRealEstimate.UseVisualStyleBackColor = true;
            // 
            // lblErrorsNumber
            // 
            this.lblErrorsNumber.AutoSize = true;
            this.lblErrorsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorsNumber.Location = new System.Drawing.Point(7, 353);
            this.lblErrorsNumber.Name = "lblErrorsNumber";
            this.lblErrorsNumber.Size = new System.Drawing.Size(16, 18);
            this.lblErrorsNumber.TabIndex = 4;
            this.lblErrorsNumber.Text = "0";
            // 
            // btnLinearityTest
            // 
            this.btnLinearityTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinearityTest.Location = new System.Drawing.Point(6, 254);
            this.btnLinearityTest.Name = "btnLinearityTest";
            this.btnLinearityTest.Size = new System.Drawing.Size(151, 34);
            this.btnLinearityTest.TabIndex = 3;
            this.btnLinearityTest.Text = "Тестувати лінійність";
            this.btnLinearityTest.UseVisualStyleBackColor = true;
            this.btnLinearityTest.Click += new System.EventHandler(this.btnLinearityTest_Click);
            // 
            // btnReadUsbData
            // 
            this.btnReadUsbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadUsbData.Location = new System.Drawing.Point(7, 70);
            this.btnReadUsbData.Name = "btnReadUsbData";
            this.btnReadUsbData.Size = new System.Drawing.Size(151, 34);
            this.btnReadUsbData.TabIndex = 3;
            this.btnReadUsbData.Text = "Отримати ХП";
            this.btnReadUsbData.UseVisualStyleBackColor = true;
            this.btnReadUsbData.Click += new System.EventHandler(this.btnReadUsbData_Click);
            // 
            // usbReadingDataProgress
            // 
            this.usbReadingDataProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usbReadingDataProgress.Location = new System.Drawing.Point(7, 299);
            this.usbReadingDataProgress.Name = "usbReadingDataProgress";
            this.usbReadingDataProgress.Size = new System.Drawing.Size(151, 47);
            this.usbReadingDataProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.usbReadingDataProgress.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(8, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Число попадань у код";
            // 
            // txtHitsPerCode
            // 
            this.txtHitsPerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtHitsPerCode.Location = new System.Drawing.Point(11, 221);
            this.txtHitsPerCode.Name = "txtHitsPerCode";
            this.txtHitsPerCode.Size = new System.Drawing.Size(85, 24);
            this.txtHitsPerCode.TabIndex = 0;
            this.txtHitsPerCode.Text = "18";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(8, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Максимальний код";
            // 
            // txtMaxCode
            // 
            this.txtMaxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMaxCode.Location = new System.Drawing.Point(11, 174);
            this.txtMaxCode.Name = "txtMaxCode";
            this.txtMaxCode.Size = new System.Drawing.Size(85, 24);
            this.txtMaxCode.TabIndex = 0;
            this.txtMaxCode.Text = "18";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Нулевий код";
            // 
            // txtZeroCode
            // 
            this.txtZeroCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtZeroCode.Location = new System.Drawing.Point(11, 127);
            this.txtZeroCode.Name = "txtZeroCode";
            this.txtZeroCode.Size = new System.Drawing.Size(85, 24);
            this.txtZeroCode.TabIndex = 0;
            this.txtZeroCode.Text = "18";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(7, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Розрядність";
            // 
            // txtAdcRes
            // 
            this.txtAdcRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAdcRes.Location = new System.Drawing.Point(10, 30);
            this.txtAdcRes.Name = "txtAdcRes";
            this.txtAdcRes.Size = new System.Drawing.Size(85, 24);
            this.txtAdcRes.TabIndex = 0;
            this.txtAdcRes.Text = "18";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl1.ForeColor = System.Drawing.Color.Coral;
            this.zedGraphControl1.IsAutoScrollRange = true;
            this.zedGraphControl1.IsShowCursorValues = true;
            this.zedGraphControl1.IsShowHScrollBar = true;
            this.zedGraphControl1.IsShowVScrollBar = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(178, 31);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(909, 738);
            this.zedGraphControl1.TabIndex = 10;
            // 
            // ADCTimeDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 791);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ADCTimeDiagram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCTimeDiagram";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabModdelingPage.ResumeLayout(false);
            this.tabRealEstimate.ResumeLayout(false);
            this.tabRealEstimate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem нелінійністьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиКодовіКомбінаціїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диференціальнаНелінійністьПоДіапазонуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem безКалібруванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зКалібруваннямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem межовіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиВагиРозрядівToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxBeatTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSignalType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelParamOfSignal;
        private System.Windows.Forms.ComboBox comboBoxTimeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbxAnalogSignal;
        private System.Windows.Forms.CheckBox chkBxShowReal;
        private System.Windows.Forms.CheckBox chkBxShowCalibrated;
        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmdMethodOfCalibration;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabModdelingPage;
        private System.Windows.Forms.TabPage tabRealEstimate;
        private System.Windows.Forms.Button btnReadUsbData;
        private System.Windows.Forms.ProgressBar usbReadingDataProgress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdcRes;
        private System.Windows.Forms.Label lblErrorsNumber;
        public ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button btnLinearityTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtZeroCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHitsPerCode;

    }
}