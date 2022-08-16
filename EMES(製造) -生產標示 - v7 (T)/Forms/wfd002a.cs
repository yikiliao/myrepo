using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMES.Models;
using Newtonsoft.Json;

namespace EMES.Forms
{
    public partial class wfd002a : Form
    {
        string Menu_Sel;
        public string rMfdate;
        string ClickName = string.Empty;
        //public wfd002a()
        //{
        //    InitializeComponent();
        //}

        public wfd002a(string Sel, Processch rProcessch)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            labMessage.Text = string.Empty;


            f_docno.Text = rProcessch.DocNo;//單據號
            f_mfd.Text = rProcessch.MakeDate;
            f_station.Text = rProcessch.Station; //站別
            f_works.Text = System.Convert.ToString(rProcessch.OperNumber); //工作人數
            f_gp.Text = System.Convert.ToString(rProcessch.GoodQty); //良品
            f_ng.Text = System.Convert.ToString(rProcessch.UnGoodQty); //不良品 
            rMfdate = f_mfd.Text; //傳值用
            f_docno.Enabled = false;//單據號
            f_station.Enabled = false;//站別
            f_mfd.Enabled = false;//日期

            //新增時的處理
            if (Sel == "A")
            {
                f_docno.Text = "--自動給號--";
                f_station.Text = "B2";
                Menu_Sel = "Add";
            }

            //異動時的處理
            if (Sel == "U") Menu_Sel = "Upd";

            //刪除時的處理
            if (Sel == "D") Menu_Sel = "Del";


            initForm();
        }

        private void initForm()
        {
            ////產品資料畫面
            //this.dataGridView1.ColumnCount = 4;            
            //this.dataGridView1.Columns[0].Name = "sfb01";  //工單
            //this.dataGridView1.Columns[1].Name = "sfb05";  //主件          
            //this.dataGridView1.Columns[2].Name = "ima02";  //品名
            //this.dataGridView1.Columns[3].Name = "ima021"; //規格

            //this.dataGridView1.Columns["sfb01"].HeaderText = "工單";
            //this.dataGridView1.Columns["sfb05"].HeaderText = "料件編號";
            //this.dataGridView1.Columns["ima02"].HeaderText = "品名";
            //this.dataGridView1.Columns["ima021"].HeaderText = "規格";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 18);
        }
       

        private void wfd002a_Load(object sender, EventArgs e)
        {
            //f_station.Text = Login.DBNAME + " " + Login.DEPT + Login.DEPT_NAME;            
        }

        private void f_add_Click(object sender, EventArgs e)
        {
            decimal i_number = 0M;
            if (ClickName == "OperNumber")
            {
                i_number = System.Convert.ToDecimal(f_works.Text);
                i_number += 1;
                f_works.Text = i_number.ToString();
            }
            if (ClickName == "GoodQty")
            {
                i_number = System.Convert.ToDecimal(f_gp.Text);
                i_number += 1;
                f_gp.Text = i_number.ToString();
            }
            if (ClickName == "UnGoodQty")
            {
                i_number = System.Convert.ToDecimal(f_ng.Text);
                i_number += 1;
                f_ng.Text = i_number.ToString();
            }
        }

        private void f_sub_Click(object sender, EventArgs e)
        {
            decimal i_number = 0M;
            if (ClickName == "OperNumber")
            {
                i_number = System.Convert.ToDecimal(f_works.Text);
                i_number -= 1;
                if (i_number < 0) i_number = 0;
                f_works.Text = i_number.ToString();
            }
            if (ClickName == "GoodQty")
            {
                i_number = System.Convert.ToDecimal(f_gp.Text);
                i_number -= 1;
                if (i_number < 0) i_number = 0M;
                f_gp.Text = i_number.ToString();
            }
            if (ClickName == "UnGoodQty")
            {
                i_number = System.Convert.ToDecimal(f_ng.Text);
                i_number -= 1;
                if (i_number < 0) i_number = 0M;
                f_ng.Text = i_number.ToString();
            }
        }

        

        private void f_OK_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_Check() == false)
                        return;
                    try
                    {
                        f_Insert();
                        //Config.Show(String.Format("{0}", f_Insert()));
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                else
                {
                    return;
                }
                Close_Form();//離開畫面
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {
                        f_Update();                        
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                else
                {
                    return;
                }
                Close_Form();
            }

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        f_Delete();                        
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                else
                {
                    return;
                }
                Close_Form();
            }
        }

        

        private void f_Update()
        {            
            Processch rProcessch = new Processch();
            rProcessch.Dept = Login.DEPT;
            rProcessch.Station = f_station.Text;
            rProcessch.DocNo = f_docno.Text;
            rProcessch.MakeDate = f_mfd.Text;
            rProcessch.OperNumber = System.Convert.ToDecimal(f_works.Text);
            rProcessch.GoodQty = System.Convert.ToDecimal(f_gp.Text);
            rProcessch.UnGoodQty = System.Convert.ToDecimal(f_ng.Text);
            rProcessch.JobStart = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rProcessch.JobEnd = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rProcessch.ModUser = Login.ID;            
            string sql =  Processch.Set_Update(rProcessch);

            var i = DOSQL.Excute(Login.WU, sql);
            if (i == 0)
                labMessage.Text = "修改失敗";
            else
                labMessage.Text = "修改成功";
            //---
            //GoWeb("Upd", rProcessch);
        }

        private void f_Delete()
        {            
            Processch rProcessch = new Processch();
            rProcessch.DocNo = f_docno.Text;
            string sql = Processch.Set_Delete(rProcessch);

            var i = DOSQL.Excute(Login.WU, sql);
            if (i == 0)
                labMessage.Text = "刪除失敗";
            else
                labMessage.Text = "刪除成功";
            ////---
            //GoWeb("Del", rProcessch);
        }

        private void f_Insert()
        {
            string rf = string.Empty;
            Processch rProcessch = new Processch();
            rProcessch.Dept = Login.DEPT;
            rProcessch.Station = f_station.Text;
            rProcessch.DocNo = StationDoc.getDocNO(Login.DEPT, StationDoc.getDocType(f_station.Text));
            rProcessch.MakeDate = f_mfd.Text;
            rProcessch.OperNumber = System.Convert.ToDecimal(f_works.Text);
            rProcessch.GoodQty = System.Convert.ToDecimal(f_gp.Text);
            rProcessch.UnGoodQty = System.Convert.ToDecimal(f_ng.Text);
            rProcessch.JobStart = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rProcessch.JobEnd = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rProcessch.AddUser = Login.ID;
            rProcessch.ModUser = Login.ID;
            string sql = Processch.Set_Insert(rProcessch);
            var i = DOSQL.Excute(Login.WU, sql);
            if (i == 0) labMessage.Text = "新增失敗"; else labMessage.Text = "新增成功";

            

            //GoWeb("Add", rProcessch);
        }


        //private void f_Insert()
        //{
        //    string rf = string.Empty;
        //    Processch rProcessch = new Processch();
        //    rProcessch.Dept = Login.DEPT;
        //    rProcessch.Station = f_station.Text;
        //    rProcessch.DocNo = StationDoc.getDocNO(Login.DEPT, StationDoc.getDocType(f_station.Text));
        //    rProcessch.MakeDate = f_mfd.Text;
        //    rProcessch.OperNumber = System.Convert.ToDecimal(f_works.Text);
        //    rProcessch.GoodQty = System.Convert.ToDecimal(f_gp.Text);
        //    rProcessch.UnGoodQty = System.Convert.ToDecimal(f_ng.Text);
        //    rProcessch.JobStart = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        //    rProcessch.JobEnd = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        //    rProcessch.AddUser = Login.ID;            
        //    rProcessch.ModUser = Login.ID;
        //    string sql = Processch.Set_Insert(rProcessch);
        //    var i = DOSQL.Excute(Login.WU, sql);
        //    if (i == 0) labMessage.Text = "新增失敗"; else labMessage.Text = "新增成功";
        //    GoWeb("Add", rProcessch);
        //}

        private void GoWeb(string Sel, Processch rProcessch)
        {
            if (Config.ApiCheck("127.0.0.1", 64198, 500))
            {
                List<Processch> u = new List<Processch>();
                u.Add(rProcessch);
                if (Sel == "Add") Add(u);
                if (Sel == "Upd") Upd(u);
                if (Sel == "Del") Del(u);
            }
        }

        private async void Add(List<Processch> u)
        {
            string Url = "http://localhost:64198/api/Processch/Insert";
            string myJson = JsonConvert.SerializeObject(u);
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Url),
                    Content = new StringContent(myJson, Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode) labMessage.Text = "Web--新增失敗";
            }
        }

        private async void Upd(List<Processch> u)
        {
            string Url = "http://localhost:64198/api/Processch/Update";
            string myJson = JsonConvert.SerializeObject(u);
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(Url),
                    Content = new StringContent(myJson, Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode) labMessage.Text = "web-修改失敗";
            }
        }

        private async void Del(List<Processch> u)
        {            
            string Url = "http://localhost:64198/api/Processch/Delete";
            string myJson = JsonConvert.SerializeObject(u);
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(Url),
                    Content = new StringContent(myJson, Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode) labMessage.Text = "web-刪除失敗";
            }
        }



        private bool f_Check()
        {
            if (f_mfd.Text == String.Empty)
            {
                Config.Show("生產日期不可空白");
                f_mfd.Focus();
                return false;
            }
            return true;
        }

        private void Close_Form()
        {            
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }

        private void f_works_Click(object sender, EventArgs e)
        {
            ClickName = "OperNumber";
        }

        private void f_gp_Click(object sender, EventArgs e)
        {
            ClickName = "GoodQty";
        }

        private void f_ng_Click(object sender, EventArgs e)
        {
            ClickName = "UnGoodQty";
        }

        private void f_prno_bt_Click(object sender, EventArgs e)
        {
            wfdwk fm = new wfdwk();//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = fm.dtProd;                
                dataGridView1.DataSource = dt;
                //---畫面字體變大畫面優化------
                FontGridView(dt.Rows.Count);
            }
        }
        private void FontGridView(int CRow)
        {            
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
    }
}
