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
    public partial class prc050_okcanel : Form
    {
        public bool isConf = false;
        public string Msg = string.Empty;
        public string isOK = string.Empty;
        public prc050_okcanel()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
        }

        private void btn_Conf_Click(object sender, EventArgs e)
        {
            isConf = true;
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            isConf = false;
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void prc050_okcanel_Load(object sender, EventArgs e)
        {
            label1.Text = Msg;
        }
    }
}
