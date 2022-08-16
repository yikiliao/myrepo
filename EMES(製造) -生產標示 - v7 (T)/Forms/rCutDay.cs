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
    public partial class rCutDay : Form
    {
        public DataTable dtProd = new DataTable();
        public string Dept;
        public string Schdate;
        public string Station;
        public rCutDay()
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

            //產品資料畫面
            this.dataGridView2.ColumnCount = 9;
            this.dataGridView2.Columns[0].Name = "ck";  //
            this.dataGridView2.Columns[1].Name = "sfb01";  //工單
            this.dataGridView2.Columns[2].Name = "ecm03";  //工序
            this.dataGridView2.Columns[3].Name = "ecm04"; //作業編號             
            this.dataGridView2.Columns[4].Name = "ecm45"; //作業名稱
            this.dataGridView2.Columns[5].Name = "sfb08";  //派工數
            this.dataGridView2.Columns[6].Name = "sfb05";  //料號
            this.dataGridView2.Columns[7].Name = "ima02";  //品名
            this.dataGridView2.Columns[8].Name = "ima021";  //規格                    
            

            //是否允許使用者編輯
            //this.dataGridView2.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView2.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView2.ColumnHeadersVisible = false;

            //設抬頭文字
            this.dataGridView2.Columns["sfb01"].HeaderText = "工單";
            this.dataGridView2.Columns["ecm03"].HeaderText = "工序";
            this.dataGridView2.Columns["ecm04"].HeaderText = "作業編號";
            this.dataGridView2.Columns["ecm45"].HeaderText = "作業名稱";
            this.dataGridView2.Columns["sfb08"].HeaderText = "派工數";
            this.dataGridView2.Columns["sfb05"].HeaderText = "料號";
            this.dataGridView2.Columns["ima02"].HeaderText = "品名";
            this.dataGridView2.Columns["ima021"].HeaderText = "規格";
            
            

            //--定義datatable 欄位
            dtProd.Columns.Add("sfb01", typeof(String));
            dtProd.Columns.Add("ecm03", typeof(String));
            dtProd.Columns.Add("ecm04", typeof(String));
            dtProd.Columns.Add("ecm45", typeof(String));
            dtProd.Columns.Add("sfb08", typeof(String));
            dtProd.Columns.Add("sfb05", typeof(String));
            dtProd.Columns.Add("ima02", typeof(String));
            dtProd.Columns.Add("ima021", typeof(String));
            
            

            //標題字體
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView2.DefaultCellStyle.Font = new Font("新細明體", 22);
            this.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        

        private void rWkDay_Load(object sender, EventArgs e)
        {
            getData(); //抓資料
        }

        private void getData()
        {
            int rcnt = 0;
            dataGridView2.Rows.Clear();
            DataTable dt = Procschwork.DayCutList(Dept, Schdate, Station);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView2.Rows.Add(new object[] {false,
                    dt.Rows[i]["sfb01"],
                    dt.Rows[i]["ecm03"],
                    dt.Rows[i]["ecm04"],
                    dt.Rows[i]["ecm45"],
                    Convert.ToInt16(dt.Rows[i]["sfb08"]),
                    //dt.Rows[i]["sfb08"],
                    dt.Rows[i]["sfb05"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"]});
                rcnt += 1;
            }
            if (rcnt > 0)
            {
                dataGridView2.Rows[0].Selected = true;
                label2.Text = "筆數：" + rcnt.ToString("##0");
            }
        }

        

        private void btn_OK_Click(object sender, EventArgs e)
        {            
            OK_A();
            //Add_();
        }

        private void OK_A()
        {
            DataRow dr;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView2.Rows[i].Cells["ck"].Value);
                if (isSelected)
                {
                    dr = dtProd.NewRow();
                    dr["sfb01"] = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    dr["ecm03"] = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    dr["ecm04"] = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    dr["ecm45"] = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    dr["sfb08"] = dataGridView2.Rows[i].Cells[5].Value.ToString();
                    dr["sfb05"] = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    dr["ima02"] = dataGridView2.Rows[i].Cells[7].Value.ToString();
                    dr["ima021"] = dataGridView2.Rows[i].Cells[8].Value.ToString();
                    dtProd.Rows.Add(dr);
                }
            }
            if (dtProd.Rows.Count == 0)
            {
                MessageBox.Show("尚未選取工單，請點選");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView2.Rows[e.RowIndex].Selected = true;            
            isCheck(e.RowIndex);//點選勾選 
        }

        private void isCheck(int e)
        {
            if ((bool)dataGridView2.Rows[e].Cells["ck"].Value == false)
                dataGridView2.Rows[e].Cells["ck"].Value = true;
            else
                dataGridView2.Rows[e].Cells["ck"].Value = false;
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridView2.Columns[e.ColumnIndex];
            string btText = newColumn.HeaderText;
            switch (btText)
            {
                case "全選":
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells["ck"].Value = true;
                    }
                    newColumn.HeaderText = "選取";
                    break;

                case "選取":
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells["ck"].Value = false;
                    }
                    newColumn.HeaderText = "全選";
                    break;
                default:
                    break;
            }
        }
    }
}
