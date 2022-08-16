using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using EVAERP.Models;

namespace EVAERP.Forms
{
    public partial class pri023 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt016> LS1 = new List<prt016>();
        prt028 p_prt0028 = new prt028();
        prt016 p_prt016 = new prt016();
        Int32 Spec_year = 0;
        Int32 Spec_mon = 0;
        DateTime o_in_date;
        string DataRang;//處理廠部範圍

        public pri023()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);//初始
            DataRang = sst901.Get(Home.Id).Rang;
            D_Sex();//性別下拉選單
            D_Blood();//血型下拉選單
            D_Meery();//婚姻下拉選單
            D_Pr_direct_type();//支薪代碼
            D_Pr_slry_type();//薪資種類
            D_Direct_type1();//成本直間接
            D_Direct_type2();//會計直間接
        }

        private void D_Sex()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("男", "M"));
            data.Add(new DictionaryEntry("女", "F"));
            f_pr_sex.DisplayMember = "Key";
            f_pr_sex.ValueMember = "Value";
            f_pr_sex.DataSource = data;
        }
        private void D_Blood()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("A型", "A"));
            data.Add(new DictionaryEntry("B型", "B"));
            data.Add(new DictionaryEntry("O型", "O"));
            data.Add(new DictionaryEntry("AB型", "AB"));
            //data.Add(new DictionaryEntry("RH+型", "RH+"));
            //data.Add(new DictionaryEntry("RH-型", "RH-"));
            f_pr_blood.DisplayMember = "Key";
            f_pr_blood.ValueMember = "Value";
            f_pr_blood.DataSource = data;
        }
        private void D_Meery()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("未婚", "N"));
            data.Add(new DictionaryEntry("已婚", "M"));
            f_pr_merry.DisplayMember = "Key";
            f_pr_merry.ValueMember = "Value";
            f_pr_merry.DataSource = data;
        }

        private void D_Pr_direct_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("間接(月)", "I"));
            data.Add(new DictionaryEntry("直接(日)", "E"));
            f_pr_direct_type.DisplayMember = "Key";
            f_pr_direct_type.ValueMember = "Value";
            f_pr_direct_type.DataSource = data;
        }

        private void D_Pr_slry_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("月薪", "M"));
            data.Add(new DictionaryEntry("日薪", "D"));
            data.Add(new DictionaryEntry("計件", "P"));
            f_pr_slry_type.DisplayMember = "Key";
            f_pr_slry_type.ValueMember = "Value";
            f_pr_slry_type.DataSource = data;
        }

        private void D_Direct_type1()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("直接 ", "1"));
            data.Add(new DictionaryEntry("間接", "2"));
            data.Add(new DictionaryEntry("管理", "21"));
            data.Add(new DictionaryEntry("製造", "22"));
            data.Add(new DictionaryEntry("銷售", "23"));
            f_direct_type1.DisplayMember = "Key";
            f_direct_type1.ValueMember = "Value";
            f_direct_type1.DataSource = data;
        }

        private void D_Direct_type2()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("直接 ", "1"));
            data.Add(new DictionaryEntry("間接", "2"));
            f_direct_type2.DisplayMember = "Key";
            f_direct_type2.ValueMember = "Value";
            f_direct_type2.DataSource = data;
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            //Menu_Sel = "Add";
            //SetColumn(this);
            //f_pr_company.Enabled = false;
            //f_pr_dept.Enabled = false;
            //f_pr_dept_name.Enabled = false;
            //f_pr_schl.Enabled = false;
            //f_pr_schl_name.Enabled = false;
            //f_pr_long.Enabled = false;
            //f_pr_long_name.Enabled = false;
            //f_pr_work.Enabled = false;
            //f_pr_work_name.Enabled = false;
            //f_position.Enabled = false;
            //f_position_name.Enabled = false;
            //f_pr_cdept.Enabled = false;
            //f_pr_cdept_name.Enabled = false;
            //f_pr_wk_cdept.Enabled = false;
            //f_pr_wk_cdept_name.Enabled = false;
            //f_pr_clas_code.Enabled = false;
            //f_pr_clas_code_name.Enabled = false;
            //f_bank_code.Enabled = false;
            //f_bank_code_name.Enabled = false;
            //f_pr_spec_yearpay.Text = "0";
            //f_pr_spec_monthpay.Text = "0";
            //f_pr_live_pr.Text = "0";
            //f_wk_code.Text = "0";
            //f_pr_leave_date.Enabled = false;
            //f_pr_back_insr_date.Enabled = false;

            //f_pr_no.Text = "--系統給號--";
            //f_pr_no.Enabled = false;
            //Config.Set_DateTo(f_pr_birth_date, "1900/01/01");
            //Config.Set_DateTo(f_pr_in_date, DateTime.Now.ToString("yyyy/MM/dd"));
            //Config.Set_DateTo(f_pr_insr_date, DateTime.Now.ToString("yyyy/MM/dd"));
            //Config.Set_DateTo(f_pr_leave_date, " ");
            //Config.Set_DateTo(f_pr_back_insr_date, " ");
            ////下拉選單
            //f_pr_sex.SelectedIndex = 1;
            //f_pr_blood.SelectedIndex = 1;
            //f_pr_merry.SelectedIndex = 1;
            //f_pr_direct_type.SelectedIndex = 1;
            //f_pr_direct_type.SelectedIndex = 1;
            //f_pr_slry_type.SelectedIndex = 1;
            //f_direct_type1.SelectedIndex = 1;
            //f_direct_type2.SelectedIndex = 1;

        }

        
                

        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
        }
                

        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                if (a is Panel) SetColumn(a);
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
                if (c is Panel) InitColumn(c);
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
            }
            
        }

        //主板欄位限制
        private void InitMotherboard(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                if (c is Panel) InitMotherboard(c);
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
            }
           
        }

        //主板欄位解除限制
        private void SetMotherboard(Control ctl_true)
        {  
            foreach (Control a in ctl_true.Controls)
            {   
                if (a is Panel) SetMotherboard(a);
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
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            //if (Menu_Sel == "Add")
            //{
            //    if (Config.Message("確定新增?") == "Y")
            //    {   
            //        if (f_Check() == false)
            //            return;
            //        try
            //        {   
            //            Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Insert(),f_pr_no.Text, f_pr_name.Text));
            //        }
            //        catch (Exception ex)
            //        {
            //            Config.Show(ex.Message);
            //        }
            //    }
            //    InitMotherboard(Motherboard);
            //}

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定復職?") == "Y")
                {
                    try
                    {                        
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Update(), f_pr_no.Text, f_pr_name.Text));
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(Motherboard);
            }

        }


        //private bool f_Check()
        //{
        //    if (f_pr_dept.Text  == System.String.Empty)
        //    {
        //        Config.Show("廠部不可空白");
        //        f_pr_dept.Focus();
        //        return false;
        //    }
        //    if (f_pr_no.Text == System.String.Empty)
        //    {
        //        Config.Show("員工編號不可空白");
        //        f_pr_no.Focus();
        //        return false;
        //    }
        //    if (f_pr_name.Text == System.String.Empty)
        //    {
        //        Config.Show("姓名不可空白");
        //        f_pr_name.Focus();
        //        return false;
        //    }
        //    if (f_pr_idno.Text  == System.String.Empty)
        //    {
        //        Config.Show("身分證號不可空白");
        //        f_pr_idno.Focus();
        //        return false;
        //    }
        //    if (f_pr_company.Text != "S" && f_pr_company.Text != "6")
        //    {
        //        Config.Show("公司別不符合定義");
        //        f_pr_company.Focus();
        //        return false;
        //    }

        //    if (prt016.GetWithIdno(f_pr_idno.Text) != null)
        //    {
        //        Config.Show("已有此筆資料-相同ID證號\n請用復職作業");
        //        f_pr_idno.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        //private string f_Insert()
        //{
        //    return String.Format("{0}\n{1}\n{2}\n{3}", f_Insert_prt016(), f_Insert_prt027(), f_Insert_prt028(), f_Insert_prt029());
        //}

        /// <summary>
        /// 改prt016人是基本檔資料,寫入prt027異動檔,修改prt029 假別檔
        /// </summary>
        /// <returns></returns>
        private string f_Update()
        {
            return String.Format("{0}\n{1}\n{2}", f_Update_prt016(), f_Insert_prt027(),f_Insert_prt029());
        }


        private string f_Update_prt016()
        {
            var p_prt016 = new prt016();
            Get_Spec();
            p_prt016.Pr_no = f_pr_no.Text;
            p_prt016.Pr_company = f_pr_company.Text;
            p_prt016.Pr_dept = f_pr_dept.Text;
            p_prt016.Pr_cdept = f_pr_cdept.Text;
            p_prt016.Pr_wk_cdept = f_pr_wk_cdept.Text;
            p_prt016.Pr_name = f_pr_name.Text;
            p_prt016.Wk_code = f_wk_code.Text;
            p_prt016.Pr_work = f_pr_work.Text;
            p_prt016.Position = f_position.Text;
            p_prt016.Pr_idno = f_pr_idno.Text;
            p_prt016.Pr_sex = f_pr_sex.SelectedValue.ToString();
            p_prt016.Pr_blood = f_pr_blood.SelectedValue.ToString();
            p_prt016.Pr_merry = f_pr_merry.SelectedValue.ToString();
            p_prt016.Pr_local = f_pr_local.Text;
            p_prt016.Pr_clas_code = f_pr_clas_code.Text;
            p_prt016.Pr_schl = f_pr_schl.Text;
            p_prt016.Pr_long = f_pr_long.Text;
            p_prt016.Pr_spec_yearpay = Spec_year;
            p_prt016.Pr_spec_monthpay = Spec_mon;
            p_prt016.Pr_tel_no = f_pr_tel_no.Text;
            p_prt016.Pr_in_date = f_pr_in_date.Text;
            p_prt016.Pr_insr_date = f_pr_insr_date.Text;
            p_prt016.Pr_direct_type = f_pr_direct_type.SelectedValue.ToString();
            p_prt016.Pr_slry_type = f_pr_slry_type.SelectedValue.ToString();
            p_prt016.Bank_code = f_bank_code.Text;
            p_prt016.Account_no = f_account_no.Text;
            p_prt016.Pr_local_addr = f_pr_local_addr.Text;
            p_prt016.Pr_comm_addr = f_pr_comm_addr.Text;
            p_prt016.Pr_live_pr = Int32.Parse(f_pr_live_pr.Text);
            p_prt016.Pr_comm_man = f_pr_comm_man.Text;
            p_prt016.Pr_comm_tel_no = f_pr_comm_tel_no.Text;
            p_prt016.Pr_comm_relative = f_pr_comm_relative.Text;
            p_prt016.Direct_type1 = f_direct_type1.SelectedValue.ToString();
            p_prt016.Direct_type2 = f_direct_type2.SelectedValue.ToString();
            p_prt016.Pr_birth_date = f_pr_birth_date.Text;
            p_prt016.Pr_leave_date = null;
            return p_prt016.Update(p_prt016.Pr_no);
        }

        private void Get_Spec()
        {
            Int32 sy1, sy2, sm1, sm2, sd1, sd2, cls_yn = 0;

            sy1 = f_pr_in_date.Value.Year;
            sm1 = f_pr_in_date.Value.Month;
            sd1 = f_pr_in_date.Value.Day;

            sy2 = o_in_date.Year;
            sm2 = o_in_date.Month;
            sd2 = o_in_date.Day;

            if (sd1 < sd2)
            {
                sd1 = sd1 + 30;
                sm1 = sm1 - 1;
            }
            if (sm1 < sm2)
            {
                sm1 = sm1 + 12;
                sy1 = sy1 - 1;
            }

            cls_yn = (sy1 - sy2) * 12 + (sm1 - sm2) + (sd1 - sd2) / 30;
            if (cls_yn > 3)
                Spec_year = 0; Spec_mon = 0;
        }

        //private string f_Update_prt028()
        //{   
        //    if ( prt028.Get(f_pr_no.Text) !=null)
        //    {
        //        Set_prt028();
        //        return p_prt0028.Update(f_pr_no.Text);
        //    }
        //    else
        //    {                
        //        return f_Insert_prt028();
        //    }
        //}

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_in_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_insr_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_leave_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_back_insr_date, " ");//清空預設日期
            //下拉選單
            f_pr_sex.SelectedIndex = 0;
            f_pr_blood.SelectedIndex = 0;
            f_pr_merry.SelectedIndex = 0;
            f_pr_direct_type.SelectedIndex = 0;
            f_pr_direct_type.SelectedIndex = 0;
            f_pr_slry_type.SelectedIndex = 0;
            f_direct_type1.SelectedIndex = 0;
            f_direct_type2.SelectedIndex = 0;
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt016.ToDoList(f_pr_dept.Text, f_pr_no.Text, f_pr_name.Text,f_pr_idno.Text,DataRang,"L").ToList();
            if (LS1.Count() == 0)
            {
                Config.Show("無符合資料");
                return;
            }
            else
            {
                i = 0;
                f_show(i);
            }
        }

        private void f_show(int idx)
        {
            if (idx < 0 || idx > LS1.Count - 1)
            {
                Config.Show("已無資料");
            }
            else
            {
                f_pr_no.Text = LS1[idx].Pr_no;
                f_pr_name.Text = LS1[idx].Pr_name;
                f_pr_company.Text = LS1[idx].Pr_company;
                f_pr_dept.Text = LS1[idx].Pr_dept;
                f_pr_dept_name.Text = sst012.Get(LS1[idx].Pr_dept)== null ? "" : sst012.Get(LS1[idx].Pr_dept).Dept_name;
                f_pr_cdept.Text = LS1[idx].Pr_cdept;
                f_pr_cdept_name.Text = prt001.Get(LS1[idx].Pr_dept, LS1[idx].Pr_cdept) == null ? "" : prt001.Get(LS1[idx].Pr_dept,LS1[idx].Pr_cdept).Department_name_new;
                f_pr_wk_cdept.Text = LS1[idx].Pr_wk_cdept;
                f_pr_wk_cdept_name.Text = prt001.Get(LS1[idx].Pr_dept, LS1[idx].Pr_wk_cdept) == null ? "" : prt001.Get(LS1[idx].Pr_dept, LS1[idx].Pr_wk_cdept).Department_name_new;
                f_wk_code.Text = LS1[idx].Wk_code;
                f_pr_work.Text = LS1[idx].Pr_work;
                f_pr_work_name.Text = prt003.Get(LS1[idx].Pr_work) == null ? "" : prt003.Get(LS1[idx].Pr_work).Code_desc;
                f_position.Text = LS1[idx].Position;
                f_position_name.Text = prt002.Get(LS1[idx].Position) == null ? "" : prt002.Get(LS1[idx].Position).Code_desc;
                f_pr_idno.Text = LS1[idx].Pr_idno;
                f_pr_sex.SelectedValue = LS1[idx].Pr_sex;
                f_pr_blood.SelectedValue = LS1[idx].Pr_blood;
                f_pr_merry.SelectedValue = LS1[idx].Pr_merry;
                f_pr_local.Text = LS1[idx].Pr_local;
                f_pr_clas_code.Text = LS1[idx].Pr_clas_code;
                f_pr_clas_code_name.Text = prt006.Get(f_pr_dept.Text, "CL", LS1[idx].Pr_clas_code) == null ? "" : prt006.Get(f_pr_dept.Text, "CL", LS1[idx].Pr_clas_code).Code_desc;
                f_pr_schl.Text = LS1[idx].Pr_schl;
                f_pr_schl_name.Text = prt006.Get(f_pr_dept.Text, "SC", LS1[idx].Pr_schl) == null ? "" : prt006.Get(f_pr_dept.Text, "SC", LS1[idx].Pr_schl).Code_desc;
                f_pr_long.Text = LS1[idx].Pr_long;
                f_pr_long_name.Text = prt006.Get(f_pr_dept.Text, "LG", LS1[idx].Pr_long) == null ? "" : prt006.Get(f_pr_dept.Text, "LG", LS1[idx].Pr_long).Code_desc;
                f_pr_spec_yearpay.Text = LS1[idx].Pr_spec_yearpay.ToString();
                f_pr_spec_monthpay.Text = LS1[idx].Pr_spec_monthpay.ToString();
                f_pr_tel_no.Text = LS1[idx].Pr_tel_no;
                
                f_pr_direct_type.SelectedValue = LS1[idx].Pr_direct_type;
                f_pr_slry_type.SelectedValue = LS1[idx].Pr_slry_type;
                f_bank_code.Text = LS1[idx].Bank_code;
                f_bank_code_name.Text = Get_bank_name(f_pr_dept.Text, f_bank_code.Text);
                f_account_no.Text = LS1[idx].Account_no;
                f_pr_local_addr.Text = LS1[idx].Pr_local_addr;
                f_pr_comm_addr.Text = LS1[idx].Pr_comm_addr;
                f_pr_comm_man.Text = LS1[idx].Pr_comm_man;
                f_pr_comm_tel_no.Text = LS1[idx].Pr_comm_tel_no;
                f_pr_comm_relative.Text = LS1[idx].Pr_comm_relative;
                f_direct_type1.SelectedValue = LS1[idx].Direct_type1;
                f_direct_type2.SelectedValue = LS1[idx].Direct_type2;
                f_pr_live_pr.Text = LS1[idx].Pr_live_pr.ToString();
                f_add_date.Text = LS1[idx].Add_date.ToString();
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = LS1[idx].Mod_date.ToString();
                f_mod_user.Text = LS1[idx].Mod_user.Trim();

                Config.Set_DateTo(f_pr_birth_date, LS1[idx].Pr_birth_date.ToString());
                Config.Set_DateTo(f_pr_in_date, LS1[idx].Pr_in_date.ToString());
                Config.Set_DateTo(f_pr_insr_date, LS1[idx].Pr_insr_date.ToString());
                Config.Set_DateTo(f_pr_leave_date, LS1[idx].Pr_leave_date.ToString());
                Config.Set_DateTo(f_pr_back_insr_date, LS1[idx].Pr_back_insr_date.ToString());
            }
        }

        //銀行名稱
        private string Get_bank_name(string Dept, string Bank_code)
        {   
            var _name = "";
            var Country_code = "TW";
            if (Dept.Trim() != "W")
                Country_code = "CN";
            if (ntt001.Get(Country_code, Bank_code, Bank_code) != null)
                _name = ntt001.Get(Country_code, Bank_code, Bank_code).Bank_name;
            return _name;
        }



        private void menu_first_Click(object sender, EventArgs e)
        {
            i = 0;
            f_show(i);
        }

        private void menu_previous_Click(object sender, EventArgs e)
        {
            i = i - 1;
            f_show(i);
            if (i < 0) i = 0;
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            i = i + 1;
            f_show(i);
            if (i > LS1.Count - 1) i = LS1.Count - 1;
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            i = LS1.Count() - 1;
            f_show(i);
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
                f_pr_dept.Enabled = false;
                f_pr_dept_name.Enabled = false;
                f_pr_schl.Enabled = false;
                f_pr_schl_name.Enabled = false;
                f_pr_long.Enabled = false;
                f_pr_long_name.Enabled = false;
                f_pr_work.Enabled = false;
                f_pr_work_name.Enabled = false;
                f_position.Enabled = false;
                f_position_name.Enabled = false;
                f_pr_cdept.Enabled = false;
                f_pr_cdept_name.Enabled = false;
                f_pr_wk_cdept.Enabled = false;
                f_pr_wk_cdept_name.Enabled = false;
                f_pr_clas_code.Enabled = false;
                f_pr_clas_code_name.Enabled = false;
                f_bank_code.Enabled = false;
                f_bank_code_name.Enabled = false;
                code_dearch_bt.Enabled = false;
                f_pr_no.Enabled = false;
                f_pr_company.Enabled = false;

                o_in_date = f_pr_in_date.Value;

                f_pr_in_date.Value = DateTime.Now;
                f_pr_insr_date.Value = DateTime.Now;

                f_pr_leave_date.Enabled = false;
                f_pr_back_insr_date.Enabled = false;
                f_pr_name.Enabled = false;
                f_pr_idno.Enabled = false;
                f_wk_code.Focus();
            }
            else
            {
                Config.Show("請先查詢");
            }
        }
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            ssi012w fm = new ssi012w(DataRang);//廠部窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_dept.Text = fm.Code as string;
                f_pr_dept_name.Text = fm.Code_dsec as string;
                f_pr_company.Text = fm.Company as string;
            }
        }
                       

        private void f_pr_schl_bt_Click(object sender, EventArgs e)
        {
            pri006w fm = new pri006w(f_pr_dept.Text,"SC");//學歷視窗
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_schl.Text = fm.Code as string;
                f_pr_schl_name.Text = fm.Code_desc as string;
            }
        }

        private void f_pr_long_bt_Click(object sender, EventArgs e)
        {
            pri006w fm = new pri006w(f_pr_dept.Text,"LG");//專長視窗
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_long.Text = fm.Code as string;
                f_pr_long_name.Text = fm.Code_desc as string;
            }
        }

        private void f_pr_work_bt_Click(object sender, EventArgs e)
        {   
            pri006w fm = new pri006w(f_pr_dept.Text, "WK");//職稱視窗
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_work.Text = fm.Code as string;
                f_pr_work_name.Text = fm.Code_desc as string;
            }
        }

        private void f_position_bt_Click(object sender, EventArgs e)
        {
            pri006w fm = new pri006w(f_pr_dept.Text, "WT");//職位視窗
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_position.Text = fm.Code as string;
                f_position_name.Text = fm.Code_desc as string;
            }
        }

        private void f_pr_cdept_bt_Click(object sender, EventArgs e)
        {            
            pri001w fm = new pri001w(f_pr_dept.Text);//部門
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_cdept.Text = fm.Code as string;
                f_pr_cdept_name.Text = fm.Code_desc as string;
            }
        }

        private void f_pr_wk_cdept_bt_Click(object sender, EventArgs e)
        {            
            pri001w fm = new pri001w(f_pr_dept.Text);//部門
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_wk_cdept.Text = fm.Code as string;
                f_pr_wk_cdept_name.Text = fm.Code_desc as string;
            }
        }

        private void f_pr_clas_code_bt_Click(object sender, EventArgs e)
        {
            pri006w fm = new pri006w(f_pr_dept.Text,"CL");//班別視窗
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_clas_code.Text = fm.Code as string;
                f_pr_clas_code_name.Text = fm.Code_desc as string;
            }
        }

        private void f_bank_code_bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(f_pr_dept.Text))
            {
                var country_code = "TW";
                if (f_pr_dept.Text != "W")
                    country_code = "CN";
                nti001w fm = new nti001w(country_code);//銀行代碼視窗
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    f_bank_code.Text = fm.Code as string;
                    f_bank_code_name.Text = fm.Code_desc as string;
                }
            }
        }

        private void f_pr_spec_yearpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 49 || (byte)e.KeyChar > 57 || (byte)e.KeyChar > 127)//若小於0或大於或中文
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true;//不接受字元
                }
            }
        }

        private void pri019_Load(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_in_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_insr_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_leave_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_back_insr_date, " ");//清空預設日期
        }

        //入廠日
        private void f_pr_in_date_ValueChanged(object sender, EventArgs e)
        {            
            Config.Set_DateTo(f_pr_in_date, f_pr_in_date.Value.ToString("yyyy/MM/dd"));
            f_pr_insr_date.Value = f_pr_in_date.Value;
        }

        //入保日
        private void f_pr_insr_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_insr_date, f_pr_insr_date.Value.ToString("yyyy/MM/dd"));
        }

        //出生日
        private void f_pr_birth_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_birth_date, f_pr_birth_date.Value.ToString("yyyy/MM/dd"));
        }


        //private string f_Insert_prt016()
        //{
        //    var p_prt016 = new prt016();
        //    f_pr_no.Text = prt016.GetPrNo(f_pr_company.Text);
        //    p_prt016.Pr_no = f_pr_no.Text;
        //    p_prt016.Pr_company = f_pr_company.Text;
        //    p_prt016.Pr_dept = f_pr_dept.Text;
        //    p_prt016.Pr_cdept = f_pr_cdept.Text;
        //    p_prt016.Pr_wk_cdept = f_pr_wk_cdept.Text;
        //    p_prt016.Pr_name = f_pr_name.Text;
        //    p_prt016.Wk_code = f_wk_code.Text;
        //    p_prt016.Pr_work = f_pr_work.Text;
        //    p_prt016.Position = f_position.Text;
        //    p_prt016.Pr_idno = f_pr_idno.Text;
        //    p_prt016.Pr_sex = f_pr_sex.SelectedValue.ToString();
        //    p_prt016.Pr_blood = f_pr_blood.SelectedValue.ToString();
        //    p_prt016.Pr_merry = f_pr_merry.SelectedValue.ToString();
        //    p_prt016.Pr_local = f_pr_local.Text;
        //    p_prt016.Pr_clas_code = f_pr_clas_code.Text;
        //    p_prt016.Pr_schl = f_pr_schl.Text;
        //    p_prt016.Pr_long = f_pr_long.Text;
        //    p_prt016.Pr_spec_yearpay = Int32.Parse(f_pr_spec_yearpay.Text);
        //    p_prt016.Pr_spec_monthpay = Int32.Parse(f_pr_spec_monthpay.Text);
        //    p_prt016.Pr_tel_no = f_pr_tel_no.Text;
        //    p_prt016.Pr_in_date = f_pr_in_date.Text;
        //    p_prt016.Pr_insr_date = f_pr_insr_date.Text;
        //    p_prt016.Pr_leave_date = f_pr_leave_date.Text == " " ? null : f_pr_leave_date.Text;
        //    p_prt016.Pr_back_insr_date = f_pr_leave_date.Text == " " ? null : f_pr_leave_date.Text;
        //    p_prt016.Pr_direct_type = f_pr_direct_type.SelectedValue.ToString();
        //    p_prt016.Pr_slry_type = f_pr_slry_type.SelectedValue.ToString();
        //    p_prt016.Bank_code = f_bank_code.Text;
        //    p_prt016.Account_no = f_account_no.Text;
        //    p_prt016.Pr_local_addr = f_pr_local_addr.Text;
        //    p_prt016.Pr_comm_addr = f_pr_comm_addr.Text;
        //    p_prt016.Pr_live_pr = Int32.Parse(f_pr_live_pr.Text);
        //    p_prt016.Pr_comm_man = f_pr_comm_man.Text;
        //    p_prt016.Pr_comm_tel_no = f_pr_comm_tel_no.Text;
        //    p_prt016.Pr_comm_relative = f_pr_comm_relative.Text;
        //    p_prt016.Direct_type1 = f_direct_type1.SelectedValue.ToString();
        //    p_prt016.Direct_type2 = f_direct_type2.SelectedValue.ToString();
        //    p_prt016.Pr_birth_date = f_pr_birth_date.Text;
        //    return p_prt016.Insert();
        //}

        private string f_Insert_prt027()
        {
            var p_prt0027 = new prt027();
            p_prt0027.Tr_id_no = f_pr_idno.Text;
            p_prt0027.Tr_sqe_no = prt027.GetSqeNo(f_pr_idno.Text);
            p_prt0027.Tr_type = "W";
            p_prt0027.Tr_start_date = f_pr_in_date.Text;
            p_prt0027.Tr_end_date = "";
            p_prt0027.Tr_comp = f_pr_company.Text;
            p_prt0027.Tr_dept_no = f_pr_dept.Text;
            p_prt0027.Tr_move_code = f_pr_work.Text;
            p_prt0027.Tr_old_comp = f_pr_company.Text;
            p_prt0027.Tr_old_dept = f_pr_dept.Text;
            p_prt0027.Tr_old_code = f_pr_work.Text;
            p_prt0027.Tr_move_amt = 0;
            p_prt0027.Tr_t1 = "";
            p_prt0027.Tr_t2 = "";
            p_prt0027.Tr_t3 = "";
            p_prt0027.Tr_comment = "復職";
            p_prt0027.Tr_wk_dept = f_pr_wk_cdept.Text;
            p_prt0027.Tr_old_posit = f_position.Text;
            p_prt0027.Tr_old_funct = "";
            p_prt0027.Tr_list_flag_ok = "";
            p_prt0027.Bpm_no = "";
            return p_prt0027.Insert();
        }

        //private string f_Insert_prt028()
        //{
        //    Set_prt028();
        //    return p_prt0028.Insert();
        //}

        //private void Set_prt028()
        //{            
        //    p_prt0028.Pr_no = f_pr_no.Text;
        //    p_prt0028.Pr_dept = f_pr_dept.Text;
        //    p_prt0028.Pr_wk_dept = f_pr_wk_cdept.Text;
        //    p_prt0028.Pr_work_type = null;
        //    p_prt0028.Pr_work = f_pr_work.Text;
        //    p_prt0028.Position = f_pr_work.Text;
        //    p_prt0028.Functions = null;
        //    p_prt0028.Wk_code = f_wk_code.Text;
        //    p_prt0028.Pr_clas_code = f_pr_clas_code.Text;
        //    p_prt0028.Direct_type5 = null;
        //    p_prt0028.Pr_fmy = "N";
        //}

        private string f_Insert_prt029()
        {
            var p_prt0029 = new prt029();
            p_prt0029.Va_year = Int32.Parse(f_pr_in_date.Text.Substring(0, 4));
            p_prt0029.Va_pr_no = f_pr_no.Text;
            p_prt0029.Va_id_no = f_pr_idno.Text;
            p_prt0029.Va_spec_date = 0;
            p_prt0029.Va_spec_hour = 0;
            p_prt0029.Va_spec_month = 1;
            p_prt0029.Vaca_a = 0;
            p_prt0029.Vaca_b = 0;
            p_prt0029.Vaca_c = 0;
            p_prt0029.Vaca_d = 0;
            p_prt0029.Vaca_e = 0;
            p_prt0029.Vaca_f = 0;
            p_prt0029.Vaca_g = 0;
            p_prt0029.Vaca_h = 0;
            p_prt0029.Vaca_i = 0;
            p_prt0029.Vaca_j = 0;
            p_prt0029.Vaca_k = 0;
            p_prt0029.Vaca_l = 0;
            p_prt0029.Vaca_m = 0;
            p_prt0029.Vaca_n = 0;
            p_prt0029.Vaca_o = 0;
            if (prt029.Get(p_prt0029.Va_year, p_prt0029.Va_pr_no) == null)
            {                
                return p_prt0029.Insert();
            }
            else
            {
                return p_prt0029.Update(p_prt0029.Va_year, p_prt0029.Va_pr_no);
            }
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

        private void pri023_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(Control+A)
            if (e.Control && e.KeyCode == Keys.A)
            {
                menu_add_Click(sender, e);
            }
            //查詢(Control+Q)
            if (e.Control && e.KeyCode == Keys.Q)
            {
                menu_query_Click(sender, e);
            }
            //修改(Control+E)
            if (e.Control && e.KeyCode == Keys.E)
            {
                menu_edit_Click(sender, e);
            }


            //第一筆(Control+F)
            if (e.Control && e.KeyCode == Keys.F)
            {
                menu_first_Click(sender, e);
            }

            //上一筆(Control+P)
            if (e.Control && e.KeyCode == Keys.P)
            {
                menu_previous_Click(sender, e);
            }

            //下一筆(Control+N)
            if (e.Control && e.KeyCode == Keys.N)
            {
                menu_next_Click(sender, e);
            }

            //最後一筆(Control+L)
            if (e.Control && e.KeyCode == Keys.L)
            {
                menu_last_Click(sender, e);
            }

            //確認(Escape)
            if (e.KeyCode == Keys.Escape)
            {
                confirm_Click(sender, e);
            }
            //取消(Delete)
            if (e.KeyCode == Keys.Delete)
            {
                cancel_Click(sender, e);
            }

            //離開(Control+Del)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                mnu_exit_Click(sender, e);
            }
        }




    }
}
