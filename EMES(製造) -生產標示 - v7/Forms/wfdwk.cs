using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EMES.Models;

namespace EMES.Forms
{   
    public partial class wfdwk : Form
    {
        public string dept;
        public string schdate;
        public string ecb06;
        public string ecb08;
        public DataTable dtProd = new DataTable(); //產品資料
        public Selwk selwk;
        
        public wfdwk()
        {
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.ControlBox = false;

            //產品資料畫面
            this.dataGridView1.ColumnCount = 12;
            this.dataGridView1.Columns[0].Name = "ck";  //選取
            this.dataGridView1.Columns[1].Name = "sfb01";  //工單
            this.dataGridView1.Columns[2].Name = "occ02";  //客戶
            this.dataGridView1.Columns[3].Name = "sfb05";  //主件          
            this.dataGridView1.Columns[4].Name = "ima02";  //品名
            this.dataGridView1.Columns[5].Name = "ima021"; //規格
            this.dataGridView1.Columns[6].Name = "ecb03"; //製程序
            this.dataGridView1.Columns[7].Name = "ecb06"; //作業編號
            this.dataGridView1.Columns[8].Name = "ecb17"; //作業說明
            this.dataGridView1.Columns[9].Name = "ecb08"; //工作站
            this.dataGridView1.Columns[10].Name = "eca02"; //工作站說明
            this.dataGridView1.Columns[11].Name = "sfb13"; //預計開始生產日

            //是否允許使用者編輯
            this.dataGridView1.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView1.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView1.ColumnHeadersVisible = false;

            //設攔寬 
            this.dataGridView1.Columns["ck"].Width = 50;
            //this.dataGridView1.Columns["sfb01"].Width = 100;
            //this.dataGridView1.Columns["sfb05"].Width = 190;
            //this.dataGridView1.Columns["ima02"].Width = 190;
            //this.dataGridView1.Columns["ima021"].Width = 290;

            this.dataGridView1.Columns["ck"].HeaderText = "選取";
            this.dataGridView1.Columns["sfb01"].HeaderText = "工單";
            this.dataGridView1.Columns["occ02"].HeaderText = "客戶";
            this.dataGridView1.Columns["sfb05"].HeaderText = "料件編號";
            this.dataGridView1.Columns["ima02"].HeaderText = "品名";
            this.dataGridView1.Columns["ima021"].HeaderText = "規格";
            this.dataGridView1.Columns["ecb03"].HeaderText = "製程序";
            this.dataGridView1.Columns["ecb06"].HeaderText = "作業編號";
            this.dataGridView1.Columns["ecb17"].HeaderText = "作業說明";
            this.dataGridView1.Columns["ecb08"].HeaderText = "工作站";
            this.dataGridView1.Columns["eca02"].HeaderText = "工作站說明";
            this.dataGridView1.Columns["sfb13"].HeaderText = "預計開始生產日";


            ////欄位靠右
            //this.dataGridView1.Columns["sfb01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            //this.dataGridView1.Columns["sfb05"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            //--定義datatable 欄位
            dtProd.Columns.Add("sfb01", typeof(String));
            dtProd.Columns.Add("occ02", typeof(String));
            dtProd.Columns.Add("sfb05", typeof(String));
            dtProd.Columns.Add("ima02", typeof(String));
            dtProd.Columns.Add("ima021", typeof(String));
            dtProd.Columns.Add("ecb03", typeof(String));
            dtProd.Columns.Add("ecb06", typeof(String));
            dtProd.Columns.Add("ecb17", typeof(String));
            dtProd.Columns.Add("ecb08", typeof(String));
            dtProd.Columns.Add("eca02", typeof(String));
            dtProd.Columns.Add("sfb13", typeof(String));
            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 18);
        }

        private void wfdwk_Load(object sender, EventArgs e)
        {
            getData2();
        }

        private void getData2()
        {
            int rcnt = 0;
            dataGridView1.Rows.Clear();
            DataTable dt = Wfdwk.ToDoList(dept, ecb06, ecb08); //前一面傳過來的作業名稱代碼
           // DataTable dt = Wfdwk.ToDoList(dept,schdate, ecb06, ecb08); //前一面傳過來的作業名稱代碼
            //MessageBox.Show(dt.Rows.Count.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //wkhproc 有資料就找下一筆
                if (Wkhproc.havesch(dt.Rows[i]["sfb01"].ToString(), System.Convert.ToInt16(dt.Rows[i]["ecb03"].ToString()), schdate) == false)
                {
                    dataGridView1.Rows.Add(new object[] {false, dt.Rows[i]["sfb01"],
                    dt.Rows[i]["occ02"],
                    dt.Rows[i]["sfb05"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"],
                    dt.Rows[i]["ecb03"],
                    dt.Rows[i]["ecb06"],
                    dt.Rows[i]["ecb17"],
                    dt.Rows[i]["ecb08"],
                    dt.Rows[i]["eca02"],
                    dt.Rows[i]["sfb13"]});
                    rcnt += 1;
                }
            }
            //---畫面字體變大畫面優化------            
            FontGridView(rcnt);
        }

        //private void getData2()
        //{
        //    dataGridView1.Rows.Clear();            
        //    DataTable dt = Wfdwk.ToDoList(dept,ecb06,ecb08); //前一面傳過來的作業名稱代碼
        //    //MessageBox.Show(dt.Rows.Count.ToString());
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dataGridView1.Rows.Add(new object[] {true, dt.Rows[i]["sfb01"],
        //            dt.Rows[i]["occ02"],
        //            dt.Rows[i]["sfb05"],
        //            dt.Rows[i]["ima02"],
        //            dt.Rows[i]["ima021"],
        //            dt.Rows[i]["ecb03"],
        //            dt.Rows[i]["ecb06"],
        //            dt.Rows[i]["ecb17"],
        //            dt.Rows[i]["ecb08"],
        //            dt.Rows[i]["eca02"]});
        //    }
        //    //---畫面字體變大畫面優化------
        //    FontGridView(dt.Rows.Count);
        //}



        private void FontGridView(int CRow)
        {
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 18);
            for (int i = 0; i < CRow; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("新細明體", 20);
                //dataGridView1.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //dataGridView1.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if ((i % 2) == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
            selwk = new Selwk();
            selwk.sfb01 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            selwk.sfb05 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            selwk.ima02 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            selwk.ima021 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value == false)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            else
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
        }

        private void OK(object sender, EventArgs e)
        {   
            DataRow dr;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                {
                    dr = dtProd.NewRow();
                    dr["sfb01"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    dr["occ02"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    dr["sfb05"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dr["ima02"] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    dr["ima021"] = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    dr["ecb03"] = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    dr["ecb06"] = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    dr["ecb17"] = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    dr["ecb08"] = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    dr["eca02"] = dataGridView1.Rows[i].Cells[10].Value.ToString();
                    dr["sfb13"] = dataGridView1.Rows[i].Cells[11].Value.ToString();
                    dtProd.Rows.Add(dr);
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        

    }
}
