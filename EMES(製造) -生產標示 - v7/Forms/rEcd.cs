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
    public partial class rEcd : Form
    {
        public DataTable dtProd = new DataTable();
        public string Dept;
        public rEcd()
        {
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {            
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //產品資料畫面
            this.dataGridView1.ColumnCount = 4;
            this.dataGridView1.Columns[0].Name = "ecd01";  //作業編號
            this.dataGridView1.Columns[1].Name = "ecd02";  //作業名稱
            this.dataGridView1.Columns[2].Name = "ecd05";  //作業型態
            this.dataGridView1.Columns[3].Name = "ecd07";  //工作站

            //是否允許使用者編輯
            this.dataGridView1.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView1.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView1.ColumnHeadersVisible = false;

            //設名稱
            this.dataGridView1.Columns["ecd01"].HeaderText = "作業編號";
            this.dataGridView1.Columns["ecd02"].HeaderText = "作業名稱";
            this.dataGridView1.Columns["ecd05"].HeaderText = "作業型態";
            this.dataGridView1.Columns["ecd07"].HeaderText = "工作站";


            ////欄位靠右
            //this.dataGridView1.Columns["ecd01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            //this.dataGridView1.Columns["ecd02"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            //--定義datatable 欄位
            dtProd.Columns.Add("ecd01", typeof(String));
            dtProd.Columns.Add("ecd02", typeof(String));
            dtProd.Columns.Add("ecd05", typeof(String));
            dtProd.Columns.Add("ecd07", typeof(String));

            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12);
        }

        private void rEcd_Load(object sender, EventArgs e)
        {            
            getData(); //抓資料
        }

        private void getData()
        {   
            int rcnt = 0;
            string Name = string.Empty;
            dataGridView1.Rows.Clear();
            DataTable dt = ecd_file.GetAll(Dept);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ecd05"].ToString() == "1") Name = "人工操作";
                if (dt.Rows[i]["ecd05"].ToString() == "2") Name = "作業機器";
                dataGridView1.Rows.Add(new object[] {dt.Rows[i]["ecd01"],
                    dt.Rows[i]["ecd02"],
                    Name,                    
                    dt.Rows[i]["ecd07"]});
                rcnt += 1;
            }
            if (rcnt > 1)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

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
                    dr["ecd01"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dr["ecd02"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    dr["ecd05"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    dr["ecd07"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dtProd.Rows.Add(dr);
                }
            }
            if (dtProd.Rows.Count == 0)
            {
                MessageBox.Show("尚未選取工單，請點選");
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
