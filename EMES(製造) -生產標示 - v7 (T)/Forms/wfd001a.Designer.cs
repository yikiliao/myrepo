namespace EMES.Forms
{
    partial class wfd001a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfd001a));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.f_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.f_mline = new System.Windows.Forms.ComboBox();
            this.f_mlineb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.f_prno_bt = new System.Windows.Forms.Button();
            this.f_schdate_s = new System.Windows.Forms.DateTimePicker();
            this.f_schdate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.f_sfb01 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.f_occ02 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.f_ima01 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.f_ima02 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.f_sfb08 = new System.Windows.Forms.TextBox();
            this.f_sfb13 = new System.Windows.Forms.TextBox();
            this.f_sfb06 = new System.Windows.Forms.TextBox();
            this.f_ima021 = new System.Windows.Forms.RichTextBox();
            this.sfb13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eca02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecb17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ima021 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ima02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfb05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occ02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecb03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfb01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // f_OK
            // 
            this.f_OK.Dock = System.Windows.Forms.DockStyle.Top;
            this.f_OK.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_OK.Location = new System.Drawing.Point(3, 18);
            this.f_OK.Name = "f_OK";
            this.f_OK.Size = new System.Drawing.Size(93, 52);
            this.f_OK.TabIndex = 19;
            this.f_OK.Text = "確認";
            this.f_OK.UseVisualStyleBackColor = true;
            this.f_OK.Click += new System.EventHandler(this.f_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_OK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1285, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 761);
            this.groupBox1.TabIndex = 10093;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1285, 352);
            this.panel2.TabIndex = 10095;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(965, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "作業名稱";
            // 
            // f_mline
            // 
            this.f_mline.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mline.FormattingEnabled = true;
            this.f_mline.Location = new System.Drawing.Point(742, 368);
            this.f_mline.Name = "f_mline";
            this.f_mline.Size = new System.Drawing.Size(180, 27);
            this.f_mline.TabIndex = 20;
            this.f_mline.SelectedIndexChanged += new System.EventHandler(this.f_mline_SelectedIndexChanged);
            // 
            // f_mlineb
            // 
            this.f_mlineb.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mlineb.FormattingEnabled = true;
            this.f_mlineb.Location = new System.Drawing.Point(1060, 367);
            this.f_mlineb.Name = "f_mlineb";
            this.f_mlineb.Size = new System.Drawing.Size(180, 27);
            this.f_mlineb.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(667, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "工作站";
            // 
            // f_prno_bt
            // 
            this.f_prno_bt.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_prno_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_prno_bt.Image")));
            this.f_prno_bt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.f_prno_bt.Location = new System.Drawing.Point(25, 298);
            this.f_prno_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_prno_bt.Name = "f_prno_bt";
            this.f_prno_bt.Size = new System.Drawing.Size(85, 50);
            this.f_prno_bt.TabIndex = 17;
            this.f_prno_bt.Text = "工單";
            this.f_prno_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.f_prno_bt.UseVisualStyleBackColor = true;
            this.f_prno_bt.Click += new System.EventHandler(this.f_prno_bt_Click);
            // 
            // f_schdate_s
            // 
            this.f_schdate_s.Location = new System.Drawing.Point(924, 312);
            this.f_schdate_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_schdate_s.Name = "f_schdate_s";
            this.f_schdate_s.Size = new System.Drawing.Size(16, 22);
            this.f_schdate_s.TabIndex = 10092;
            this.f_schdate_s.ValueChanged += new System.EventHandler(this.f_schdate_s_ValueChanged);
            // 
            // f_schdate
            // 
            this.f_schdate.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_schdate.Location = new System.Drawing.Point(742, 308);
            this.f_schdate.Name = "f_schdate";
            this.f_schdate.Size = new System.Drawing.Size(177, 30);
            this.f_schdate.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(647, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "排程日期";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(163, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 50);
            this.button1.TabIndex = 10093;
            this.button1.Text = "全不選";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(21, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 10094;
            this.label2.Text = "工單";
            // 
            // f_sfb01
            // 
            this.f_sfb01.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sfb01.Location = new System.Drawing.Point(96, 14);
            this.f_sfb01.Name = "f_sfb01";
            this.f_sfb01.Size = new System.Drawing.Size(266, 30);
            this.f_sfb01.TabIndex = 10095;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(466, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 10096;
            this.label3.Text = "客戶";
            // 
            // f_occ02
            // 
            this.f_occ02.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_occ02.Location = new System.Drawing.Point(533, 14);
            this.f_occ02.Name = "f_occ02";
            this.f_occ02.Size = new System.Drawing.Size(266, 30);
            this.f_occ02.TabIndex = 10097;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(21, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 10098;
            this.label4.Text = "料號";
            // 
            // f_ima01
            // 
            this.f_ima01.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_ima01.Location = new System.Drawing.Point(96, 60);
            this.f_ima01.Name = "f_ima01";
            this.f_ima01.Size = new System.Drawing.Size(266, 30);
            this.f_ima01.TabIndex = 10099;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(33, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 10100;
            this.label5.Text = "品名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(21, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 10101;
            this.label8.Text = "規格";
            // 
            // f_ima02
            // 
            this.f_ima02.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_ima02.Location = new System.Drawing.Point(100, 96);
            this.f_ima02.Name = "f_ima02";
            this.f_ima02.Size = new System.Drawing.Size(701, 30);
            this.f_ima02.TabIndex = 10102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(21, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 19);
            this.label9.TabIndex = 10104;
            this.label9.Text = "製程編號";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(339, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 19);
            this.label10.TabIndex = 10105;
            this.label10.Text = "生產數";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(612, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 19);
            this.label11.TabIndex = 10106;
            this.label11.Text = "客戶交期";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.f_ima021);
            this.panel1.Controls.Add(this.f_sfb13);
            this.panel1.Controls.Add(this.f_sfb08);
            this.panel1.Controls.Add(this.f_sfb06);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.f_ima02);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.f_ima01);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.f_occ02);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.f_sfb01);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.f_schdate);
            this.panel1.Controls.Add(this.f_schdate_s);
            this.panel1.Controls.Add(this.f_prno_bt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.f_mlineb);
            this.panel1.Controls.Add(this.f_mline);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1285, 409);
            this.panel1.TabIndex = 10094;
            // 
            // f_sfb08
            // 
            this.f_sfb08.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sfb08.Location = new System.Drawing.Point(414, 226);
            this.f_sfb08.Name = "f_sfb08";
            this.f_sfb08.Size = new System.Drawing.Size(180, 30);
            this.f_sfb08.TabIndex = 10108;
            // 
            // f_sfb13
            // 
            this.f_sfb13.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sfb13.Location = new System.Drawing.Point(707, 226);
            this.f_sfb13.Name = "f_sfb13";
            this.f_sfb13.Size = new System.Drawing.Size(180, 30);
            this.f_sfb13.TabIndex = 10109;
            // 
            // f_sfb06
            // 
            this.f_sfb06.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sfb06.Location = new System.Drawing.Point(131, 226);
            this.f_sfb06.Name = "f_sfb06";
            this.f_sfb06.Size = new System.Drawing.Size(180, 30);
            this.f_sfb06.TabIndex = 10107;
            // 
            // f_ima021
            // 
            this.f_ima021.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_ima021.Location = new System.Drawing.Point(96, 142);
            this.f_ima021.Name = "f_ima021";
            this.f_ima021.Size = new System.Drawing.Size(703, 58);
            this.f_ima021.TabIndex = 10110;
            this.f_ima021.Text = "";
            // 
            // sfb13
            // 
            this.sfb13.DataPropertyName = "sfb13";
            this.sfb13.HeaderText = "sfb13";
            this.sfb13.Name = "sfb13";
            this.sfb13.ReadOnly = true;
            this.sfb13.Width = 68;
            // 
            // eca02
            // 
            this.eca02.DataPropertyName = "eca02";
            this.eca02.HeaderText = "eca02";
            this.eca02.Name = "eca02";
            this.eca02.ReadOnly = true;
            this.eca02.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ecb08";
            this.Column4.HeaderText = "ecb08";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 71;
            // 
            // ecb17
            // 
            this.ecb17.DataPropertyName = "ecb17";
            this.ecb17.HeaderText = "ecb17";
            this.ecb17.Name = "ecb17";
            this.ecb17.ReadOnly = true;
            this.ecb17.Width = 71;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ecb06";
            this.Column2.HeaderText = "ecb06";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 71;
            // 
            // ima021
            // 
            this.ima021.DataPropertyName = "ima021";
            this.ima021.HeaderText = "規格";
            this.ima021.Name = "ima021";
            this.ima021.ReadOnly = true;
            this.ima021.Width = 65;
            // 
            // ima02
            // 
            this.ima02.DataPropertyName = "ima02";
            this.ima02.HeaderText = "品名";
            this.ima02.Name = "ima02";
            this.ima02.ReadOnly = true;
            this.ima02.Width = 65;
            // 
            // sfb05
            // 
            this.sfb05.DataPropertyName = "sfb05";
            this.sfb05.HeaderText = "料件編號";
            this.sfb05.Name = "sfb05";
            this.sfb05.ReadOnly = true;
            this.sfb05.Width = 97;
            // 
            // occ02
            // 
            this.occ02.DataPropertyName = "occ02";
            this.occ02.HeaderText = "客戶";
            this.occ02.Name = "occ02";
            this.occ02.ReadOnly = true;
            this.occ02.Width = 65;
            // 
            // ecb03
            // 
            this.ecb03.DataPropertyName = "ecb03";
            this.ecb03.HeaderText = "製程序號";
            this.ecb03.Name = "ecb03";
            this.ecb03.ReadOnly = true;
            this.ecb03.Width = 97;
            // 
            // sfb01
            // 
            this.sfb01.DataPropertyName = "sfb01";
            this.sfb01.HeaderText = "工單";
            this.sfb01.Name = "sfb01";
            this.sfb01.ReadOnly = true;
            this.sfb01.Width = 65;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 72;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.sfb01,
            this.ecb03,
            this.occ02,
            this.sfb05,
            this.ima02,
            this.ima021,
            this.Column2,
            this.ecb17,
            this.Column4,
            this.eca02,
            this.sfb13});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1285, 542);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // wfd001a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wfd001a";
            this.Text = "wfd001a";
            this.Load += new System.EventHandler(this.wfd001a_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button f_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox f_mline;
        private System.Windows.Forms.ComboBox f_mlineb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button f_prno_bt;
        private System.Windows.Forms.DateTimePicker f_schdate_s;
        private System.Windows.Forms.TextBox f_schdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox f_sfb01;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox f_occ02;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_ima01;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox f_ima02;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox f_sfb08;
        private System.Windows.Forms.TextBox f_sfb13;
        private System.Windows.Forms.RichTextBox f_ima021;
        private System.Windows.Forms.TextBox f_sfb06;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfb01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecb03;
        private System.Windows.Forms.DataGridViewTextBoxColumn occ02;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfb05;
        private System.Windows.Forms.DataGridViewTextBoxColumn ima02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ima021;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecb17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn eca02;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfb13;
    }
}