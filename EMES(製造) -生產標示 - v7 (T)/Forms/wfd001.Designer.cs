namespace EMES.Forms
{
    partial class wfd001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfd001));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.f_del = new System.Windows.Forms.Button();
            this.f_upd = new System.Windows.Forms.Button();
            this.f_add = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.f_prno_bt = new System.Windows.Forms.Button();
            this.f_sfb01 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.f_mlineb = new System.Windows.Forms.ComboBox();
            this.f_mline = new System.Windows.Forms.ComboBox();
            this.f_sdate_e = new System.Windows.Forms.DateTimePicker();
            this.f_mfdate_end = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.f_mfdate_beg = new System.Windows.Forms.TextBox();
            this.f_sdate_s = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.f_plant = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.f_ecm04 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.f_del);
            this.panel2.Controls.Add(this.f_upd);
            this.panel2.Controls.Add(this.f_add);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 41);
            this.panel2.TabIndex = 2;
            // 
            // f_del
            // 
            this.f_del.BackColor = System.Drawing.Color.White;
            this.f_del.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_del.Image = global::EMES.Properties.Resources._1385_Disable_16x16_72;
            this.f_del.Location = new System.Drawing.Point(209, 0);
            this.f_del.Name = "f_del";
            this.f_del.Size = new System.Drawing.Size(45, 41);
            this.f_del.TabIndex = 45;
            this.f_del.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.f_del.UseVisualStyleBackColor = false;
            this.f_del.Click += new System.EventHandler(this.f_del_Click);
            // 
            // f_upd
            // 
            this.f_upd.BackColor = System.Drawing.Color.White;
            this.f_upd.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_upd.Image = ((System.Drawing.Image)(resources.GetObject("f_upd.Image")));
            this.f_upd.Location = new System.Drawing.Point(113, 0);
            this.f_upd.Name = "f_upd";
            this.f_upd.Size = new System.Drawing.Size(45, 41);
            this.f_upd.TabIndex = 44;
            this.f_upd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.f_upd.UseVisualStyleBackColor = false;
            this.f_upd.Click += new System.EventHandler(this.f_upd_Click);
            // 
            // f_add
            // 
            this.f_add.BackColor = System.Drawing.Color.White;
            this.f_add.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_add.Image = global::EMES.Properties.Resources.Item_Add;
            this.f_add.Location = new System.Drawing.Point(7, 0);
            this.f_add.Name = "f_add";
            this.f_add.Size = new System.Drawing.Size(45, 41);
            this.f_add.TabIndex = 43;
            this.f_add.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.f_add.UseVisualStyleBackColor = false;
            this.f_add.Click += new System.EventHandler(this.f_add_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.button3.Location = new System.Drawing.Point(1037, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 41);
            this.button3.TabIndex = 42;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 22);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_sdate_s);
            this.groupBox1.Controls.Add(this.f_mfdate_beg);
            this.groupBox1.Controls.Add(this.f_ecm04);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.f_prno_bt);
            this.groupBox1.Controls.Add(this.f_sfb01);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.f_mlineb);
            this.groupBox1.Controls.Add(this.f_mline);
            this.groupBox1.Controls.Add(this.f_sdate_e);
            this.groupBox1.Controls.Add(this.f_mfdate_end);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_plant);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 529);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(11, 421);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 10130;
            this.label7.Text = "工單";
            this.label7.Visible = false;
            // 
            // f_prno_bt
            // 
            this.f_prno_bt.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_prno_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_prno_bt.Image")));
            this.f_prno_bt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.f_prno_bt.Location = new System.Drawing.Point(221, 418);
            this.f_prno_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_prno_bt.Name = "f_prno_bt";
            this.f_prno_bt.Size = new System.Drawing.Size(49, 35);
            this.f_prno_bt.TabIndex = 10129;
            this.f_prno_bt.Text = "工單";
            this.f_prno_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.f_prno_bt.UseVisualStyleBackColor = true;
            this.f_prno_bt.Visible = false;
            this.f_prno_bt.Click += new System.EventHandler(this.f_prno_bt_Click);
            // 
            // f_sfb01
            // 
            this.f_sfb01.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sfb01.Location = new System.Drawing.Point(62, 418);
            this.f_sfb01.Name = "f_sfb01";
            this.f_sfb01.Size = new System.Drawing.Size(158, 30);
            this.f_sfb01.TabIndex = 10128;
            this.f_sfb01.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(227, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10101;
            this.label6.Text = "（迄）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(227, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10100;
            this.label5.Text = "（起）";
            // 
            // f_mlineb
            // 
            this.f_mlineb.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mlineb.FormattingEnabled = true;
            this.f_mlineb.Location = new System.Drawing.Point(84, 486);
            this.f_mlineb.Name = "f_mlineb";
            this.f_mlineb.Size = new System.Drawing.Size(180, 27);
            this.f_mlineb.TabIndex = 10099;
            this.f_mlineb.Visible = false;
            // 
            // f_mline
            // 
            this.f_mline.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mline.FormattingEnabled = true;
            this.f_mline.Location = new System.Drawing.Point(77, 352);
            this.f_mline.Name = "f_mline";
            this.f_mline.Size = new System.Drawing.Size(180, 27);
            this.f_mline.TabIndex = 10098;
            this.f_mline.Visible = false;
            this.f_mline.SelectedIndexChanged += new System.EventHandler(this.f_mline_SelectedIndexChanged);
            // 
            // f_sdate_e
            // 
            this.f_sdate_e.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sdate_e.Location = new System.Drawing.Point(195, 126);
            this.f_sdate_e.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_e.Name = "f_sdate_e";
            this.f_sdate_e.Size = new System.Drawing.Size(16, 30);
            this.f_sdate_e.TabIndex = 10097;
            this.f_sdate_e.ValueChanged += new System.EventHandler(this.f_sdate_e_ValueChanged);
            // 
            // f_mfdate_end
            // 
            this.f_mfdate_end.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate_end.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mfdate_end.Location = new System.Drawing.Point(81, 126);
            this.f_mfdate_end.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate_end.MaxLength = 10;
            this.f_mfdate_end.Name = "f_mfdate_end";
            this.f_mfdate_end.Size = new System.Drawing.Size(130, 30);
            this.f_mfdate_end.TabIndex = 10096;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 10095;
            this.label4.Text = "排程日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 491);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 10094;
            this.label3.Text = "作業名稱";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 355);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 10093;
            this.label1.Text = "工作站";
            this.label1.Visible = false;
            // 
            // f_mfdate_beg
            // 
            this.f_mfdate_beg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate_beg.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mfdate_beg.Location = new System.Drawing.Point(81, 79);
            this.f_mfdate_beg.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate_beg.MaxLength = 10;
            this.f_mfdate_beg.Name = "f_mfdate_beg";
            this.f_mfdate_beg.Size = new System.Drawing.Size(130, 30);
            this.f_mfdate_beg.TabIndex = 10090;
            // 
            // f_sdate_s
            // 
            this.f_sdate_s.CalendarFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sdate_s.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sdate_s.Location = new System.Drawing.Point(195, 81);
            this.f_sdate_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_s.Name = "f_sdate_s";
            this.f_sdate_s.Size = new System.Drawing.Size(16, 27);
            this.f_sdate_s.TabIndex = 10091;
            this.f_sdate_s.ValueChanged += new System.EventHandler(this.f_sdate_s_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 10092;
            this.label2.Text = "排程日";
            // 
            // f_plant
            // 
            this.f_plant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_plant.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_plant.FormattingEnabled = true;
            this.f_plant.Location = new System.Drawing.Point(81, 35);
            this.f_plant.Name = "f_plant";
            this.f_plant.Size = new System.Drawing.Size(130, 27);
            this.f_plant.TabIndex = 10089;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(32, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 10088;
            this.label8.Text = "廠部";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancel);
            this.groupBox2.Controls.Add(this.confirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(275, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(88, 529);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // cancel
            // 
            this.cancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancel.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel.Location = new System.Drawing.Point(3, 74);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(82, 58);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // confirm
            // 
            this.confirm.Dock = System.Windows.Forms.DockStyle.Top;
            this.confirm.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.confirm.Location = new System.Drawing.Point(3, 18);
            this.confirm.Margin = new System.Windows.Forms.Padding(2);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(82, 56);
            this.confirm.TabIndex = 4;
            this.confirm.Text = "確認";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(363, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(719, 529);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(5, 179);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 10131;
            this.label9.Text = "作業名稱";
            // 
            // f_ecm04
            // 
            this.f_ecm04.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_ecm04.FormattingEnabled = true;
            this.f_ecm04.Location = new System.Drawing.Point(81, 175);
            this.f_ecm04.Name = "f_ecm04";
            this.f_ecm04.Size = new System.Drawing.Size(130, 27);
            this.f_ecm04.TabIndex = 10132;
            // 
            // wfd001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 592);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "wfd001";
            this.Text = "wfd001-加工工單排程";
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button f_del;
        private System.Windows.Forms.Button f_upd;
        private System.Windows.Forms.Button f_add;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox f_plant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox f_mfdate_beg;
        private System.Windows.Forms.DateTimePicker f_sdate_s;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_mfdate_end;
        private System.Windows.Forms.DateTimePicker f_sdate_e;
        private System.Windows.Forms.ComboBox f_mline;
        private System.Windows.Forms.ComboBox f_mlineb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button f_prno_bt;
        private System.Windows.Forms.TextBox f_sfb01;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox f_ecm04;
        private System.Windows.Forms.Label label9;
    }
}