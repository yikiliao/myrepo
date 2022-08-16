using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using EMES.Models;

using System.Collections;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;

namespace EMES.Forms
{
    public partial class Login : Form
    {        
        public static string DEPT;      //ej 廠部代碼
        public static string DEPT_NAME; //廠部簡稱
        public static string COMPNAME;  //公司全名
        public static string MFPD;      //Sql 連線字串
        public static string TT;        //Oracle 連線字串        
        public static Int16 DB;         //正式區 1 測試區 2
        public static string DBNAME;    //正式區 測試區
        public static string ID;        //登入帳號
        public static string IDNAME;    //中文名稱
        public static string WU; //DB name
        public static string DeptOne;   //判斷單據第一碼
        public static string LOG;       //寫入LOG
        public static string IDCdept;   //登入所屬部門
        //Account p_account = new Account();

        string ClickName = string.Empty;
        int TryTime=0;
        ClsINI Setupini = new ClsINI(Application.StartupPath + "\\ini\\Setup.ini");
        public Login()
        {
            InitializeComponent();                        
            init_Form();
        }

        private void init_Form()
        {
            //*******************調整視窗位置大小
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            //this.Font = new Font("新細明體", 10);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            

            //連線資訊**********************
            MFPD = ConfigurationManager.ConnectionStrings["MFPD"].ToString();   //來源
            WU = ConfigurationManager.ConnectionStrings["local"].ToString();   //來源
            TT = ConfigurationManager.ConnectionStrings["TT"].ToString();
            DEPT = ConfigurationManager.AppSettings["CODE"]; //ew
            DEPT_NAME = ConfigurationManager.AppSettings["NAME"];//
            COMPNAME = ConfigurationManager.AppSettings["COMPNAME"];//鎔利興業股份有限公司
            DBNAME = ConfigurationManager.AppSettings["DBNAME"];
            //******************************
            f_id.ReadOnly = true;
            f_password.ReadOnly = true;
        }

        private void D_Plant(string dept)
        {
            string sql = string.Empty;
            sql += "SELECT code,name from company where 1=1";
            sql += " and code ='" + dept + "'";
            DataTable dt = DOSQL.GetDataTable(WU, sql);
            f_plant.DisplayMember = "name";
            f_plant.ValueMember = "code";
            f_plant.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Usrid = f_id.Text.Trim();
            string Passwd = f_password.Text.Trim();
            ID = Usrid; //登入帳號 
            TryTime = TryTime + 1;
            if (TryTime > 5)
            {
                Config.Show("登入錯誤次數太多");
                System.Threading.Thread.Sleep(1000);//停1秒
                Application.Exit();
            }

            if (f_Check(Usrid, Passwd) == false)
                return;
            try
            {
                this.Hide();
                prc050 fm = new prc050();
                fm.Show();
            }
            catch (Exception ex)
            {
                Config.Show(ex.Message);
            }

        }




        //private void button1_Click(object sender, EventArgs e)
        //{  
        //    string Usrid = f_id.Text.Trim();
        //    string Passwd = f_password.Text.Trim();
        //    ID = Usrid; //登入帳號 
        //    TryTime = TryTime + 1;
        //    if (TryTime > 5)
        //    {
        //        Config.Show("登入錯誤次數太多");
        //        System.Threading.Thread.Sleep(1000);//停1秒
        //        Application.Exit();
        //    }

        //    if (f_Check(Usrid, Passwd) == false)
        //        return;
        //    try
        //    {                
        //        this.Hide();
        //        if (Usrid == "JFW10" || Usrid == "JFW11")
        //        {
        //            prc020 fm = new prc020();
        //            fm.Show();
        //        }
        //        else
        //        {
        //            prc001 fm = new prc001();
        //            fm.Show();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Config.Show(ex.Message);
        //    }

        //}

        private bool f_Check(string Usrid, string Passwd)
        {
            if (Usrid.Trim().Length == 0)
            {
                Config.Show("帳號錯誤");
                f_id.Focus();
                f_id_Click(null, null);
                return false;
            }
            if (Passwd.Trim().Length == 0)
            {
                Config.Show("密碼錯誤");
                f_password.Focus();
                f_password_Click(null, null);
                return false;
            }
            var p_account = new Account();
            p_account = Account.Get(Usrid);
            if (p_account == null)
            {
                Config.Show("無此使用者");
                return false;
            }
            if (p_account.Id == Usrid && p_account.Password == Passwd)
            {
                // do nothing
                ID = p_account.Id;
                IDNAME = p_account.Name;
                //DEPT = p_account.Rang;
                DeptOne = DEPT.Substring(1, 1).ToUpper();  //J或W
                //DataTable p_eca = eca_file.Get(Usrid);
                //if (p_eca.Rows.Count == 0)
                //    IDCdept = "";
                //else
                //    IDCdept = p_eca.Rows[0][2].ToString();
            }
            else
            {
                Config.Show("密碼錯誤");
                return false;
            }
            return true;
        }



        private void menu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            //離開(Control+Del)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                menu_exit_Click(sender, e);
            }

            //確認(Escape)
            if (e.KeyCode == Keys.Escape)
            {
                button1_Click(sender, e);
            }
        }

        //產生提示訊息
        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttTip = new ToolTip();
            ttTip.SetToolTip(button1, "Escape");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Login_Load(object sender, EventArgs e)
        {            
            FindControl(this);
            f_id_Click(null, null);
            Loadini();//讀ini檔
            D_Plant(DEPT);//營運中心
        }

        private void Loadini()
        {
            DEPT = Setupini.IniReadValue("LOCAL", "DEPT"); //login name
            ID = Setupini.IniReadValue("LOCAL", "ID"); //login name
            LOG = Setupini.IniReadValue("LOCAL", "LOG"); //log
            f_id.Text = ID;
            f_password.Text = ID;            
        }

        private void dnlo_Parm()
        {
            SyncAccount();
            SyncStationDoc();
        }

        private void dlod_Parm()
        {
            //偵測網站是否有運作，有就同步
            if (Config.ApiCheck("127.0.0.1", 64198, 500) == true)
            {
                GetAccount();
                GetStationDoc();
            }
            else
            {
                //do nothing;
            }
        }

        private async void GetAccount()
        {            
            string Url = "http://localhost:64198/api/Account/Get";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Url);                
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Account> fc = JsonConvert.DeserializeObject<List<Account>>(responseBody);                                  
                    dload_Account(fc);
                }
            }
        }

        private async void GetStationDoc()
        {
            string Url = "http://localhost:64198/api/StationDoc/Get";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<StationDoc> fc = JsonConvert.DeserializeObject<List<StationDoc>>(responseBody);
                    dload_StationDoc(fc);
                }
            }
        }

        //private void dload_Account(List<Account> fc)
        //{
        //    string allsql = string.Empty;
        //    foreach (var item in fc)
        //    {
        //        Account p_account = new Account();
        //        p_account.Id = item.Id;
        //        p_account.Name = item.Name;
        //        p_account.Password = item.Password;
        //        p_account.Mail = item.Mail;
        //        p_account.Vaild = item.Vaild;
        //        p_account.Add_date = item.Add_date;
        //        p_account.Add_user = item.Add_user;
        //        p_account.Mod_date = item.Mod_date;
        //        p_account.Mod_user = item.Mod_user;
        //        p_account.Rang = item.Rang;
        //        if (Account.Get(item.Id) == null)
        //            allsql += Account.Set_Insert(p_account);
        //        else
        //            allsql += Account.Set_Update(p_account);
        //    }            
        //    if (!string.IsNullOrEmpty(allsql))
        //    {
        //        var i = DOSQL.Excute(Login.WU, allsql); //寫入DB
        //    }
        //}


        /// <summary>
        /// 刪除再新增
        /// </summary>
        /// <param name="fc"></param>
        private void dload_Account(List<Account> fc)
        {
            string allsql = string.Empty;
            allsql += "delete from Account where 1=1 ;\r\n";
            foreach (var item in fc)
            {
                Account p_account = new Account();
                p_account.Id = item.Id;
                p_account.Name = item.Name;
                p_account.Password = item.Password;
                p_account.Mail = item.Mail;
                p_account.Vaild = item.Vaild;
                p_account.Add_date = item.Add_date;
                p_account.Add_user = item.Add_user;
                p_account.Mod_date = item.Mod_date;
                p_account.Mod_user = item.Mod_user;
                p_account.Rang = item.Rang;
                allsql += Account.Set_Insert(p_account);                
            }
            if (!string.IsNullOrEmpty(allsql))
            {
                var i = DOSQL.Excute(Login.WU, allsql); //寫入DB
            }
        }

        //private void dload_StationDoc(List<StationDoc> fc)
        //{
        //    string allsql = string.Empty;
        //    foreach (var item in fc)
        //    {
        //        StationDoc p = new StationDoc();
        //        p.Station = item.Station;
        //        p.DocName = item.DocName;
        //        p.DocType = item.DocType;
        //        if (StationDoc.ToDoList().Where(a => a.Station == p.Station).Count() == 0)
        //            allsql += StationDoc.Set_Insert(p);
        //        else
        //            allsql += StationDoc.Set_Update(p);
        //    }
        //    if (!string.IsNullOrEmpty(allsql))
        //    {
        //        var i = DOSQL.Excute(Login.WU, allsql); //寫入DB
        //    }
        //}

        /// <summary>
        /// 刪除再新增
        /// </summary>
        /// <param name="fc"></param>
        private void dload_StationDoc(List<StationDoc> fc)
        {
            string allsql = string.Empty;
            allsql += "delete from StationDoc where 1=1;\r\n";
            foreach (var item in fc)
            {
                StationDoc p = new StationDoc();
                p.Station = item.Station;
                p.DocName = item.DocName;
                p.DocType = item.DocType;
                allsql += StationDoc.Set_Insert(p);                
            }
            if (!string.IsNullOrEmpty(allsql))
            {
                var i = DOSQL.Excute(Login.WU, allsql); //寫入DB
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

        private void f_id_Validating(object sender, CancelEventArgs e)
        {
            //string errMsg;
            //if (!isNotEmpty(f_id.Text, out errMsg))
            //{
            //    e.Cancel = true;
            //    Config.Show("帳號"+errMsg);
            //}
        }

        

        private void f_password_Validating(object sender, CancelEventArgs e)
        {
            //string errMsg;
            //if (!isNotEmpty(f_password.Text, out errMsg))
            //{
            //    e.Cancel = true;
            //    Config.Show("密碼"+errMsg);
            //}
        }


        public bool isNotEmpty(string st, out string errMsg)
        {
            if (st.Trim().Length==0)
            {
                errMsg = "不可空白";
                return false;
            }

            errMsg = "";
            return true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void f_id_Click(object sender, EventArgs e)
        {
            ClickName = "id"; //判斷點到這個是id 讓畫面的鍵盤使用
        }

        private void f_password_Click(object sender, EventArgs e)
        {
            ClickName = "passwd"; //判斷點到這個是密碼
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "0";
            if (ClickName == "passwd") f_password.Text += "0";
        }
        private void bt_1_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "1";
            if (ClickName == "passwd") f_password.Text += "1";
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "2";
            if (ClickName == "passwd") f_password.Text += "2";
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "3";
            if (ClickName == "passwd") f_password.Text += "3";
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "4";
            if (ClickName == "passwd") f_password.Text += "4";
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "5";
            if (ClickName == "passwd") f_password.Text += "5";
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "6";
            if (ClickName == "passwd") f_password.Text += "6";
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "7";
            if (ClickName == "passwd") f_password.Text += "7";
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "8";
            if (ClickName == "passwd") f_password.Text += "8";
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "9";
            if (ClickName == "passwd") f_password.Text += "9";
        }

        private void bt_a_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "a";
            if (ClickName == "passwd") f_password.Text += "a";
        }

        private void bt_b_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "b";
            if (ClickName == "passwd") f_password.Text += "b";
        }

        private void bt_c_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "c";
            if (ClickName == "passwd") f_password.Text += "c";
        }

        private void bt_d_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "d";
            if (ClickName == "passwd") f_password.Text += "d";
        }

        private void bt_e_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "e";
            if (ClickName == "passwd") f_password.Text += "e";
        }

        private void bt_f_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "f";
            if (ClickName == "passwd") f_password.Text += "f";
        }

        private void bt_g_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "g";
            if (ClickName == "passwd") f_password.Text += "g";
        }

        private void bt_h_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "h";
            if (ClickName == "passwd") f_password.Text += "h";
        }

        private void bt_i_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "i";
            if (ClickName == "passwd") f_password.Text += "i";
        }

        private void bt_j_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "j";
            if (ClickName == "passwd") f_password.Text += "j";
        }

        private void bt_k_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "k";
            if (ClickName == "passwd") f_password.Text += "k";
        }

        private void bt_l_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "l";
            if (ClickName == "passwd") f_password.Text += "l";
        }

        private void bt_m_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "m";
            if (ClickName == "passwd") f_password.Text += "m";
        }

        private void bt_n_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "n";
            if (ClickName == "passwd") f_password.Text += "n";
        }

        private void bt_o_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "o";
            if (ClickName == "passwd") f_password.Text += "o";
        }

        private void bt_p_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "p";
            if (ClickName == "passwd") f_password.Text += "p";
        }

        private void bt_q_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "q";
            if (ClickName == "passwd") f_password.Text += "q";
        }

        private void bt_r_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "r";
            if (ClickName == "passwd") f_password.Text += "r";
        }

        private void bt_s_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "s";
            if (ClickName == "passwd") f_password.Text += "s";
        }

        private void bt_t_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "t";
            if (ClickName == "passwd") f_password.Text += "t";
        }

        private void bt_u_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "u";
            if (ClickName == "passwd") f_password.Text += "u";
        }

        private void bt_v_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "v";
            if (ClickName == "passwd") f_password.Text += "v";
        }

        private void bt_w_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "w";
            if (ClickName == "passwd") f_password.Text += "w";
        }

        private void bt_x_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "x";
            if (ClickName == "passwd") f_password.Text += "x";
        }

        private void bt_y_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "y";
            if (ClickName == "passwd") f_password.Text += "y";
        }

        private void bt_z_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text += "z";
            if (ClickName == "passwd") f_password.Text += "z";
        }

        private void bt_cls_Click(object sender, EventArgs e)
        {
            if (ClickName == "id") f_id.Text = string.Empty;
            if (ClickName == "passwd") f_password.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_id.Text = "admin";
            f_password.Text = "admin";
            button1_Click(null, null);
        }

        private static bool PingTest(string IP)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse(IP), 5000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ApiCheck(string IPStr, int Port, int Timeout)
        {
            bool success = false;
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    success = socket.BeginConnect(IPAddress.Parse(IPStr), Port, null, null).AsyncWaitHandle.WaitOne(Timeout, true);
            }
            catch { }
            return success;
        }

        private void SyncAccount()
        {
            DataTable dt1 = DOSQL.GetDataTable(ConfigurationManager.ConnectionStrings["WU_66_8"].ToString(), "select * from Account");//來源          
            DataTable dt2 = DOSQL.GetDataTable(ConfigurationManager.ConnectionStrings["local"].ToString(), "select * from Account");//目的
            
            //获取两个数据源的差集
            IEnumerable<DataRow> query2 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);
            string allsql = string.Empty;
            foreach (DataRow dr in query2)
            {
                Account p = new Account();
                p.Id = dr["Id"].ToString();
                p.Name = dr["Name"].ToString();
                p.Password = dr["Password"].ToString();
                p.Mail = dr["Mail"].ToString();
                p.Vaild = dr["Vaild"].ToString();
                //p.Add_date = System.Convert.ToDateTime(dr["Add_date"].ToString());
                p.Add_user = dr["Add_user"].ToString();
                //p.Mod_date = System.Convert.ToDateTime(dr["Mod_date"].ToString());
                p.Mod_user = dr["Mod_user"].ToString();
                p.Rang = dr["Rang"].ToString();
                if (Account.ToDoList().Where(a =>a.Id == p.Id).Count() == 0)
                    allsql += Account.Set_Insert(p);
                else
                    allsql += Account.Set_Update(p);
            }
            if (!string.IsNullOrEmpty(allsql))
            {
                var i = DOSQL.Excute(Login.WU, allsql); //寫入DB
            }
        }

        private void SyncStationDoc()
        {
            DataTable dt1 = DOSQL.GetDataTable(ConfigurationManager.ConnectionStrings["WU_66_8"].ToString(), "select * from StationDoc");//來源          
            DataTable dt2 = DOSQL.GetDataTable(ConfigurationManager.ConnectionStrings["local"].ToString(), "select * from StationDoc");//目的
            
            //获取两个数据源的差集
            IEnumerable<DataRow> query2 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);            
            string allsql = string.Empty;
            foreach (DataRow dr in query2)
            {
                StationDoc p = new StationDoc();
                p.Station = dr["Station"].ToString();
                p.DocName = dr["DocName"].ToString();
                p.DocType = dr["DocType"].ToString();
                if (StationDoc.ToDoList().Where(a => a.Station == p.Station).Count() == 0)
                    allsql += StationDoc.Set_Insert(p);
                else
                    allsql += StationDoc.Set_Update(p);
            }
            if (!string.IsNullOrEmpty(allsql))
            {
                var i = DOSQL.Excute(Login.WU, allsql); //寫入DB
            }
        }



    }
}


