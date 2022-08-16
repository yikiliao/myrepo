namespace EMES.Forms
{
    partial class wfd002a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfd002a));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.f_station = new System.Windows.Forms.TextBox();
            this.f_works = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.f_sub = new System.Windows.Forms.Button();
            this.f_mfd = new System.Windows.Forms.TextBox();
            this.f_docno = new System.Windows.Forms.TextBox();
            this.f_add = new System.Windows.Forms.Button();
            this.f_gp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.f_ng = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sfb01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfb05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ima02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ima021 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labMessage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_OK = new System.Windows.Forms.Button();
            this.f_prno_bt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作站";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "作業人數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "良品";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(610, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "不良品";
            // 
            // f_station
            // 
            this.f_station.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_station.Location = new System.Drawing.Point(146, 20);
            this.f_station.Name = "f_station";
            this.f_station.Size = new System.Drawing.Size(277, 33);
            this.f_station.TabIndex = 4;
            // 
            // f_works
            // 
            this.f_works.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_works.Location = new System.Drawing.Point(146, 80);
            this.f_works.Name = "f_works";
            this.f_works.Size = new System.Drawing.Size(113, 36);
            this.f_works.TabIndex = 6;
            this.f_works.Text = "0";
            this.f_works.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.f_works.Click += new System.EventHandler(this.f_works_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.f_station);
            this.panel1.Controls.Add(this.f_prno_bt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.f_sub);
            this.panel1.Controls.Add(this.f_works);
            this.panel1.Controls.Add(this.f_mfd);
            this.panel1.Controls.Add(this.f_docno);
            this.panel1.Controls.Add(this.f_add);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.f_gp);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.f_ng);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 761);
            this.panel1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(610, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "日期";
            // 
            // f_sub
            // 
            this.f_sub.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_sub.Location = new System.Drawing.Point(352, 75);
            this.f_sub.Name = "f_sub";
            this.f_sub.Size = new System.Drawing.Size(71, 46);
            this.f_sub.TabIndex = 8;
            this.f_sub.Text = "-";
            this.f_sub.UseVisualStyleBackColor = true;
            this.f_sub.Click += new System.EventHandler(this.f_sub_Click);
            // 
            // f_mfd
            // 
            this.f_mfd.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mfd.Location = new System.Drawing.Point(740, 20);
            this.f_mfd.Name = "f_mfd";
            this.f_mfd.Size = new System.Drawing.Size(177, 33);
            this.f_mfd.TabIndex = 10;
            // 
            // f_docno
            // 
            this.f_docno.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_docno.Location = new System.Drawing.Point(740, 78);
            this.f_docno.Name = "f_docno";
            this.f_docno.Size = new System.Drawing.Size(209, 33);
            this.f_docno.TabIndex = 14;
            // 
            // f_add
            // 
            this.f_add.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_add.Location = new System.Drawing.Point(275, 75);
            this.f_add.Name = "f_add";
            this.f_add.Size = new System.Drawing.Size(71, 46);
            this.f_add.TabIndex = 7;
            this.f_add.Text = "+";
            this.f_add.UseVisualStyleBackColor = true;
            this.f_add.Click += new System.EventHandler(this.f_add_Click);
            // 
            // f_gp
            // 
            this.f_gp.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_gp.Location = new System.Drawing.Point(146, 142);
            this.f_gp.Name = "f_gp";
            this.f_gp.Size = new System.Drawing.Size(113, 36);
            this.f_gp.TabIndex = 11;
            this.f_gp.Text = "0";
            this.f_gp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.f_gp.Click += new System.EventHandler(this.f_gp_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(610, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "單據號";
            // 
            // f_ng
            // 
            this.f_ng.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_ng.Location = new System.Drawing.Point(740, 142);
            this.f_ng.Name = "f_ng";
            this.f_ng.Size = new System.Drawing.Size(113, 36);
            this.f_ng.TabIndex = 12;
            this.f_ng.Text = "0";
            this.f_ng.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.f_ng.Click += new System.EventHandler(this.f_ng_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.labMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 494);
            this.panel2.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sfb01,
            this.sfb05,
            this.ima02,
            this.ima021});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1069, 494);
            this.dataGridView1.TabIndex = 17;
            // 
            // sfb01
            // 
            this.sfb01.DataPropertyName = "sfb01";
            this.sfb01.HeaderText = "工單";
            this.sfb01.Name = "sfb01";
            this.sfb01.ReadOnly = true;
            this.sfb01.Width = 54;
            // 
            // sfb05
            // 
            this.sfb05.DataPropertyName = "sfb05";
            this.sfb05.HeaderText = "料件編號";
            this.sfb05.Name = "sfb05";
            this.sfb05.ReadOnly = true;
            this.sfb05.Width = 78;
            // 
            // ima02
            // 
            this.ima02.DataPropertyName = "ima02";
            this.ima02.HeaderText = "品名";
            this.ima02.Name = "ima02";
            this.ima02.ReadOnly = true;
            this.ima02.Width = 54;
            // 
            // ima021
            // 
            this.ima021.DataPropertyName = "ima021";
            this.ima021.HeaderText = "規格";
            this.ima021.Name = "ima021";
            this.ima021.ReadOnly = true;
            this.ima021.Width = 54;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(12, 267);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(33, 12);
            this.labMessage.TabIndex = 0;
            this.labMessage.Text = "label8";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_OK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1069, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 761);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // f_OK
            // 
            this.f_OK.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_OK.Location = new System.Drawing.Point(6, 76);
            this.f_OK.Name = "f_OK";
            this.f_OK.Size = new System.Drawing.Size(92, 52);
            this.f_OK.TabIndex = 0;
            this.f_OK.Text = "確認";
            this.f_OK.UseVisualStyleBackColor = true;
            this.f_OK.Click += new System.EventHandler(this.f_OK_Click);
            // 
            // f_prno_bt
            // 
            this.f_prno_bt.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_prno_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_prno_bt.Image")));
            this.f_prno_bt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.f_prno_bt.Location = new System.Drawing.Point(12, 202);
            this.f_prno_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_prno_bt.Name = "f_prno_bt";
            this.f_prno_bt.Size = new System.Drawing.Size(84, 50);
            this.f_prno_bt.TabIndex = 16;
            this.f_prno_bt.Text = "工單";
            this.f_prno_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.f_prno_bt.UseVisualStyleBackColor = true;
            this.f_prno_bt.Click += new System.EventHandler(this.f_prno_bt_Click);
            // 
            // wfd002a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wfd002a";
            this.Text = "W002a加工作業";
            this.Load += new System.EventHandler(this.wfd002a_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_station;
        private System.Windows.Forms.TextBox f_works;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button f_sub;
        private System.Windows.Forms.Button f_add;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox f_mfd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox f_ng;
        private System.Windows.Forms.TextBox f_gp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button f_OK;
        private System.Windows.Forms.TextBox f_docno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button f_prno_bt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfb01;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfb05;
        private System.Windows.Forms.DataGridViewTextBoxColumn ima02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ima021;
    }
}