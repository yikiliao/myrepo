using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using EMES.Models;
using System.Windows.Forms;

namespace EMES.Forms
{
    public partial class wWkno : Form
    {
        public string Code;
        public string Code_desc;

        public wWkno()
        {
            InitializeComponent();            
            Config.SetFormSize(this, "W");            
            Config.SetPer(this);
            
            //最後增加一筆 工單號:樣品 料號:MISC
            var data = sfb_file.WkToDoList().ToList();
            var p_sfb_file = new sfb_file();
            p_sfb_file.Wkno = "樣品";
            p_sfb_file.Imno = "MISC";
            data.Add(p_sfb_file);
            bindingSource1.DataSource = data;            
        }

        private void bmi003w_Load(object sender, EventArgs e)
        {
            //bindingSource1.DataSource = prt016.ToDoListPrno().ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Code_desc = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["pr_name"].Value.ToString() == f_search.Text)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[row.Index].Cells["pr_name"];
                    break;
                }
            }            
        }

        private void f_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bt1_Click(sender, e);
        }
    }
}
