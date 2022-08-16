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
using System.Net;
using System.Net.Sockets;

namespace EMES.Forms
{
    public partial class prc001 : Form
    {
        string rEcm06; //切台作業
        List<string> myIP = new List<string>(); //IP位址
        string ClickName = string.Empty;
        //string ePlant
        string ePlant= (Login.DEPT == "ej" ? "EW" : Login.DEPT.ToUpper());//營運中心        
        public prc001()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;            
        }

        private void prc001_Load(object sender, EventArgs e)
        {            
            Set_Bhh();
            Set_Bmm();
            Set_Ehh();
            Set_Emm();
            f_mfd.Text = DateTime.Now.ToString("yyyy/MM/dd");
            Set_Class();//班別
                        
            EleTime(); //觸發電子時鐘
            MyIP();
            clsForm();//清除畫面
            FindControl(this);

            f_station_no.Text = Login.ID;
            f_station_name.Text = Login.IDNAME;
            f_wkno.Select();
            f_wkno.Focus();
        }

        




        private void Set_Class()
        {
            f_class.DataSource = ecg_file.ToDoList();
            f_class.DisplayMember = "ecg02";
            f_class.ValueMember = "ecg01";
        }

        private void Set_Bhh()
        {
            for (int i = 0; i < 24; i++)
            {                
                string thh = i.ToString("00");
                f_mfd_bhh.Items.Add(thh);
            }
            f_mfd_bhh.SelectedIndex = 0;
        }
        private void Set_Ehh()
        {
            for (int i = 0; i < 24; i++)
            {
                string thh = i.ToString("00");
                f_mfd_ehh.Items.Add(thh);
            }
            f_mfd_ehh.SelectedIndex = 0;
        }

        private void Set_Bmm()
        {
            for (int i = 0; i < 60; i++)
            {                
                string tmm = i.ToString("00");
                f_mfd_bmm.Items.Add(tmm);
            }
            f_mfd_bmm.SelectedIndex = 0;
        }
        private void Set_Emm()
        {
            for (int i = 0; i < 60; i++)
            {
                string tmm = i.ToString("00");
                f_mfd_emm.Items.Add(tmm);
            }
            f_mfd_emm.SelectedIndex = 0;
        }

        private void btn_machion_Click(object sender, EventArgs e)
        {
            if (isClick(f_wkno.Text) == false) return;
            rMachion fm = new rMachion();            
            fm.Dept = Login.DeptOne;
            fm.Eci03 = f_station_no.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                if (dt.Rows.Count > 0)
                {
                    RecordShow(dt);//顯示資料
                }
                Get_qty_g();
            }
        }

        private void RecordShow(DataTable dt)
        {
            f_machion.Text = dt.Rows[0]["eci01"].ToString();
            f_machion_name.Text = dt.Rows[0]["eci06"].ToString();            
            f_cdept.Text = dt.Rows[0]["eca03"].ToString();
            f_cdept_name.Text = dt.Rows[0]["gem02"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void btn_wk_Click(object sender, EventArgs e)
        {
            rWkDay fm = new rWkDay();
            fm.Dept = Login.DeptOne;
            fm.Schdate = f_mfd.Text;
            fm.Station = f_station_no.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                WkShow(dt);//顯示資料
                //
                btn_wkseq_Click(null, null);
                //
                btn_machion_Click(null, null);
            }
        }

        //private void btn_wk_Click(object sender, EventArgs e)
        //{            
        //    rWkDay fm = new rWkDay();
        //    fm.Dept = Login.DeptOne;
        //    fm.Schdate = f_mfd.Text;
        //    fm.Station = f_station_no.Text;
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        //接收回傳資料
        //        DataTable dt = fm.dtProd;
        //        WkShow(dt);//顯示資料                
        //    }
        //}

        private void WkShow(DataTable dt)
        {
            f_wkno.Text = dt.Rows[0]["sfb01"].ToString();
            f_imno.Text = dt.Rows[0]["sfb05"].ToString();
            f_imdesc.Text = dt.Rows[0]["ima02"].ToString();
            f_imsize.Text = dt.Rows[0]["ima021"].ToString();
            f_wkqty.Text = dt.Rows[0]["sfb08"].ToString();
        }



        private void btn_wkseq_Click(object sender, EventArgs e)
        {
            if (isClick(f_wkno.Text) == false) return;
            rWKseq fm = new rWKseq();
            fm.Sfb01 = f_wkno.Text;
            fm.Schdate = f_mfd.Text;
            fm.Station = f_station_no.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                WkSeqShow(dt);//顯示資料
            }
        }

        private bool isClick(string rs)
        {
            bool rb= false;
            if (!string.IsNullOrEmpty(rs)) rb = true;
            return rb;
        }


        private void WkSeqShow(DataTable dt)
        {
            f_wkseq.Text = dt.Rows[0]["ecb03"].ToString();
            f_workno.Text = dt.Rows[0]["ecm04"].ToString();
            f_workname.Text = dt.Rows[0]["ecm45"].ToString();            
        }

        private void btn_station_Click(object sender, EventArgs e)
        {
            clsForm();//清除畫面
            rStationDay fm = new rStationDay();
            fm.Dept = Login.DeptOne;
            fm.Schdate = f_mfd.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                f_station_name.Text = dt.Rows[0][1].ToString();
                StationShow(dt);//顯示資料

                btn_wk_Click(null, null);
                //
                btn_wkseq_Click(null, null);
                //
                btn_machion_Click(null, null);
            }
        }

        private void StationShow(DataTable dt)
        {
            f_station_no.Text = dt.Rows[0][0].ToString();
            f_station_name.Text = dt.Rows[0][1].ToString();
        }

        private void clsForm()
        {            
            f_wkno.Text = string.Empty;
            f_imno.Text = string.Empty;
            f_imdesc.Text = string.Empty;
            f_imsize.Text = string.Empty;
            f_wkseq.Text = string.Empty;
            f_workno.Text = string.Empty;
            f_workname.Text = string.Empty;
            f_machion.Text = string.Empty;
            f_machion_name.Text = string.Empty;
            f_cdept.Text = string.Empty;
            f_cdept_name.Text = string.Empty;
            f_wkqty.Text = string.Empty;
            f_qty_bad.Value = 0;
            f_qty_g.Text = string.Empty;// "0";
            f_qty_bonus.Value = 0;
            f_qty_b.Text = string.Empty;// "0";
            f_qty_good.Value = 0;
            f_qty_bns.Text = string.Empty;// "0";
            f_mfd_bhh.SelectedIndex = 0;
            f_mfd_ehh.SelectedIndex = 0;
            f_mfd_bmm.SelectedIndex = 0;
            f_mfd_emm.SelectedIndex = 0;
            f_class.SelectedIndex = 0;

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.DataSource = null;
            //else
            //    dataGridView1.Rows.Clear();

            if (dataGridView2.Rows.Count > 0)
                dataGridView2.DataSource = null;
            //else
            //    dataGridView2.Rows.Clear();

        }

        private void EleTime()
        {
            //觸發電子時鐘
            timer1_Tick(this, null);
            timer1.Interval = 1000; // 設定每秒觸發一次
            timer1.Enabled = true; // 啟動 Timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            f_Time.Text = String.Format("{0:yyyy/MM/dd} {1:00}:{2:00}:{3:00}",
                time.Date, time.Hour, time.Minute, time.Second);
        }

        private void MyIP()
        {
            //mylocalip
            myIP = GetHostIPAddress(); //列印主機IP
            f_ip.Text = string.Format("{0}{1}", "IP：", myIP[0]);
        }

        private static List<string> GetHostIPAddress()
        {
            List<string> lstIPAddress = new List<string>();
            string hostName = Dns.GetHostName();  //取得本機名稱
            //取得所有IP，包含IPV4和IPV6
            System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ip in addressList)
            {
                //過濾IPV4的位址
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    lstIPAddress.Add(ip.ToString());
                }
            }
            return lstIPAddress; // result: 192.168.1.17 ......
        }

        private void f_qty_good_Click(object sender, EventArgs e)
        {
            ClickName = "qtygood";
        }

        private void bt_9_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "9";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "9";
            if (ClickName == "qtybonus") f_qty_bns.Text += "9";
        }

        private void bt_8_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "8";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "8";
            if (ClickName == "qtybonus") f_qty_bns.Text += "8";
        }

        private void bt_7_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "7";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "7";
            if (ClickName == "qtybonus") f_qty_bns.Text += "7";
        }

        private void bt_6_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "6";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "6";
            if (ClickName == "qtybonus") f_qty_bns.Text += "6";
        }

        private void bt_5_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "5";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "5";
            if (ClickName == "qtybonus") f_qty_bns.Text += "5";
        }

        private void bt_4_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "4";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "4";
            if (ClickName == "qtybonus") f_qty_bns.Text += "4";
        }

        private void bt_3_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "3";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "3";
            if (ClickName == "qtybonus") f_qty_bns.Text += "3";
        }

        private void bt_2_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "2";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "2";
            if (ClickName == "qtybonus") f_qty_bns.Text += "2";
        }

        private void bt_1_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "1";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "1";
            if (ClickName == "qtybonus") f_qty_bns.Text += "1";
        }

        private void bt_0_Click(object sender, EventArgs e)
        {            
            if (ClickName == "qtygood") f_qty_g.Text += "0";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "0";
            if (ClickName == "qtybonus") f_qty_bns.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClickName == "qtygood") f_qty_g.Text += "00";
            if (ClickName == "qtybad" && f_qty_b.ReadOnly != true) f_qty_b.Text += "00";
            if (ClickName == "qtybonus") f_qty_bns.Text += "00";
        }

        private void f_qty_g_Click(object sender, EventArgs e)
        {
            ClickName = "qtygood";
        }

        private void f_qty_b_Click(object sender, EventArgs e)
        {
            ClickName = "qtybad";
        }

        private void f_qty_bns_Click(object sender, EventArgs e)
        {
            ClickName = "qtybonus";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ClickName == "qtygood") f_qty_g.Text = string.Empty;
            if (ClickName == "qtybad") f_qty_b.Text = string.Empty;
            if (ClickName == "qtybonus") f_qty_bns.Text = string.Empty;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (ClickName == "qtygood") {
                if (f_qty_g.Text.Length == 0) return;
                f_qty_g.Text = f_qty_g.Text.Substring(0, f_qty_g.Text.Length - 1);
            }

            if (ClickName == "qtybad") {
                if (f_qty_b.Text.Length == 0) return;
                f_qty_b.Text = f_qty_b.Text.Substring(0, f_qty_b.Text.Length - 1);                
            }

            if (ClickName == "qtybonus") {
                if (f_qty_bns.Text.Length == 0) return;
                f_qty_bns.Text = f_qty_bns.Text.Substring(0, f_qty_bns.Text.Length - 1);                
            }
        }

        private void isDecimal(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar != 46 &&
                (byte)e.KeyChar != 49 &&
                (byte)e.KeyChar != 50 &&
                (byte)e.KeyChar != 51 &&
                (byte)e.KeyChar != 52 &&
                (byte)e.KeyChar != 53 &&
                (byte)e.KeyChar != 54 &&
                (byte)e.KeyChar != 55 &&
                (byte)e.KeyChar != 56 &&
                (byte)e.KeyChar != 57 &&
                (byte)e.KeyChar != 48 &&
                (byte)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (f_Check() == false)
            {
                return;
            }
            try
            {
                Add();
                clsForm();//清畫面
            }
            catch (Exception ex)
            {
                if (Login.LOG == "Y")
                {
                    toLog(ex.Message);
                }
                Config.Show(ex.Message);
                throw;
            }
        }

        

        private bool f_Check()
        {
            int a = f_qty_g.Text.Trim().Length;
            int b = f_qty_b.Text.Trim().Length;
            int c = f_qty_bns.Text.Trim().Length;
            if (string.IsNullOrEmpty(f_station_no.Text))
            {
                Config.Show("請選擇工作站");
                return false;
            }
            if (string.IsNullOrEmpty(f_wkno.Text))
            {
                Config.Show("請選擇工單");
                return false;
            }
            if (string.IsNullOrEmpty(f_wkseq.Text))
            {
                Config.Show("請選擇工序");
                return false;
            }
            if (f_mfd_bhh.Text=="00")
            {
                Config.Show("請選擇時間");
                f_mfd_bhh.Focus();
                return false;
            }
            if (f_mfd_ehh.Text == "00")
            {
                Config.Show("請選擇時間");
                f_mfd_ehh.Focus();
                return false;
            }
            if (a + b + c == 0)
            {
                Config.Show("請輸入數量");
                Get_qty_g();
                return false;
            }
            return true;
        }


        //private void Add()
        //{
        //    string Begdate = f_mfd.Text + " " + f_mfd_bhh.Text + ":" + f_mfd_bmm.Text;
        //    string Enddate = f_mfd.Text + " " + f_mfd_ehh.Text + ":" + f_mfd_emm.Text;
        //    string DocNo = StationDoc.getDocNO(Login.DeptOne); //單據號
        //    int WorkTime = TimeSpan2(Begdate, Enddate); //工時

        //    //報工主檔資料
        //    In_Proc(DocNo, WorkTime);
        //    //員工主檔資料
        //    In_Ede(DocNo);
        //    //員工明細檔資料
        //    In_Edf(DocNo, WorkTime);
        //    //報廢數
        //    In_Shc(DocNo);
        //}

        private void Add()
        {
            string Begdate = f_mfd.Text + " " + f_mfd_bhh.Text + ":" + f_mfd_bmm.Text;
            string Enddate = f_mfd.Text + " " + f_mfd_ehh.Text + ":" + f_mfd_emm.Text;
            string DocNo = StationDoc.getDocNO(Login.DeptOne); //單據號
            int WorkTime = TimeSpan2(Begdate, Enddate); //工時

            //報工主檔資料
            In_Proc(DocNo, WorkTime);

            ////員工主檔資料
            //In_Ede(DocNo);

            ////員工明細檔資料
            //In_Edf(DocNo, WorkTime);

            ////報廢數
            //In_Shc(DocNo);
        }


        private void In_Proc(string Doc,int WorkTime)
        {
            Inproc rc = new Inproc();
            rc.Doc = Doc;
            rc.Shb02 = f_mfd.Text;
            rc.Shb021 = f_mfd_bhh.Text + ":" + f_mfd_bmm.Text;
            rc.Shb03 = f_mfd.Text;
            rc.Shb031 = f_mfd_ehh.Text + ":" + f_mfd_emm.Text;
            rc.Shb032 = WorkTime;
            rc.Shb033 = WorkTime;
            rc.Shb04 = Login.ID;
            rc.Shb05 = f_wkno.Text;
            rc.Shb06 = System.Convert.ToInt16(f_wkseq.Text);
            rc.Shb07 = f_station_no.Text;
            rc.Shb08 = f_class.SelectedValue.ToString();
            rc.Shb081 = f_workno.Text;
            rc.Shb082 = f_workname.Text;
            rc.Shb09 = f_machion.Text;
            rc.Shb10 = f_imno.Text;
            rc.Shb111 = f_qty_g.Text.Length == 0 ? 0 : System.Convert.ToDecimal(f_qty_g.Text);
            rc.Shb112 = f_qty_b.Text.Length == 0 ? 0 : System.Convert.ToDecimal(f_qty_b.Text);
            rc.Shb115 = f_qty_bns.Text.Length == 0 ? 0 : System.Convert.ToDecimal(f_qty_bns.Text);
            //rc.Shbgrup = "topgui";
            rc.Shbgrup = Login.IDCdept;
            rc.Shblegal = ePlant;
            rc.Shbmodu = Login.ID;
            //rc.Shborig = "topgui";
            rc.Shborig = Login.IDCdept;//報工人員部門
            rc.Shboriu = Login.ID;
            rc.Shbplant = ePlant;
            rc.Shbuser = Login.ID;
            rc.Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rc.Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rc.Ip = myIP[0];
            rc.Status = "0";
            //紀錄Log
            if (Login.LOG == "Y")
            {                
                string Work = rc.Shb081 + " " + rc.Shb082;
                string logMsg = string.Format("單據：{0}|工單：{1}|作業：{2}|工序：{3}|開始時間：{4}|結束時間：{5}|工時：{6}", rc.Doc, rc.Shb05, Work, rc.Shb06, rc.Shb021, rc.Shb031, rc.Shb032);
                toLog(logMsg);
            }
            //--------------

            string sql = Inproc.Set_Insert(rc);            
            var i = DOSQL.Excute(Login.WU, sql);
            if (i <= 0) MessageBox.Show("Fail-InProc");
        }

        private void In_Ede(string Doc)
        {
            string sql = string.Empty;
            if (dataGridView1.Rows.Count == 0) return;
            InEde rc = new InEde();
            rc.Doc = Doc;
            rc.Edegrup = Login.IDCdept;
            rc.Edelegal = ePlant;
            rc.Edemodu = Login.ID;
            rc.Edeorig = Login.IDCdept;
            rc.Edeoriu = Login.ID;
            rc.Edeplant = ePlant;
            rc.Edeuser = Login.ID;
            rc.Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rc.Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            rc.Status = "0";
            sql += InEde.Set_Insert(rc);
            if (sql.Length > 0)
            {
                var i = DOSQL.Excute(Login.WU, sql);
                if (i <= 0) MessageBox.Show("Fail-InEde");
            }
        }

        private void In_Edf(string Doc,decimal Machtime)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                InEdf rc = new InEdf();
                rc.Doc = Doc;
                rc.Edf03 = f_wkno.Text;
                rc.Edf04 = f_imno.Text;
                rc.Edf06 = f_workno.Text;
                rc.Edf07 = System.Convert.ToDecimal(f_wkseq.Text);
                rc.Edf08 = System.Convert.ToDecimal(f_qty_g.Text);
                rc.Edf09 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                rc.Edf11 = Machtime;
                rc.Edf12 = Machtime;
                rc.Edf14 = Machtime;
                rc.Edf15 = Machtime;
                rc.Edflegal = ePlant;
                rc.Edfplant = ePlant;
                rc.Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff"); ;
                rc.Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff"); ;
                rc.Status = "0";
                sql += InEdf.Set_Insert(rc);                
            }
            if (sql.Length > 0)
            {
                var j = DOSQL.Excute(Login.WU, sql);
                if (j <= 0) MessageBox.Show("Fail-InEdf");
            }
        }

        private void In_Shc(string Doc)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                Inshc rc = new Inshc();
                rc.Doc = Doc;
                rc.Wkno = f_wkno.Text;
                rc.Shc03 = System.Convert.ToDecimal(dataGridView2.Rows[i].Cells[0].Value.ToString());
                rc.Shc04 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                rc.Shc05 = System.Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value.ToString());
                rc.Shc06 = dataGridView2.Rows[i].Cells[4].Value.ToString();
                rc.Shcacti = "Y";
                rc.Shcuser = Login.ID;
                rc.Shcgrup = Login.IDCdept;
                rc.Shcdate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                rc.Shcplant = ePlant;
                rc.Shclegal = ePlant;
                rc.Shcorig = Login.IDCdept;
                rc.Shcoriu = Login.ID;
                rc.Status = "0";
                sql += Inshc.Set_Insert(rc);                
            }
            if (sql.Length > 0)
            {
                var j = DOSQL.Excute(Login.WU, sql);
                if (j <= 0) MessageBox.Show("Fail-InShc");
            }
        }



        //private void In_Ede(string Doc)
        //{
        //    string sql = string.Empty;
        //    if (dataGridView1.Rows.Count == 0) return;

        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        InEde rc = new InEde();
        //        rc.Doc = Doc;
        //        rc.Edegrup = "topgui";
        //        rc.Edemodu = Login.ID;
        //        rc.Edeorig = "topgui";
        //        rc.Edeoriu = Login.ID;
        //        rc.Edeplant = ePlant;
        //        rc.Edeuser = Login.ID;
        //        rc.Add_date = DateTime.Now;
        //        rc.Mod_date = DateTime.Now;
        //        rc.Status = "0";
        //        sql += InEde.Set_Insert(rc);
        //    }
        //    if (sql.Length > 0)
        //    {
        //        var i = DOSQL.Excute(Login.WU, sql);
        //        if (i <= 0) MessageBox.Show("Fail-InEde");
        //    }

        //}


        private int TimeSpan2(string Begdate,string Enddate)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(System.Convert.ToDateTime(Begdate).Ticks);
            TimeSpan ts2 = new TimeSpan(System.Convert.ToDateTime(Enddate).Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";            
            var mD = ts.Days * 24 * 60;
            var mH = ts.Hours * 60;
            var mM = mD + mH + ts.Minutes;
            return mM;
        }

        private void Get_qty_g()
        {
            f_qty_g_Click(null, null);
            f_qty_g.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clsForm();//清除畫面
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            if (isClick(f_wkno.Text) == false) return;
            if (String.IsNullOrEmpty(f_station_no.Text)) return;
            //是否顯示首列資料
            this.dataGridView1.ColumnHeadersVisible = false;
            rEmployee fm = new rEmployee();
            fm.Dept = Login.DEPT;
            fm.Schdate = f_mfd.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料(員工)
                DataTable dt = fm.dtProd;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
        }



        private void FindControl(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                FindControl(c);
                if (c is TextBox)
                {
                    (c as TextBox).GotFocus += new EventHandler(Control_GotFocus);
                    (c as TextBox).LostFocus += new EventHandler(Control_LostFocus);
                }
            }
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            Config.Control_Click(sender, e);
        }

        private void Control_LostFocus(object sender, EventArgs e)
        {
            Config.Control_Leave(sender, e);
        }

        private void btnStup_Click(object sender, EventArgs e)
        {
            if (isClick(f_wkno.Text) == true) return;
            frmPass frm = new frmPass();
            if (frm.ShowDialog() == DialogResult.OK) //密碼通過 設定
            {
                Setting();
            }
        }


        private void Setting()
        {
            frmSetting frm = new frmSetting();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Form1_Load(this, null);
            }
        }


        private void toLog(string logMsg)
        {
            LogRecord.WriteLog(logMsg);
        }

        private void btn_outqty_Click(object sender, EventArgs e)
        {
            if (isClick(f_wkno.Text) == false) return;
            if (String.IsNullOrEmpty(f_station_no.Text)) return;
            this.dataGridView2.ColumnHeadersVisible = false;
            
            rOutqty fm = new rOutqty();
            fm.Sch06 = f_wkseq.Text;
            fm.Sch06no = f_workno.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = fm.dtProd;                
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dt;
                f_qty_b.Text = fm.sumSch05.ToString();
                dataGridView2.Columns[0].Width = 30;
                dataGridView2.Columns[1].Width = 80;
                dataGridView2.Columns[2].Width = 170;
                dataGridView2.Columns[3].Width = 40;
                dataGridView2.Columns[4].Width = 40;
                dataGridView2.Columns[5].Width = 100;

            }
        }
    }
}
