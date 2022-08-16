namespace EMES.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.f_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.f_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.f_db = new System.Windows.Forms.ComboBox();
            this.f_plant = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_9 = new System.Windows.Forms.Button();
            this.bt_0 = new System.Windows.Forms.Button();
            this.bt_8 = new System.Windows.Forms.Button();
            this.bt_7 = new System.Windows.Forms.Button();
            this.bt_6 = new System.Windows.Forms.Button();
            this.bt_3 = new System.Windows.Forms.Button();
            this.bt_4 = new System.Windows.Forms.Button();
            this.bt_5 = new System.Windows.Forms.Button();
            this.bt_2 = new System.Windows.Forms.Button();
            this.bt_1 = new System.Windows.Forms.Button();
            this.bt_z = new System.Windows.Forms.Button();
            this.bt_y = new System.Windows.Forms.Button();
            this.bt_x = new System.Windows.Forms.Button();
            this.bt_w = new System.Windows.Forms.Button();
            this.bt_v = new System.Windows.Forms.Button();
            this.bt_u = new System.Windows.Forms.Button();
            this.bt_t = new System.Windows.Forms.Button();
            this.bt_s = new System.Windows.Forms.Button();
            this.bt_r = new System.Windows.Forms.Button();
            this.bt_i = new System.Windows.Forms.Button();
            this.bt_q = new System.Windows.Forms.Button();
            this.bt_p = new System.Windows.Forms.Button();
            this.bt_o = new System.Windows.Forms.Button();
            this.bt_n = new System.Windows.Forms.Button();
            this.bt_m = new System.Windows.Forms.Button();
            this.bt_l = new System.Windows.Forms.Button();
            this.bt_k = new System.Windows.Forms.Button();
            this.bt_j = new System.Windows.Forms.Button();
            this.bt_h = new System.Windows.Forms.Button();
            this.bt_g = new System.Windows.Forms.Button();
            this.bt_f = new System.Windows.Forms.Button();
            this.bt_c = new System.Windows.Forms.Button();
            this.bt_d = new System.Windows.Forms.Button();
            this.bt_e = new System.Windows.Forms.Button();
            this.bt_b = new System.Windows.Forms.Button();
            this.bt_a = new System.Windows.Forms.Button();
            this.bt_cls = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menu_exit = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // f_id
            // 
            this.f_id.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_id.Location = new System.Drawing.Point(119, 17);
            this.f_id.Margin = new System.Windows.Forms.Padding(2);
            this.f_id.Name = "f_id";
            this.f_id.Size = new System.Drawing.Size(218, 42);
            this.f_id.TabIndex = 0;
            this.f_id.Click += new System.EventHandler(this.f_id_Click);
            this.f_id.Validating += new System.ComponentModel.CancelEventHandler(this.f_id_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "密碼";
            // 
            // f_password
            // 
            this.f_password.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_password.Location = new System.Drawing.Point(119, 69);
            this.f_password.Margin = new System.Windows.Forms.Padding(2);
            this.f_password.Name = "f_password";
            this.f_password.Size = new System.Drawing.Size(218, 42);
            this.f_password.TabIndex = 1;
            this.f_password.UseSystemPasswordChar = true;
            this.f_password.Click += new System.EventHandler(this.f_password_Click);
            this.f_password.Validating += new System.ComponentModel.CancelEventHandler(this.f_password_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(10, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "廠部";
            // 
            // f_db
            // 
            this.f_db.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_db.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_db.FormattingEnabled = true;
            this.f_db.Location = new System.Drawing.Point(99, 285);
            this.f_db.Name = "f_db";
            this.f_db.Size = new System.Drawing.Size(218, 29);
            this.f_db.TabIndex = 3;
            this.f_db.Visible = false;
            // 
            // f_plant
            // 
            this.f_plant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_plant.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_plant.FormattingEnabled = true;
            this.f_plant.Location = new System.Drawing.Point(119, 121);
            this.f_plant.Name = "f_plant";
            this.f_plant.Size = new System.Drawing.Size(218, 37);
            this.f_plant.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(12, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "資料庫";
            this.label4.Visible = false;
            // 
            // bt_9
            // 
            this.bt_9.BackColor = System.Drawing.Color.Yellow;
            this.bt_9.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_9.Location = new System.Drawing.Point(900, 30);
            this.bt_9.Name = "bt_9";
            this.bt_9.Size = new System.Drawing.Size(40, 40);
            this.bt_9.TabIndex = 82;
            this.bt_9.Text = "9";
            this.bt_9.UseVisualStyleBackColor = false;
            this.bt_9.Visible = false;
            this.bt_9.Click += new System.EventHandler(this.bt_9_Click);
            // 
            // bt_0
            // 
            this.bt_0.BackColor = System.Drawing.Color.Yellow;
            this.bt_0.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_0.Location = new System.Drawing.Point(459, 30);
            this.bt_0.Name = "bt_0";
            this.bt_0.Size = new System.Drawing.Size(40, 40);
            this.bt_0.TabIndex = 81;
            this.bt_0.Text = "0";
            this.bt_0.UseVisualStyleBackColor = false;
            this.bt_0.Visible = false;
            this.bt_0.Click += new System.EventHandler(this.bt_0_Click);
            // 
            // bt_8
            // 
            this.bt_8.BackColor = System.Drawing.Color.Yellow;
            this.bt_8.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_8.Location = new System.Drawing.Point(851, 30);
            this.bt_8.Name = "bt_8";
            this.bt_8.Size = new System.Drawing.Size(40, 40);
            this.bt_8.TabIndex = 80;
            this.bt_8.Text = "8";
            this.bt_8.UseVisualStyleBackColor = false;
            this.bt_8.Visible = false;
            this.bt_8.Click += new System.EventHandler(this.bt_8_Click);
            // 
            // bt_7
            // 
            this.bt_7.BackColor = System.Drawing.Color.Yellow;
            this.bt_7.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_7.Location = new System.Drawing.Point(802, 30);
            this.bt_7.Name = "bt_7";
            this.bt_7.Size = new System.Drawing.Size(40, 40);
            this.bt_7.TabIndex = 79;
            this.bt_7.Text = "7";
            this.bt_7.UseVisualStyleBackColor = false;
            this.bt_7.Visible = false;
            this.bt_7.Click += new System.EventHandler(this.bt_7_Click);
            // 
            // bt_6
            // 
            this.bt_6.BackColor = System.Drawing.Color.Yellow;
            this.bt_6.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_6.Location = new System.Drawing.Point(753, 30);
            this.bt_6.Name = "bt_6";
            this.bt_6.Size = new System.Drawing.Size(40, 40);
            this.bt_6.TabIndex = 78;
            this.bt_6.Text = "6";
            this.bt_6.UseVisualStyleBackColor = false;
            this.bt_6.Visible = false;
            this.bt_6.Click += new System.EventHandler(this.bt_6_Click);
            // 
            // bt_3
            // 
            this.bt_3.BackColor = System.Drawing.Color.Yellow;
            this.bt_3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_3.Location = new System.Drawing.Point(606, 30);
            this.bt_3.Name = "bt_3";
            this.bt_3.Size = new System.Drawing.Size(40, 40);
            this.bt_3.TabIndex = 77;
            this.bt_3.Text = "3";
            this.bt_3.UseVisualStyleBackColor = false;
            this.bt_3.Visible = false;
            this.bt_3.Click += new System.EventHandler(this.bt_3_Click);
            // 
            // bt_4
            // 
            this.bt_4.BackColor = System.Drawing.Color.Yellow;
            this.bt_4.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_4.Location = new System.Drawing.Point(655, 30);
            this.bt_4.Name = "bt_4";
            this.bt_4.Size = new System.Drawing.Size(40, 40);
            this.bt_4.TabIndex = 76;
            this.bt_4.Text = "4";
            this.bt_4.UseVisualStyleBackColor = false;
            this.bt_4.Visible = false;
            this.bt_4.Click += new System.EventHandler(this.bt_4_Click);
            // 
            // bt_5
            // 
            this.bt_5.BackColor = System.Drawing.Color.Yellow;
            this.bt_5.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_5.Location = new System.Drawing.Point(704, 30);
            this.bt_5.Name = "bt_5";
            this.bt_5.Size = new System.Drawing.Size(40, 40);
            this.bt_5.TabIndex = 75;
            this.bt_5.Text = "5";
            this.bt_5.UseVisualStyleBackColor = false;
            this.bt_5.Visible = false;
            this.bt_5.Click += new System.EventHandler(this.bt_5_Click);
            // 
            // bt_2
            // 
            this.bt_2.BackColor = System.Drawing.Color.Yellow;
            this.bt_2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_2.Location = new System.Drawing.Point(557, 30);
            this.bt_2.Name = "bt_2";
            this.bt_2.Size = new System.Drawing.Size(40, 40);
            this.bt_2.TabIndex = 74;
            this.bt_2.Text = "2";
            this.bt_2.UseVisualStyleBackColor = false;
            this.bt_2.Visible = false;
            this.bt_2.Click += new System.EventHandler(this.bt_2_Click);
            // 
            // bt_1
            // 
            this.bt_1.BackColor = System.Drawing.Color.Yellow;
            this.bt_1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_1.Location = new System.Drawing.Point(508, 30);
            this.bt_1.Name = "bt_1";
            this.bt_1.Size = new System.Drawing.Size(40, 40);
            this.bt_1.TabIndex = 73;
            this.bt_1.Text = "1";
            this.bt_1.UseVisualStyleBackColor = false;
            this.bt_1.Visible = false;
            this.bt_1.Click += new System.EventHandler(this.bt_1_Click);
            // 
            // bt_z
            // 
            this.bt_z.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_z.Location = new System.Drawing.Point(704, 216);
            this.bt_z.Name = "bt_z";
            this.bt_z.Size = new System.Drawing.Size(40, 40);
            this.bt_z.TabIndex = 72;
            this.bt_z.Text = "z";
            this.bt_z.UseVisualStyleBackColor = true;
            this.bt_z.Visible = false;
            this.bt_z.Click += new System.EventHandler(this.bt_z_Click);
            // 
            // bt_y
            // 
            this.bt_y.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_y.Location = new System.Drawing.Point(655, 216);
            this.bt_y.Name = "bt_y";
            this.bt_y.Size = new System.Drawing.Size(40, 40);
            this.bt_y.TabIndex = 71;
            this.bt_y.Text = "y";
            this.bt_y.UseVisualStyleBackColor = true;
            this.bt_y.Visible = false;
            this.bt_y.Click += new System.EventHandler(this.bt_y_Click);
            // 
            // bt_x
            // 
            this.bt_x.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_x.Location = new System.Drawing.Point(606, 216);
            this.bt_x.Name = "bt_x";
            this.bt_x.Size = new System.Drawing.Size(40, 40);
            this.bt_x.TabIndex = 70;
            this.bt_x.Text = "x";
            this.bt_x.UseVisualStyleBackColor = true;
            this.bt_x.Visible = false;
            this.bt_x.Click += new System.EventHandler(this.bt_x_Click);
            // 
            // bt_w
            // 
            this.bt_w.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_w.Location = new System.Drawing.Point(557, 216);
            this.bt_w.Name = "bt_w";
            this.bt_w.Size = new System.Drawing.Size(40, 40);
            this.bt_w.TabIndex = 69;
            this.bt_w.Text = "w";
            this.bt_w.UseVisualStyleBackColor = true;
            this.bt_w.Visible = false;
            this.bt_w.Click += new System.EventHandler(this.bt_w_Click);
            // 
            // bt_v
            // 
            this.bt_v.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_v.Location = new System.Drawing.Point(508, 216);
            this.bt_v.Name = "bt_v";
            this.bt_v.Size = new System.Drawing.Size(40, 40);
            this.bt_v.TabIndex = 68;
            this.bt_v.Text = "v";
            this.bt_v.UseVisualStyleBackColor = true;
            this.bt_v.Visible = false;
            this.bt_v.Click += new System.EventHandler(this.bt_v_Click);
            // 
            // bt_u
            // 
            this.bt_u.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_u.Location = new System.Drawing.Point(459, 216);
            this.bt_u.Name = "bt_u";
            this.bt_u.Size = new System.Drawing.Size(40, 40);
            this.bt_u.TabIndex = 67;
            this.bt_u.Text = "u";
            this.bt_u.UseVisualStyleBackColor = true;
            this.bt_u.Visible = false;
            this.bt_u.Click += new System.EventHandler(this.bt_u_Click);
            // 
            // bt_t
            // 
            this.bt_t.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_t.Location = new System.Drawing.Point(900, 154);
            this.bt_t.Name = "bt_t";
            this.bt_t.Size = new System.Drawing.Size(40, 40);
            this.bt_t.TabIndex = 66;
            this.bt_t.Text = "t";
            this.bt_t.UseVisualStyleBackColor = true;
            this.bt_t.Visible = false;
            this.bt_t.Click += new System.EventHandler(this.bt_t_Click);
            // 
            // bt_s
            // 
            this.bt_s.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_s.Location = new System.Drawing.Point(851, 154);
            this.bt_s.Name = "bt_s";
            this.bt_s.Size = new System.Drawing.Size(40, 40);
            this.bt_s.TabIndex = 65;
            this.bt_s.Text = "s";
            this.bt_s.UseVisualStyleBackColor = true;
            this.bt_s.Visible = false;
            this.bt_s.Click += new System.EventHandler(this.bt_s_Click);
            // 
            // bt_r
            // 
            this.bt_r.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_r.Location = new System.Drawing.Point(802, 154);
            this.bt_r.Name = "bt_r";
            this.bt_r.Size = new System.Drawing.Size(40, 40);
            this.bt_r.TabIndex = 64;
            this.bt_r.Text = "r";
            this.bt_r.UseVisualStyleBackColor = true;
            this.bt_r.Visible = false;
            this.bt_r.Click += new System.EventHandler(this.bt_r_Click);
            // 
            // bt_i
            // 
            this.bt_i.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_i.Location = new System.Drawing.Point(851, 92);
            this.bt_i.Name = "bt_i";
            this.bt_i.Size = new System.Drawing.Size(40, 40);
            this.bt_i.TabIndex = 63;
            this.bt_i.Text = "i";
            this.bt_i.UseVisualStyleBackColor = true;
            this.bt_i.Visible = false;
            this.bt_i.Click += new System.EventHandler(this.bt_i_Click);
            // 
            // bt_q
            // 
            this.bt_q.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_q.Location = new System.Drawing.Point(753, 154);
            this.bt_q.Name = "bt_q";
            this.bt_q.Size = new System.Drawing.Size(40, 40);
            this.bt_q.TabIndex = 62;
            this.bt_q.Text = "q";
            this.bt_q.UseVisualStyleBackColor = true;
            this.bt_q.Visible = false;
            this.bt_q.Click += new System.EventHandler(this.bt_q_Click);
            // 
            // bt_p
            // 
            this.bt_p.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_p.Location = new System.Drawing.Point(704, 154);
            this.bt_p.Name = "bt_p";
            this.bt_p.Size = new System.Drawing.Size(40, 40);
            this.bt_p.TabIndex = 61;
            this.bt_p.Text = "p";
            this.bt_p.UseVisualStyleBackColor = true;
            this.bt_p.Visible = false;
            this.bt_p.Click += new System.EventHandler(this.bt_p_Click);
            // 
            // bt_o
            // 
            this.bt_o.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_o.Location = new System.Drawing.Point(655, 154);
            this.bt_o.Name = "bt_o";
            this.bt_o.Size = new System.Drawing.Size(40, 40);
            this.bt_o.TabIndex = 60;
            this.bt_o.Text = "o";
            this.bt_o.UseVisualStyleBackColor = true;
            this.bt_o.Visible = false;
            this.bt_o.Click += new System.EventHandler(this.bt_o_Click);
            // 
            // bt_n
            // 
            this.bt_n.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_n.Location = new System.Drawing.Point(606, 154);
            this.bt_n.Name = "bt_n";
            this.bt_n.Size = new System.Drawing.Size(40, 40);
            this.bt_n.TabIndex = 59;
            this.bt_n.Text = "n";
            this.bt_n.UseVisualStyleBackColor = true;
            this.bt_n.Visible = false;
            this.bt_n.Click += new System.EventHandler(this.bt_n_Click);
            // 
            // bt_m
            // 
            this.bt_m.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_m.Location = new System.Drawing.Point(557, 154);
            this.bt_m.Name = "bt_m";
            this.bt_m.Size = new System.Drawing.Size(40, 40);
            this.bt_m.TabIndex = 58;
            this.bt_m.Text = "m";
            this.bt_m.UseVisualStyleBackColor = true;
            this.bt_m.Visible = false;
            this.bt_m.Click += new System.EventHandler(this.bt_m_Click);
            // 
            // bt_l
            // 
            this.bt_l.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_l.Location = new System.Drawing.Point(508, 154);
            this.bt_l.Name = "bt_l";
            this.bt_l.Size = new System.Drawing.Size(40, 40);
            this.bt_l.TabIndex = 57;
            this.bt_l.Text = "l";
            this.bt_l.UseVisualStyleBackColor = true;
            this.bt_l.Visible = false;
            this.bt_l.Click += new System.EventHandler(this.bt_l_Click);
            // 
            // bt_k
            // 
            this.bt_k.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_k.Location = new System.Drawing.Point(459, 154);
            this.bt_k.Name = "bt_k";
            this.bt_k.Size = new System.Drawing.Size(40, 40);
            this.bt_k.TabIndex = 56;
            this.bt_k.Text = "k";
            this.bt_k.UseVisualStyleBackColor = true;
            this.bt_k.Visible = false;
            this.bt_k.Click += new System.EventHandler(this.bt_k_Click);
            // 
            // bt_j
            // 
            this.bt_j.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_j.Location = new System.Drawing.Point(900, 92);
            this.bt_j.Name = "bt_j";
            this.bt_j.Size = new System.Drawing.Size(40, 40);
            this.bt_j.TabIndex = 55;
            this.bt_j.Text = "j";
            this.bt_j.UseVisualStyleBackColor = true;
            this.bt_j.Visible = false;
            this.bt_j.Click += new System.EventHandler(this.bt_j_Click);
            // 
            // bt_h
            // 
            this.bt_h.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_h.Location = new System.Drawing.Point(802, 92);
            this.bt_h.Name = "bt_h";
            this.bt_h.Size = new System.Drawing.Size(40, 40);
            this.bt_h.TabIndex = 54;
            this.bt_h.Text = "h";
            this.bt_h.UseVisualStyleBackColor = true;
            this.bt_h.Visible = false;
            this.bt_h.Click += new System.EventHandler(this.bt_h_Click);
            // 
            // bt_g
            // 
            this.bt_g.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_g.Location = new System.Drawing.Point(753, 92);
            this.bt_g.Name = "bt_g";
            this.bt_g.Size = new System.Drawing.Size(40, 40);
            this.bt_g.TabIndex = 53;
            this.bt_g.Text = "g";
            this.bt_g.UseVisualStyleBackColor = true;
            this.bt_g.Visible = false;
            this.bt_g.Click += new System.EventHandler(this.bt_g_Click);
            // 
            // bt_f
            // 
            this.bt_f.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_f.Location = new System.Drawing.Point(704, 92);
            this.bt_f.Name = "bt_f";
            this.bt_f.Size = new System.Drawing.Size(40, 40);
            this.bt_f.TabIndex = 52;
            this.bt_f.Text = "f";
            this.bt_f.UseVisualStyleBackColor = true;
            this.bt_f.Visible = false;
            this.bt_f.Click += new System.EventHandler(this.bt_f_Click);
            // 
            // bt_c
            // 
            this.bt_c.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_c.Location = new System.Drawing.Point(557, 92);
            this.bt_c.Name = "bt_c";
            this.bt_c.Size = new System.Drawing.Size(40, 40);
            this.bt_c.TabIndex = 51;
            this.bt_c.Text = "c";
            this.bt_c.UseVisualStyleBackColor = true;
            this.bt_c.Visible = false;
            this.bt_c.Click += new System.EventHandler(this.bt_c_Click);
            // 
            // bt_d
            // 
            this.bt_d.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_d.Location = new System.Drawing.Point(606, 92);
            this.bt_d.Name = "bt_d";
            this.bt_d.Size = new System.Drawing.Size(40, 40);
            this.bt_d.TabIndex = 50;
            this.bt_d.Text = "d";
            this.bt_d.UseVisualStyleBackColor = true;
            this.bt_d.Visible = false;
            this.bt_d.Click += new System.EventHandler(this.bt_d_Click);
            // 
            // bt_e
            // 
            this.bt_e.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_e.Location = new System.Drawing.Point(655, 92);
            this.bt_e.Name = "bt_e";
            this.bt_e.Size = new System.Drawing.Size(40, 40);
            this.bt_e.TabIndex = 49;
            this.bt_e.Text = "e";
            this.bt_e.UseVisualStyleBackColor = true;
            this.bt_e.Visible = false;
            this.bt_e.Click += new System.EventHandler(this.bt_e_Click);
            // 
            // bt_b
            // 
            this.bt_b.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_b.Location = new System.Drawing.Point(508, 92);
            this.bt_b.Name = "bt_b";
            this.bt_b.Size = new System.Drawing.Size(40, 40);
            this.bt_b.TabIndex = 48;
            this.bt_b.Text = "b";
            this.bt_b.UseVisualStyleBackColor = true;
            this.bt_b.Visible = false;
            this.bt_b.Click += new System.EventHandler(this.bt_b_Click);
            // 
            // bt_a
            // 
            this.bt_a.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_a.Location = new System.Drawing.Point(459, 92);
            this.bt_a.Name = "bt_a";
            this.bt_a.Size = new System.Drawing.Size(40, 40);
            this.bt_a.TabIndex = 47;
            this.bt_a.Text = "a";
            this.bt_a.UseVisualStyleBackColor = true;
            this.bt_a.Visible = false;
            this.bt_a.Click += new System.EventHandler(this.bt_a_Click);
            // 
            // bt_cls
            // 
            this.bt_cls.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bt_cls.Location = new System.Drawing.Point(900, 216);
            this.bt_cls.Name = "bt_cls";
            this.bt_cls.Size = new System.Drawing.Size(40, 40);
            this.bt_cls.TabIndex = 45;
            this.bt_cls.Text = "清";
            this.bt_cls.UseVisualStyleBackColor = true;
            this.bt_cls.Visible = false;
            this.bt_cls.Click += new System.EventHandler(this.bt_cls_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(802, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 83;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Cancel.Image = global::EMES.Properties.Resources._1385_Disable_16x16_72;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Location = new System.Drawing.Point(251, 191);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(86, 65);
            this.btn_Cancel.TabIndex = 25;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Image = global::EMES.Properties.Resources.tick;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(15, 191);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menu_exit
            // 
            this.menu_exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_exit.Image = ((System.Drawing.Image)(resources.GetObject("menu_exit.Image")));
            this.menu_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(23, 22);
            this.menu_exit.Text = "toolStripButton2";
            this.menu_exit.ToolTipText = "離開(Ctrl+Del)";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 267);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_9);
            this.Controls.Add(this.bt_0);
            this.Controls.Add(this.bt_8);
            this.Controls.Add(this.bt_7);
            this.Controls.Add(this.bt_6);
            this.Controls.Add(this.bt_3);
            this.Controls.Add(this.bt_4);
            this.Controls.Add(this.bt_5);
            this.Controls.Add(this.bt_2);
            this.Controls.Add(this.bt_1);
            this.Controls.Add(this.bt_z);
            this.Controls.Add(this.bt_y);
            this.Controls.Add(this.bt_x);
            this.Controls.Add(this.bt_w);
            this.Controls.Add(this.bt_v);
            this.Controls.Add(this.bt_u);
            this.Controls.Add(this.bt_t);
            this.Controls.Add(this.bt_s);
            this.Controls.Add(this.bt_r);
            this.Controls.Add(this.bt_i);
            this.Controls.Add(this.bt_q);
            this.Controls.Add(this.bt_p);
            this.Controls.Add(this.bt_o);
            this.Controls.Add(this.bt_n);
            this.Controls.Add(this.bt_m);
            this.Controls.Add(this.bt_l);
            this.Controls.Add(this.bt_k);
            this.Controls.Add(this.bt_j);
            this.Controls.Add(this.bt_h);
            this.Controls.Add(this.bt_g);
            this.Controls.Add(this.bt_f);
            this.Controls.Add(this.bt_c);
            this.Controls.Add(this.bt_d);
            this.Controls.Add(this.bt_e);
            this.Controls.Add(this.bt_b);
            this.Controls.Add(this.bt_a);
            this.Controls.Add(this.bt_cls);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.f_plant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.f_db);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.f_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.f_id);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.Text = "Login登入畫面";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox f_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox f_password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton menu_exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox f_db;
        private System.Windows.Forms.ComboBox f_plant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button bt_9;
        private System.Windows.Forms.Button bt_0;
        private System.Windows.Forms.Button bt_8;
        private System.Windows.Forms.Button bt_7;
        private System.Windows.Forms.Button bt_6;
        private System.Windows.Forms.Button bt_3;
        private System.Windows.Forms.Button bt_4;
        private System.Windows.Forms.Button bt_5;
        private System.Windows.Forms.Button bt_2;
        private System.Windows.Forms.Button bt_1;
        private System.Windows.Forms.Button bt_z;
        private System.Windows.Forms.Button bt_y;
        private System.Windows.Forms.Button bt_x;
        private System.Windows.Forms.Button bt_w;
        private System.Windows.Forms.Button bt_v;
        private System.Windows.Forms.Button bt_u;
        private System.Windows.Forms.Button bt_t;
        private System.Windows.Forms.Button bt_s;
        private System.Windows.Forms.Button bt_r;
        private System.Windows.Forms.Button bt_i;
        private System.Windows.Forms.Button bt_q;
        private System.Windows.Forms.Button bt_p;
        private System.Windows.Forms.Button bt_o;
        private System.Windows.Forms.Button bt_n;
        private System.Windows.Forms.Button bt_m;
        private System.Windows.Forms.Button bt_l;
        private System.Windows.Forms.Button bt_k;
        private System.Windows.Forms.Button bt_j;
        private System.Windows.Forms.Button bt_h;
        private System.Windows.Forms.Button bt_g;
        private System.Windows.Forms.Button bt_f;
        private System.Windows.Forms.Button bt_c;
        private System.Windows.Forms.Button bt_d;
        private System.Windows.Forms.Button bt_e;
        private System.Windows.Forms.Button bt_b;
        private System.Windows.Forms.Button bt_a;
        private System.Windows.Forms.Button bt_cls;
        private System.Windows.Forms.Button button2;
    }
}