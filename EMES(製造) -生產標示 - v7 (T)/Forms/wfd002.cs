using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using EMES.Models;
using System.Reflection;
using System.Configuration;

namespace EMES.Forms
{
    public partial class wfd002 : Form
    {
        DataTable dtProd = new DataTable(); //產品資料
               
        Processch rProcessch;

        string Mfd = string.Empty;
        string Station = string.Empty;        
        public bool rOK = false;//按下確認鍵

        public string fMfdate;


        /// <summary>
        /// 每頁記錄數
        /// </summary>
        public int pageSize = 13;

        /// <summary>
        /// 總記錄數
        /// </summary>
        public int recordCount = 0;

        /// <summary>
        /// 總頁數
        /// </summary>
        public int pageCount = 0;

        /// <summary>
        /// 當前頁
        /// </summary>
        public int currentPage = 0;

        public wfd002()
        {
            InitializeComponent();
            
            init_Form();
        }

        private void init_Form()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;

            //產品資料畫面
            this.dataGridView1.ColumnCount = 7;
            this.dataGridView1.Columns[0].Name = "Dept";  //料號
            this.dataGridView1.Columns[1].Name = "Station";   //            
            this.dataGridView1.Columns[2].Name = "DocNo";  //
            this.dataGridView1.Columns[3].Name = "MakeDate";  //
            this.dataGridView1.Columns[4].Name = "OperNumber";
            this.dataGridView1.Columns[5].Name = "GoodQty";
            this.dataGridView1.Columns[6].Name = "UnGoodQty";

            //是否允許使用者編輯
            this.dataGridView1.ReadOnly = true;

            //是否允許使用者自行新增
            this.dataGridView1.AllowUserToAddRows = false;

            //是否顯示首列資料
            this.dataGridView1.ColumnHeadersVisible = true;

            //給頁首中文字
            this.dataGridView1.Columns[0].HeaderText = "廠部";
            this.dataGridView1.Columns[1].HeaderText = "工作站";
            this.dataGridView1.Columns[2].HeaderText = "單據號";
            this.dataGridView1.Columns[3].HeaderText = "生產日期";
            this.dataGridView1.Columns[4].HeaderText = "作業人數";
            this.dataGridView1.Columns[5].HeaderText = "良品";
            this.dataGridView1.Columns[6].HeaderText = "不良品";

            //Header字型
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 16, FontStyle.Bold);

            //數字欄位靠右
            this.dataGridView1.Columns["OperNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            this.dataGridView1.Columns["GoodQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            this.dataGridView1.Columns["UnGoodQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            //把欄位隱藏
            this.dataGridView1.Columns["Dept"].Visible = false; //料號

            //--定義datatable 欄位
            dtProd.Columns.Add("Dept", typeof(String)); //料號
            dtProd.Columns.Add("Station", typeof(String)); //品名一
            dtProd.Columns.Add("DocNo", typeof(String));//品名二
            dtProd.Columns.Add("MakeDate", typeof(String));//品名二
            dtProd.Columns.Add("OperNumber", typeof(Decimal));
            dtProd.Columns.Add("GoodQty", typeof(Decimal));
            dtProd.Columns.Add("UnGoodQty", typeof(Decimal));
            //------------------
            set_dept(); //下拉廠部
            f_sdate_s.Value = DateTime.Now;//給生產日期
        }

        private void set_dept()
        {
            //--廠部下拉選單
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(Login.DEPT_NAME, Login.DEPT));
            f_plant.DisplayMember = "Key";
            f_plant.ValueMember = "Value";
            f_plant.DataSource = data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void confirm_Click(object sender, EventArgs e)
        //{
        //    dtProd.Clear();
        //    dataGridView1.Rows.Clear();
        //    var a = Proch.ToDoList(string.Empty, string.Empty, string.Empty);
        //    dtProd = Config.LinqQueryToDataTable(a); //轉成DataTable
        //    for (int i = 0; i < dtProd.Rows.Count; i++)
        //    {
        //        dataGridView1.Rows.Add(new object[] { dtProd.Rows[i]["Dept"],
        //            dtProd.Rows[i]["Station"],
        //            dtProd.Rows[i]["Docno"],
        //        dtProd.Rows[i]["Mfd"],
        //        dtProd.Rows[i]["Works"],
        //        dtProd.Rows[i]["Gp"],
        //        dtProd.Rows[i]["Ng"]});
        //    }
        //    //---畫面字體變大畫面優化------
        //    FontGridView(dtProd.Rows.Count);
        //}

        private void confirm_Click(object sender, EventArgs e)
        {
            dtProd.Clear();
            dataGridView1.Rows.Clear();
            string sBeg = f_mfdate_beg.Text;
            string sEnd = f_mfdate_end.Text;
            var a = Processch.ToDoList(string.Empty, sBeg, sEnd);
            dtProd = Config.LinqQueryToDataTable(a); //轉成DataTable
            ShowGV(); //顯示畫面資料
        }

        private void ShowGV()
        {
            if (dtProd.Rows.Count == 0)
            {
                ShowPage();
                return;
            }
            PageSorter();//分頁
        }
        private void ShowPage()
        {
            labPageIndex.Text = "當前頁: " + currentPage.ToString() + " / " + pageCount.ToString();//當前頁
            labRecordCount.Text = "總行數: " + recordCount.ToString() + " 行";//總記錄數
        }
        private void PageSorter()
        {
            recordCount = dtProd.Rows.Count;     //記錄總行數
            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }

            //預設第一頁
            currentPage = 1;

            LoadPage();//呼叫載入資料的方法
        }

        private void LoadPage()
        {
            if (dtProd.Rows.Count == 0) return;
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;    //開始指標
            int endRecord;      //結束指標
            DataTable dtTemp;
            dtTemp = dtProd.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(dtProd.Rows[i]);
            }
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {   
                dataGridView1.Rows.Add(new object[] { dtTemp.Rows[i]["Dept"],
                    dtTemp.Rows[i]["Station"],
                    dtTemp.Rows[i]["DocNo"],
                    dtTemp.Rows[i]["MakeDate"],
                    dtTemp.Rows[i]["OperNumber"],
                    dtTemp.Rows[i]["GoodQty"],
                    dtTemp.Rows[i]["UnGoodQty"]});
            }
            ShowPage();//顯示分頁數

            //---畫面字體變大畫面優化------
            if (currentPage < pageCount)
            {
                FontGridView(pageSize);
            }
            else
            {
                var unrecordCount = recordCount - ((currentPage - 1) * pageSize); //剩下筆數
                FontGridView(unrecordCount);
            }            
            dataGridView1.Rows[0].Selected = true; //第一列反藍
            dataGridView1_CellClick(null, null); //模擬按一下的動作
        }


        private void FontGridView(int CRow)
        {
            for (int i = 0; i < CRow; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("新細明體", 22);
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

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage = 1;
            LoadPage();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage--;
            LoadPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage++;
            LoadPage();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage = pageCount;
            LoadPage();
        }

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate_beg.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
            f_mfdate_end.Text = f_mfdate_beg.Text;
        }

        private void f_sdate_e_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate_end.Text = f_sdate_e.Value.ToString("yyyy/MM/dd");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void f_add_Click(object sender, EventArgs e)
        {
            rProcessch = new Processch();
            rProcessch.MakeDate = DateTime.Now.ToString("yyyy/MM/dd");
            rProcessch.Station = "";
            rProcessch.DocNo = "";
            rProcessch.OperNumber = 0;
            rProcessch.GoodQty = 0;
            rProcessch.UnGoodQty = 0;

            wfd002a fm = new wfd002a("A", rProcessch);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                fMfdate = fm.rMfdate;
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();

            //如果不是上一個畫面 按確認鍵過來的就return回去
            if (rOK == false) return;

            //f_plant.SelectedValue = fPlant;
            f_sdate_s.Value = System.Convert.ToDateTime(fMfdate);
            f_sdate_e.Value = System.Convert.ToDateTime(fMfdate);
            confirm_Click(null, null);
        }

        private void f_upd_Click(object sender, EventArgs e)
        {
            if (rProcessch == null) {
                MessageBox.Show("請選資料");
                return;
            }
            wfd002a fm = new wfd002a("U", rProcessch);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                fMfdate = fm.rMfdate;
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();

            //如果不是上一個畫面 按確認鍵過來的就return回去
            if (rOK == false) return;

            //f_plant.SelectedValue = fPlant;
            f_sdate_s.Value = System.Convert.ToDateTime(fMfdate);
            f_sdate_e.Value = System.Convert.ToDateTime(fMfdate);
            confirm_Click(null, null);
        }

        private void f_del_Click(object sender, EventArgs e)
        {
            if (rProcessch == null)
            {
                MessageBox.Show("請選資料");
                return;
            }
            wfd002a fm = new wfd002a("D", rProcessch);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                fMfdate = fm.rMfdate;
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();

            //如果不是上一個畫面 按確認鍵過來的就return回去
            if (rOK == false) return;

            //f_plant.SelectedValue = fPlant;
            f_sdate_s.Value = System.Convert.ToDateTime(fMfdate);
            f_sdate_e.Value = System.Convert.ToDateTime(fMfdate);
            confirm_Click(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            rProcessch = new Processch();

            rProcessch.Dept = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            rProcessch.Station = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            rProcessch.DocNo = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            rProcessch.MakeDate = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            rProcessch.OperNumber = (decimal)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value;
            rProcessch.GoodQty = (decimal)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value;
            rProcessch.UnGoodQty = (decimal)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["UnGoodQty"].Value;

            //整列反藍
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;

        }
    }
}
