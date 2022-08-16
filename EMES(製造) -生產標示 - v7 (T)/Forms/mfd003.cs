using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EMES.Models;

namespace EMES.Forms
{
    public partial class mfd003 : Form
    {
        public mfd003()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var iL = sst100.ToDoList();
            BindingSource bds = new BindingSource();
            bds.DataSource = iL;

            dataGridView1.DataSource = bds;
            //MessageBox.Show(iL.Count().ToString());
        }
    }
}
