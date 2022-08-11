namespace EMES.Forms
{
    partial class wfd001u
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
            this.label1 = new System.Windows.Forms.Label();
            this.f_schdate = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.f_sdate_s = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
            // 
            // f_schdate
            // 
            this.f_schdate.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_schdate.Location = new System.Drawing.Point(125, 38);
            this.f_schdate.Name = "f_schdate";
            this.f_schdate.Size = new System.Drawing.Size(166, 33);
            this.f_schdate.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_OK.Location = new System.Drawing.Point(416, 38);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "確認";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // f_sdate_s
            // 
            this.f_sdate_s.Location = new System.Drawing.Point(296, 41);
            this.f_sdate_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_sdate_s.Name = "f_sdate_s";
            this.f_sdate_s.Size = new System.Drawing.Size(16, 22);
            this.f_sdate_s.TabIndex = 10092;
            this.f_sdate_s.ValueChanged += new System.EventHandler(this.f_sdate_s_ValueChanged);
            // 
            // wfd001u
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 109);
            this.Controls.Add(this.f_sdate_s);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.f_schdate);
            this.Controls.Add(this.label1);
            this.Name = "wfd001u";
            this.Text = "wfd001u-日期修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox f_schdate;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DateTimePicker f_sdate_s;
    }
}