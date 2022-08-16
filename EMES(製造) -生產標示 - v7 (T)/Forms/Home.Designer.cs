namespace EMES.Forms
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pt001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w001加工工單排程ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.w002加工作業ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w003包裝作業ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.倉儲管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.品質管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.壓力台IPQC檢驗製成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.q002ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.製程檢驗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.實驗室檢驗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加工站IPQC檢驗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成品QC檢驗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.異常通報管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排程異常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工時異常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.耗料異常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.品質異常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.報表管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.進度查詢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.wIPToolStripMenuItem,
            this.倉儲管理ToolStripMenuItem,
            this.品質管理ToolStripMenuItem,
            this.異常通報管理ToolStripMenuItem,
            this.報表管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 34);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pt001ToolStripMenuItem,
            this.離開ToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 30);
            this.fileToolStripMenuItem.Text = "檔案";
            // 
            // pt001ToolStripMenuItem
            // 
            this.pt001ToolStripMenuItem.Name = "pt001ToolStripMenuItem";
            this.pt001ToolStripMenuItem.Size = new System.Drawing.Size(145, 30);
            this.pt001ToolStripMenuItem.Text = "pt001";
            this.pt001ToolStripMenuItem.Click += new System.EventHandler(this.pt001ToolStripMenuItem_Click);
            // 
            // 離開ToolStripMenuItem
            // 
            this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
            this.離開ToolStripMenuItem.Size = new System.Drawing.Size(145, 30);
            this.離開ToolStripMenuItem.Text = "離開";
            this.離開ToolStripMenuItem.Click += new System.EventHandler(this.離開ToolStripMenuItem_Click);
            // 
            // wIPToolStripMenuItem
            // 
            this.wIPToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.wIPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.w001加工工單排程ToolStripMenuItem1,
            this.w002加工作業ToolStripMenuItem,
            this.w003包裝作業ToolStripMenuItem});
            this.wIPToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.wIPToolStripMenuItem.Name = "wIPToolStripMenuItem";
            this.wIPToolStripMenuItem.Size = new System.Drawing.Size(108, 30);
            this.wIPToolStripMenuItem.Text = "在製管理";
            // 
            // w001加工工單排程ToolStripMenuItem1
            // 
            this.w001加工工單排程ToolStripMenuItem1.Name = "w001加工工單排程ToolStripMenuItem1";
            this.w001加工工單排程ToolStripMenuItem1.Size = new System.Drawing.Size(276, 30);
            this.w001加工工單排程ToolStripMenuItem1.Text = "W001 加工工單排程";
            this.w001加工工單排程ToolStripMenuItem1.Click += new System.EventHandler(this.w001加工工單排程ToolStripMenuItem1_Click);
            // 
            // w002加工作業ToolStripMenuItem
            // 
            this.w002加工作業ToolStripMenuItem.Name = "w002加工作業ToolStripMenuItem";
            this.w002加工作業ToolStripMenuItem.Size = new System.Drawing.Size(276, 30);
            this.w002加工作業ToolStripMenuItem.Text = "W002 加工作業";
            this.w002加工作業ToolStripMenuItem.Click += new System.EventHandler(this.w002加工作業ToolStripMenuItem_Click);
            // 
            // w003包裝作業ToolStripMenuItem
            // 
            this.w003包裝作業ToolStripMenuItem.Name = "w003包裝作業ToolStripMenuItem";
            this.w003包裝作業ToolStripMenuItem.Size = new System.Drawing.Size(276, 30);
            this.w003包裝作業ToolStripMenuItem.Text = "W003 包裝作業";
            // 
            // 倉儲管理ToolStripMenuItem
            // 
            this.倉儲管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.倉儲管理ToolStripMenuItem.Name = "倉儲管理ToolStripMenuItem";
            this.倉儲管理ToolStripMenuItem.Size = new System.Drawing.Size(108, 30);
            this.倉儲管理ToolStripMenuItem.Text = "倉儲管理";
            // 
            // 品質管理ToolStripMenuItem
            // 
            this.品質管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.壓力台IPQC檢驗製成ToolStripMenuItem,
            this.q002ToolStripMenuItem,
            this.加工站IPQC檢驗ToolStripMenuItem,
            this.成品QC檢驗ToolStripMenuItem});
            this.品質管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.品質管理ToolStripMenuItem.Name = "品質管理ToolStripMenuItem";
            this.品質管理ToolStripMenuItem.Size = new System.Drawing.Size(108, 30);
            this.品質管理ToolStripMenuItem.Text = "品質管理";
            // 
            // 壓力台IPQC檢驗製成ToolStripMenuItem
            // 
            this.壓力台IPQC檢驗製成ToolStripMenuItem.Name = "壓力台IPQC檢驗製成ToolStripMenuItem";
            this.壓力台IPQC檢驗製成ToolStripMenuItem.Size = new System.Drawing.Size(342, 30);
            this.壓力台IPQC檢驗製成ToolStripMenuItem.Text = "Q001 壓力台IPQC檢驗製成";
            // 
            // q002ToolStripMenuItem
            // 
            this.q002ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.製程檢驗ToolStripMenuItem,
            this.實驗室檢驗ToolStripMenuItem});
            this.q002ToolStripMenuItem.Name = "q002ToolStripMenuItem";
            this.q002ToolStripMenuItem.Size = new System.Drawing.Size(342, 30);
            this.q002ToolStripMenuItem.Text = "半成品PQC檢驗";
            // 
            // 製程檢驗ToolStripMenuItem
            // 
            this.製程檢驗ToolStripMenuItem.Name = "製程檢驗ToolStripMenuItem";
            this.製程檢驗ToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.製程檢驗ToolStripMenuItem.Text = "製程檢驗";
            // 
            // 實驗室檢驗ToolStripMenuItem
            // 
            this.實驗室檢驗ToolStripMenuItem.Name = "實驗室檢驗ToolStripMenuItem";
            this.實驗室檢驗ToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.實驗室檢驗ToolStripMenuItem.Text = "實驗室檢驗";
            // 
            // 加工站IPQC檢驗ToolStripMenuItem
            // 
            this.加工站IPQC檢驗ToolStripMenuItem.Name = "加工站IPQC檢驗ToolStripMenuItem";
            this.加工站IPQC檢驗ToolStripMenuItem.Size = new System.Drawing.Size(342, 30);
            this.加工站IPQC檢驗ToolStripMenuItem.Text = "加工站IPQC檢驗";
            // 
            // 成品QC檢驗ToolStripMenuItem
            // 
            this.成品QC檢驗ToolStripMenuItem.Name = "成品QC檢驗ToolStripMenuItem";
            this.成品QC檢驗ToolStripMenuItem.Size = new System.Drawing.Size(342, 30);
            this.成品QC檢驗ToolStripMenuItem.Text = "成品QC檢驗";
            // 
            // 異常通報管理ToolStripMenuItem
            // 
            this.異常通報管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.排程異常ToolStripMenuItem,
            this.工時異常ToolStripMenuItem,
            this.耗料異常ToolStripMenuItem,
            this.品質異常ToolStripMenuItem});
            this.異常通報管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.異常通報管理ToolStripMenuItem.Name = "異常通報管理ToolStripMenuItem";
            this.異常通報管理ToolStripMenuItem.Size = new System.Drawing.Size(150, 30);
            this.異常通報管理ToolStripMenuItem.Text = "異常通報管理";
            // 
            // 排程異常ToolStripMenuItem
            // 
            this.排程異常ToolStripMenuItem.Name = "排程異常ToolStripMenuItem";
            this.排程異常ToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.排程異常ToolStripMenuItem.Text = "排程異常";
            // 
            // 工時異常ToolStripMenuItem
            // 
            this.工時異常ToolStripMenuItem.Name = "工時異常ToolStripMenuItem";
            this.工時異常ToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.工時異常ToolStripMenuItem.Text = "工時異常";
            // 
            // 耗料異常ToolStripMenuItem
            // 
            this.耗料異常ToolStripMenuItem.Name = "耗料異常ToolStripMenuItem";
            this.耗料異常ToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.耗料異常ToolStripMenuItem.Text = "耗料異常";
            // 
            // 品質異常ToolStripMenuItem
            // 
            this.品質異常ToolStripMenuItem.Name = "品質異常ToolStripMenuItem";
            this.品質異常ToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.品質異常ToolStripMenuItem.Text = "品質異常";
            // 
            // 報表管理ToolStripMenuItem
            // 
            this.報表管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.進度查詢ToolStripMenuItem});
            this.報表管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.報表管理ToolStripMenuItem.Name = "報表管理ToolStripMenuItem";
            this.報表管理ToolStripMenuItem.Size = new System.Drawing.Size(108, 30);
            this.報表管理ToolStripMenuItem.Text = "報表管理";
            // 
            // 進度查詢ToolStripMenuItem
            // 
            this.進度查詢ToolStripMenuItem.Name = "進度查詢ToolStripMenuItem";
            this.進度查詢ToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.進度查詢ToolStripMenuItem.Text = "進度查詢";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 465);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "首頁";
            this.Load += new System.EventHandler(this.Home_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Home_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pt001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 離開ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w002加工作業ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w003包裝作業ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 倉儲管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 品質管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 壓力台IPQC檢驗製成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem q002ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 製程檢驗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 實驗室檢驗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加工站IPQC檢驗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成品QC檢驗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 異常通報管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排程異常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工時異常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗料異常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 品質異常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 報表管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 進度查詢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w001加工工單排程ToolStripMenuItem1;
    }
}