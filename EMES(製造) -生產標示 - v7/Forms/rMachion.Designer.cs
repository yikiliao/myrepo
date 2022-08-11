namespace EMES.Forms
{
    partial class rMachion
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
            this.eci01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eci03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eci06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eca03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gem02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_OK = new System.Windows.Forms.Button();
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
            this.eci01,
            this.eci03,
            this.eci06,
            this.eca03,
            this.gem02});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.dataGridView1.Size = new System.Drawing.Size(950, 470);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // eci01
            // 
            this.eci01.DataPropertyName = "eci01";
            this.eci01.HeaderText = "機台編號";
            this.eci01.Name = "eci01";
            this.eci01.ReadOnly = true;
            this.eci01.Width = 61;
            // 
            // eci03
            // 
            this.eci03.DataPropertyName = "eci03";
            this.eci03.HeaderText = "工作站";
            this.eci03.Name = "eci03";
            this.eci03.ReadOnly = true;
            this.eci03.Width = 61;
            // 
            // eci06
            // 
            this.eci06.DataPropertyName = "eci06";
            this.eci06.HeaderText = "機台說明";
            this.eci06.Name = "eci06";
            this.eci06.ReadOnly = true;
            this.eci06.Width = 61;
            // 
            // eca03
            // 
            this.eca03.DataPropertyName = "eca03";
            this.eca03.HeaderText = "所屬部門";
            this.eca03.Name = "eca03";
            this.eca03.ReadOnly = true;
            this.eca03.Width = 61;
            // 
            // gem02
            // 
            this.gem02.DataPropertyName = "gem02";
            this.gem02.HeaderText = "所屬部門說明";
            this.gem02.Name = "gem02";
            this.gem02.ReadOnly = true;
            this.gem02.Width = 72;
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_OK.Location = new System.Drawing.Point(12, 499);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 50);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "確認";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // rMachion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dataGridView1);
            this.Name = "rMachion";
            this.Text = "rMachion";
            this.Load += new System.EventHandler(this.rMachion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridViewTextBoxColumn eci01;
        private System.Windows.Forms.DataGridViewTextBoxColumn eci03;
        private System.Windows.Forms.DataGridViewTextBoxColumn eci06;
        private System.Windows.Forms.DataGridViewTextBoxColumn eca03;
        private System.Windows.Forms.DataGridViewTextBoxColumn gem02;
    }
}