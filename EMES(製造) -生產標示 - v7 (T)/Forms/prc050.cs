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
    public partial class prc050 : Form
    {
        string rEcm06; //切台作業
        List<string> myIP = new List<string>(); //IP位址
        string ClickName = string.Empty;
        public static DataTable dtProd = new DataTable(); //存資料            
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

        private string TxtName = string.Empty;


        private float x;//定義當前窗體的寬度
        private float y;//定義當前窗體的高度

        public prc050()
        {
            InitializeComponent();
            Init_DataTable();
            this.StartPosition = FormStartPosition.CenterScreen;
            //標題字體(工單)
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 17);
            dataGridView3.DefaultCellStyle.Font = new Font("新細明體", 17);
            this.dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            //
            this.dataGridView3.Columns[1].Visible = false;
            this.dataGridView3.Columns[6].Visible = false;


            //唯讀
            this.dataGridView3.Columns[1].ReadOnly = true;
            this.dataGridView3.Columns[2].ReadOnly = true;
            this.dataGridView3.Columns[3].ReadOnly = true;
            this.dataGridView3.Columns[4].ReadOnly = true;
            this.dataGridView3.Columns[5].ReadOnly = true;
            this.dataGridView3.Columns[6].ReadOnly = true;
            this.dataGridView3.Columns[7].ReadOnly = true;

            this.dataGridView3.Columns[8].ReadOnly = true;
            this.dataGridView3.Columns[9].ReadOnly = true;
            this.dataGridView3.Columns[10].ReadOnly = true;
            this.dataGridView3.Columns[11].ReadOnly = true;

            //第一欄的大小
            this.dataGridView3.RowHeadersWidth = 5;
            this.ControlBox = false;
            //
            x = this.Width;
            y = this.Height;
            setTag(this);
        }

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍歷窗體中的控制元件，重新設定控制元件的值
            foreach (Control con in cons.Controls)
            {
                //獲取控制元件的Tag屬性值，並分割後儲存字串陣列
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根據窗體縮放的比例確定控制元件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//寬度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左邊距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//頂邊距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字型大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }


        private void Init_DataTable()
        {
            //--定義datatable 欄位
            dtProd.Reset();
            dtProd.Columns.Add("mfdate", typeof(String));
            dtProd.Columns.Add("mfline", typeof(String));
            dtProd.Columns.Add("mftable", typeof(String));
            dtProd.Columns.Add("wkno", typeof(String));
            dtProd.Columns.Add("cond", typeof(String));
            dtProd.Columns.Add("workqty", typeof(String));
            dtProd.Columns.Add("story", typeof(String));
            dtProd.Columns.Add("long_lower", typeof(String));
            dtProd.Columns.Add("long_upper", typeof(String));
            dtProd.Columns.Add("width_lower", typeof(String));
            dtProd.Columns.Add("width_upper", typeof(String));
        }

        private void prc001_Load(object sender, EventArgs e)
        {
            D_line();//生產線
            D_table();//炊台
            D_story();//樓層
            EleTime(); //觸發電子時鐘
            MyIP();
            clsForm();//清除畫面
            f_begdate_ValueChanged(null, null);
            ////背景工作作業
            //backgroundWorker1.WorkerReportsProgress = true;         //是否要回報進度
            //backgroundWorker1.WorkerSupportsCancellation = true;    //是否支援取消作業
        }

        private void D_line()
        {   
            var iL = sst100.ToDoList().Where(a => a.Type == "A" && a.Dept == Login.DEPT).ToList();
            iL.Add(new sst100 { Type = "A", Code = "", Code_desc = "--全選--", Dept = Login.DEPT });
            f_mfline.DataSource = iL;
            f_mfline.ValueMember = "Code";
            f_mfline.DisplayMember = "Code_desc";

            f_mfline.SelectedIndex = f_mfline.Items.Count - 1;
        }

        private void D_table()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "B" && a.Dept == Login.DEPT).ToList();
            iL.Add(new sst100 { Type = "B", Code = "", Code_desc = "--全選--", Dept = Login.DEPT });
            f_mftable.DataSource = iL;
            f_mftable.ValueMember = "Code";
            f_mftable.DisplayMember = "Code_desc";

            f_mftable.SelectedIndex = f_mftable.Items.Count - 1;
        }

        private void D_story()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "C" && a.Dept == Login.DEPT).ToList();            
            f_story.DataSource = iL;
            f_story.ValueMember = "Code";
            f_story.DisplayMember = "Code_desc";

            f_story.SelectedIndex =0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();            
            Application.Exit();
        }



        private void clsForm()
        {
            D_line();
            D_table();            

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
            dtProd.Clear();
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


        private void button4_Click(object sender, EventArgs e)
        {
            if (doOkCancel("是否確定列印生產標示？") == true)
            {
                var Org_Color = lb_msg.ForeColor;
                Cursor_wait(); //改變滑鼠游標漏斗指標
                DoWork();
                UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
            }
        }

        private bool doOkCancel(string Meg)
        {
            bool rf = false;
            prc050_okcanel fm = new prc050_okcanel();
            fm.Msg = Meg;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rf = fm.isConf;
                //do nothing
            }
            return rf;
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (Config.Message("是否確定列印明細資料？\r\n\r\n" ) == "Y")
        //    {
        //        var Org_Color = lb_msg.ForeColor;
        //        Cursor_wait(); //改變滑鼠游標漏斗指標
        //        DoWork();
        //        UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        //    }   
        //}

        private void Cursor_wait()
        {
            lb_msg.ForeColor = Color.Blue;
            lb_msg.Text = "資料處理中...請稍候";
            System.Threading.Thread.Sleep(100);//停0.1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            lb_msg.Text = "";
        }

        private void DoWork()
        {
            if (f_Check() == false) return;
            IndtProd();//寫入datatable
            prc0501 fm = new prc0501();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //donothing

                ////接收回傳資料
                //DataTable dt = fm.dtProd;
                //FindD(dt);
            }
        }


        //private void DoWork()
        //{
        //    if (!backgroundWorker1.IsBusy)
        //    {
        //        if (f_Check() == false) return;

        //        IndtProd();

        //        backgroundWorker1.RunWorkerAsync();
        //    }
        //}

        private void IndtProd()
        {
            dtProd.Clear();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView3.Rows[i].Cells["ck"].Value);
                if (isSelected)
                {
                    DataRow dr = dtProd.NewRow();
                    dr["mfdate"] = dataGridView3.Rows[i].Cells["mfdate"].Value.ToString();
                    dr["mfline"] = dataGridView3.Rows[i].Cells["mfline"].Value.ToString();
                    dr["mftable"] = dataGridView3.Rows[i].Cells["mftable"].Value.ToString();
                    dr["wkno"] = dataGridView3.Rows[i].Cells["wkno"].Value.ToString();
                    dr["cond"] = dataGridView3.Rows[i].Cells["cond"].Value.ToString();
                    dr["workqty"] = dataGridView3.Rows[i].Cells["workqty"].Value.ToString();
                    dr["story"] = dataGridView3.Rows[i].Cells["story"].Value.ToString();
                    dr["long_lower"] = dataGridView3.Rows[i].Cells["long_lower"].Value.ToString();
                    dr["long_upper"] = dataGridView3.Rows[i].Cells["long_upper"].Value.ToString();
                    dr["width_lower"] = dataGridView3.Rows[i].Cells["width_lower"].Value.ToString();
                    dr["width_upper"] = dataGridView3.Rows[i].Cells["width_upper"].Value.ToString();                    
                    dtProd.Rows.Add(dr);
                }
            }
        }





        private bool f_Check()
        {
            int CkCnt = 0;
            if (dataGridView3.Rows.Count == 0)
            {                
                doMsg("請先查詢資料");
                return false;
            }
            
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView3.Rows[i].Cells["ck"].Value);
                if (isSelected)
                {
                    CkCnt += 1;
                }
            }
            if (CkCnt == 0)
            {                
                doMsg("請先選取資料");
                return false;
            }
            return true;
        }

        


        private void button5_Click(object sender, EventArgs e)
        {
            clsForm();//清除畫面
            
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
            Setting();
        }

        //private void btnStup_Click(object sender, EventArgs e)
        //{
        //    //畫面沒有清空不選設定
        //    if (isNoData(f_wkno.Text) == true) return;
        //    if (dataGridView1.Rows.Count > 0) return;
        //    if (dataGridView3.Rows.Count > 0) return;
        //    //--------------------
        //    frmPass frm = new frmPass();
        //    if (frm.ShowDialog() == DialogResult.OK) //密碼通過 設定
        //    {
        //        Setting();
        //    }
        //}


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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView3.Rows[e.RowIndex].Selected = true;
        }

        //private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
        //    dataGridView3.Rows[e.RowIndex].Selected = true;

        //    GetHeader();
        //}

        private void GetHeader()
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Selected == true)
                {
                    string story = dataGridView3.Rows[i].Cells["story"].Value.ToString();//樓層

                    
                    f_story.SelectedValue = story;
                    f_long_lower.Text = dataGridView3.Rows[i].Cells["long_lower"].Value.ToString();
                    f_long_upper.Text = dataGridView3.Rows[i].Cells["long_upper"].Value.ToString();
                    f_width_lower.Text = dataGridView3.Rows[i].Cells["width_lower"].Value.ToString();
                    f_width_upper.Text = dataGridView3.Rows[i].Cells["width_upper"].Value.ToString();
                    //f_story.SelectedIndex = f_story.Items.IndexOf(story);
                }
            }


            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Selected == true)
            //    {
            //        f_employeeid.Text = dataGridView1.Rows[i].Cells["employeeid"].Value.ToString();
            //        f_employeename.Text = dataGridView1.Rows[i].Cells["employeename"].Value.ToString();
            //        string bHH = dataGridView1.Rows[i].Cells["bHH"].Value.ToString();
            //        string bMM = dataGridView1.Rows[i].Cells["bMM"].Value.ToString();
            //        string eHH = dataGridView1.Rows[i].Cells["eHH"].Value.ToString();
            //        string eMM = dataGridView1.Rows[i].Cells["eMM"].Value.ToString();
            //        f_d_bHH.SelectedIndex = f_d_bHH.Items.IndexOf(bHH);
            //        f_d_bMM.SelectedIndex = f_d_bMM.Items.IndexOf(bMM);
            //        f_d_eHH.SelectedIndex = f_d_eHH.Items.IndexOf(eHH);
            //        f_d_eMM.SelectedIndex = f_d_eMM.Items.IndexOf(eMM);
            //    }
            //}
        }

        
        

        

        

        private void button6_Click(object sender, EventArgs e)
        {
            //刪除單筆工單資料 DataGrivew3的資料列
            rm_RowDel();            
        }


        private void rm_RowDel()
        {            
            if (Config.Message("確定刪除?") == "Y")
            {
                foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
                {
                    dataGridView3.Rows.RemoveAt(item.Index);
                }
                //
                //rm_dtOutProd();//刪除不良數
                //---------
                if (dataGridView3.Rows.Count == 0)
                {
                    button5_Click(null, null); //觸發取消按鈕
                }
                else
                {
                    dataGridView3.Rows[0].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3.Rows[0].Cells[0];                    
                }
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            //Add_S();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)  //如果背景做完了
            {
                clsForm();//清畫面
                clsDataTable();//清DataTable                
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("新增成功");
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            DataTable dt = getMfplan();            
            if (dt.Rows.Count == 0)
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                }
                else
                {
                    dataGridView3.Rows.Clear();
                }
                doMsg("無符合資料");                            
                return;
            }
            FindD(dt);
        }        

        private void FindD(DataTable dt)
        {
            dataGridView3.Rows.Clear();
            int idx = 0;
            
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {   
                string dd = System.Convert.ToDateTime(dt.Rows[i]["mfdate"]).ToString("yyyy/MM/dd");
                int qty = System.Convert.ToInt16(dt.Rows[i]["workqty"]);
                string story = "外倉";
                string long_lower = string.Empty;
                string long_upper = string.Empty;
                string width_lower = string.Empty;
                string width_upper = string.Empty;

                dataGridView3.Rows.Add(new object[] {true,
                    dd,
                    dt.Rows[i]["mfline"],
                    dt.Rows[i]["mftable"],
                    dt.Rows[i]["wkno"],
                    dt.Rows[i]["cond"],
                    qty.ToString(),
                    story,
                    long_lower,long_upper,
                    width_lower,width_upper
                    });
                idx += 1;
            }

            if (idx > 0)
            {
                dataGridView3.Rows[0].Selected = true; //第一列反藍選取                
                //dataGridView3_CellClick(null, null);//點選欄位抓取資料
            }
        }

        private void doMsg(string Meg)
        {
            prc050_msg fm = new prc050_msg();
            fm.Msg = Meg;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //do nothing
            }
        }

        private DataTable getMfplan()
        {
            string rMline = f_mfline.SelectedValue == null ? "" : f_mfline.SelectedValue.ToString();//生產線
            string rMtable = f_mftable.SelectedValue == null ? "" : f_mftable.SelectedValue.ToString();//炊台
            string sql = string.Empty;
            sql += "select * from mfplan where 1=1";
            sql += " and plant='" + Login.DEPT + "'";
            sql += " and mfdate BETWEEN '" + f_begdate.Value.ToString("yyyy/MM/dd") + "' and '" + f_enddate.Value.ToString("yyyy/MM/dd") + "'";
            if (rMline.Trim().Length > 0)
            {
                sql += " and mfline='" + rMline + "'";
            }
            if (rMtable.Trim().Length > 0)
            {
                sql += " and mftable='" + rMtable + "'";
            }
            sql += " ORDER BY mfdate, mfline,mftable";
            DataTable dt = DOSQL.GetDataTable(Login.MFPD, sql);
            return dt;
        }


        private void f_begdate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, f_begdate.Value.ToString("yyyy/MM/dd"));
            f_enddate.Text = f_begdate.Text;
        }

        private void f_enddate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, f_enddate.Value.ToString("yyyy/MM/dd"));
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridView3.Columns[e.ColumnIndex];
            string btText = newColumn.HeaderText;
            switch (btText)
            {
                case "全選":
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        dataGridView3.Rows[i].Cells["ck"].Value = true;
                    }
                    newColumn.HeaderText = "選取";
                    break;

                case "選取":
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        dataGridView3.Rows[i].Cells["ck"].Value = false;
                    }
                    newColumn.HeaderText = "全選";
                    break;
                default:
                    break;
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

        private void btn_emp_Upd_Click(object sender, EventArgs e)
        {
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            rowUpd();
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        }

        //private void btn_emp_Upd_Click(object sender, EventArgs e)
        //{
        //    if (doOkCancel("是否確定修改上下限？") == true)
        //    {
        //        var Org_Color = lb_msg.ForeColor;
        //        Cursor_wait(); //改變滑鼠游標漏斗指標
        //        rowUpd();
        //        UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        //    }
        //}

        private void rowUpd()
        {            
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView3.Rows[i].Cells["ck"].Value);
                if (isSelected)
                {
                    //dataGridView3.Rows[i].Cells["story"].Value = f_story.SelectedValue.ToString();
                    dataGridView3.Rows[i].Cells["long_lower"].Value = f_long_lower.Text;
                    dataGridView3.Rows[i].Cells["long_upper"].Value = f_long_upper.Text;
                    dataGridView3.Rows[i].Cells["width_lower"].Value = f_width_lower.Text;
                    dataGridView3.Rows[i].Cells["width_upper"].Value = f_width_upper.Text;
                }
            }
        }



        //private void rowUpd()
        //{
        //    string awkno = f_wkno.Text; //工單            
        //    for (int i = 0; i < dataGridView3.Rows.Count; i++)
        //    {
        //        string bwkno = dataGridView3.Rows[i].Cells["wkno"].Value.ToString();                
        //        if (awkno == bwkno)//工單相同
        //        {
        //            dataGridView3.Rows[i].Cells["story"].Value = f_story.SelectedValue.ToString();
        //            dataGridView3.Rows[i].Cells["long_lower"].Value = f_long_lower.Text;
        //            dataGridView3.Rows[i].Cells["long_upper"].Value = f_long_upper.Text;
        //            dataGridView3.Rows[i].Cells["width_lower"].Value = f_width_lower.Text;
        //            dataGridView3.Rows[i].Cells["width_upper"].Value = f_width_upper.Text;
        //        }
        //    }
        //}

        private void clsRecord()
        {            
            f_long_lower.Text = string.Empty;
            f_long_upper.Text = string.Empty;
            f_width_lower.Text = string.Empty;
            f_width_upper.Text = string.Empty;
        }
        private void btn_story_Click(object sender, EventArgs e)
        {
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            updStory();
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        }

        //private void btn_story_Click(object sender, EventArgs e)
        //{
        //    if (doOkCancel("是否確定修改樓層？") == true)
        //    {
        //        var Org_Color = lb_msg.ForeColor;
        //        Cursor_wait(); //改變滑鼠游標漏斗指標
        //        updStory();
        //        UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        //    }
        //}

        private void updStory()
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView3.Rows[i].Cells["ck"].Value);
                if (isSelected)
                {
                    dataGridView3.Rows[i].Cells["story"].Value = f_story.SelectedValue.ToString();
                    //dataGridView3.Rows[i].Cells["long_lower"].Value = f_long_lower.Text;
                    //dataGridView3.Rows[i].Cells["long_upper"].Value = f_long_upper.Text;
                    //dataGridView3.Rows[i].Cells["width_lower"].Value = f_width_lower.Text;
                    //dataGridView3.Rows[i].Cells["width_upper"].Value = f_width_upper.Text;
                }
            }
        }

        private void f_long_lower_Click(object sender, EventArgs e)
        {
            TxtName = "f_long_lower";
            TxtSelect();
        }

        private void f_long_upper_Click(object sender, EventArgs e)
        {
            TxtName = "f_long_upper";
            TxtSelect();
        }

        private void f_width_lower_Click(object sender, EventArgs e)
        {
            TxtName = "f_width_lower";
            TxtSelect();
        }

        private void f_width_upper_Click(object sender, EventArgs e)
        {
            TxtName = "f_width_upper";
            TxtSelect();
        }

        private void TxtSelect()
        {
            if (TxtName == "f_long_lower") { f_long_lower.Focus(); f_long_lower.Select(0, f_long_lower.Text.Length); }
            if (TxtName == "f_long_upper") { f_long_upper.Focus(); f_long_upper.Select(0, f_long_upper.Text.Length); }
            if (TxtName == "f_width_lower") { f_width_lower.Focus(); f_width_lower.Select(0, f_width_lower.Text.Length); }
            if (TxtName == "f_width_upper") { f_width_upper.Focus(); f_width_upper.Select(0, f_width_upper.Text.Length); }
        }

        private void prc050_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }
    }
}
