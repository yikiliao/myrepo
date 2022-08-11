namespace EMES.Forms
{
    partial class wfd002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfd002));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.f_del = new System.Windows.Forms.Button();
            this.f_upd = new System.Windows.Forms.Button();
            this.f_add = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f_plant = new System.Windows.Forms.ComboBox();
            this.f_sdate_e = new System.Windows.Forms.DateTimePicker();
            this.f_mfdate_beg = new System.Windows.Forms.TextBox();
            this.f_mfdate_end = new System.Windows.Forms.TextBox();
            this.f_sdate_s = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.labPageIndex = new System.Windows.Forms.Label();
            this.labRecordCount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 12);
            this.panel1.TabIndex = 0;
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
            this.panel2.Size = new System.Drawing.Size(1200, 41);
            this.panel2.TabIndex = 1;
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
            this.button3.Location = new System.Drawing.Point(1155, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 41);
            this.button3.TabIndex = 42;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_plant);
            this.groupBox1.Controls.Add(this.f_sdate_e);
            this.groupBox1.Controls.Add(this.f_mfdate_beg);
            this.groupBox1.Controls.Add(this.f_mfdate_end);
            this.groupBox1.Controls.Add(this.f_sdate_s);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 502);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 12);
            this.label4.TabIndex = 10093;
            this.label4.Text = "(迄)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 10087;
            this.label8.Text = "廠部";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 12);
            this.label3.TabIndex = 10092;
            this.label3.Text = "(起)";
            // 
            // f_plant
            // 
            this.f_plant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_plant.FormattingEnabled = true;
            this.f_plant.Location = new System.Drawing.Point(58, 28);
            this.f_plant.Name = "f_plant";
            this.f_plant.Size = new System.Drawing.Size(100, 20);
            this.f_plant.TabIndex = 10084;
            // 
            // f_sdate_e
            // 
            this.f_sdate_e.Location = new System.Drawing.Point(162, 105);
            this.f_sdate_e.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_e.Name = "f_sdate_e";
            this.f_sdate_e.Size = new System.Drawing.Size(16, 22);
            this.f_sdate_e.TabIndex = 10091;
            this.f_sdate_e.ValueChanged += new System.EventHandler(this.f_sdate_e_ValueChanged);
            // 
            // f_mfdate_beg
            // 
            this.f_mfdate_beg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate_beg.Location = new System.Drawing.Point(58, 68);
            this.f_mfdate_beg.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate_beg.MaxLength = 10;
            this.f_mfdate_beg.Name = "f_mfdate_beg";
            this.f_mfdate_beg.Size = new System.Drawing.Size(100, 22);
            this.f_mfdate_beg.TabIndex = 10085;
            // 
            // f_mfdate_end
            // 
            this.f_mfdate_end.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate_end.Location = new System.Drawing.Point(58, 105);
            this.f_mfdate_end.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate_end.MaxLength = 10;
            this.f_mfdate_end.Name = "f_mfdate_end";
            this.f_mfdate_end.Size = new System.Drawing.Size(100, 22);
            this.f_mfdate_end.TabIndex = 10086;
            // 
            // f_sdate_s
            // 
            this.f_sdate_s.Location = new System.Drawing.Point(162, 68);
            this.f_sdate_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_s.Name = "f_sdate_s";
            this.f_sdate_s.Size = new System.Drawing.Size(16, 22);
            this.f_sdate_s.TabIndex = 10088;
            this.f_sdate_s.ValueChanged += new System.EventHandler(this.f_sdate_s_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10090;
            this.label1.Text = "生產日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10089;
            this.label2.Text = "生產日期";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancel);
            this.groupBox2.Controls.Add(this.confirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(226, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 502);
            this.groupBox2.TabIndex = 3;
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
            this.cancel.Size = new System.Drawing.Size(101, 58);
            this.cancel.TabIndex = 3;
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
            this.confirm.Size = new System.Drawing.Size(101, 56);
            this.confirm.TabIndex = 2;
            this.confirm.Text = "確認";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(333, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(867, 421);
            this.dataGridView1.TabIndex = 76;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.SkyBlue;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLast.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLast.Location = new System.Drawing.Point(740, 41);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(120, 35);
            this.btnLast.TabIndex = 93;
            this.btnLast.Text = "末頁";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SkyBlue;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNext.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNext.Location = new System.Drawing.Point(499, 41);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 35);
            this.btnNext.TabIndex = 92;
            this.btnNext.Text = "下一頁";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.SkyBlue;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrev.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPrev.Location = new System.Drawing.Point(258, 41);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(120, 35);
            this.btnPrev.TabIndex = 91;
            this.btnPrev.Text = "上一頁";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.SkyBlue;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFirst.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFirst.Location = new System.Drawing.Point(17, 41);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(120, 35);
            this.btnFirst.TabIndex = 90;
            this.btnFirst.Text = "首頁";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // labPageIndex
            // 
            this.labPageIndex.AutoSize = true;
            this.labPageIndex.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPageIndex.ForeColor = System.Drawing.Color.DarkBlue;
            this.labPageIndex.Location = new System.Drawing.Point(24, 9);
            this.labPageIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPageIndex.Name = "labPageIndex";
            this.labPageIndex.Size = new System.Drawing.Size(76, 21);
            this.labPageIndex.TabIndex = 88;
            this.labPageIndex.Text = "當前頁";
            // 
            // labRecordCount
            // 
            this.labRecordCount.AutoSize = true;
            this.labRecordCount.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labRecordCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.labRecordCount.Location = new System.Drawing.Point(240, 9);
            this.labRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labRecordCount.Name = "labRecordCount";
            this.labRecordCount.Size = new System.Drawing.Size(76, 21);
            this.labRecordCount.TabIndex = 89;
            this.labRecordCount.Text = "總行數";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labRecordCount);
            this.panel3.Controls.Add(this.btnLast);
            this.panel3.Controls.Add(this.labPageIndex);
            this.panel3.Controls.Add(this.btnFirst);
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnPrev);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(333, 462);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(867, 81);
            this.panel3.TabIndex = 77;
            // 
            // wfd002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 555);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "wfd002";
            this.Text = "wfd002-加工廠";
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox f_plant;
        private System.Windows.Forms.DateTimePicker f_sdate_e;
        private System.Windows.Forms.TextBox f_mfdate_beg;
        private System.Windows.Forms.TextBox f_mfdate_end;
        private System.Windows.Forms.DateTimePicker f_sdate_s;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label labPageIndex;
        private System.Windows.Forms.Label labRecordCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button f_add;
        private System.Windows.Forms.Button f_upd;
        private System.Windows.Forms.Button f_del;
    }
}