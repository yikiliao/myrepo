using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using EMES.Models;

namespace EMES.Forms
{
    public partial class frmPass : Form
    {
        ClsINI Setupini = new ClsINI(Application.StartupPath + "\\ini\\Setup.ini");
        string User = string.Empty;
        public frmPass()
        {
            InitializeComponent();
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtPasswd.Text = User;
            CloseForm();
        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            txtPasswd.Text = string.Empty;
            txtPasswd.Focus();            
            labError.Visible = false;
        }


        private void CloseForm()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (LoginCheck()) {
                CloseForm();
            }
            else
            {
                labError.Text = "帳號輸入錯誤";
                labError.Visible = true;
            }
        }

        private bool LoginCheck()
        {
            bool rf = false;
            if (txtPasswd.Text == User) rf = true;
            return rf;
        }

        private void bt_a_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "a";
        }

        private void bt_b_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "b";
        }

        private void bt_c_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "c";
        }

        private void bt_d_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "d";
        }

        private void bt_e_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "e";
        }

        private void bt_f_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "f";
        }

        private void bt_g_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "g";
        }

        private void bt_h_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "h";
        }

        private void bt_i_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "i";
        }

        private void bt_j_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "j";
        }

        private void bt_k_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "k";
        }

        private void bt_l_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "l";
        }

        private void bt_m_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "m";
        }

        private void bt_n_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "n";
        }

        private void bt_o_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "o";
        }

        private void bt_p_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "p";
        }

        private void bt_q_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "q";
        }

        private void bt_r_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "r";
        }

        private void bt_s_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "s";
        }

        private void bt_t_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "t";
        }

        private void bt_u_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "u";
        }

        private void bt_v_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "v";
        }

        private void bt_w_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "w";
        }

        private void bt_x_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "x";
        }

        private void bt_y_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "y";
        }

        private void bt_z_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "z";
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "0";
        }

        private void bt_1_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "1";
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "2";
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "3";
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "4";
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "5";
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "6";
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "7";
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "8";
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            txtPasswd.Text += "9";
        }

        private void txtPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_OK_Click(this, null);
            }
        }

        private void txtPasswd_Click(object sender, EventArgs e)
        {
            labError.Visible = false;
        }

        private void frmPass_Load(object sender, EventArgs e)
        {
            User = Setupini.IniReadValue("LOCAL", "ADMIN"); //login name
        }
    }
}
