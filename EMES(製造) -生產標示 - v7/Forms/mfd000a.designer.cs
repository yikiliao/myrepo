namespace EMES.Forms
{
    partial class mfd000a
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
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.Panel();
            this.f_sdate_s = new System.Windows.Forms.DateTimePicker();
            this.f_mfdate = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_ta06 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.f_ta05 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.f_ta04 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.f_ta03 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.f_ta02 = new System.Windows.Forms.NumericUpDown();
            this.f_ta01 = new System.Windows.Forms.NumericUpDown();
            this.f_mfline = new System.Windows.Forms.ComboBox();
            this.f_dept = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta01)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancel.Location = new System.Drawing.Point(3, 41);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(69, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消(Del)";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            this.cancel.MouseHover += new System.EventHandler(this.cancel_MouseHover);
            // 
            // confirm
            // 
            this.confirm.Dock = System.Windows.Forms.DockStyle.Top;
            this.confirm.Location = new System.Drawing.Point(3, 18);
            this.confirm.Margin = new System.Windows.Forms.Padding(2);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(69, 23);
            this.confirm.TabIndex = 0;
            this.confirm.Text = "確認(Esc)";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            this.confirm.MouseHover += new System.EventHandler(this.confirm_MouseHover);
            // 
            // Record
            // 
            this.Record.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Record.Location = new System.Drawing.Point(0, 380);
            this.Record.Margin = new System.Windows.Forms.Padding(2);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(829, 31);
            this.Record.TabIndex = 19;
            // 
            // f_sdate_s
            // 
            this.f_sdate_s.Location = new System.Drawing.Point(163, 50);
            this.f_sdate_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_s.Name = "f_sdate_s";
            this.f_sdate_s.Size = new System.Drawing.Size(16, 22);
            this.f_sdate_s.TabIndex = 10143;
            this.f_sdate_s.ValueChanged += new System.EventHandler(this.f_sdate_s_ValueChanged);
            // 
            // f_mfdate
            // 
            this.f_mfdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate.Location = new System.Drawing.Point(79, 50);
            this.f_mfdate.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate.MaxLength = 10;
            this.f_mfdate.Name = "f_mfdate";
            this.f_mfdate.Size = new System.Drawing.Size(100, 22);
            this.f_mfdate.TabIndex = 5;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(7, 92);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 16700;
            this.label47.Text = "工作桶數";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(7, 18);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(29, 12);
            this.label53.TabIndex = 15100;
            this.label53.Text = "廠部";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(183, 55);
            this.label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(53, 12);
            this.label55.TabIndex = 14400;
            this.label55.Text = "生產線別";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13300;
            this.label2.Text = "生產日期";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(754, 380);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(746, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主畫面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_ta06);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.f_ta05);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.f_ta04);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.f_ta03);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.f_ta02);
            this.groupBox1.Controls.Add(this.f_ta01);
            this.groupBox1.Controls.Add(this.f_mfline);
            this.groupBox1.Controls.Add(this.f_dept);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.label55);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.f_sdate_s);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_mfdate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // f_ta06
            // 
            this.f_ta06.Location = new System.Drawing.Point(79, 265);
            this.f_ta06.MaxLength = 255;
            this.f_ta06.Multiline = true;
            this.f_ta06.Name = "f_ta06";
            this.f_ta06.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.f_ta06.Size = new System.Drawing.Size(651, 36);
            this.f_ta06.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10115;
            this.label4.Text = "翻料桶數";
            // 
            // f_ta05
            // 
            this.f_ta05.DecimalPlaces = 2;
            this.f_ta05.Location = new System.Drawing.Point(79, 235);
            this.f_ta05.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.f_ta05.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.f_ta05.Name = "f_ta05";
            this.f_ta05.Size = new System.Drawing.Size(100, 22);
            this.f_ta05.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 277);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 10132;
            this.label10.Text = "備註";
            // 
            // f_ta04
            // 
            this.f_ta04.DecimalPlaces = 2;
            this.f_ta04.Location = new System.Drawing.Point(79, 198);
            this.f_ta04.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.f_ta04.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.f_ta04.Name = "f_ta04";
            this.f_ta04.Size = new System.Drawing.Size(100, 22);
            this.f_ta04.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10119;
            this.label8.Text = "試料桶數";
            // 
            // f_ta03
            // 
            this.f_ta03.DecimalPlaces = 2;
            this.f_ta03.Location = new System.Drawing.Point(79, 161);
            this.f_ta03.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.f_ta03.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.f_ta03.Name = "f_ta03";
            this.f_ta03.Size = new System.Drawing.Size(100, 22);
            this.f_ta03.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10117;
            this.label5.Text = "洗桶桶數";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 240);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 10127;
            this.label12.Text = "研發桶數";
            // 
            // f_ta02
            // 
            this.f_ta02.DecimalPlaces = 2;
            this.f_ta02.Location = new System.Drawing.Point(79, 124);
            this.f_ta02.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.f_ta02.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.f_ta02.Name = "f_ta02";
            this.f_ta02.Size = new System.Drawing.Size(100, 22);
            this.f_ta02.TabIndex = 8;
            // 
            // f_ta01
            // 
            this.f_ta01.DecimalPlaces = 2;
            this.f_ta01.Location = new System.Drawing.Point(79, 87);
            this.f_ta01.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.f_ta01.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.f_ta01.Name = "f_ta01";
            this.f_ta01.Size = new System.Drawing.Size(100, 22);
            this.f_ta01.TabIndex = 7;
            // 
            // f_mfline
            // 
            this.f_mfline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_mfline.FormattingEnabled = true;
            this.f_mfline.Location = new System.Drawing.Point(240, 51);
            this.f_mfline.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfline.Name = "f_mfline";
            this.f_mfline.Size = new System.Drawing.Size(100, 20);
            this.f_mfline.TabIndex = 6;
            // 
            // f_dept
            // 
            this.f_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_dept.FormattingEnabled = true;
            this.f_dept.Location = new System.Drawing.Point(79, 14);
            this.f_dept.Name = "f_dept";
            this.f_dept.Size = new System.Drawing.Size(100, 20);
            this.f_dept.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancel);
            this.groupBox2.Controls.Add(this.confirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(754, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 380);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 380);
            this.panel1.TabIndex = 28;
            // 
            // mfd000a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Record);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mfd000a";
            this.Text = "mfd000a-製造課桶數維護";
            this.Load += new System.EventHandler(this.mfd001a_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_ta01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel Record;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker f_sdate_s;
        private System.Windows.Forms.TextBox f_mfdate;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox f_dept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox f_mfline;
        private System.Windows.Forms.NumericUpDown f_ta01;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown f_ta05;
        private System.Windows.Forms.NumericUpDown f_ta04;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown f_ta03;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown f_ta02;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_ta06;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}