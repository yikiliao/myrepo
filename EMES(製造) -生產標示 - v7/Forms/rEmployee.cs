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
    public partial class rEmployee : Form
    {
        public DataTable dtProd = new DataTable();
        public string Dept;
        public string Schdate;
        public rEmployee()
        {
            InitializeComponent();
            initForm();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void initForm()
        {
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //--定義datatable 欄位
            dtProd.Columns.Add("employeeid", typeof(String));
            dtProd.Columns.Add("employeename", typeof(String));

            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView1.DefaultCellStyle.Font = new Font("新細明體", 22);            
        }

        private void rEmployee_Load(object sender, EventArgs e)
        {
            getData(); //抓資料
        }

        private void getData()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = Employee.ToList(Dept, Schdate);
            int idx = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[] {
                    false,
                    dt.Rows[i]["BCode"],
                    dt.Rows[i]["BCnName"],
                    dt.Rows[i]["B2Code"],
                    dt.Rows[i]["B2Name"],                    
                dt.Rows[i]["CCode"],
                dt.Rows[i]["CName"]});
                idx += 1;
            }            
            if (idx > 0) dataGridView1.Rows[0].Selected = true;
        }

        //private void getData()
        //{
        //    dataGridView1.Rows.Clear();
        //    DataTable dt = Employee.ToList(Dept, Schdate);
        //    int idx = 0;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dataGridView1.Rows.Add(new object[] {
        //            false,
        //            dt.Rows[i]["B2Code"],
        //            dt.Rows[i]["B2Name"],
        //            dt.Rows[i]["BCode"],
        //            dt.Rows[i]["BCnName"],
        //        dt.Rows[i]["CCode"],
        //        dt.Rows[i]["CName"]});
        //        idx += 1;
        //    }
        //    if (idx > 0) dataGridView1.Rows[0].Selected = true;
        //}




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
            isCheck(e.RowIndex);//點選勾選
        }

        private void isCheck(int e)
        {
            if ((bool)dataGridView1.Rows[e].Cells["Bcheck"].Value == false)
                dataGridView1.Rows[e].Cells["Bcheck"].Value = true;
            else
                dataGridView1.Rows[e].Cells["Bcheck"].Value = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Add_();
        }
        private void Add_()
        {           
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {                
                bool isSelected = Convert.ToBoolean(dataGridView1.Rows[i].Cells["Bcheck"].Value);
                if (isSelected)
                {
                    DataRow dr = dtProd.NewRow();
                    dr["employeeid"] = dataGridView1.Rows[i].Cells["BCode"].Value.ToString();
                    dr["employeename"] = dataGridView1.Rows[i].Cells["BCnName"].Value.ToString();
                    dtProd.Rows.Add(dr);
                }
            }                       
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }


    }
}
