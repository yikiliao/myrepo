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
    public partial class prc050_msg : Form
    {
        public string Msg = string.Empty;
        public prc050_msg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
        }

        private void prc050_msg_Load(object sender, EventArgs e)
        {
            label1.Text = Msg;
        }

        private void btn_Conf_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }
    }
}
