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

using EMES.Forms;

namespace EMES.Forms
{
    public partial class rStationDay : Form
    {
        public DataTable dtProd = new DataTable();
        public string Dept;
        public string Schdate;
        public string Ecm06;
        public rStationDay()
        {
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //--定義datatable 欄位
            dtProd.Columns.Add("ecm06", typeof(String));
            dtProd.Columns.Add("eca02", typeof(String));

            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12);
            dataGridView1.DefaultCellStyle.Font = new Font("新細明體", 12);
        }

        private void rStationDay_Load(object sender, EventArgs e)
        {
            getData(); //抓資料
        }

        private void getData()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = Procschwork.GroupEcm06(Schdate);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0) dataGridView1.Rows[0].Selected = true;
        }

        //private void getData()
        //{
        //    dataGridView1.Rows.Clear();
        //    DataTable dt = Procscmwork.GroupEcm06(Schdate);
        //    dataGridView1.DataSource = dt;
        //    if (dt.Rows.Count > 0) dataGridView1.Rows[0].Selected = true;
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Add_();
        }

        private void Add_()
        {
            DataRow dr;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    dr = dtProd.NewRow();
                    dr["ecm06"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dr["eca02"] = dataGridView1.Rows[i].Cells[1].Value.ToString();                    
                    dtProd.Rows.Add(dr);
                }
            }
            if (dtProd.Rows.Count == 0)
            {
                MessageBox.Show("尚未選取，請點選");
                return;
            }
            if (dtProd.Rows.Count > 1)
            {
                MessageBox.Show("不可複選單，請重新點選");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

    }
}
