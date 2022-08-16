namespace EMES.Forms
{
    partial class mfd000
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mfd000));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.menu_add = new System.Windows.Forms.ToolStripButton();
            this.menu_query = new System.Windows.Forms.ToolStripButton();
            this.menu_edit = new System.Windows.Forms.ToolStripButton();
            this.menu_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_exit = new System.Windows.Forms.ToolStripButton();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mfdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wkno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f_sdate_e = new System.Windows.Forms.DateTimePicker();
            this.f_mfdate_end = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.f_sdate_s = new System.Windows.Forms.DateTimePicker();
            this.f_mfdate_beg = new System.Windows.Forms.TextBox();
            this.f_plant = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Record = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Record.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.SystemColors.Control;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_add,
            this.menu_query,
            this.menu_edit,
            this.menu_del,
            this.toolStripSeparator2,
            this.mnu_exit});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(973, 25);
            this.bindingNavigator1.TabIndex = 16;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // menu_add
            // 
            this.menu_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_add.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_add.Image = global::EMES.Properties.Resources.Item_Add;
            this.menu_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_add.Name = "menu_add";
            this.menu_add.Size = new System.Drawing.Size(23, 22);
            this.menu_add.Text = "toolStripButton1";
            this.menu_add.ToolTipText = "新增(Ctrl+A)";
            this.menu_add.Click += new System.EventHandler(this.menu_add_Click);
            // 
            // menu_query
            // 
            this.menu_query.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_query.Image = ((System.Drawing.Image)(resources.GetObject("menu_query.Image")));
            this.menu_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_query.Name = "menu_query";
            this.menu_query.Size = new System.Drawing.Size(23, 22);
            this.menu_query.Text = "toolStripButton1";
            this.menu_query.ToolTipText = "查詢(Ctrl+Q)";
            this.menu_query.Click += new System.EventHandler(this.menu_query_Click);
            // 
            // menu_edit
            // 
            this.menu_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_edit.Image = ((System.Drawing.Image)(resources.GetObject("menu_edit.Image")));
            this.menu_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_edit.Name = "menu_edit";
            this.menu_edit.Size = new System.Drawing.Size(23, 22);
            this.menu_edit.Text = "toolStripButton1";
            this.menu_edit.ToolTipText = "修改(Ctrl+E)";
            this.menu_edit.Click += new System.EventHandler(this.menu_edit_Click);
            // 
            // menu_del
            // 
            this.menu_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_del.Image = ((System.Drawing.Image)(resources.GetObject("menu_del.Image")));
            this.menu_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_del.Name = "menu_del";
            this.menu_del.Size = new System.Drawing.Size(23, 22);
            this.menu_del.Text = "toolStripButton1";
            this.menu_del.ToolTipText = "刪除(Ctrl+D)";
            this.menu_del.Click += new System.EventHandler(this.menu_del_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mnu_exit
            // 
            this.mnu_exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnu_exit.Image = ((System.Drawing.Image)(resources.GetObject("mnu_exit.Image")));
            this.mnu_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_exit.Name = "mnu_exit";
            this.mnu_exit.Size = new System.Drawing.Size(23, 22);
            this.mnu_exit.Text = "toolStripButton1";
            this.mnu_exit.ToolTipText = "離開(Ctrl+Del)";
            this.mnu_exit.Click += new System.EventHandler(this.mnu_exit_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mfdate,
            this.wkno,
            this.Column1,
            this.ta01,
            this.ta02,
            this.ta03,
            this.ta04,
            this.ta05,
            this.ta06});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(266, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(707, 400);
            this.dataGridView1.TabIndex = 145;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // mfdate
            // 
            this.mfdate.DataPropertyName = "mfdate";
            this.mfdate.HeaderText = "生產日期";
            this.mfdate.Name = "mfdate";
            this.mfdate.ReadOnly = true;
            this.mfdate.Width = 78;
            // 
            // wkno
            // 
            this.wkno.DataPropertyName = "mfline";
            this.wkno.HeaderText = "線別";
            this.wkno.Name = "wkno";
            this.wkno.ReadOnly = true;
            this.wkno.Width = 54;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "排程桶數";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 78;
            // 
            // ta01
            // 
            this.ta01.DataPropertyName = "ta01";
            this.ta01.HeaderText = "工作桶數";
            this.ta01.Name = "ta01";
            this.ta01.ReadOnly = true;
            this.ta01.Width = 78;
            // 
            // ta02
            // 
            this.ta02.DataPropertyName = "ta02";
            this.ta02.HeaderText = "翻料桶數";
            this.ta02.Name = "ta02";
            this.ta02.ReadOnly = true;
            this.ta02.Width = 78;
            // 
            // ta03
            // 
            this.ta03.DataPropertyName = "ta03";
            this.ta03.HeaderText = "洗桶桶數";
            this.ta03.Name = "ta03";
            this.ta03.ReadOnly = true;
            this.ta03.Width = 78;
            // 
            // ta04
            // 
            this.ta04.DataPropertyName = "ta04";
            this.ta04.HeaderText = "試料桶數";
            this.ta04.Name = "ta04";
            this.ta04.ReadOnly = true;
            this.ta04.Width = 78;
            // 
            // ta05
            // 
            this.ta05.DataPropertyName = "ta05";
            this.ta05.HeaderText = "研發桶數";
            this.ta05.Name = "ta05";
            this.ta05.ReadOnly = true;
            this.ta05.Width = 78;
            // 
            // ta06
            // 
            this.ta06.DataPropertyName = "ta06";
            this.ta06.HeaderText = "備註";
            this.ta06.Name = "ta06";
            this.ta06.ReadOnly = true;
            this.ta06.Width = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 131;
            this.label8.Text = "廠部";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_sdate_e);
            this.groupBox1.Controls.Add(this.f_mfdate_end);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_sdate_s);
            this.groupBox1.Controls.Add(this.f_mfdate_beg);
            this.groupBox1.Controls.Add(this.f_plant);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 12);
            this.label4.TabIndex = 10083;
            this.label4.Text = "(迄)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 12);
            this.label3.TabIndex = 10082;
            this.label3.Text = "(起)";
            // 
            // f_sdate_e
            // 
            this.f_sdate_e.Location = new System.Drawing.Point(142, 91);
            this.f_sdate_e.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_e.Name = "f_sdate_e";
            this.f_sdate_e.Size = new System.Drawing.Size(16, 22);
            this.f_sdate_e.TabIndex = 10081;
            this.f_sdate_e.ValueChanged += new System.EventHandler(this.f_sdate_e_ValueChanged);
            // 
            // f_mfdate_end
            // 
            this.f_mfdate_end.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate_end.Location = new System.Drawing.Point(58, 91);
            this.f_mfdate_end.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate_end.MaxLength = 10;
            this.f_mfdate_end.Name = "f_mfdate_end";
            this.f_mfdate_end.Size = new System.Drawing.Size(100, 22);
            this.f_mfdate_end.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10079;
            this.label1.Text = "生產日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10076;
            this.label2.Text = "生產日期";
            // 
            // f_sdate_s
            // 
            this.f_sdate_s.Location = new System.Drawing.Point(142, 52);
            this.f_sdate_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_s.Name = "f_sdate_s";
            this.f_sdate_s.Size = new System.Drawing.Size(16, 22);
            this.f_sdate_s.TabIndex = 10075;
            this.f_sdate_s.ValueChanged += new System.EventHandler(this.f_sdate_s_ValueChanged);
            // 
            // f_mfdate_beg
            // 
            this.f_mfdate_beg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_mfdate_beg.Location = new System.Drawing.Point(58, 52);
            this.f_mfdate_beg.Margin = new System.Windows.Forms.Padding(2);
            this.f_mfdate_beg.MaxLength = 10;
            this.f_mfdate_beg.Name = "f_mfdate_beg";
            this.f_mfdate_beg.Size = new System.Drawing.Size(100, 22);
            this.f_mfdate_beg.TabIndex = 1;
            // 
            // f_plant
            // 
            this.f_plant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_plant.FormattingEnabled = true;
            this.f_plant.Location = new System.Drawing.Point(58, 14);
            this.f_plant.Name = "f_plant";
            this.f_plant.Size = new System.Drawing.Size(100, 20);
            this.f_plant.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cancel);
            this.groupBox4.Controls.Add(this.confirm);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(191, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(75, 400);
            this.groupBox4.TabIndex = 149;
            this.groupBox4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 400);
            this.panel3.TabIndex = 150;
            // 
            // Record
            // 
            this.Record.Controls.Add(this.groupBox2);
            this.Record.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Record.Location = new System.Drawing.Point(0, 425);
            this.Record.Margin = new System.Windows.Forms.Padding(2);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(973, 40);
            this.Record.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(973, 40);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // mfd000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 465);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mfd000";
            this.Text = "mfd000-製造課桶數維護";
            this.Load += new System.EventHandler(this.mfd001_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pri036_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.Record.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton menu_add;
        private System.Windows.Forms.ToolStripButton menu_edit;
        private System.Windows.Forms.ToolStripButton menu_query;
        private System.Windows.Forms.ToolStripButton mnu_exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton menu_del;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox f_plant;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker f_sdate_s;
        private System.Windows.Forms.TextBox f_mfdate_beg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker f_sdate_e;
        private System.Windows.Forms.TextBox f_mfdate_end;
        private System.Windows.Forms.Panel Record;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mfdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn wkno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta03;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta04;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta05;
        private System.Windows.Forms.DataGridViewTextBoxColumn ta06;
    }
}