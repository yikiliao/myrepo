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
using EMES.Crpts;

namespace EMES.Forms
{
    public partial class mfr002 : Form
    {        
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        //public string rDept; //傳過來的廠部
        //public Int16 rYy;//傳過來的年度
        //public Int16 rMm;//傳過來的月份
        //public string rPrno;//工號
        //public string rIsCall;//傳過來的

        //public void SetValue()
        //{            
        //    this.f_comDept.SelectedValue = rDept;
        //    this.f_cdept.Text = null;
        //    this.f_yy.Text = rYy.ToString();
        //    this.f_month.Text = rMm.ToString();
        //    this.f_prno.Text = string.Format("'{0}'", rPrno);
        //    this.f_type.SelectedIndex = 0;

        //    this.f_comDept.Enabled = false;
        //    this.f_cdept.Enabled = false;
        //    this.f_yy.Enabled = false;
        //    this.f_month.Enabled = false;
        //    this.f_type.Enabled = false;
        //    this.f_prno.Enabled = false;
        //    this.button2.Enabled = false;
        //    this.button3.Enabled = false;
        //    this.button1_Click(null, null);
        //    this.button1.Enabled = false;
        //}

        public mfr002()
        {
            InitializeComponent();            
            Config.SetFormSize(this, "R");
            Config.SetPer(this);

            init_Form();
        }

        private void init_Form()
        {            
            D_line();//生產線
            D_table();//炊台
            Config.Set_DateTo(f_begdate, " ");//清空預設日期
            Config.Set_DateTo(f_enddate, " ");//清空預設日期            
            f_mfline.SelectedIndex = f_mfline.Items.Count - 1;
            f_mftable.SelectedIndex = f_mftable.Items.Count - 1;
            f_begdate.Value = DateTime.Now.AddDays(1);//內定明天
            f_enddate.Value = DateTime.Now.AddDays(1);//內定明天
        }

        //private void D_line()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("A 線", "A"));
        //    data.Add(new DictionaryEntry("B 線", "B"));
        //    data.Add(new DictionaryEntry("C 線", "C"));
        //    data.Add(new DictionaryEntry("D 線", "D"));
        //    data.Add(new DictionaryEntry("", ""));
        //    f_mfline.DisplayMember = "Key";
        //    f_mfline.ValueMember = "Value";
        //    f_mfline.DataSource = data;
        //}

        //private void D_line()
        //{
        //    var iL = sst001.ToDoList().Where(a => a.Type == "A").ToList();
        //    iL.Add(new sst001 { Type = "A", Code = "", Code_desc = "" });
        //    f_mfline.DataSource = iL;
        //    f_mfline.ValueMember = "Code";
        //    f_mfline.DisplayMember = "Code_desc";
        //}

        private void D_line()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "A" && a.Dept == Login.DEPT).ToList();
            iL.Add(new sst100 { Type = "A", Code = "", Code_desc = "", Dept = Login.DEPT });
            f_mfline.DataSource = iL;
            f_mfline.ValueMember = "Code";
            f_mfline.DisplayMember = "Code_desc";
        }



        //private void D_table()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("A 台", "A"));
        //    data.Add(new DictionaryEntry("B 台", "B"));
        //    data.Add(new DictionaryEntry("C 台", "C"));
        //    data.Add(new DictionaryEntry("D 台", "D"));
        //    data.Add(new DictionaryEntry("E 台", "E"));
        //    data.Add(new DictionaryEntry("F 台", "F"));
        //    data.Add(new DictionaryEntry("G 台", "G"));
        //    data.Add(new DictionaryEntry("H 台", "H"));
        //    data.Add(new DictionaryEntry("I 台", "I"));
        //    data.Add(new DictionaryEntry("J 台", "J"));
        //    data.Add(new DictionaryEntry("K 台", "K"));
        //    data.Add(new DictionaryEntry("L 台", "L"));
        //    data.Add(new DictionaryEntry("M 台", "M"));
        //    data.Add(new DictionaryEntry("N 台", "N"));
        //    data.Add(new DictionaryEntry("O 台", "O"));
        //    data.Add(new DictionaryEntry("打料板", "打料板"));
        //    data.Add(new DictionaryEntry("", ""));
        //    f_mftable.DisplayMember = "Key";
        //    f_mftable.ValueMember = "Value";
        //    f_mftable.DataSource = data;
        //}

        //private void D_table()
        //{
        //    var iL = sst001.ToDoList().Where(a => a.Type == "B").ToList();
        //    iL.Add(new sst001 { Type = "B", Code = "", Code_desc = "" });
        //    f_mftable.DataSource = iL;
        //    f_mftable.ValueMember = "Code";
        //    f_mftable.DisplayMember = "Code_desc";
        //}

        private void D_table()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "B" && a.Dept == Login.DEPT).ToList();
            iL.Add(new sst100 { Type = "B", Code = "", Code_desc = "", Dept = Login.DEPT });
            f_mftable.DataSource = iL;
            f_mftable.ValueMember = "Code";
            f_mftable.DisplayMember = "Code_desc";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rPlant = Login.DEPT;
            string rMfline = f_mfline.SelectedValue == null ? "" : f_mfline.SelectedValue.ToString();//生產線            
            string rMftable = f_mftable.SelectedValue == null ? "" : f_mftable.SelectedValue.ToString();//炊台
            string rBegdate = f_begdate.Text;//生產日(起)
            string rEnddate = f_enddate.Text;//生產日(迄)                       

            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            var count = 0;
            count = mfplap.ToDoList1(rPlant, rMfline, rMftable, rBegdate, rEnddate).Count();
            
            if (count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                if (f_model.Checked == true)
                {
                    Print_cs(rPlant, rMfline, rMftable, rBegdate, rEnddate);
                }
                else
                {
                    Print_cs_2(rPlant, rMfline, rMftable, rBegdate, rEnddate);
                }
            }
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        }

        

        

        private void Cursor_wait()
        {
            lb_msg.ForeColor = Color.Blue;
            lb_msg.Text = "資料處理中...請稍候";
            System.Threading.Thread.Sleep(1000);//停1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            lb_msg.Text = "";
        }

        //有印模具
        private void Print_cs(string rPlant, string rMfline, string rMftable, string rBegdate, string rEnddate)
        {
            var rpname = "實際生產排程表";

            CrystalReport_mfr002 rp = new CrystalReport_mfr002();
            rp.SetDataSource(mfplap.ToDoList1(rPlant, rMfline, rMftable, rBegdate, rEnddate));

            rp.SetParameterValue("CompName", Login.COMPNAME);//公司名稱            
            rp.SetParameterValue("ReportName",rpname);//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(rPlant, rMfline, rMftable, rBegdate, rEnddate));//列印條件
            rp.SetParameterValue("ReportId", "mfr002");//程式編號            
            rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        //沒印模具
        private void Print_cs_2(string rPlant, string rMfline, string rMftable, string rBegdate, string rEnddate)
        {
            var rpname = "實際生產排程表";

            CrystalReport_mfr002_2 rp = new CrystalReport_mfr002_2();
            rp.SetDataSource(mfplap.ToDoList1(rPlant, rMfline, rMftable, rBegdate, rEnddate));

            rp.SetParameterValue("CompName", Login.COMPNAME);//公司名稱            
            rp.SetParameterValue("ReportName", rpname);//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(rPlant, rMfline, rMftable, rBegdate, rEnddate));//列印條件
            rp.SetParameterValue("ReportId", "mfr002");//程式編號            
            rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
        

        private string f_Cond(string rPlant, string rMfline, string rMftable, string rBegdate, string rEnddate)
        {
            string cond = "";
            cond += string.Format(" | 公司={0}", rPlant);

            if (!string.IsNullOrWhiteSpace(rMfline))
            {
                cond += string.Format(" | 生產線別={0}", rMfline);
            }
            if (!string.IsNullOrWhiteSpace(rMftable))
            {
                cond += string.Format(" | 炊台={0}", rMftable);
            }

            if (!string.IsNullOrWhiteSpace(rBegdate))
            {
                cond += string.Format(" | 生產日期(起)>={0}", rBegdate);
            }
            if (!string.IsNullOrWhiteSpace(rEnddate))
            {
                cond += string.Format(" | 生產日期(迄)<={0}", rEnddate);
            }
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        

        
        private void init_prno()
        {
            
            LPrno.Clear();
        }

        private void init_cdept()
        {
            
            LCdept.Clear();
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, " ");//清空預設日期
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, " ");//清空預設日期
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
                

    }
}
