using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EMES.Models;

namespace EMES.Forms
{
    public partial class frmSetting : Form
    {
        ClsINI Setupini = new ClsINI(Application.StartupPath + "\\ini\\Setup.ini");

        string DEPT;
        string ID;
        string LOG;
        string stDefPrint;      //預設印表機
        string stCopyNum;       //列印張數
        public frmSetting()
        {
            InitializeComponent();
            init_Form();
        }

        private void init_Form()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            DEPT = Setupini.IniReadValue("LOCAL", "DEPT"); //
            ID = Setupini.IniReadValue("LOCAL", "ID"); //login name 
            LOG = Setupini.IniReadValue("LOCAL", "LOG"); //log
            stDefPrint = Setupini.IniReadValue("LOCAL", "LPRINT ");//列表機
            stCopyNum = Setupini.IniReadValue("TITLE", "COPYNUM "); //列印張數
            D_Plant(DEPT);//廠部
            D_Work();//工作站
            D_Log();//寫入log
            D_SU();            
            GetPrinterList();//印表機            
            PrintNum();//列印張數
            f_su.ReadOnly = true;
        }

        private void GetPrinterList()
        {
            //獲取本地連線印表機列表載入到下拉框中
            PrinterSettings.StringCollection list = PrinterSettings.InstalledPrinters;
            foreach (string pkInstalledPrinters in list)
            {
                DropDownList1.Items.Add(pkInstalledPrinters);
                //本地預設的印表機為預設選擇項
                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//獲取預設的印表機名
                if (pkInstalledPrinters == stDefPrint)
                //把本地預設印表機設為預設值
                {
                    DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(pkInstalledPrinters);
                }
            }
        }

        private void PrintNum()
        {
            f_printnum.Items.Add("1");
            f_printnum.Items.Add("2");
            f_printnum.Items.Add("3");
            f_printnum.Items.Add("4");
            f_printnum.Items.Add("5");
            f_printnum.SelectedIndex = f_printnum.Items.IndexOf(stCopyNum);
        }

        private void D_Plant(string dept)
        {
            string sql = string.Empty;
            sql += "SELECT code,name from company where 1=1";
            sql += " and code='" + dept + "'";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            f_plant.DataSource = dt;
            f_plant.DisplayMember = "name";
            f_plant.ValueMember = "code";                       
            f_plant.SelectedValue = DEPT;
        }
        private void D_Work()
        {
            string sql = string.Empty;
            sql += "SELECT id,eca02 from account";
            sql += " LEFT OUTER JOIN eca_file on eca01 = account.id ";
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(id,1,1)='" + Login.DeptOne + "'";
            sql += " and account.vaild='Y'";
            sql += " ORDER BY id";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            f_ptno.DataSource = dt;
            f_ptno.DisplayMember = "eca02";
            f_ptno.ValueMember = "id";
            f_ptno.SelectedValue = ID;
        }

        private void D_Log()
        {
            f_log.Items.Add("Y");
            f_log.Items.Add("N");            
            //內定值
            f_log.SelectedIndex = f_log.Items.IndexOf(LOG);
        }

        private void D_SU()
        {            
            f_su.Text = Setupini.IniReadValue("LOCAL", "ADMIN"); //SU
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePath();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void SavePath()
        {
            string stDept = f_plant.SelectedValue.ToString(); //廠部
            string stID = f_ptno.SelectedValue.ToString();//工作站            
            string stLOG = f_log.Items[f_log.SelectedIndex].ToString();//LOG
            string stADMIN = f_su.Text;
            stDefPrint = DropDownList1.Items[DropDownList1.SelectedIndex].ToString();
            stCopyNum = f_printnum.Items[f_printnum.SelectedIndex].ToString();
            try
            {
                Setupini.IniWriteValue("LOCAL", "DEPT", stDept.Trim()); //廠部
                Setupini.IniWriteValue("LOCAL", "ID", stID.Trim()); //工作站
                Setupini.IniWriteValue("LOCAL", "LOG", stLOG.Trim()); //LOG
                Setupini.IniWriteValue("LOCAL", "ADMIN", stADMIN.Trim()); //
                Setupini.IniWriteValue("TITLE", "LPRINT", stDefPrint.Trim()); //印表機
                Setupini.IniWriteValue("TITLE", "COPYNUM", stCopyNum.Trim()); //列印張數
                //MessageBox.Show("完成\n\r請重新登入");
                //System.Threading.Thread.Sleep(1000);//停1秒
                //Application.Exit();
            }
            catch
            {
                MessageBox.Show("失敗");
            }

        }

        //private void SavePath()
        //{
        //    string stDept = f_plant.SelectedValue.ToString(); //廠部
        //    string stID = f_ptno.SelectedValue.ToString();//工作站            
        //    string stLOG = f_log.Items[f_log.SelectedIndex].ToString();//LOG
        //    string stADMIN = f_su.Text;
        //    try
        //    {
        //        Setupini.IniWriteValue("LOCAL", "DEPT", stDept.Trim()); //廠部
        //        Setupini.IniWriteValue("LOCAL", "ID", stID.Trim()); //工作站
        //        Setupini.IniWriteValue("LOCAL", "LOG", stLOG.Trim()); //LOG
        //        Setupini.IniWriteValue("LOCAL", "ADMIN", stADMIN.Trim()); //
        //        MessageBox.Show("完成\n\r請重新登入");               
        //        System.Threading.Thread.Sleep(1000);//停1秒
        //        Application.Exit();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("失敗");
        //    }

        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void bt_cls_Click(object sender, EventArgs e)
        {
            f_su.Text = string.Empty;
            f_su.Select();
            f_su.Focus();
        }

        private void bt_Click(object sender, EventArgs e)
        {
            if (f_su.ReadOnly == true) return;
            Button bt = (Button)sender;

            switch (bt.Text)
            {
                case "清":
                    f_su.Text = string.Empty;
                    f_su.Select();
                    f_su.Focus();
                    break;

                case "<--":
                    if (f_su.Text.Trim().Length == 0) break;
                    f_su.Text = f_su.Text.Substring(0, f_su.Text.Length - 1);
                    break;

                default:
                    f_su.Text += bt.Text;
                    break;
            }
        }


    }
}
