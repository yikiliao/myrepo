using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using EMES.Models;

namespace EMES.Forms
{
    public partial class mfd000a : Form
    {        
        string Menu_Sel;
        string Dept = Login.DEPT;

        public string rPrno;//工號
        public bool rOK = false;//按下確認鍵

        public string rPlant;//部門
        public string rMfdate;//生產日
        public string rMfline;//生產線別
        //public string rMftable;//炊台
        //public string rWkno;//工單號
        //public Int32 rSeqno;//序號

        //private string dPlant;
        //private string dMfdate;        
        //public Int32 dSeqno;//序號


        public mfd000a(string Sel, string rPlant, string rMfdate, string rMfline)
        {
            InitializeComponent();
            FindControl(this);

            Config.SetFormSize(this, "F");
            Config.SetPer(this);

            InitColumn(this);
            set_dept();
            D_line();//生產線
            Config.FontBlod(this, true);//加粗體

            //新增時的處理
            if (Sel == "A")
            {
                Menu_Sel = "Add";
                SetColumn(this);//把欄位打開可以使用

                //給日期
                if (rMfdate != string.Empty)
                    f_sdate_s.Value = System.Convert.ToDateTime(rMfdate);
                else
                    f_sdate_s.Value = DateTime.Now;

                f_mfline.SelectedIndex = 0;
                //數字給零
                GNumberZero(this);
                //------
                f_mfdate.Select();
                f_mfdate.Focus();
            }

            //修改時的處理
            if (Sel == "U")
            {
                Menu_Sel = "Upd";
                SetColumn(this);//把欄位打開可以使用 

                //數字給零
                GNumberZero(this);
                Show_Form(rPlant, rMfdate, rMfline);//顯示畫面資料

                f_dept.Enabled = false;
                f_mfdate.Enabled = false;
                f_sdate_s.Enabled = false;
                f_mfline.Enabled = false;
                //------
                f_ta01.Select();
                f_ta01.Focus();
                
            }

            //顯示資料
            if (Sel == "S")
            {
                Menu_Sel = "See";               

                //數字給零
                GNumberZero(this);

                Show_Form(rPlant, rMfdate, rMfline);//顯示畫面資料
                confirm.Enabled = true;

                //欄位加粗
                Config.FontBlod(this, true);
            }


        }


        

        private void Show_Form(string rPlant, string rMfdate, string rMfline)
        {
            var p_mfplah = mfplah.Get(rPlant, rMfdate, rMfline);
            f_dept.SelectedValue = p_mfplah.Plant;
            f_mfdate.Text = p_mfplah.Mfdate;
            f_mfline.SelectedValue = p_mfplah.Mfline;

            f_ta01.Value = p_mfplah.Ta01;
            f_ta02.Value = p_mfplah.Ta02;
            f_ta03.Value = p_mfplah.Ta03;
            f_ta04.Value = p_mfplah.Ta04;
            f_ta05.Value = p_mfplah.Ta05;
            f_ta06.Text = p_mfplah.Ta06;
        }


        //private void Show_Form(string rPlant, string rMfdate, Int32 rSeqno)
        //{
        //    //找實際生產桶數及炊台資料                        
        //    var p_mfplan = mfplan.Get(rPlant, rMfdate, rSeqno);

        //    f_dept.SelectedValue = p_mfplan.Plant;
        //    f_mfdate.Text = p_mfplan.Mfdate;
        //    f_mfline.SelectedValue = p_mfplan.Mfline;
        //    f_mftable.SelectedValue = p_mfplan.Mftable;
        //    f_wkno.Text = p_mfplan.Wkno;
        //    f_workqty.Value = p_mfplan.Workqty;

        //    //工作桶數
        //    f_ta01.Value = p_mfplan.Tubno;
        //    f_ta02.Value = p_mfplan.Tubno_1;
        //    f_ta03.Value = p_mfplan.Tubno_2;
        //    f_ta04.Value = p_mfplan.Tubno_3;
        //    f_ta05.Value = p_mfplan.Tubno_4;
        //    f_tubno_5.Value = p_mfplan.Tubno_5;
        //    f_tubno_6.Value = p_mfplan.Tubno_6;
        //    f_tubno_memo.Text = p_mfplan.Tubno_memo;
        //    //切料尺寸
        //    f_cut_long.Value = p_mfplan.Cut_long;
        //    f_cut_width.Value = p_mfplan.Cut_width;

        //    //SP資料
        //    f_sp.Text = p_mfplan.Sp;
        //    f_cond.Text = p_mfplan.Cond;

        //    //模具資料
        //    f_ta_sfb02.Value = p_mfplan.Ta_sfb02;
        //    f_ta_sfb03.Value = p_mfplan.Ta_sfb03;
        //    f_ta_sfb04.Value = p_mfplan.Ta_sfb04;
        //    f_ta_sfb06.Value = p_mfplan.Ta_sfb06;
        //    f_ta_sfb07.Value = p_mfplan.Ta_sfb07;
        //    f_ta_sfb08.Value = p_mfplan.Ta_sfb08;


        //    if (p_mfplan.Wkno != "樣品")
        //    {
        //        //找工令相關資料顯示出來
        //        Get_WknoData(p_mfplan.Wkno);

        //        //找歷史生產紀錄
        //        History_p(f_wkno.Text);
        //    }

        //    confirm.Enabled = true;
        //    cancel.Enabled = true;
        //}

               

        //private void set_dept()
        //{
        //    //--廠部下拉選單
        //    f_dept.DataSource = sst011.ToDoList().ToList();
        //    f_dept.DisplayMember = "dept_name";
        //    f_dept.ValueMember = "dept";
        //}

        private void set_dept()
        {
            //--廠部下拉選單
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(Login.DEPT_NAME, Login.DEPT));
            f_dept.DisplayMember = "Key";
            f_dept.ValueMember = "Value";
            f_dept.DataSource = data;
        }

        //private void D_line()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("A 線", "A"));
        //    data.Add(new DictionaryEntry("B 線", "B"));
        //    data.Add(new DictionaryEntry("C 線", "C"));
        //    data.Add(new DictionaryEntry("D 線", "D"));
        //    f_mfline.DisplayMember = "Key";
        //    f_mfline.ValueMember = "Value";
        //    f_mfline.DataSource = data;
        //}

        //private void D_line()
        //{
        //    var iL = sst001.ToDoList().Where(a => a.Type == "A").ToList();
        //    f_mfline.DataSource = iL;
        //    f_mfline.ValueMember = "Code";
        //    f_mfline.DisplayMember = "Code_desc";
        //}
        private void D_line()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "A" && a.Dept == Login.DEPT).ToList();
            f_mfline.DataSource = iL;
            f_mfline.ValueMember = "Code";
            f_mfline.DisplayMember = "Code_desc";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                this.Close();
        }

        
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                SetColumn(a);
                if (a is TextBox)
                {
                    (a as TextBox).Text = "";
                    (a as TextBox).Enabled = true;
                    (a as TextBox).ReadOnly = false;
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Checked = false;
                    (a as RadioButton).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;
                }
            }            
        }

        //所有欄位限制並清空
        private void InitColumn(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                InitColumn(c);
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                    (c as TextBox).Enabled = false;
                    (c as TextBox).ReadOnly = true;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                    (c as RadioButton).Enabled = false;
                }
                if (c is  ComboBox)
                {   
                    (c as ComboBox).Enabled = false;
                }
                if (c is  Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Enabled = false;
                }
            }
        }

        //主板欄位限制
        private void InitMotherboard(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                InitMotherboard(c);
                if (c is TextBox)
                {
                    (c as TextBox).Enabled = false;
                    (c as TextBox).ReadOnly = true;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Enabled = false;
                }
            }
        }

        //主板欄位解除限制
        private void SetMotherboard(Control ctl_true)
        {  
            foreach (Control a in ctl_true.Controls)
            {   
                SetMotherboard(a);
                if (a is TextBox)
                {
                    (a as TextBox).Enabled = true;
                    (a as TextBox).ReadOnly = false;
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;
                }
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_Check() == false)
                        return;
                    try
                    {
                        Config.Show(String.Format("{0}", f_Insert()));
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
                        Config.Show(f_Update());
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

            //if (Menu_Sel == "Del")
            //{
            //    if (Config.Message("確定刪除?") == "Y")
            //    {
            //        try
            //        {
            //            Config.Show(f_Delete());
            //        }
            //        catch (Exception ex)
            //        {
            //            Config.Show(ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //    Close_Form();
            //}

            if (Menu_Sel == "See")
            {                
                Close_Form();
            }

        }

        private void Close_Form()
        {
            InitMotherboard(this);

            rPlant = f_dept.SelectedValue.ToString();//部門
            rMfdate = f_mfdate.Text;//生產日
            //rMfline = f_mfline.SelectedValue.ToString();//生產線別
                      
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }


        private bool f_Check()
        {
            if (f_mfdate.Text == String.Empty)
            {
                Config.Show("生產日期不可空白");
                f_mfdate.Focus();
                return false;
            }
            if (mfplah.Get(f_dept.SelectedValue.ToString(), f_mfdate.Text, f_mfline.SelectedValue.ToString()) != null)
            {
                Config.Show("已有此筆資料");
                f_mfdate.Focus();
                return false;
            }
                
            return true;
        }

        private string f_Insert()
        {
            return String.Format("{0}", f_Insert_1());
        }

        private string f_Insert_1()
        {
            var iPlant = f_dept.SelectedValue.ToString();
            var iMfdate = f_mfdate.Text;
            var iMfline = f_mfline.SelectedValue.ToString();
            var p_mfplah = new mfplah();
            p_mfplah.Plant = iPlant;
            p_mfplah.Mfdate = iMfdate;
            p_mfplah.Mfline = iMfline;
            
            p_mfplah.Ta01 = f_ta01.Value;
            p_mfplah.Ta02 = f_ta02.Value;
            p_mfplah.Ta03 = f_ta03.Value;
            p_mfplah.Ta04 = f_ta04.Value;
            p_mfplah.Ta05 = f_ta05.Value;
            p_mfplah.Ta06 = f_ta06.Text;
            return p_mfplah.Insert();
        }

        //private string f_Insert_1()
        //{
        //    var iPlant = f_dept.SelectedValue.ToString();
        //    var iMfdate = f_mfdate.Text;
        //    var iMfline = f_mfline.SelectedValue.ToString();
        //    var p_mfplan = new mfplan();
        //    p_mfplan.Plant = iPlant;
        //    p_mfplan.Mfdate = iMfdate;
        //    p_mfplan.Mfline = iMfline;
        //    p_mfplan.Seqno = mfplan.GetSeqNo(iPlant, iMfdate);
        //    p_mfplan.Mftable = f_mftable.SelectedValue.ToString();
        //    p_mfplan.Wkno = f_wkno.Text;
        //    p_mfplan.Tubno = f_ta01.Value;
        //    p_mfplan.Workqty = f_workqty.Value;
        //    p_mfplan.Ta_sfb02 = f_ta_sfb02.Value;
        //    p_mfplan.Ta_sfb03 = f_ta_sfb03.Value;
        //    p_mfplan.Ta_sfb04 = f_ta_sfb04.Value;
        //    p_mfplan.Ta_sfb06 = f_ta_sfb06.Value;
        //    p_mfplan.Ta_sfb07 = f_ta_sfb07.Value;
        //    p_mfplan.Ta_sfb08 = f_ta_sfb08.Value;

        //    p_mfplan.Sp = f_sp.Text;
        //    p_mfplan.Cond = f_cond.Text;
        //    p_mfplan.Tubno_1 = f_ta02.Value;
        //    p_mfplan.Tubno_2 = f_ta03.Value;
        //    p_mfplan.Tubno_3 = f_ta04.Value;
        //    p_mfplan.Tubno_4 = f_ta05.Value;
        //    p_mfplan.Tubno_5 = f_tubno_5.Value;
        //    p_mfplan.Tubno_6 = f_tubno_6.Value;

        //    p_mfplan.Cut_long = f_cut_long.Value;
        //    p_mfplan.Cut_width = f_cut_width.Value;
        //    p_mfplan.S_qty = 0;
        //    p_mfplan.Tubno_memo = f_tubno_memo.Text;
        //    return p_mfplan.Insert();
        //}


        private string f_Update()
        {
            return String.Format("{0}", f_Update_prt021());
        }

        private string f_Update_prt021()
        {
            var p_mfplah = new mfplah();
            p_mfplah.Plant = f_dept.SelectedValue.ToString();            
            p_mfplah.Mfdate = f_mfdate.Text;
            p_mfplah.Mfline = f_mfline.SelectedValue.ToString();

            p_mfplah.Ta01 = f_ta01.Value;
            p_mfplah.Ta02 = f_ta02.Value;
            p_mfplah.Ta03 = f_ta03.Value;
            p_mfplah.Ta04 = f_ta04.Value;
            p_mfplah.Ta05 = f_ta05.Value;
            p_mfplah.Ta06 = f_ta06.Text;
            return p_mfplah.Update(p_mfplah.Plant, p_mfplah.Mfdate, p_mfplah.Mfline);
        }

        

        private void GNumberZero(Control ctl_false)
        {
            //數字部分先給值再清為0,直接給0會空白...不知道甚麼原因            
            foreach (Control c in ctl_false.Controls)
            {
                GNumberZero(c);
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Value = 1;
                    (c as NumericUpDown).Value = 0;
                    (c as NumericUpDown).TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                }
            }
        }

        

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
        }

       
        //產生提示訊息
        private void confirm_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttTip = new ToolTip();
            ttTip.SetToolTip(confirm, "Escape");
        }

        private void cancel_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttTip = new ToolTip();
            ttTip.SetToolTip(cancel, "Delete");
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


        private void mfd001a_Load(object sender, EventArgs e)
        {
            FormRight();            
        }

        private void FormRight()
        {
            f_ta01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;            
        }

        private void FindControl(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                FindControl(c);
                if (c is TextBox)
                {
                    (c as TextBox).Click += new EventHandler(Control_GotFocus);
                    (c as TextBox).Enter += new EventHandler(Control_GotFocus);
                    (c as TextBox).Leave += new EventHandler(Control_LostFocus);
                }
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Click += new EventHandler(Control_GotFocus);
                    (c as NumericUpDown).Enter += new EventHandler(Control_GotFocus);
                    (c as NumericUpDown).Leave += new EventHandler(Control_LostFocus);
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Click += new EventHandler(Control_GotFocus);
                    (c as ComboBox).Enter += new EventHandler(Control_GotFocus);
                    (c as ComboBox).Leave += new EventHandler(Control_LostFocus);
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
    }
}
