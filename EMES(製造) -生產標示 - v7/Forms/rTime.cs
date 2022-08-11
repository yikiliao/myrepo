using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMES.Forms
{
    public partial class rTime : Form
    {
        public string tHH;//前一畫面傳過來開始時
        public string tMM;//前一畫面傳過來開始分        
        public static string rHH;//傳回去的值時
        public static string rMM;//傳回去的值分
        public rTime()
        {
            InitializeComponent();
            init_Form();
        }

        private void init_Form()
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            HH_backcolor();//設底色
            
        }

        

        private void HH_backcolor()
        {
            bt_0.BackColor = Color.SeaGreen;
            bt_1.BackColor = Color.SeaGreen;
            bt_2.BackColor = Color.SeaGreen;
            bt_3.BackColor = Color.SeaGreen;
            bt_4.BackColor = Color.SeaGreen;
            bt_5.BackColor = Color.SeaGreen;
            bt_6.BackColor = Color.SeaGreen;
            bt_7.BackColor = Color.SeaGreen;
            bt_8.BackColor = Color.SeaGreen;
            bt_9.BackColor = Color.SeaGreen;
            bt_10.BackColor = Color.SeaGreen;
            bt_11.BackColor = Color.SeaGreen;
            bt_12.BackColor = Color.SeaGreen;
            bt_13.BackColor = Color.SeaGreen;
            bt_14.BackColor = Color.SeaGreen;
            bt_15.BackColor = Color.SeaGreen;
            bt_16.BackColor = Color.SeaGreen;
            bt_17.BackColor = Color.SeaGreen;
            bt_18.BackColor = Color.SeaGreen;
            bt_19.BackColor = Color.SeaGreen;
            bt_20.BackColor = Color.SeaGreen;
            bt_21.BackColor = Color.SeaGreen;
            bt_22.BackColor = Color.SeaGreen;
            bt_23.BackColor = Color.SeaGreen;
        }




        private void rTime_Load(object sender, EventArgs e)
        {
            f_HH.Text = tHH;
            f_MM.Text = tMM;            
        }

        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            f_HH.Text = bt.Text;            
        }

        private void bt_MM_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            f_MM.Text = bt.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            rHH = f_HH.Text;
            rMM = f_MM.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        
    }
}
