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
    public partial class wfd001u : Form
    {
        public string schdate = string.Empty;
        public wfd001u()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_schdate.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (f_Check() == false) return;
            schdate = f_schdate.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }

        private Boolean f_Check()
        {
            if (f_schdate.Text == String.Empty)
            {
                Config.Show("排程日期不可空白");
                f_schdate.Focus();
                return false;
            }
            if (System.Convert.ToDateTime(f_schdate.Text) >= System.Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")))
            {
                //do nothing
            }
            else
            {
                Config.Show("排程日期不可小於今天");
                f_schdate.Focus();
                return false;
            }
            return true;
        }

    }
        
}
