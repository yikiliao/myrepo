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
    public partial class mfd002a : Form
    {        
        string Menu_Sel;
        string Dept = Login.DEPT;

        public string rPrno;//工號
        public bool rOK = false;//按下確認鍵

        public string rPlant;//部門
        public string rMfdate;//生產日
        public string rMfline;//生產線別
        public string rMftable;//炊台
        public string rWkno;//工單號
        public Int32 rSeqno;//序號

        private string dPlant;
        private string dMfdate;        
        public Int32 dSeqno;//序號

        

        public mfd002a(string Sel, string rPlant, string rMfdate, string rMfline, Int32 rSeqno)
        {
            InitializeComponent();
            FindControl(this);

            Config.SetFormSize(this, "F");
            Config.SetPer(this);

            InitColumn(this);
            set_dept();
            D_line();//生產線
            D_table();//炊台
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//dataGridView1 欄位靠右對齊
            
            //新增時的處理
            if (Sel == "A")
            {
                Menu_Sel = "Add";
                SetColumn(this);//把欄位打開可以使用

                Config.TextReadOnly(f_mfdate);
                Config.TextReadOnly(f_wkno);

                //生產日期
                if (rMfdate != string.Empty)
                {
                    f_sdate_s.Value = System.Convert.ToDateTime(rMfdate);
                    //生產線別
                    f_mfline.SelectedValue = rMfline;
                }
                else
                {
                    f_sdate_s.Value = DateTime.Now.AddDays(1);//製造日內定明天
                    //生產線別
                    f_mfline.SelectedIndex = 0;
                }

                //數字給零
                GNumberZero(this);

                //實際生產桶數
                f_tubno.Enabled = false;

                //欄位加粗
                Config.FontBlod(groupBox6, true);

                f_mfdate.Select();
                f_mfdate.Focus();
                
            }

            //刪除
            if (Sel == "D")
            {
                Menu_Sel = "Del";
                //--資料存起來
                dPlant = rPlant;
                dMfdate = rMfdate;
                dSeqno = rSeqno;

                //數字給零
                GNumberZero(this);

                Show_Form(dPlant, dMfdate, dSeqno);//顯示畫面資料
                //欄位加粗
                Config.FontBlod(this, true);
            }

            //修改
            if (Sel == "U")
            {
                Menu_Sel = "Upd";
                SetColumn(this);//把欄位打開可以使用
                //--資料存起來
                dPlant = rPlant;
                dMfdate = rMfdate;
                dSeqno = rSeqno;

                //數字給零
                GNumberZero(this);

                Show_Form(dPlant, dMfdate, dSeqno);//顯示畫面資料

                //---把不可修改的欄位禁止輸入
                f_dept.Enabled = false;
                f_mfdate.Enabled = false;
                f_sdate_s.Enabled = false;
                f_tubno.Enabled = false;
                f_mfline.Enabled = false;

                //欄位加粗
                Config.FontBlod(groupBox6, true);

                f_mftable.Select();
                f_mftable.Focus();
            }

            //顯示資料
            if (Sel == "S")
            {
                Menu_Sel = "See";
                //--資料存起來
                dPlant = rPlant;
                dMfdate = rMfdate;
                dSeqno = rSeqno;

                //數字給零
                GNumberZero(this);

                Show_Form(dPlant, dMfdate, dSeqno);//顯示畫面資料
                confirm.Enabled = false;

                //欄位加粗
                Config.FontBlod(this, true);
            }
        }


        private void Show_Form(string rPlant, string rMfdate, Int32 rSeqno)
        {
            //找實際生產桶數及炊台資料                        
            var p_mfplap = mfplap.Get(rPlant, rMfdate, rSeqno);

            f_dept.SelectedValue = p_mfplap.Plant;
            f_mfdate.Text = p_mfplap.Mfdate;
            f_mfline.SelectedValue = p_mfplap.Mfline;
            f_mftable.SelectedValue = p_mfplap.Mftable;
            f_wkno.Text = p_mfplap.Wkno;
            f_workqty.Value = p_mfplap.Workqty;

            //工作桶數
            f_tubno.Value = p_mfplap.Tubno;
            f_tubno_1.Value = p_mfplap.Tubno_1;
            f_tubno_2.Value = p_mfplap.Tubno_2;
            f_tubno_3.Value = p_mfplap.Tubno_3;
            f_tubno_4.Value = p_mfplap.Tubno_4;
            f_tubno_5.Value = p_mfplap.Tubno_5;
            f_tubno_6.Value = p_mfplap.Tubno_6;
            f_tubno_memo.Text = p_mfplap.Tubno_memo;
            //切料尺寸
            f_cut_long.Value = p_mfplap.Cut_long;
            f_cut_width.Value = p_mfplap.Cut_width;

            //SP資料
            f_sp.Text = p_mfplap.Sp;
            f_cond.Text = p_mfplap.Cond;

            //模具資料
            f_ta_sfb02.Value = p_mfplap.Ta_sfb02;
            f_ta_sfb03.Value = p_mfplap.Ta_sfb03;
            f_ta_sfb04.Value = p_mfplap.Ta_sfb04;
            f_ta_sfb06.Value = p_mfplap.Ta_sfb06;
            f_ta_sfb07.Value = p_mfplap.Ta_sfb07;
            f_ta_sfb08.Value = p_mfplap.Ta_sfb08;


            if (p_mfplap.Wkno != "樣品")
            {
                //找工令相關資料顯示出來
                Get_WknoData(p_mfplap.Wkno);

                //找歷史生產紀錄
                History_p(f_wkno.Text);
            }

            confirm.Enabled = true;
            cancel.Enabled = true;
        }

               

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
            var iL = sst100.ToDoList().Where(a => a.Type == "A" && a.Dept==Login.DEPT).ToList();
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
        //    f_mftable.DisplayMember = "Key";
        //    f_mftable.ValueMember = "Value";
        //    f_mftable.DataSource = data;
        //}


        //private void D_table()
        //{
        //    var iL = sst001.ToDoList().Where(a => a.Type == "B").ToList();
        //    f_mftable.DataSource = iL;
        //    f_mftable.ValueMember = "Code";
        //    f_mftable.DisplayMember = "Code_desc";
        //}

        private void D_table()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "B" && a.Dept == Login.DEPT).ToList();
            f_mftable.DataSource = iL;
            f_mftable.ValueMember = "Code";
            f_mftable.DisplayMember = "Code_desc";
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
            f_add_date.Enabled = false;
            f_add_user.Enabled = false;
            f_mod_date.Enabled = false;
            f_mod_user.Enabled = false;
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

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
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

        private void Close_Form()
        {
            InitMotherboard(this);

            rPlant = f_dept.SelectedValue.ToString();//部門
            rMfdate = f_mfdate.Text;//生產日
            rMfline = f_mfline.SelectedValue.ToString();//生產線別
            rMftable = f_mftable.SelectedValue.ToString();//炊台
            rSeqno = dSeqno;            
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }


        private bool f_Check()
        {
            rPlant = f_dept.SelectedValue.ToString();//部門
            rMfdate = f_mfdate.Text;//生產日
            rMfline = f_mfline.SelectedValue.ToString();//生產線別
            rMftable = f_mftable.SelectedValue.ToString();//炊台
            rSeqno = dSeqno;
            if (f_mfdate.Text == String.Empty)
            {
                Config.Show("生產日期不可空白");
                f_wkno.Focus();
                return false;
            }

            if (f_wkno.Text == String.Empty)
            {
                Config.Show("工單號碼不可空白");
                f_wkno.Focus();
                return false;
            }
            return true;
        }

        private string f_Insert()
        {
            return String.Format("實際排程{0}", f_Insert_1());
        }

        private string f_Insert_1()
        {
            var iPlant = f_dept.SelectedValue.ToString();
            var iMfdate = f_mfdate.Text;
            var iMfline = f_mfline.SelectedValue.ToString();
            var p_mfplap = new mfplap();
            p_mfplap.Plant = iPlant;
            p_mfplap.Mfdate = iMfdate;
            p_mfplap.Mfline = iMfline;
            p_mfplap.Seqno = mfplap.GetSeqNo(iPlant, iMfdate);
            p_mfplap.Mftable = f_mftable.SelectedValue.ToString();
            p_mfplap.Wkno = f_wkno.Text;
            p_mfplap.Tubno = f_tubno.Value;
            p_mfplap.Workqty = f_workqty.Value;
            p_mfplap.Ta_sfb02 = f_ta_sfb02.Value;
            p_mfplap.Ta_sfb03 = f_ta_sfb03.Value;
            p_mfplap.Ta_sfb04 = f_ta_sfb04.Value;
            p_mfplap.Ta_sfb06 = f_ta_sfb06.Value;
            p_mfplap.Ta_sfb07 = f_ta_sfb07.Value;
            p_mfplap.Ta_sfb08 = f_ta_sfb08.Value;

            p_mfplap.Sp = f_sp.Text;
            p_mfplap.Cond = f_cond.Text;
            p_mfplap.Tubno_1 = f_tubno_1.Value;
            p_mfplap.Tubno_2 = f_tubno_2.Value;
            p_mfplap.Tubno_3 = f_tubno_3.Value;
            p_mfplap.Tubno_4 = f_tubno_4.Value;
            p_mfplap.Tubno_5 = f_tubno_5.Value;
            p_mfplap.Tubno_6 = f_tubno_6.Value;

            p_mfplap.Cut_long = f_cut_long.Value;
            p_mfplap.Cut_width = f_cut_width.Value;
            p_mfplap.S_qty = 0;
            p_mfplap.Tubno_memo = f_tubno_memo.Text;
            return p_mfplap.Insert();
        }


        private string f_Update()
        {
            return String.Format("實際排程{0}", f_Update_prt021());
        }

        private string f_Update_prt021()
        {
            var p_mfplap = new mfplap();
            p_mfplap.Mfline = f_mfline.SelectedValue.ToString();
            p_mfplap.Mftable = f_mftable.SelectedValue.ToString();
            p_mfplap.Wkno = f_wkno.Text;

            p_mfplap.Tubno = f_tubno.Value;
            p_mfplap.Workqty = f_workqty.Value;
            //模具資料
            p_mfplap.Ta_sfb02 = f_ta_sfb02.Value;
            p_mfplap.Ta_sfb03 = f_ta_sfb03.Value;
            p_mfplap.Ta_sfb04 = f_ta_sfb04.Value;
            p_mfplap.Ta_sfb06 = f_ta_sfb06.Value;
            p_mfplap.Ta_sfb07 = f_ta_sfb07.Value;
            p_mfplap.Ta_sfb08 = f_ta_sfb08.Value;

            //SP資料
            p_mfplap.Sp = f_sp.Text;
            p_mfplap.Cond = f_cond.Text;

            //工作桶數
            p_mfplap.Tubno_1 = f_tubno_1.Value;
            p_mfplap.Tubno_2 = f_tubno_2.Value;
            p_mfplap.Tubno_3 = f_tubno_3.Value;
            p_mfplap.Tubno_4 = f_tubno_4.Value;
            p_mfplap.Tubno_5 = f_tubno_5.Value;
            p_mfplap.Tubno_6 = f_tubno_6.Value;
            p_mfplap.Tubno_memo = f_tubno_memo.Text;

            //切料尺寸
            p_mfplap.Cut_long = f_cut_long.Value;
            p_mfplap.Cut_width = f_cut_width.Value;

            return p_mfplap.Update(dPlant, dMfdate, dSeqno);
        }


        private string f_Delete()
        {
            return String.Format("實際排程{0}", f_Delete_prt021());
        }

        private string f_Delete_prt021()
        {   
            return new mfplap().Delete(dPlant, dMfdate, dSeqno);
        }


        private void f_prno_bt_Click(object sender, EventArgs e)
        {
            wWkno fm = new wWkno();//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_wkno.Text = fm.Code as string;

                if (f_wkno.Text != "樣品")
                {
                    //找相關資料顯示出來
                    Find_p(f_wkno.Text);

                    //找歷史生產紀錄
                    History_p(f_wkno.Text);
                }
                else
                {
                    Find_Sample(f_wkno.Text);
                }
                f_tubno_1.Select();
                f_tubno_1.Focus();
            }
        }


        private void Find_p(string Wkno)
        {
            //清欄位資料
            f_tubno_memo.Text = string.Empty;
            f_sp.Text = string.Empty;
            f_cond.Text = string.Empty;
            f_ta_sfb04.Value = 0;//上模厚
            f_ta_sfb02.Value = 0;//上模長
            f_ta_sfb03.Value = 0;//上模寬
            f_ta_sfb08.Value = 0;//下模厚
            f_ta_sfb06.Value = 0;//下模長
            f_ta_sfb07.Value = 0;//下模寬
            //----------
            
            var p_sfb_file = sfb_file.Get(Wkno);
            
            if (p_sfb_file == null)
            {
                Config.Show(string.Format("工單號碼:{0}\n工令主檔料無此資料", Wkno));
            }


            f_sfb223.Text = p_sfb_file.Sfb223;  //客戶編號
            f_occ02.Text = p_sfb_file.Occ02;    //客戶名稱
            f_ima01.Text = p_sfb_file.Sfb05;    //料號
            f_ima02.Text = p_sfb_file.Ima02;    //品名
            f_ima021.Text = p_sfb_file.Ima021;  //規格
            f_sfb81.Text = p_sfb_file.Sfb81;    //開單日期

            f_ta_sfb17.Value = p_sfb_file.Ta_sfb17; //原床厚度_mm
            f_sfb08.Value = p_sfb_file.Sfb08;       //生產數量
            f_ta_sfb19.Value = p_sfb_file.Ta_sfb19; //預計生產桶數
            f_ta_sfb20.Value = p_sfb_file.Ta_sfb20; //每桶重量

            //-----------------------------
            f_tubno_1.Value = p_sfb_file.Ta_sfb19 - mfplap.TToDoList(f_dept.SelectedValue.ToString(), "", "", "").Where(m => m.Wkno == Wkno).Sum(m => m.Tubno);   // 工作桶數 = 預計生產桶數-歷史合計工作桶數
            f_workqty.Value = p_sfb_file.Sfb08; //實際生產數量 內定跟生產數量相同

            f_ta_sfb04.Value = p_sfb_file.Ta_sfb04;//上模厚
            f_ta_sfb02.Value = p_sfb_file.Ta_sfb02;//上模長
            f_ta_sfb03.Value = p_sfb_file.Ta_sfb03;//上模寬
            f_ta_sfb08.Value = p_sfb_file.Ta_sfb08;//下模厚
            f_ta_sfb06.Value = p_sfb_file.Ta_sfb06;//下模長
            f_ta_sfb07.Value = p_sfb_file.Ta_sfb07;//下模寬
            f_cond.Text = p_sfb_file.Ima02;// 品名=生產條件
            //-----------------------------

            
            //設不可作用
            f_sfb223.Enabled = false;  //客戶編號
            f_occ02.Enabled = false;    //客戶名稱
            f_ima01.Enabled = false;    //料號
            f_ima02.Enabled = false;    //品名
            f_ima021.Enabled = false;  //規格
            f_sfb81.Enabled = false;    //開單日期

            f_ta_sfb17.Enabled = false; //原床厚度_mm
            f_sfb08.Enabled = false;    //生產數量
            f_ta_sfb19.Enabled = false; //預計生產桶數
            f_ta_sfb20.Enabled = false; //每桶重量
        }

        private void History_p(string Wkno)
        {
            string gPlant = f_dept.SelectedValue.ToString();
            string gWkno = Wkno;

            var _p = mfplap.TToDoList(gPlant, "", "", "").Where(m => m.Wkno == gWkno).ToList();
            bindingSource1.Clear();
            foreach (var i in _p.ToList())
            {
                mfplap a_mfplap = new mfplap();              

                a_mfplap.Mfdate = i.Mfdate;
                a_mfplap.Mfline = i.Mfline;
                a_mfplap.Mftable = i.Mftable;                
                a_mfplap.Tubno = i.Tubno;
                bindingSource1.Add(a_mfplap);
            };
        }

        private void Find_Sample(string Wkno)
        {            
            f_tubno_memo.Text = "MISC";//備註
            f_sp.Text = string.Empty; //SP
            f_cond.Text = string.Empty;//條件

            //清資料
            f_sfb223.Text = string.Empty;  //客戶編號
            f_occ02.Text = string.Empty;    //客戶名稱
            f_ima01.Text = string.Empty;    //料號
            f_ima02.Text = string.Empty;    //品名
            f_ima021.Text = string.Empty;  //規格
            f_sfb81.Text = string.Empty;    //開單日期
            f_ta_sfb17.Value = 0;           //厚度(mm)
            f_sfb08.Value = 0;              //生產數量
            f_ta_sfb19.Value = 0;           //預計生產桶數
            f_ta_sfb20.Value = 0;           //每桶重量

            //模具上下模資料
            f_ta_sfb02.Value = 0;
            f_ta_sfb03.Value = 0;
            f_ta_sfb04.Value = 0;
            f_ta_sfb06.Value = 0;
            f_ta_sfb07.Value = 0;
            f_ta_sfb08.Value = 0;
            //-------------
            
            //設不可作用
            f_sfb223.Enabled = false;  //客戶編號
            f_occ02.Enabled = false;    //客戶名稱
            f_ima01.Enabled = false;    //料號
            f_ima02.Enabled = false;    //品名
            f_ima021.Enabled = false;  //規格
            f_sfb81.Enabled = false;    //開單日期
            f_ta_sfb17.Enabled = false; //原床厚度_mm
            f_sfb08.Enabled = false;    //生產數量
            f_ta_sfb19.Enabled = false; //預計生產桶數
            f_ta_sfb20.Enabled = false; //每桶重量

            //清歷史資料
            bindingSource1.Clear();
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
                }
            }
        }


        private void Get_WknoData(string Wkno)
        {
            var p_sfb_file = sfb_file.Get(Wkno);            

            if (p_sfb_file == null)
            {
                Config.Show(string.Format("工單號碼:{0}\n工令主檔料無此資料", Wkno));
            }


            f_sfb223.Text = p_sfb_file.Sfb223;  //客戶編號
            f_occ02.Text = p_sfb_file.Occ02;    //客戶名稱
            f_ima01.Text = p_sfb_file.Sfb05;    //料號
            f_ima02.Text = p_sfb_file.Ima02;    //品名
            f_ima021.Text = p_sfb_file.Ima021;  //規格
            f_sfb81.Text = p_sfb_file.Sfb81;    //開單日期

            f_ta_sfb17.Value = p_sfb_file.Ta_sfb17; //原床厚度_mm
            f_sfb08.Value = p_sfb_file.Sfb08;       //生產數量
            f_ta_sfb19.Value = p_sfb_file.Ta_sfb19; //預計生產桶數
            f_ta_sfb20.Value = p_sfb_file.Ta_sfb20; //每桶重量
            

            //設不可作用
            f_sfb223.Enabled = false;  //客戶編號
            f_occ02.Enabled = false;    //客戶名稱
            f_ima01.Enabled = false;    //料號
            f_ima02.Enabled = false;    //品名
            f_ima021.Enabled = false;  //規格
            f_sfb81.Enabled = false;    //開單日期

            f_ta_sfb17.Enabled = false; //原床厚度_mm
            f_sfb08.Enabled = false;    //生產數量
            f_ta_sfb19.Enabled = false; //預計生產桶數
            f_ta_sfb20.Enabled = false; //每桶重量
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

        

        private void f_sum(object sender, EventArgs e)
        {
            f_tubno.Value = 0;
            f_tubno.Value = f_tubno_1.Value + f_tubno_2.Value + f_tubno_3.Value + f_tubno_4.Value + f_tubno_5.Value + f_tubno_6.Value;
        }

        

        private void mfd001a_Load(object sender, EventArgs e)
        {
            FormRight();            
        }

        private void FormRight()
        {
            f_tubno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tubno_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tubno_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tubno_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tubno_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tubno_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tubno_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            f_workqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_cut_long.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_cut_width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            f_ta_sfb02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            f_ta_sfb17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_sfb08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_ta_sfb20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        }


        private void Control_Click(object sender, EventArgs e)
        {
            Config.Control_Click(sender, e);
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            Config.Control_Leave(sender, e);
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
