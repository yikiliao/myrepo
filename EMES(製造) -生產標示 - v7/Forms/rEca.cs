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
    public partial class rEca : Form
    {
        public DataTable dtProd = new DataTable();
        public string Dept;
        public rEca()
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
            this.dataGridView1.ColumnCount = 2;
            this.dataGridView1.Columns[0].Name = "eca01";  //作業編號
            this.dataGridView1.Columns[1].Name = "eca02";  //作業名稱
            

            //是否允許使用者編輯
            this.dataGridView1.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView1.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView1.ColumnHeadersVisible = false;

            //設名稱
            this.dataGridView1.Columns["eca01"].HeaderText = "工作站";
            this.dataGridView1.Columns["eca02"].HeaderText = "工作站名稱";


            ////欄位靠右
            //this.dataGridView1.Columns["eca01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            //this.dataGridView1.Columns["eca02"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            //--定義datatable 欄位
            dtProd.Columns.Add("eca01", typeof(String));
            dtProd.Columns.Add("eca02", typeof(String));

            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12);
        }

        private void rEca_Load(object sender, EventArgs e)
        {
            getData(); //抓資料
        }

        private void getData()
        {
            int rcnt = 0;
            string Name = string.Empty;
            dataGridView1.Rows.Clear();
            DataTable dt = eca_file.GetAll(Dept);
            for (int i = 0; i < dt.Rows.Count; i++)
            {                
                dataGridView1.Rows.Add(new object[] {dt.Rows[i]["eca01"],
                    dt.Rows[i]["eca02"]});
                rcnt += 1;
            }
            if (rcnt > 1)
            {
                dataGridView1.Rows[0].Selected = true;
            }
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
                    dr["eca01"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dr["eca02"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}
