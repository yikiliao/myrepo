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
    public partial class rWKno : Form
    {
        public string dept;
        public DataTable dtProd = new DataTable(); //產品資料
        public string rType = string.Empty;//決定抓工單的table資料 
        public string rSfb01 = string.Empty;//儲存選取工單資料
        
        public rWKno()
        {
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {
            //sfb01,occ02,ima01,ima02,ima021,sfb06,sfb08,sfb13
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //產品資料畫面
            this.dataGridView1.ColumnCount = 8;            
            this.dataGridView1.Columns[0].Name = "sfb01";  //工單
            this.dataGridView1.Columns[1].Name = "occ02";  //客戶
            this.dataGridView1.Columns[2].Name = "ima01";  //料件編號          
            this.dataGridView1.Columns[3].Name = "ima02";  //品名
            this.dataGridView1.Columns[4].Name = "ima021"; //規格
            this.dataGridView1.Columns[5].Name = "sfb06"; //製成編號
            this.dataGridView1.Columns[6].Name = "sfb08"; //生產數
            this.dataGridView1.Columns[7].Name = "sfb13"; //客戶交期

            //是否允許使用者編輯
            this.dataGridView1.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView1.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView1.ColumnHeadersVisible = false;

            //設攔寬
            this.dataGridView1.Columns["sfb01"].HeaderText = "工單";
            this.dataGridView1.Columns["occ02"].HeaderText = "客戶";
            this.dataGridView1.Columns["ima01"].HeaderText = "料件編號";
            this.dataGridView1.Columns["ima02"].HeaderText = "品名";
            this.dataGridView1.Columns["ima021"].HeaderText = "規格";
            this.dataGridView1.Columns["sfb06"].HeaderText = "製程編號";
            this.dataGridView1.Columns["sfb08"].HeaderText = "生產數";
            this.dataGridView1.Columns["sfb13"].HeaderText = "客戶交期";


            ////欄位靠右
            //this.dataGridView1.Columns["sfb01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            //this.dataGridView1.Columns["sfb05"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            //--定義datatable 欄位
            dtProd.Columns.Add("sfb01", typeof(String));
            dtProd.Columns.Add("occ02", typeof(String));
            dtProd.Columns.Add("ima01", typeof(String));
            dtProd.Columns.Add("ima02", typeof(String));
            dtProd.Columns.Add("ima021", typeof(String));
            dtProd.Columns.Add("sfb06", typeof(String));
            dtProd.Columns.Add("sfb08", typeof(String));
            dtProd.Columns.Add("sfb13", typeof(String));

            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 12);
        }

        private void rWKno_Load(object sender, EventArgs e)
        {
            if (rType=="A") getData();//抓資料 (同步過來的TT工單))
            if (rType == "B") getData2();//抓資料 (排程的工單資料)
        }

        //已經有排程不顯示
        private void getData()
        {
            int rcnt = 0;
            dataGridView1.Rows.Clear();
            DataTable dt = Wfdwk.ToDoList(dept); //前一面傳過來的作業名稱代碼
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sfb01 = "'" + dt.Rows[i]["sfb01"].ToString() + "'";
                if (Procsca.ToDoList(sfb01).Rows.Count > 0)
                    continue;
                else
                {
                    dataGridView1.Rows.Add(new object[] {dt.Rows[i]["sfb01"],
                    dt.Rows[i]["occ02"],
                    dt.Rows[i]["ima01"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"],
                    dt.Rows[i]["sfb06"],
                    dt.Rows[i]["sfb08"],
                    dt.Rows[i]["sfb13"]});
                    rcnt += 1;
                }
            }
            if (rcnt > 1)
            {
                dataGridView1.Rows[0].Selected = true;
            }            
        }

        private void getData2()
        {
            int rcnt = 0;
            dataGridView1.Rows.Clear();
            DataTable dt = Procsca.ToDoList(string.Empty); //作業名稱代碼
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[] {dt.Rows[i]["sfb01"],
                    dt.Rows[i]["occ02"],
                    dt.Rows[i]["ima01"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"],
                    dt.Rows[i]["sfb06"],
                    dt.Rows[i]["sfb08"],
                    dt.Rows[i]["sfb13"]});
                rcnt += 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rType == "A")
            {
                OK_A();
            }
            if (rType == "B")
            {
                OK_B();
            }
            //DataRow dr;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Selected ==true)
            //    {
            //        dr = dtProd.NewRow();
            //        dr["sfb01"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //        dr["occ02"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //        dr["ima01"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //        dr["ima02"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //        dr["ima021"] = dataGridView1.Rows[i].Cells[4].Value.ToString();
            //        dr["sfb06"] = dataGridView1.Rows[i].Cells[5].Value.ToString();
            //        dr["sfb08"] = dataGridView1.Rows[i].Cells[6].Value.ToString();
            //        dr["sfb13"] = dataGridView1.Rows[i].Cells[7].Value.ToString();
            //        dtProd.Rows.Add(dr);                    
            //    }
            //}
            //if (dtProd.Rows.Count == 0)
            //{
            //    MessageBox.Show("尚未選取工單，請點選");
            //    return;
            //}
            //if (dtProd.Rows.Count > 1)
            //{
            //    MessageBox.Show("不可複選單，請重新點選");
            //    return;
            //}
            //DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            //Close();
        }

        private void OK_A()
        {
            DataRow dr;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    dr = dtProd.NewRow();
                    dr["sfb01"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dr["occ02"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    dr["ima01"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    dr["ima02"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dr["ima021"] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    dr["sfb06"] = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    dr["sfb08"] = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    dr["sfb13"] = dataGridView1.Rows[i].Cells[7].Value.ToString();
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

        private void OK_B()
        {  
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    rSfb01 += "'" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "',";                    
                }
            }
            if (rSfb01.Length > 0)
            {
                rSfb01 = rSfb01.Substring(0, rSfb01.Length - 1);//取字串把最後一個逗號去掉
            }            
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

    }
}
