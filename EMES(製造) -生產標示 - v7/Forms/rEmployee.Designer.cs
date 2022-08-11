namespace EMES.Forms
{
    partial class rEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.Bcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B2Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bcheck,
            this.BCode,
            this.BCnName,
            this.B2Code,
            this.B2Name,
            this.CCode,
            this.CName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1050, 470);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_OK.Location = new System.Drawing.Point(12, 499);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 50);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "確認";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // Bcheck
            // 
            this.Bcheck.HeaderText = "選取";
            this.Bcheck.Name = "Bcheck";
            this.Bcheck.ReadOnly = true;
            this.Bcheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Bcheck.Width = 35;
            // 
            // BCode
            // 
            this.BCode.DataPropertyName = "BCode";
            this.BCode.HeaderText = "工號";
            this.BCode.Name = "BCode";
            this.BCode.ReadOnly = true;
            this.BCode.Width = 54;
            // 
            // BCnName
            // 
            this.BCnName.DataPropertyName = "BCnName";
            this.BCnName.HeaderText = "姓名";
            this.BCnName.Name = "BCnName";
            this.BCnName.ReadOnly = true;
            this.BCnName.Width = 54;
            // 
            // B2Code
            // 
            this.B2Code.DataPropertyName = "B2Code";
            this.B2Code.HeaderText = "組別";
            this.B2Code.Name = "B2Code";
            this.B2Code.ReadOnly = true;
            this.B2Code.Width = 54;
            // 
            // B2Name
            // 
            this.B2Name.DataPropertyName = "B2Name";
            this.B2Name.HeaderText = "組別說明";
            this.B2Name.Name = "B2Name";
            this.B2Name.ReadOnly = true;
            this.B2Name.Width = 78;
            // 
            // CCode
            // 
            this.CCode.DataPropertyName = "CCode";
            this.CCode.HeaderText = "班別代碼";
            this.CCode.Name = "CCode";
            this.CCode.ReadOnly = true;
            this.CCode.Width = 78;
            // 
            // CName
            // 
            this.CName.DataPropertyName = "CName";
            this.CName.HeaderText = "班別說明";
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            this.CName.Width = 78;
            // 
            // rEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dataGridView1);
            this.Name = "rEmployee";
            this.Text = "rEmployee";
            this.Load += new System.EventHandler(this.rEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Bcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn B2Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn B2Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
    }
}