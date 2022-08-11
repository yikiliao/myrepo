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
    public partial class prc020 : Form
    {
        string rEcm06; //切台作業
        List<string> myIP = new List<string>(); //IP位址
        string ClickName = string.Empty;
        public DataTable dtOutProd = new DataTable(); //存報廢資料
        public static DataTable dtFewProd = new DataTable(); //各別報廢明細        
        string ePlant= (Login.DEPT == "ej" ? "EW" : Login.DEPT.ToUpper());//營運中心

        private string Begdate = string.Empty;
        private string Enddate = string.Empty;
        private string Workday = string.Empty;
        private string Station = string.Empty;//工作站
        private string StationName = string.Empty;//工作站名稱
        //private string aCalss = string.Empty;//班別
        private string aClassno = string.Empty;//班別代碼
        private string aClassname = string.Empty;//班別名稱
        private string aMachno = string.Empty;//機台代碼
        private bool isDragonDoor = false;//是否龍門機台
        private string DragonNextStation = string.Empty;//龍門下一站工作站
        private string DragonNextStationName = string.Empty;//龍門下一站工作站名稱
        public prc020()
        {
            InitializeComponent();
            ////--
            //this.Font = new System.Drawing.Font(
            //          "Microsoft Sans Serif",
            //          24F,
            //          System.Drawing.FontStyle.Regular,
            //          System.Drawing.GraphicsUnit.Point,
            //          ((byte)(0)));
            // //--

            this.StartPosition = FormStartPosition.CenterScreen;
            Init_DataTable();

            //標題字體(工單)
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView3.DefaultCellStyle.Font = new Font("新細明體", 22);
            this.dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //標題字體(員工)
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView1.DefaultCellStyle.Font = new Font("新細明體", 22);
            this.ControlBox = false;
        }

        private void Init_DataTable()
        {
            //--定義datatable 欄位
            dtOutProd.Reset();
            dtOutProd.Columns.Add("wkno", typeof(String));
            dtOutProd.Columns.Add("shc03", typeof(String));
            dtOutProd.Columns.Add("shc04", typeof(String));
            dtOutProd.Columns.Add("shc04name", typeof(String));
            dtOutProd.Columns.Add("shc05", typeof(String));
            dtOutProd.Columns.Add("shc06", typeof(String));
            dtOutProd.Columns.Add("shc06no", typeof(String));


            //個別報廢
            dtFewProd.Reset();
            dtFewProd.Columns.Add("shc03", typeof(String));
            dtFewProd.Columns.Add("shc04", typeof(String));
            dtFewProd.Columns.Add("shc04name", typeof(String));
            dtFewProd.Columns.Add("shc05", typeof(String));
            dtFewProd.Columns.Add("shc06", typeof(String));
            dtFewProd.Columns.Add("shc06no", typeof(String));
        }

        private void prc001_Load(object sender, EventArgs e)
        {            
            Set_Bhh();
            Set_Bmm();
            Set_Ehh();
            Set_Emm();
            //
            Set_Bhh_Emp();
            Set_Bmm_Emp();
            Set_Ehh_Emp();
            Set_Emm_Emp();
            f_mfd.Text = DateTime.Now.ToString("yyyy/MM/dd");
            Set_Class();//班別
            Set_Mach();//機台
                        
            EleTime(); //觸發電子時鐘
            MyIP();
            clsForm();//清除畫面
            FindControl(this);

            f_station_no.Text = Login.ID;
            f_station_name.Text = Login.IDNAME;
            f_wkno.Select();
            f_wkno.Focus();

            //背景工作作業
            backgroundWorker1.WorkerReportsProgress = true;         //是否要回報進度
            backgroundWorker1.WorkerSupportsCancellation = true;    //是否支援取消作業
        }

        private void Set_Mach()
        {
            DataTable dt = eci_file.ToDoList(Login.DeptOne, Login.ID);
            f_mach.DataSource = dt;
            f_mach.DisplayMember = "eci06";
            f_mach.ValueMember = "eci01";            
        }


        private void Set_Class()
        {
            f_class.DataSource = ecg_file.ToDoList();
            f_class.DisplayMember = "ecg02";
            f_class.ValueMember = "ecg01";
        }

        private void Set_Bhh()
        {
            f_mfd_bhh.Items.Clear();
            for (int i = 0; i < 24; i++)
            {                
                string thh = i.ToString("00");
                f_mfd_bhh.Items.Add(thh);
            }
            f_mfd_bhh.SelectedIndex = 0;
        }
        private void Set_Ehh()
        {
            f_mfd_ehh.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                string thh = i.ToString("00");
                f_mfd_ehh.Items.Add(thh);
            }
            f_mfd_ehh.SelectedIndex = 0;
        }
        private void Set_Bhh_Emp()
        {
            f_d_bHH.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                string thh = i.ToString("00");
                f_d_bHH.Items.Add(thh);
            }
            f_d_bHH.SelectedIndex = 0;
        }
        private void Set_Ehh_Emp()
        {
            f_d_eHH.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                string thh = i.ToString("00");
                f_d_eHH.Items.Add(thh);
            }
            f_d_eHH.SelectedIndex = 0;
        }

        private void Set_Bmm()
        {
            f_mfd_bmm.Items.Clear();
            for (int i = 0; i < 60; i = i + 5)
            {                
                string tmm = i.ToString("00");
                f_mfd_bmm.Items.Add(tmm);
            }
            f_mfd_bmm.SelectedIndex = 0;
        }
        private void Set_Emm()
        {
            f_mfd_emm.Items.Clear();
            for (int i = 0; i < 60; i = i + 5)
            {
                string tmm = i.ToString("00");
                f_mfd_emm.Items.Add(tmm);
            }
            f_mfd_emm.SelectedIndex = 0;
        }

        private void Set_Bmm_Emp()
        {
            f_d_bMM.Items.Clear();
            for (int i = 0; i < 60; i = i + 5)
            {
                string tmm = i.ToString("00");
                f_d_bMM.Items.Add(tmm);
            }
            f_d_bMM.SelectedIndex = 0;
        }

        private void Set_Emm_Emp()
        {
            f_d_eMM.Items.Clear();
            for (int i = 0; i < 60; i = i + 5)
            {
                string tmm = i.ToString("00");
                f_d_eMM.Items.Add(tmm);
            }
            f_d_eMM.SelectedIndex = 0;
        }

        private void btn_machion_Click(object sender, EventArgs e)
        {
            if (isNoData(f_wkno.Text) == false) return;
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
            rCutDay fm = new rCutDay();
            fm.Dept = Login.DeptOne;
            fm.Schdate = f_mfd.Text;
            fm.Station = f_station_no.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                FindD(dt);
            }
        }

        //private void btn_wk_Click(object sender, EventArgs e)
        //{
        //    //if (isNoData(f_wkno.Text) == true) return;
        //    //dtFewProd.Clear();//清各別報廢暫存檔
        //    rCutDay fm = new rCutDay();
        //    fm.Dept = Login.DeptOne;
        //    fm.Schdate = f_mfd.Text;
        //    fm.Station = f_station_no.Text;
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        //接收回傳資料
        //        DataTable dt = fm.dtProd;
        //        FindD(dt);
        //        //CutShow(dt);//顯示資料
        //        //Get_qty_g();
        //    }
        //}

        private void FindD(DataTable dt)
        {            
            int idx = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sfb01 = dt.Rows[i]["sfb01"].ToString();//工單 
                Int16 ecm03 = System.Convert.ToInt16(dt.Rows[i]["ecm03"].ToString());//工序
                if (havadata(sfb01,ecm03) == true) //以有資料不再寫入
                {
                    continue;
                }
                else
                {
                    dataGridView3.Rows.Add(new object[] {dt.Rows[i]["sfb01"],
                    dt.Rows[i]["ecm03"],
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    dt.Rows[i]["ecm04"],
                    dt.Rows[i]["ecm45"],
                    dt.Rows[i]["sfb05"],
                    dt.Rows[i]["sfb08"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"]
                    });
                    idx += 1;
                }
            }

            if (idx > 0)
            {
                dataGridView3.Rows[0].Selected = true; //第一列反藍選取                
                //dataGridView3_CellClick(null, null);//點選欄位抓取資料
            }
        }


        private bool havadata(string sfb01)
        {
            bool rf = false;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string b = dataGridView3.Rows[i].Cells[0].Value.ToString();               
                if (sfb01 == b)
                {
                    rf = true;
                    return rf;
                }
            }
            return rf;
        }

        private bool havadata(string sfb01,Int16 ecm03)
        {
            bool rf = false;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string a = dataGridView3.Rows[i].Cells[0].Value.ToString();//工單                
                Int16 b = System.Convert.ToInt16(dataGridView3.Rows[i].Cells[1].Value.ToString());//工序
                if (sfb01 == a && ecm03 == b)
                {
                    rf = true;
                    return rf;
                }
            }
            return rf;
        }

        //private void btn_wk_Click(object sender, EventArgs e)
        //{
        //    if (isNoData(f_wkno.Text) == true) return;
        //    dtFewProd.Clear();//清各別報廢暫存檔
        //    rCutDay fm = new rCutDay();
        //    fm.Dept = Login.DeptOne;
        //    fm.Schdate = f_mfd.Text;
        //    fm.Station = f_station_no.Text;
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        //接收回傳資料
        //        DataTable dt = fm.dtProd;
        //        CutShow(dt);//顯示資料
        //        Get_qty_g();
        //    }
        //}

        //private void btn_wk_Click(object sender, EventArgs e)
        //{
        //    if (isNoData(f_wkno.Text) == true) return;
        //    dtFewProd.Clear();//清各別報廢暫存檔
        //    rWkDay fm = new rWkDay();
        //    fm.Dept = Login.DeptOne;
        //    fm.Schdate = f_mfd.Text;
        //    fm.Station = f_station_no.Text;
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        //接收回傳資料
        //        DataTable dt = fm.dtProd;
        //        WkShow(dt);//顯示資料
        //        //
        //        btn_wkseq_Click(null, null);                
        //    }
        //}

        private void CutShow(DataTable dt)
        {
            f_wkno.Text = dt.Rows[0]["sfb01"].ToString();
            f_imno.Text = dt.Rows[0]["sfb05"].ToString();
            f_imdesc.Text = dt.Rows[0]["ima02"].ToString();
            f_imsize.Text = dt.Rows[0]["ima021"].ToString();
            f_wkqty.Text = dt.Rows[0]["sfb08"].ToString();
            f_wkseq.Text = dt.Rows[0]["ecm03"].ToString();
            f_workno.Text = dt.Rows[0]["ecm04"].ToString();
            f_workname.Text = dt.Rows[0]["ecm45"].ToString();
        }


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
            if (isNoData(f_wkno.Text) == false) return;
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

        private bool isNoData(string rs)
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

            f_employeeid.Text = string.Empty;
            f_employeename.Text = string.Empty;
            f_d_bHH.SelectedIndex = 0;
            f_d_bMM.SelectedIndex = 0;
            f_d_eHH.SelectedIndex = 0;
            f_d_eMM.SelectedIndex = 0;


            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
            else
                dataGridView1.Rows.Clear();

            //if (dataGridView2.Rows.Count > 0)
            //{
            //    dataGridView2.DataSource = null;
            //    dataGridView2.Rows.Clear();
            //}
            //else
            //    dataGridView2.Rows.Clear();

            if (dataGridView3.Rows.Count > 0)
            {
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();
            }
            else
                dataGridView3.Rows.Clear();
        }


        private void clsDataTable()
        {
            dtOutProd.Clear();
            dtFewProd.Clear();
        }

        private void clsRecord()
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

            string runDate = f_Time.Text.Substring(0, 10);
            string sysDate = f_mfd.Text;
            if (runDate.Trim() != sysDate.Trim())
            {
                f_mfd.Text = runDate;
            }           
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
            if (Config.Message("是否確定輸入下列資料？\r\n\r\n"+ Msg()) == "Y")
            {
                DoWork();
            }   
        }

        private  string Msg()
        {
            string rf = "";
            string StName = f_station_name.Text;
            string StMachName = f_mach.Text;
            string BegTime = f_mfd_bhh.Text + ":" + f_mfd_bmm.Text;
            string EndTime = f_mfd_ehh.Text + ":" + f_mfd_emm.Text;
            string Msg_1 = "工作站:" + StName + "\t機台：" + StMachName + "\t機時:" + BegTime + "～" + EndTime + "\r\n";
            Msg_1 += "----------------------------------------------------------------- ";
            Msg_1 += "\r\n\r\n";

            string Msg_A = "工單\t\t良品數\t報廢數\tBonus數" + "\r\n";
            Msg_A += "----------------------------------------------------------------- \r\n";
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                Msg_A += dataGridView3.Rows[i].Cells[0].Value.ToString() + "\t" +
                    dataGridView3.Rows[i].Cells[2].Value.ToString() + "\t" +
                    dataGridView3.Rows[i].Cells[3].Value.ToString() + "\t" +
                    dataGridView3.Rows[i].Cells[4].Value.ToString() + "\r\n";
            }
            Msg_A += "\r\n";
            string Msg_B = "工號\t姓名\t開始(時)\t開始(分)\t結束(時)\t結束(分)" + "\r\n";
            Msg_B += "----------------------------------------------------------------- \r\n";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Msg_B += dataGridView1.Rows[i].Cells[0].Value.ToString() + "\t" +
                    dataGridView1.Rows[i].Cells[1].Value.ToString() + "\t" +
                    dataGridView1.Rows[i].Cells[2].Value.ToString() + "\t" +
                    dataGridView1.Rows[i].Cells[3].Value.ToString() + "\t" +
                    dataGridView1.Rows[i].Cells[4].Value.ToString() + "\t" +
                    dataGridView1.Rows[i].Cells[5].Value.ToString() + "\r\n";
            }
            rf = Msg_1 + Msg_A + Msg_B;
            return rf;
        }


        private void DoWork()
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (f_Check() == false) return;
                Get_LAB();//
                backgroundWorker1.RunWorkerAsync();
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (f_Check() == false)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        Add();
        //        clsForm();//清畫面
        //        clsDataTable();//清DataTable
        //        this.tabControl1.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (Login.LOG == "Y")
        //        {
        //            toLog(ex.Message);
        //        }
        //        Config.Show(ex.Message);
        //        throw;
        //    }
        //}



        private bool f_Check()
        {
            if (dataGridView3.Rows.Count == 0)
            {
                Config.Show("無資料請輸入工單資料");
                this.tabControl1.SelectedIndex = 0;
                return false;
            }
           
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string Good = dataGridView3.Rows[i].Cells[2].Value.ToString();
                string Bad = dataGridView3.Rows[i].Cells[3].Value.ToString();
                string Bouns = dataGridView3.Rows[i].Cells[4].Value.ToString();
                if (QtyEnter(Good, Bad, Bouns) ==false )
                {
                    Config.Show("有數量未輸入請確認");
                    this.tabControl1.SelectedIndex = 0;
                    return false;
                }
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string bHH = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string bMM = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string eHH = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string eMM = dataGridView1.Rows[i].Cells[5].Value.ToString();
                if (TimeEnter(bHH, bMM,eHH,eMM) == false)
                {
                    Config.Show("有工時未輸入請確認");
                    this.tabControl1.SelectedIndex = 1;
                    return false;
                }
            }

            if (TimeEnter(f_mfd_bhh.Text, f_mfd_bmm.Text, f_mfd_ehh.Text, f_mfd_emm.Text) == false)
            {
                Config.Show("請選擇工單時間");
                f_mfd_bhh.Focus();
                return false;
            }            
            
            if (dataGridView1.Rows.Count == 0)
            {
                Config.Show("請輸入員工資料");
                this.tabControl1.SelectedIndex = 1;
                return false;
            }
            return true;
        }

        private bool TimeEnter(string a, string b)
        {
            Int16 ia = System.Convert.ToInt16(a);
            Int16 ib = System.Convert.ToInt16(b);
            Int32 ic = ia + ib;
            if (ic > 0)
                return true;
            else
                return false;
        }

        private bool TimeEnter(string bHH, string bMM,string eHH,string eMM)
        {
            Int16 ibHH = System.Convert.ToInt16(bHH);
            Int16 ibMM = System.Convert.ToInt16(bMM);
            Int16 ieHH = System.Convert.ToInt16(eHH);
            Int16 ieMM = System.Convert.ToInt16(eMM);
            Int32 ic = ibHH + ibMM + ieHH + ieMM;
            if (ic > 0)
                return true;
            else
                return false;
        }

        private bool QtyEnter(string Good, string Bad, string Bonus)
        {
            double iGood = string.IsNullOrEmpty(Good) ? 0 : System.Convert.ToDouble(Good);
            double iBad = string.IsNullOrEmpty(Bad) ? 0 : System.Convert.ToDouble(Bad);
            double iBonus = string.IsNullOrEmpty(Bonus) ? 0 : System.Convert.ToDouble(Bonus);
            double ic = iGood + iBad + iBonus;
            if (ic > 0)
                return true;
            else
                return false;
        }

        //private void Add()
        //{
        //    string Begdate = f_mfd.Text + " " + f_mfd_bhh.Text + ":" + f_mfd_bmm.Text;
        //    string Enddate = f_mfd.Text + " " + f_mfd_ehh.Text + ":" + f_mfd_emm.Text;
        //    string DocNo = StationDoc.getDocNO(Login.DeptOne); //單據號
        //    int WorkTime = TimeSpan2(Begdate, Enddate); //總工時

        //    decimal a = getminWorkTime(dataGridView3, WorkTime);// 每筆幾分鐘(總工時/所有產出數；含不良+bonus+良品)

        //    //報工主檔資料
        //    In_Proc(DocNo, WorkTime, a);

        //    //員工主檔資料
        //    In_Ede(DocNo);

        //    //員工明細檔資料
        //    In_Edf(DocNo, WorkTime);

        //    //報廢數
        //    In_Shc(DocNo, dtOutProd);

        //    //員工工時記錄檔
        //    In_EmpHead(DocNo);

        //    //員工工時記錄檔
        //    In_EmpWork(DocNo);
        //}
        private void Get_LAB()
        {
            Begdate = f_mfd.Text + " " + f_mfd_bhh.Text + ":" + f_mfd_bmm.Text;
            Enddate = f_mfd.Text + " " + f_mfd_ehh.Text + ":" + f_mfd_emm.Text;
            Workday = f_mfd.Text;
            Station = f_station_no.Text;        //工作站
            StationName = f_station_name.Text;  //工作站名稱
            aClassno = f_class.SelectedValue.ToString();//班別代碼
            aClassname = f_class.Text;//班別名稱            
            aMachno = string.IsNullOrEmpty(f_mach.Text) ? string.Empty : f_mach.SelectedValue.ToString();//機台代碼 
            isDragonDoor = getIsDragonDoor(); //是否龍門剖台
        }

        private decimal getQty()
        {
            //找總產出數
            decimal rQty = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                rQty = rQty + Qty;
            }
            return rQty;
        }

        //當站如果是龍門，自動產生下一站的回饋資料，工時 數量都是0 
        private void Add_S()
        {            
            string DocNo = StationDoc.getDocNO(Login.DeptOne); //單據號
            string DocNoNext = isDragonDoor == true ? getDocNoNext(DocNo) : string.Empty;//如果是龍門給下一站單據號，否則empty
            int WorkTime = TimeSpan2(Begdate, Enddate); //機器總工時
            int PsonTime = getWorkTime();//合計總人工工時
            decimal Qty = getQty(); //產出總數 良品+不良+Bouns

            decimal a = getminWorkTime(dataGridView3, WorkTime);// 每筆幾分鐘(總工時/所有產出數；含不良+bonus+良品)

            string sql = string.Empty;
            

            //報工主檔資料
            sql += In_Proc_S(DocNo, WorkTime, a);

            //員工主檔資料
            sql += In_Ede_S(DocNo);

            //員工明細檔資料
            sql += In_Edf_S(DocNo, WorkTime, PsonTime, Qty);

            //報廢數
            sql += In_Shc_S(DocNo, dtOutProd);

            //員工工時記錄檔
            sql += In_EmpHead_S(DocNo);

            //員工工時記錄檔
            sql += In_EmpWork_S(DocNo);

            //龍門多寫下製成
            if (!string.IsNullOrEmpty(DocNoNext))
            {
                sql += In_Proc_SD(DocNoNext, DocNo, 0, 0);
            }

            if (sql.Length > 0)
            {
                var j = DOSQL.Excute(Login.WU, sql);
                if (j <= 0) MessageBox.Show("Fail-InProc");
            }

            //工作完成回報狀態
            backgroundWorker1.ReportProgress(1);
        }

        private string getDocNoNext(string DocNo)
        {
            //把單據號+1 當成下一站的單據號
            Int32 a = System.Convert.ToInt32(DocNo.Substring(7, 3));
            a = a + 1;
            string n1 = DocNo.Substring(0, 7);
            string n2 = a.ToString("000");
            string n0 = n1 + n2;
            return n0;
        }

        private bool getIsDragonDoor()
        {
            string a = string.IsNullOrEmpty(f_mach.Text.ToString()) ? " " : f_mach.SelectedValue.ToString();
            return (a.Contains("FW12"));
        }



        //private void Add_S()
        //{
        //    string DocNo = StationDoc.getDocNO(Login.DeptOne); //單據號
        //    int WorkTime = TimeSpan2(Begdate, Enddate); //機器總工時
        //    int PsonTime = getWorkTime();//合計總人工工時
        //    decimal Qty = getQty(); //產出總數 良品+不良+Bouns

        //    decimal a = getminWorkTime(dataGridView3, WorkTime);// 每筆幾分鐘(總工時/所有產出數；含不良+bonus+良品)

        //    string sql = string.Empty;
        //    //報工主檔資料
        //    sql += In_Proc_S(DocNo, WorkTime, a);

        //    //員工主檔資料
        //    sql += In_Ede_S(DocNo);

        //    //員工明細檔資料
        //    sql += In_Edf_S(DocNo, WorkTime, PsonTime, Qty);

        //    //報廢數
        //    sql += In_Shc_S(DocNo, dtOutProd);

        //    //員工工時記錄檔
        //    sql += In_EmpHead_S(DocNo);

        //    //員工工時記錄檔
        //    sql += In_EmpWork_S(DocNo);


        //    if (sql.Length > 0)
        //    {
        //        var j = DOSQL.Excute(Login.WU, sql);
        //        if (j <= 0) MessageBox.Show("Fail-InProc");
        //    }

        //    //工作完成回報狀態
        //    backgroundWorker1.ReportProgress(1);
        //}

        private void Add()
        {
            string DocNo = StationDoc.getDocNO(Login.DeptOne); //單據號
            int WorkTime = TimeSpan2(Begdate, Enddate); //總工時

            decimal a = getminWorkTime(dataGridView3, WorkTime);// 每筆幾分鐘(總工時/所有產出數；含不良+bonus+良品)

            //報工主檔資料
            In_Proc(DocNo, WorkTime, a);

            //員工主檔資料
            In_Ede(DocNo);

            //員工明細檔資料
            In_Edf(DocNo, WorkTime);

            //報廢數
            In_Shc(DocNo, dtOutProd);

            //員工工時記錄檔
            In_EmpHead(DocNo);

            //員工工時記錄檔
            In_EmpWork(DocNo);

            //工作完成回報狀態
            backgroundWorker1.ReportProgress(1);
        }

        private decimal getminWorkTime(DataGridView dv,int WorkTime)
        {
            decimal all_q = 0M;
            for (int i = 0; i < dv.Rows.Count; i++)
            {
                decimal Qty = getQty(dv.Rows[i].Cells["shb111"].Value.ToString(), dv.Rows[i].Cells["shb112"].Value.ToString(), dv.Rows[i].Cells["shb115"].Value.ToString());
                all_q += Qty;
            }
            return WorkTime / all_q;
        }

        private decimal getQty(string ra,string rb,string rc)
        {
            decimal rf = 0M;
            decimal a = getDeci(ra);
            decimal b = getDeci(rb);
            decimal c = getDeci(rc);
            rf = a + b + c;
            return rf;
        }


        private decimal getDeci(string rs)
        {
            decimal rf = 0M;
            rf = rs.Trim().Length == 0 ? 0 : System.Convert.ToDecimal(rs);
            return rf;
        }

        private string In_Proc_S(string Doc,int WorkTime, decimal a)
        {            
            string BegTime = Begdate.Substring(11,5);
            string EndTime = Enddate.Substring(11,5);
            string sql = string.Empty;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                //每筆工單合計產出數(量+不良+Bonus)
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                decimal EachWkTime = Qty * a;
                Inproc rc = new Inproc();
                rc.Doc = Doc;
                rc.SourceDoc = Doc;
                rc.Shb02 = Workday;
                rc.Shb021 = BegTime;
                rc.Shb03 = Workday;
                rc.Shb031 = EndTime;
                rc.Shb032 = Math.Round(EachWkTime, 2);//每筆工單所需耗費時間(分攤工時時間)
                rc.Shb033 = Math.Round(EachWkTime, 2);//每筆工單所需耗費時間(分攤工時時間)
                rc.Shb04 = Login.ID;
                rc.Shb05 = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();               //工號
                rc.Shb06 = System.Convert.ToInt16(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());//工序
                rc.Shb07 = Station; //工作站
                rc.Shb08 = aClassno;  //班别代碼
                rc.Shb081 = dataGridView3.Rows[i].Cells[5].Value.ToString();//作業編號
                rc.Shb082 = dataGridView3.Rows[i].Cells[6].Value.ToString();//作業名稱
                rc.Shb09 = aMachno;//機台代碼                
                rc.Shb10 = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();//料號
                rc.Shb111 = getDeci(dataGridView3.Rows[i].Cells["shb111"].Value.ToString());//良品
                rc.Shb112 = getDeci(dataGridView3.Rows[i].Cells["shb112"].Value.ToString());//不良
                rc.Shb115 = getDeci(dataGridView3.Rows[i].Cells["shb115"].Value.ToString());//bonus
                rc.Shbgrup = Login.IDCdept;
                rc.Shblegal = ePlant;
                rc.Shbmodu = Login.ID;
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
                sql += Inproc.Set_Insert(rc);
            }
            return sql;
        }

        private void In_Proc(string Doc, int WorkTime, decimal a)
        {
            string BegTime = Begdate.Substring(11, 5);
            string EndTime = Enddate.Substring(11, 5);
            string sql = string.Empty;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                //每筆工單合計產出數(量+不良+Bonus)
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                decimal EachWkTime = Qty * a;
                Inproc rc = new Inproc();
                rc.Doc = Doc;
                rc.Shb02 = Workday;
                rc.Shb021 = BegTime;
                rc.Shb03 = Workday;
                rc.Shb031 = EndTime;
                rc.Shb032 = Math.Round(EachWkTime, 2);//每筆工單所需耗費時間(分攤工時時間)
                rc.Shb033 = Math.Round(EachWkTime, 2);//每筆工單所需耗費時間(分攤工時時間)
                rc.Shb04 = Login.ID;
                rc.Shb05 = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();               //工號
                rc.Shb06 = System.Convert.ToInt16(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());//工序
                rc.Shb07 = Station; //工作站
                rc.Shb08 = aClassno;  //班别代碼
                rc.Shb081 = dataGridView3.Rows[i].Cells[5].Value.ToString();//作業編號
                rc.Shb082 = dataGridView3.Rows[i].Cells[6].Value.ToString();//作業名稱
                rc.Shb09 = aMachno;//機台代碼                
                rc.Shb10 = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();//料號
                rc.Shb111 = getDeci(dataGridView3.Rows[i].Cells["shb111"].Value.ToString());//良品
                rc.Shb112 = getDeci(dataGridView3.Rows[i].Cells["shb112"].Value.ToString());//不良
                rc.Shb115 = getDeci(dataGridView3.Rows[i].Cells["shb115"].Value.ToString());//bonus
                rc.Shbgrup = Login.IDCdept;
                rc.Shblegal = ePlant;
                rc.Shbmodu = Login.ID;
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
                sql += Inproc.Set_Insert(rc);
            }
            var j = DOSQL.Excute(Login.WU, sql);
            if (j <= 0) MessageBox.Show("Fail-InProc");
        }


        private string In_Ede_S(string Doc)
        {
            string sql = string.Empty;            
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
            return sql;
        }

        private void In_Ede(string Doc)
        {
            string sql = string.Empty;
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

        private string In_Edf_S(string Doc, decimal Machtime,int WorkTime)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Empid = dataGridView1.Rows[i].Cells[0].Value.ToString();//員工
                string bDay = DateTime.Now.ToString("yyyy/MM/dd");
                string bHH = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                string bMM = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
                string eHH = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                string eMM = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                string Begdate = bDay + " " + bHH + ":" + bMM;
                string Enddate = bDay + " " + eHH + ":" + eMM;                             
                sql += In_Edf_F(Doc, Machtime, Empid, WorkTime, Begdate, Enddate);
            }
            return sql;
        }

        private string In_Edf_S(string Doc, decimal Machtime, int WorkTime,decimal Qty)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Empid = dataGridView1.Rows[i].Cells[0].Value.ToString();//員工
                string Empname = dataGridView1.Rows[i].Cells[1].Value.ToString();//員工姓名
                string bDay = DateTime.Now.ToString("yyyy/MM/dd");
                string bHH = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                string bMM = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
                string eHH = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                string eMM = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                string Begdate = bDay + " " + bHH + ":" + bMM;
                string Enddate = bDay + " " + eHH + ":" + eMM;
                sql += In_Edf_F(Doc, Machtime, Empid, WorkTime, Begdate, Enddate, Qty, Empname);
            }
            return sql;
        }

        private string In_Proc_SD(string Doc, string SourceDoc, int WorkTime, decimal a)
        {
            string BegTime = Begdate.Substring(11, 5);
            string EndTime = Enddate.Substring(11, 5);
            string sql = string.Empty;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string WkNo = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();    //工號
                Int16 WkSeq = System.Convert.ToInt16(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());    //工序
                DataTable dt = StationDoc.getNextStation(WkNo, WkSeq); 
                //每筆工單合計產出數(量+不良+Bonus)
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                decimal EachWkTime = Qty * a;
                Inproc rc = new Inproc();
                rc.Doc = Doc;
                rc.SourceDoc = SourceDoc;
                rc.Shb02 = Workday;
                rc.Shb021 = BegTime;
                rc.Shb03 = Workday;
                rc.Shb031 = EndTime;
                rc.Shb032 = Math.Round(EachWkTime, 2);//每筆工單所需耗費時間(分攤工時時間)
                rc.Shb033 = Math.Round(EachWkTime, 2);//每筆工單所需耗費時間(分攤工時時間)
                rc.Shb04 = dt.Rows[0]["ecm06"].ToString(); //   Login.ID;
                rc.Shb05 = WkNo;    //工號
                rc.Shb06 = System.Convert.ToInt16(dt.Rows[0]["ecm03"].ToString());   //工序
                rc.Shb07 = dt.Rows[0]["ecm06"].ToString(); //工作站
                rc.Shb08 = aClassno;  //班别代碼
                rc.Shb081 = dt.Rows[0]["ecm04"].ToString();//作業編號
                rc.Shb082 = dt.Rows[0]["ecm45"].ToString();//作業名稱
                rc.Shb09 = StationDoc.getNextMach(dt.Rows[0]["ecm06"].ToString());  //機台代碼                
                rc.Shb10 = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();   //料號                
                //
                rc.Shb111 = getDeci(dataGridView3.Rows[i].Cells["shb111"].Value.ToString());//良品
                rc.Shb112 = 0;//不良
                rc.Shb115 = getDeci(dataGridView3.Rows[i].Cells["shb115"].Value.ToString());//bonus
                //                
                rc.Shbgrup = StationDoc.getNextCdept(dt.Rows[0]["ecm06"].ToString());
                rc.Shblegal = ePlant;
                rc.Shbmodu = dt.Rows[0]["ecm06"].ToString();
                rc.Shborig = StationDoc.getNextCdept(dt.Rows[0]["ecm06"].ToString());
                rc.Shboriu = dt.Rows[0]["ecm06"].ToString();
                rc.Shbplant = ePlant;
                rc.Shbuser = dt.Rows[0]["ecm06"].ToString();
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
                sql += Inproc.Set_Insert(rc);
            }
            return sql;
        }

        


        private int getWorkTime()
        {
            //合計人工總工時
            int WorkTime = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string bDay = DateTime.Now.ToString("yyyy/MM/dd");
                string bHH = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                string bMM = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
                string eHH = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                string eMM = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                string Begdate = bDay + " " + bHH + ":" + bMM;
                string Enddate = bDay + " " + eHH + ":" + eMM;
                int perWorkTime = TimeSpan2(Begdate, Enddate); //個人總工時
                WorkTime = WorkTime + perWorkTime;
            }
            return WorkTime;
        }


        private void In_Edf(string Doc, decimal Machtime)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Empid = dataGridView1.Rows[i].Cells[0].Value.ToString();//員工
                string bDay = DateTime.Now.ToString("yyyy/MM/dd");
                string bHH = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                string bMM = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
                string eHH = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                string eMM = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                string Begdate = bDay + " " + bHH + ":" + bMM;
                string Enddate = bDay + " " + eHH + ":" + eMM;               
                int WorkTime = TimeSpan2(Begdate, Enddate); //個人總工時
                sql += In_Edf_F(Doc, Machtime, Empid, WorkTime, Begdate, Enddate);
            }
            if (sql.Length > 0)
            {
                var j = DOSQL.Excute(Login.WU, sql);
                if (j <= 0) MessageBox.Show("Fail-InEdf");
            }
        }

        //private string In_Edf_X(string Doc, decimal Machtime, string Empid, int WorkTime, string Begdate, string Enddate)
        //{
        //    string sql = string.Empty;
        //    for (int i = 0; i < dataGridView3.Rows.Count; i++)
        //    {
        //        string Wkno = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();//工單
        //        string Imno = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();//料號
        //        string Workno = dataGridView3.Rows[i].Cells["shb08"].Value.ToString();//作業編號
        //        decimal Wkseq = System.Convert.ToDecimal(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());//製程序
        //        //報工數量(良品+不良+Bonus)
        //        decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
        //        decimal EachWork = Math.Round((WorkTime / Qty), 3);
        //        decimal EachMach = Math.Round((Machtime / Qty), 3);
        //        string bDate = Begdate.Substring(0, 10);
        //        string bTime = Begdate.Substring(Begdate.Length - 5, 5);
        //        string eDate = Enddate.Substring(0, 10);
        //        string eTime = Enddate.Substring(Enddate.Length - 5, 5);
        //        InEdf rc = new InEdf();
        //        rc.Doc = Doc;
        //        rc.Edf03 = Wkno;    //工單編號
        //        rc.Edf04 = Imno;    //料號
        //        rc.Edf06 = Workno;  //作業編號
        //        rc.Edf07 = Wkseq;   //製程序
        //        rc.Edf08 = Qty;     //報工數量
        //        rc.Edf09 = Empid;   //員工
        //        rc.Edf11 = EachWork;//實際單件工時
        //        rc.Edf12 = WorkTime;//工時合計
        //        rc.Edf14 = EachMach;//實際單件機時
        //        rc.Edf15 = Machtime;//機時合計
        //        rc.Edflegal = ePlant;
        //        rc.Edfplant = ePlant;
        //        rc.Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
        //        rc.Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
        //        rc.Bdate = bDate;
        //        rc.Btime = bTime;
        //        rc.Edate = eDate;
        //        rc.Etime = eTime;
        //        rc.Status = "0";
        //        sql += InEdf.Set_Insert(rc);
        //    }
        //    return sql;
        //}

        private string In_Edf_F(string Doc, decimal Machtime, string Empid, int WorkTime, string Begdate, string Enddate)
        {
            string sql = string.Empty;

            //找總產出數
            decimal rQty = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                rQty = rQty + Qty;
            }
            //單件機時
            decimal EachMach = Math.Round((Machtime / rQty), 3);
            //單件工時
            decimal EachWork = Math.Round((WorkTime / rQty), 3);

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string Wkno = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();//工單
                string Imno = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();//料號
                string Workno = dataGridView3.Rows[i].Cells["shb08"].Value.ToString();//作業編號
                decimal Wkseq = System.Convert.ToDecimal(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());//製程序
                //報工數量(良品+不良+Bonus)
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                
                string bDate = Begdate.Substring(0, 10);
                string bTime = Begdate.Substring(Begdate.Length - 5, 5);
                string eDate = Enddate.Substring(0, 10);
                string eTime = Enddate.Substring(Enddate.Length - 5, 5);
                InEdf rc = new InEdf();
                rc.Doc = Doc;
                rc.Edf03 = Wkno;    //工單編號
                rc.Edf04 = Imno;    //料號
                rc.Edf06 = Workno;  //作業編號
                rc.Edf07 = Wkseq;   //製程序
                rc.Edf08 = Qty;     //報工數量
                rc.Edf09 = Empid;   //員工
                rc.Edf11 = EachWork;//實際單件工時
                rc.Edf12 = WorkTime;//工時合計
                rc.Edf14 = EachMach;//實際單件機時
                rc.Edf15 = Machtime;//機時合計
                rc.Edflegal = ePlant;
                rc.Edfplant = ePlant;
                rc.Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                rc.Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                rc.Bdate = bDate;
                rc.Btime = bTime;
                rc.Edate = eDate;
                rc.Etime = eTime;
                rc.Status = "0";
                sql += InEdf.Set_Insert(rc);
            }
            return sql;
        }

        private string In_Edf_F(string Doc, decimal Machtime, string Empid, int WorkTime, string Begdate, string Enddate,decimal rQty,string Empname)
        {
            string sql = string.Empty;
            //單件機時
            decimal EachMach = Math.Round((Machtime / rQty), 3);
            //單件工時
            decimal EachWork = Math.Round((WorkTime / rQty), 3);
            //開始 結束時間
            string bDate = Begdate.Substring(0, 10);
            string bTime = Begdate.Substring(Begdate.Length - 5, 5);
            string eDate = Enddate.Substring(0, 10);
            string eTime = Enddate.Substring(Enddate.Length - 5, 5);
            int perWorkTime = TimeSpan2(Begdate, Enddate); //個人總工時
            //-------------

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string Wkno = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();//工單
                string Imno = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();//料號
                string Workno = dataGridView3.Rows[i].Cells["shb08"].Value.ToString();//作業編號
                decimal Wkseq = System.Convert.ToDecimal(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());//製程序
                //報工數量(良品+不良+Bonus)
                decimal Qty = getQty(dataGridView3.Rows[i].Cells["shb111"].Value.ToString(), dataGridView3.Rows[i].Cells["shb112"].Value.ToString(), dataGridView3.Rows[i].Cells["shb115"].Value.ToString());
                                
                InEdf rc = new InEdf();
                rc.Doc = Doc;
                rc.Edf03 = Wkno;    //工單編號
                rc.Edf04 = Imno;    //料號
                rc.Edf06 = Workno;  //作業編號
                rc.Edf07 = Wkseq;   //製程序
                rc.Edf08 = Qty;     //報工數量
                rc.Edf09 = Empid;   //員工
                rc.Edf11 = EachWork;//實際單件工時                
                rc.Edf12 = perWorkTime;//個人總工時
                rc.Edf14 = EachMach;//實際單件機時
                rc.Edf15 = Machtime;//機時合計
                rc.Edflegal = ePlant;
                rc.Edfplant = ePlant;
                rc.Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                rc.Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                rc.Bdate = bDate;
                rc.Btime = bTime;
                rc.Edate = eDate;
                rc.Etime = eTime;
                rc.Empname = Empname;
                rc.Status = "0";
                sql += InEdf.Set_Insert(rc);
            }
            return sql;
        }

        private string In_Shc_S(string Doc, DataTable dt)
        {
            string sql = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Inshc rc = new Inshc();
                rc.Doc = Doc;
                rc.Wkno = dt.Rows[i]["wkno"].ToString();
                rc.Shc03 = System.Convert.ToDecimal(dt.Rows[i]["shc03"].ToString());
                rc.Shc04 = dt.Rows[i]["shc04"].ToString();
                rc.Shc05 = System.Convert.ToDecimal(dt.Rows[i]["shc05"].ToString());
                rc.Shc06 = dt.Rows[i]["shc06"].ToString();
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
            return sql;
        }

        private void In_Shc(string Doc,DataTable dt)
        {
            string sql = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Inshc rc = new Inshc();
                rc.Doc = Doc;
                rc.Wkno = dt.Rows[i]["wkno"].ToString();
                rc.Shc03 = System.Convert.ToDecimal(dt.Rows[i]["shc03"].ToString());
                rc.Shc04 = dt.Rows[i]["shc04"].ToString();
                rc.Shc05 = System.Convert.ToDecimal(dt.Rows[i]["shc05"].ToString());
                rc.Shc06 = dt.Rows[i]["shc06"].ToString();
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

        private string In_EmpHead_S(string Doc)
        {
            string sql = string.Empty;
            string Stid = Station;
            string Stname = StationName;
            string Rdt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
            string Bdate = Begdate.Substring(0, 10);
            string Bhh = Begdate.Substring(11, 2); //f_mfd_bhh.Text;
            string Bmm = Begdate.Substring(14, 2); //f_mfd_bmm.Text;
            string Edate = Enddate.Substring(0, 10);
            string Ehh = Enddate.Substring(11, 2); //f_mfd_ehh.Text;
            string Emm = Enddate.Substring(14, 2); // f_mfd_emm.Text;
            string aClass = aClassno;
            string aClassName = aClassname;
            string Machno = aMachno;//機台代碼
            int MachTime = TimeSpan2(Begdate, Enddate); //機器時間
            //-----------
            Emphead rc = new Emphead();
            rc.Doc = Doc;
            rc.Stid = Stid;
            rc.Stname = Stname;
            rc.Rdt = Rdt;
            rc.Bdate = Bdate;
            rc.Bhh = Bhh;
            rc.Bmm = Bmm;
            rc.Edate = Edate;
            rc.Ehh = Ehh;
            rc.Emm = Emm;
            rc.Class = aClass;
            rc.Classname = aClassName;
            rc.Machno = Machno;
            rc.Machtime = MachTime;
            sql += Emphead.Set_Insert(rc);
            return sql;
        }

        private void In_EmpHead(string Doc)
        {
            string sql = string.Empty;
            string Stid = Station;
            string Stname = StationName;
            string Rdt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
            string Bdate = Begdate.Substring(0, 10);
            string Bhh = Begdate.Substring(11, 2); //f_mfd_bhh.Text;
            string Bmm = Begdate.Substring(14, 2); //f_mfd_bmm.Text;
            string Edate = Enddate.Substring(0, 10);
            string Ehh = Enddate.Substring(11, 2); //f_mfd_ehh.Text;
            string Emm = Enddate.Substring(14, 2); // f_mfd_emm.Text;
            string aClass = aClassno;
            string aClassName = aClassname;            
            string Machno = aMachno;//機台代碼
            int MachTime = TimeSpan2(Begdate, Enddate); //機器時間
            //-----------
            Emphead rc = new Emphead();
            rc.Doc = Doc;
            rc.Stid = Stid;
            rc.Stname = Stname;            
            rc.Rdt = Rdt;
            rc.Bdate = Bdate;
            rc.Bhh = Bhh;
            rc.Bmm = Bmm;
            rc.Edate = Edate;
            rc.Ehh = Ehh;
            rc.Emm = Emm;
            rc.Class = aClass;
            rc.Classname = aClassName;
            rc.Machno = Machno;            
            rc.Machtime = MachTime;
            sql += Emphead.Set_Insert(rc);
            if (sql.Length > 0)
            {
                var j = DOSQL.Excute(Login.WU, sql);
                if (j <= 0) MessageBox.Show("Fail-Emphead");
            }
        }

        private string In_EmpWork_S(string Doc)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Stid = Station;
                string Stname = StationName; //f_station_name.Text;
                string Empid = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();
                string Empname = dataGridView1.Rows[i].Cells["employeename"].Value.ToString();
                string Rdt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                string Bdate = Workday;
                string Bhh = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                string Bmm = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
                string Edate = Workday;
                string Ehh = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                string Emm = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                //個人總工時
                string Begdate = Bdate + " " + Bhh + ":" + Bmm;
                string Enddate = Edate + " " + Ehh + ":" + Emm;
                int WorkTime = TimeSpan2(Begdate, Enddate);
                //-----------

                Emptime rc = new Emptime();
                rc.Doc = Doc;
                rc.Stid = Stid;
                rc.Stname = Stname;
                rc.Empid = Empid;
                rc.Empname = Empname;
                rc.Rdt = Rdt;
                rc.Bdate = Bdate;
                rc.Bhh = Bhh;
                rc.Bmm = Bmm;
                rc.Edate = Edate;
                rc.Ehh = Ehh;
                rc.Emm = Emm;
                rc.Worktime = WorkTime;
                sql += Emptime.Set_Insert(rc);
            }
            return sql;
        }

        private void In_EmpWork(string Doc)
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Stid = Station;
                string Stname = StationName; //f_station_name.Text;
                string Empid = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();
                string Empname = dataGridView1.Rows[i].Cells["employeename"].Value.ToString();
                string Rdt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:dd.fff");
                string Bdate = Workday;
                string Bhh = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                string Bmm = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
                string Edate = Workday;
                string Ehh = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                string Emm = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                //個人總工時
                string Begdate = Bdate + " " + Bhh + ":" + Bmm;
                string Enddate = Edate + " " + Ehh + ":" + Emm;
                int WorkTime = TimeSpan2(Begdate, Enddate);
                //-----------

                Emptime rc = new Emptime();
                rc.Doc = Doc;
                rc.Stid = Stid;
                rc.Stname = Stname;
                rc.Empid = Empid;
                rc.Empname = Empname;
                rc.Rdt = Rdt;
                rc.Bdate = Bdate;
                rc.Bhh = Bhh;
                rc.Bmm = Bmm;
                rc.Edate = Edate;
                rc.Ehh = Ehh;
                rc.Emm = Emm;
                rc.Worktime = WorkTime;
                sql += Emptime.Set_Insert(rc);
            }
            if (sql.Length > 0)
            {
                var j = DOSQL.Excute(Login.WU, sql);
                if (j <= 0) MessageBox.Show("Fail-Emptime");
            }
        }

        


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
            dtOutProd.Clear();
            dtFewProd.Clear();
            this.tabControl1.SelectedIndex = 0;
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count == 0)
            {
                Config.Show("沒有工單明細資料");
                this.tabControl1.SelectedIndex = 0;
                return;
            }
            if (TimeEnter(f_mfd_bhh.Text, f_mfd_bmm.Text, f_mfd_ehh.Text, f_mfd_emm.Text) == false)
            {
                Config.Show("請輸入機器工時");
                return;
            }
            rEmployee fm = new rEmployee();
            fm.Dept = Login.DEPT;
            fm.Schdate = f_mfd.Text;
            if (fm.ShowDialog() == DialogResult.OK)
            {                
                //接收回傳資料(員工)
                DataTable dt = fm.dtProd;
                FindEmployee(dt);
            }
        }

        //private void FindEmployee(DataTable dt)
        //{
        //    string bHH = f_mfd_bhh.Text;
        //    string bMM = f_mfd_bmm.Text;
        //    string eHH = f_mfd_ehh.Text;
        //    string eMM = f_mfd_emm.Text;
        //    dataGridView1.Rows.Clear();
        //    int idx = 0;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dataGridView1.Rows.Add(new object[] {dt.Rows[i]["employeeid"],
        //            dt.Rows[i]["employeename"],
        //            bHH,bMM,
        //            eHH,eMM
        //            });
        //        idx += 1;
        //    }

        //    if (idx > 0)
        //    {
        //        dataGridView1.Rows[0].Selected = true; //第一列反藍選取                                
        //    }
        //}

        private void FindEmployee(DataTable dt)
        {
            string bHH = f_mfd_bhh.Text;
            string bMM = f_mfd_bmm.Text;
            string eHH = f_mfd_ehh.Text;
            string eMM = f_mfd_emm.Text;
            //dataGridView1.Rows.Clear();
            int idx = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string empid = dt.Rows[i]["employeeid"].ToString();
                if (havaempid(empid) == true) //以有資料不再寫入
                {
                    continue;
                }
                else
                {
                    
                    dataGridView1.Rows.Add(new object[] {dt.Rows[i]["employeeid"],
                    dt.Rows[i]["employeename"],
                    bHH,bMM,
                    eHH,eMM
                    });
                    idx += 1;
                }
            }

            if (idx > 0)
            {
                dataGridView1.Rows[0].Selected = true; //第一列反藍選取                                
            }
        }

        private bool havaempid(string empid)
        {
            bool rf = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string b = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (empid == b)
                {
                    rf = true;
                    return rf;
                }
            }
            return rf;
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
            //畫面沒有清空不選設定
            if (isNoData(f_wkno.Text) == true) return;
            if (dataGridView1.Rows.Count > 0) return;
            if (dataGridView3.Rows.Count > 0) return;
            //--------------------
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
                ClsINI Setupini = new ClsINI(Application.StartupPath + "\\ini\\Setup.ini");                
                string rID = Setupini.IniReadValue("LOCAL", "ID"); //login name
                var p_account = new Account();
                p_account = Account.Get(rID);
                Login.ID = p_account.Id;
                Login.IDNAME = p_account.Name;

                Init_DataTable();
                prc001_Load(this, null);
            }
        }


        private void toLog(string logMsg)
        {
            LogRecord.WriteLog(logMsg);
        }

        //不良數按鍵動作
        private void btn_outqty_Click(object sender, EventArgs e)
        {
            if (isNoData(f_wkno.Text) == false) return;
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
                f_qty_b.Text = fm.sumSch05.ToString();//前畫面傳過來的報廢數
                dataGridView2.Columns[0].Width = 30;
                dataGridView2.Columns[1].Width = 80;
                dataGridView2.Columns[2].Width = 170;
                dataGridView2.Columns[3].Width = 40;
                dataGridView2.Columns[4].Width = 40;
                dataGridView2.Columns[5].Width = 100;               
                rm_dtOutProd(); //刪報廢數明細
                In_dtOutProd(dt); //存報廢數明細                
            }
        }
                

        private void rm_dtOutProd()
        {
            string exp = "wkno='" + f_wkno.Text + "'";
            DataRow[] rows = dtOutProd.Select(exp);

            for (int i = 0; i < rows.Length; i++)
            {
                dtOutProd.Rows.Remove(rows[i]);
            }
        }

        private void In_dtOutProd(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtOutProd.NewRow();                
                dr["wkno"] = f_wkno.Text;
                dr["shc03"] = dt.Rows[i]["shc03"].ToString();
                dr["shc04"] = dt.Rows[i]["shc04"].ToString();
                dr["shc04name"] = dt.Rows[i]["shc04name"].ToString();
                dr["shc05"] = dt.Rows[i]["shc05"].ToString();
                dr["shc06"] = dt.Rows[i]["shc06"].ToString();
                dr["shc06no"] = dt.Rows[i]["shc06no"].ToString();
                dtOutProd.Rows.Add(dr);
            }
        }


        //private void btn_upd_Click(object sender, EventArgs e)
        //{
        //    rowAdd();
        //    clsRecord();//清畫面欄位
        //}

        private void btn_upd_Click(object sender, EventArgs e)
        {
            if (f_RecordCK() == false)
            {
                MessageBox.Show("欄位不可空白");
                return;
            }
            if (dataGridView3.Rows.Count > 0)
            {
                //檢查工單+製程序編號
                if (Ecm03Doub() == true)
                {
                    rowUpd();
                }
                else
                {
                    rowAdd();
                }
            }
            else
            {
                rowAdd();
            }
            clsRecord();//清畫面欄位
        }

        private bool f_RecordCK()
        {
            bool rf = false;
            if (f_wkno.Text.ToString().Trim().Length == 0 ||
                QtyEnter(f_qty_g.Text, f_qty_b.Text, f_qty_bns.Text) ==false)
            {
                rf = false;
            }
            else
            {
                rf = true;
            }
            return rf;
        }


        //private bool f_RecordCK()
        //{
        //    bool rf = false;
        //    if (f_wkno.Text.ToString().Trim().Length == 0 ||
        //        f_qty_g.Text.ToString().Trim().Length == 0 )
        //    {
        //        rf = false;
        //    }
        //    else
        //    {
        //        rf = true;
        //    }
        //    return rf;
        //}

        private bool Ecm03Doub()
        {
            bool rf = false;
            string awkno = f_wkno.Text; //工單
            Int32 awkseq = System.Convert.ToInt32(f_wkseq.Text); //工序
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                string bwkno = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();
                Int32 bwkseq = System.Convert.ToInt32(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());
                if (awkno == bwkno && awkseq== bwkseq)
                {
                    rf = true;
                    break;
                }
            }
            return rf;
        }

        private void rowAdd()
        {
            //要檢查
            dataGridView3.Rows.Add(new object[] {f_wkno.Text ,
                f_wkseq.Text,
                f_qty_g.Text,
                f_qty_b.Text,
                f_qty_bns.Text,
                f_workno.Text,
                f_workname.Text,
                f_imno.Text,
                f_wkqty.Text,
                f_imdesc.Text,
                f_imsize.Text});
            GvSort();//排序
        }

        private void rowUpd()
        {
            string awkno = f_wkno.Text; //工單
            Int32 awkseq = System.Convert.ToInt32(f_wkseq.Text); //工序
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string bwkno = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();
                Int32 bwkseq = System.Convert.ToInt32(dataGridView3.Rows[i].Cells["shb06"].Value.ToString());
                if (awkno == bwkno && awkseq == bwkseq)//工單跟工序相同
                {
                    dataGridView3.Rows[i].Cells["shb111"].Value = f_qty_g.Text;
                    dataGridView3.Rows[i].Cells["shb112"].Value = f_qty_b.Text;
                    dataGridView3.Rows[i].Cells["shb115"].Value = f_qty_bns.Text;
                }
            }
        }

        private void GvSort()
        {
            // 根據 資料行1 (Name) 做 小到大 排序 
            dataGridView3.Sort(dataGridView3.Columns["shb05"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView3.Rows[e.RowIndex].Selected = true;
            
            GetHead();//顯示單頭資料

            Get_qty_g();

            In_FewOut();//個別不良
        }

        //依工單抓出已經輸入報廢資料存起來
        private void In_FewOut()
        {
            string exp = "wkno='" + f_wkno.Text + "'";
            dtFewProd.Clear();
            DataRow[] rows = dtOutProd.Select(exp);            
            for (int i = 0; i < rows.Length; i++)
            {                
                DataRow dr = dtFewProd.NewRow();                
                dr["shc03"] = rows[i]["shc03"].ToString();
                dr["shc04"] = rows[i]["shc04"].ToString();
                dr["shc04name"] = rows[i]["shc04name"].ToString();
                dr["shc05"] = rows[i]["shc05"].ToString();
                dr["shc06"] = rows[i]["shc06"].ToString();
                dr["shc06no"] = rows[i]["shc06no"].ToString();
                dtFewProd.Rows.Add(dr);
            }

        }

        //private void In_dtOutProd(DataTable dt)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow dr = dtOutProd.NewRow();
        //        dr["wkno"] = f_wkno.Text;
        //        dr["shc03"] = dt.Rows[i]["shc03"].ToString();
        //        dr["shc04"] = dt.Rows[i]["shc04"].ToString();
        //        dr["shc04name"] = dt.Rows[i]["shc04name"].ToString();
        //        dr["shc05"] = dt.Rows[i]["shc05"].ToString();
        //        dr["shc06"] = dt.Rows[i]["shc06"].ToString();
        //        dr["shc06no"] = dt.Rows[i]["shc06no"].ToString();
        //        dtOutProd.Rows.Add(dr);
        //    }
        //}


        private void GetHead()
        {
            //匯入相關資料
            ShowHead();
        }
        private void ShowHead()
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Selected == true)
                {
                    f_wkno.Text = dataGridView3.Rows[i].Cells["shb05"].Value.ToString();
                    f_wkseq.Text = dataGridView3.Rows[i].Cells["shb06"].Value.ToString();
                    f_qty_g.Text = dataGridView3.Rows[i].Cells["shb111"].Value.ToString();
                    f_qty_b.Text = dataGridView3.Rows[i].Cells["shb112"].Value.ToString();
                    f_qty_bns.Text = dataGridView3.Rows[i].Cells["shb115"].Value.ToString();

                    f_workno.Text = dataGridView3.Rows[i].Cells["shb08"].Value.ToString();
                    f_workname.Text = dataGridView3.Rows[i].Cells["shb081"].Value.ToString();
                    f_imno.Text = dataGridView3.Rows[i].Cells["shb10"].Value.ToString();

                    f_wkqty.Text = dataGridView3.Rows[i].Cells["r_qty"].Value.ToString();
                    f_imdesc.Text = dataGridView3.Rows[i].Cells["r_desc"].Value.ToString();
                    f_imsize.Text = dataGridView3.Rows[i].Cells["r_size"].Value.ToString();

                }
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            //刪除DataGrivew3的資料列
            rm_RowDel();
        }

        //private void btn_Del_Click(object sender, EventArgs e)
        //{
        //    if (f_wkno.Text.Length == 0) return;
        //    if (Config.Message("確定刪除?") == "Y")
        //    {
        //        foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
        //        {
        //            dataGridView3.Rows.RemoveAt(item.Index);
        //        }
        //        if (dataGridView3.Rows.Count == 0) clsRecord();
        //    }
        //}

        private void button6_Click(object sender, EventArgs e)
        {
            //刪除單筆工單資料 DataGrivew3的資料列
            rm_RowDel();            
        }

        private void rm_RowDel()
        {
            if (f_wkno.Text.Length == 0) return;
            if (Config.Message("確定刪除?") == "Y")
            {
                foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
                {
                    dataGridView3.Rows.RemoveAt(item.Index);
                }
                //
                rm_dtOutProd();//刪除不良數
                //---------
                if (dataGridView3.Rows.Count == 0)
                {
                    button5_Click(null, null); //觸發取消按鈕
                }
                else
                {
                    dataGridView3.Rows[0].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3.Rows[0].Cells[0];                    
                    clsRecord();//清畫面欄位
                }
            }
        }



        //private void rm_RowDel()
        //{
        //    if (f_wkno.Text.Length == 0) return;
        //    if (Config.Message("確定刪除?") == "Y")
        //    {
        //        foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
        //        {
        //            dataGridView3.Rows.RemoveAt(item.Index);
        //        }
        //        if (dataGridView3.Rows.Count == 0)
        //        {
        //            clsRecord();
        //            //刪除存在暫存的不良數
        //            dtOutProd.Clear();
        //            f_mfd_bhh.SelectedIndex = 0;
        //            f_mfd_bmm.SelectedIndex = 0;
        //            f_mfd_ehh.SelectedIndex = 0;
        //            f_mfd_emm.SelectedIndex = 0;
        //        }                
        //    }
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;

            GetEmployeeHead();//顯示單頭資料
        }

        private void GetEmployeeHead()
        {            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    f_employeeid.Text = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();
                    f_employeename.Text = dataGridView1.Rows[i].Cells["employeename"].Value.ToString();
                    string bHH = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
                    string bMM = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();                    
                    string eHH = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
                    string eMM = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
                    f_d_bHH.SelectedIndex = f_d_bHH.Items.IndexOf(bHH);
                    f_d_bMM.SelectedIndex = f_d_bMM.Items.IndexOf(bMM);
                    f_d_eHH.SelectedIndex = f_d_eHH.Items.IndexOf(eHH);
                    f_d_eMM.SelectedIndex = f_d_eMM.Items.IndexOf(eMM);
                }
            }
        }


        //private void GetEmployeeHead()
        //{
        //    ////內定值
        //    //f_ptno.SelectedIndex = f_ptno.Items.IndexOf(stPtno);
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Selected == true)
        //        {
        //            f_employeeid.Text = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();
        //            f_employeename.Text = dataGridView1.Rows[i].Cells["employeename"].Value.ToString();
        //            f_bHH.Text = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
        //            f_bMM.Text = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
        //            f_eHH.Text = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
        //            f_eMM.Text = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
        //        }
        //    }
        //}



        private void btn_emp_Upd_Click(object sender, EventArgs e)
        {
            if (f_EmpRecordCK() == false) return;
            if (dataGridView1.Rows.Count > 0)
            {
                //檢查工號
                if (EmpDoub() == true)
                {                    
                    rowEmpUpd();
                }                
            }            
            clsEmpRecord();//清欄位
        }


        private bool f_EmpRecordCK()
        {            
            if (f_employeeid.Text.ToString().Trim().Length == 0 )
            {
                Config.Show("欄位不可空白");
                return false;
            }
            if (TimeEnter(f_d_bHH.Text, f_d_bMM.Text, f_d_eHH.Text, f_d_eMM.Text) == false)
            {
                Config.Show("請選擇時間");
                f_d_bHH.Focus();
                return false;
            }            
            return true;
        }

        //private bool f_EmpRecordCK()
        //{
        //    bool rf = false;
        //    if (f_employeeid.Text.ToString().Trim().Length == 0 ||
        //        f_bHH.Text.ToString().Trim().Length == 0||
        //        f_bMM.Text.ToString().Trim().Length == 0||
        //        f_eHH.Text.ToString().Trim().Length == 0||
        //        f_eMM.Text.ToString().Trim().Length == 0)
        //    {
        //        rf = false;
        //    }
        //    else
        //    {
        //        rf = true;
        //    }
        //    return rf;
        //}

        private bool EmpDoub()
        {
            bool rf = false;
            string aid = f_employeeid.Text; //工號            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string bid = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();                
                if (aid == bid)
                {
                    rf = true;
                    break;
                }
            }
            return rf;
        }

        private void rowEmpUpd()
        {
            string aid = f_employeeid.Text; //工號            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string bid = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();
                if (aid == bid) //工號相同
                {
                    dataGridView1.Rows[i].Cells["bHH"].Value = f_d_bHH.Text;
                    dataGridView1.Rows[i].Cells["bMM"].Value = f_d_bMM.Text;
                    dataGridView1.Rows[i].Cells["eHH"].Value = f_d_eHH.Text;
                    dataGridView1.Rows[i].Cells["eMM"].Value = f_d_eMM.Text;
                }
            }
        }


        //private void rowEmpUpd()
        //{
        //    string aid = f_employeeid.Text; //工號            
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        string bid = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();                
        //        if (aid == bid) //工號相同
        //        {
        //            dataGridView1.Rows[i].Cells["bHH"].Value = f_bHH.Text;
        //            dataGridView1.Rows[i].Cells["bMM"].Value = f_bMM.Text;
        //            dataGridView1.Rows[i].Cells["eHH"].Value = f_eHH.Text;
        //            dataGridView1.Rows[i].Cells["eMM"].Value = f_eMM.Text;
        //        }
        //    }
        //}

        private void clsEmpRecord()
        {
            f_employeeid.Text = string.Empty;
            f_employeename.Text = string.Empty;
            f_d_bHH.SelectedIndex = 0;
            f_d_bMM.SelectedIndex = 0;
            f_d_eHH.SelectedIndex = 0;
            f_d_eMM.SelectedIndex = 0;
        }

        private void btnEmpDel_Click(object sender, EventArgs e)
        {
            //刪員工資料
            rm_EmpRowDel();
            if (dataGridView1.Rows.Count > 0)
            {   
                dataGridView1.Rows[0].Selected = true;                
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                clsEmpRecord();//清欄位
            }
        }

        private void rm_EmpRowDel()
        {
            if (f_employeeid.Text.Length == 0) return;
            if (Config.Message("確定刪除?") == "Y")
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
                if (dataGridView1.Rows.Count == 0) clsEmpRecord();                
            }
        }

        private void cgTime(object sender, EventArgs e)
        {
            ComboBox bt = (ComboBox)sender;
            string a = bt.Text;
            if (bt.Name == "f_mfd_bhh")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[2].Value = a;
                }
            }
            if (bt.Name == "f_mfd_bmm")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[3].Value = a;
                }
            }
            if (bt.Name == "f_mfd_ehh")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[4].Value = a;
                }
            }
            if (bt.Name == "f_mfd_emm")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[5].Value = a;
                }
            }
        }


        //private void cgTime(object sender, EventArgs e)
        //{
        //    ComboBox bt = (ComboBox)sender;            
        //    string a = bt.Text;
        //    if (bt.Name == "f_mfd_bhh")
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "00")
        //                dataGridView1.Rows[i].Cells[2].Value = a;
        //            else
        //                continue;
        //        }
        //    }
        //    if (bt.Name == "f_mfd_bmm")
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "00")
        //                dataGridView1.Rows[i].Cells[3].Value = a;
        //            else
        //                return;
        //        }
        //    }
        //    if (bt.Name == "f_mfd_ehh")
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "00")
        //                dataGridView1.Rows[i].Cells[4].Value = a;
        //            else
        //                continue;
        //        }
        //    }
        //    if (bt.Name == "f_mfd_emm")
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "00")
        //                dataGridView1.Rows[i].Cells[5].Value = a;
        //            else
        //                continue;
        //        }
        //    }
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            Add_S();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)  //如果背景做完了
            {
                clsForm();//清畫面
                clsDataTable();//清DataTable
                this.tabControl1.SelectedIndex = 0;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("新增成功");
        }


        //private void btn_bTime_Click(object sender, EventArgs e)
        //{
        //    bTimeSetting();
        //}

        //private void bTimeSetting()
        //{
        //    if (string.IsNullOrEmpty(f_employeeid.Text) || string.IsNullOrEmpty(f_employeename.Text)) return;
        //    rTime frm = new rTime();
        //    frm.tHH = f_bHH.Text;
        //    frm.tMM = f_bMM.Text;
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {                
        //        //--顯示時間
        //        f_bHH.Text = rTime.rHH;
        //        f_bMM.Text = rTime.rMM;
        //    }
        //}

        //private void btn_eTime_Click(object sender, EventArgs e)
        //{
        //    eTimeSetting();
        //}
        //private void eTimeSetting()
        //{
        //    if (string.IsNullOrEmpty(f_employeeid.Text) || string.IsNullOrEmpty(f_employeename.Text)) return;
        //    rTime frm = new rTime();
        //    frm.tHH = f_eHH.Text;
        //    frm.tMM = f_eMM.Text;
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        //--顯示時間
        //        f_eHH.Text = rTime.rHH;
        //        f_eMM.Text = rTime.rMM;
        //    }
        //}



    }
}
