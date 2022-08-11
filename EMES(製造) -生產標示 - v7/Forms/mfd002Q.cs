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

using EMES.Forms;
using EMES.Models;

namespace EMES.Forms
{
    public partial class mfd002Q : Form
    {
        public string DEPT = Login.DEPT;

        public string rPlant;//廠部
        public string rMline;//生產線
        public string rMtable;//炊台
        public string rBegdate;//生產日(起)
        public string rEnddate;//生產日(迄)

        public mfd002Q()
        {
            InitializeComponent();            
            Config.SetFormSize(this, "Q");            
            Config.SetPer(this);


            this.Text = this.Text + "--查詢視窗";
            initForm();// 初始畫面
        }
        
        

        private void button4_Click(object sender, EventArgs e)
        {
            initForm();
        }

        private void initForm()
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
        //    data.Add(new DictionaryEntry("小炊台", "小炊台"));
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

        private void but_OK_Click(object sender, EventArgs e)
        {
            rPlant = DEPT;
            rMline = f_mfline.SelectedValue == null ? "" : f_mfline.SelectedValue.ToString();//生產線
            rMtable = f_mftable.SelectedValue == null ? "" : f_mftable.SelectedValue.ToString();//炊台
            rBegdate = f_begdate.Text;
            rEnddate = f_enddate.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
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

        private void f_begdate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, f_begdate.Value.ToString("yyyy/MM/dd"));
            f_enddate.Text = f_begdate.Text;
        }

        private void f_enddate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, f_enddate.Value.ToString("yyyy/MM/dd"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, " ");//清空預設日期
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, " ");//清空預設日期
        }

        
    }
}
