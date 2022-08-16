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

namespace EMES.Forms
{
    public partial class wfd010 : Form
    {
        DataTable dtEcm;
        string Menu_Sel = string.Empty;
        public string dept;
        public string rSfb01;//工單
        public wfd010()
        {
            InitializeComponent();
        }

        public wfd010(string rf,string Sfb01)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            init_GridView();
            if (rf == "A")
            {
                Menu_Sel = "Add";
                f_OK.Enabled = false;
            }
            if (rf == "U")
            {
                Menu_Sel = "Upd";
                f_prno_bt.Enabled = false;//工單按鈕不可以按
                rSfb01 = Sfb01;
                f_Data();                
            }
        }

        private void f_Data()
        {
            string sql = string.Empty;
            sql += "select * from procsca where 1=1";
            sql += " and sfb01='" + rSfb01 + "'";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            HeadShow(dt);
            PschShow();
        }


        private void init_GridView()
        {
            //是否允許使用者編輯
            //this.dataGridView1.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView1.AllowUserToAddRows = false;
        }
        private void init_Table()
        {
            //--定義datatable 欄位
            dtEcm.Columns.Add("ecm01", typeof(String));
            dtEcm.Columns.Add("ecm03", typeof(String));
            dtEcm.Columns.Add("ecm04", typeof(String));
            dtEcm.Columns.Add("ecm45", typeof(String));
            dtEcm.Columns.Add("ecm06", typeof(String));
            dtEcm.Columns.Add("eca02", typeof(String));
        }

        private void f_prno_bt_Click(object sender, EventArgs e)
        {            
            rWKno fm = new rWKno();
            fm.dept = "J";
            fm.rType = "A";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = fm.dtProd;                
                HeadShow(dt);//單頭
                dataGridView1.Rows.Clear();
                HeadtlShow();//單身
                RecodeCls();//清單列資料

                f_OK.Enabled = true;

                //顯示工單基本資料

                //dataGridView1.DataSource = dt;
                //dtWkhproc = dt.Copy();
                ////---畫面字體變大畫面優化------
                ////FontGridView(dt.Rows.Count);
                ///
            }
        }

        private void RecodeCls()
        {
            f_r_ecm03.Text = string.Empty;
            f_r_ecd01.Text = string.Empty;
            f_r_ecd02.Text = string.Empty;
            f_r_ecd07.Text = string.Empty;
            f_r_eca02.Text = string.Empty;
            f_r_begdate.Text = string.Empty;
            f_r_rg.Text = string.Empty;
            f_r_enddate.Text = string.Empty;
        }

        private void HeadShow(DataTable dt)
        {
            f_sfb01.Text = dt.Rows[0]["sfb01"].ToString();
            f_occ02.Text = dt.Rows[0]["occ02"].ToString();
            f_ima01.Text = dt.Rows[0]["ima01"].ToString();
            f_ima02.Text = dt.Rows[0]["ima02"].ToString();
            f_ima021.Text = dt.Rows[0]["ima021"].ToString();
            f_sfb06.Text = dt.Rows[0]["sfb06"].ToString();
            f_sfb08.Text = dt.Rows[0]["sfb08"].ToString();
            f_sfb13.Text = dt.Rows[0]["sfb13"].ToString();
        }

        private void HeadtlShow()
        {
            string sql = string.Empty;
            sql += "SELECT ecm03,ecm04,ecm45,ecm06,eca02 from ecm_file";
            sql += " LEFT OUTER JOIN eca_file on eca_file.eca01 = ecm06";
            sql += " where 1=1";
            sql += " and ecm01='" + f_sfb01.Text + "'";
            sql += " ORDER BY ecm01,ecm03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            //
            string begdate = DateTime.Now.ToString("yyy/MM/dd");
            string rg = "0";
            string enddate = DateTime.Now.AddDays(0).ToString("yyy/MM/dd");
            //
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                dataGridView1.Rows.Add(new object[] {
                    dt.Rows[i]["ecm03"],
                    dt.Rows[i]["ecm04"],
                    dt.Rows[i]["ecm45"],
                    dt.Rows[i]["ecm06"],
                    dt.Rows[i]["eca02"],
                    begdate,
                rg,enddate});
            }
        }

        private void PschShow()
        {
            string sql = string.Empty;
            sql += "SELECT ecm03,ecm04,ecm45,ecm06,eca02,begdate,rg,enddate from procsch";
            sql += " where 1=1";
            sql += " and ecm01='" + f_sfb01.Text + "'";
            sql += " ORDER BY ecm01,ecm03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[] {
                    dt.Rows[i]["ecm03"],
                    dt.Rows[i]["ecm04"],
                    dt.Rows[i]["ecm45"],
                    dt.Rows[i]["ecm06"],
                    dt.Rows[i]["eca02"],
                    dt.Rows[i]["begdate"],
                    dt.Rows[i]["rg"],
                    dt.Rows[i]["enddate"]});
            }
        }


        private void btn_imp_Click(object sender, EventArgs e)
        {
            if (f_ckSel() == false)
            {
                MessageBox.Show("請選擇單一列資料");
                return;
            }

            //匯入相關資料
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    f_r_ecm03.Text = dataGridView1.Rows[i].Cells["ecm03"].Value.ToString();
                    f_r_ecd01.Text = dataGridView1.Rows[i].Cells["ecm04"].Value.ToString();
                    f_r_ecd02.Text = dataGridView1.Rows[i].Cells["ecm45"].Value.ToString();
                    f_r_ecd07.Text = dataGridView1.Rows[i].Cells["ecm06"].Value.ToString();
                    f_r_eca02.Text = dataGridView1.Rows[i].Cells["eca02"].Value.ToString();


                    f_r_begdate_s.Value = System.Convert.ToDateTime(dataGridView1.Rows[i].Cells["begdate"].Value.ToString());
                    f_r_begdate.Text = dataGridView1.Rows[i].Cells["begdate"].Value.ToString();
                    f_r_rg.Text = dataGridView1.Rows[i].Cells["rg"].Value.ToString();
                    f_r_enddate_s.Value = System.Convert.ToDateTime(dataGridView1.Rows[i].Cells["enddate"].Value.ToString());
                    f_r_enddate_s.Text = dataGridView1.Rows[i].Cells["enddate"].Value.ToString();
                }
            }

            //顯示已入排程資料
            DataTable dt = Procscm.SumScm(f_r_begdate.Text, f_r_ecd01.Text);
            dataGridView2.DataSource = dt;

        }

       

       


        //private void btn_imp_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Selected == true)
        //        {
        //            f_r_ecm03.Text = dataGridView1.Rows[i].Cells["ecm03"].Value.ToString();
        //            f_r_begdate.Text = dataGridView1.Rows[i].Cells["begdate"].Value.ToString();
        //            f_r_rg.Text = dataGridView1.Rows[i].Cells["rg"].Value.ToString();
        //            f_r_enddate.Text = dataGridView1.Rows[i].Cells["enddate"].Value.ToString();
        //        }
        //    }
        //}


        //點欄位整列反藍
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;            
            btn_imp_Click(null, null);            
        }

        //修改按鍵
        private void btn_upd_Click(object sender, EventArgs e)
        {
            //string bDate = string.Empty;
            //string eDate = string.Empty;
            Int16 a_ecm03 =  System.Convert.ToInt16(f_r_ecm03.Text); //製程序
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Int16 r_ecm03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecm03"].Value.ToString());//明細製程序

                if (a_ecm03 == r_ecm03)
                {
                    dataGridView1.Rows[i].Cells["begdate"].Value = f_r_begdate.Text;                    
                    dataGridView1.Rows[i].Cells["enddate"].Value = f_r_enddate.Text;
                    dataGridView1.Rows[i].Cells["rg"].Value = TimeSpan(f_r_begdate.Text, f_r_enddate.Text).ToString();
                    //eDate = dataGridView1.Rows[i].Cells["enddate"].Value.ToString();
                }
                if (Menu_Sel == "Add")
                {
                    if (a_ecm03 < r_ecm03)
                    {
                        dataGridView1.Rows[i].Cells["begdate"].Value = f_r_enddate.Text;
                        dataGridView1.Rows[i].Cells["enddate"].Value = f_r_enddate.Text;
                        dataGridView1.Rows[i].Cells["rg"].Value = TimeSpan(dataGridView1.Rows[i].Cells["begdate"].Value.ToString(), dataGridView1.Rows[i].Cells["enddate"].Value.ToString()).ToString();
                    }
                }
            }
        }


        //private void btn_upd_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Selected == true)
        //        {
        //            dataGridView1.Rows[i].Cells["begdate"].Value = f_r_begdate.Text;
        //            dataGridView1.Rows[i].Cells["rg"].Value = TimeSpan(f_r_begdate.Text, f_r_enddate.Text).ToString();                    
        //            dataGridView1.Rows[i].Cells["enddate"].Value = f_r_enddate.Text;

        //        }
        //    }
        //}

        private void f_r_begdate_s_ValueChanged(object sender, EventArgs e)
        {            
            f_r_begdate.Text = f_r_begdate_s.Value.ToString("yyyy/MM/dd");
            f_r_enddate.Text = f_r_begdate_s.Value.ToString("yyyy/MM/dd");            
        }
        
        private void f_add_Click(object sender, EventArgs e)
        {
            double i_number = 0;
            i_number = System.Convert.ToDouble(f_r_rg.Text);
            i_number += 1;
            f_r_rg.Text = i_number.ToString();
            C_enddate(i_number);
        }

        private void f_sub_Click(object sender, EventArgs e)
        {
            double i_number = 0; i_number = System.Convert.ToDouble(f_r_rg.Text);
            i_number -= 1;
            if (i_number < 0) i_number = 0;
            f_r_rg.Text = i_number.ToString();
            C_enddate(i_number);
        }

        private void C_enddate(double rg)
        {
            DateTime dt = new DateTime();
            dt = System.Convert.ToDateTime(f_r_begdate.Text).AddDays(rg);
            f_r_enddate.Text = dt.ToString("yyyy/MM/dd");
        }

        private void f_r_enddate_s_ValueChanged(object sender, EventArgs e)
        {
            f_r_enddate.Text = f_r_enddate_s.Value.ToString("yyyy/MM/dd");

            //觸發修改
            //btn_upd_Click(null, null);
            //if (System.Convert.ToDateTime(f_r_enddate.Text) < System.Convert.ToDateTime(f_r_begdate.Text))
            //{
            //    MessageBox.Show("日期不符合區間");
            //    f_r_begdate_s_ValueChanged(null, null);
            //}
        }


        private int TimeSpan(string Begdate,string Enddate)
        {
            int a = new TimeSpan(System.Convert.ToDateTime(Enddate).Ticks - System.Convert.ToDateTime(Begdate).Ticks).Days;
            return a;
        }

        private void f_OK_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    try
                    {
                        f_Insert();
                        rSfb01 = "'" + f_sfb01.Text + "'";
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
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {
                        f_Update();                        
                        rSfb01 = "'" + f_sfb01.Text + "'";
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
            }

            Close_Form();
        }


        private void f_Insert()
        {
            Ins_Procsca();//主檔
            Ins_Procsch();//明細
            Ins_Procscm();//排程
        }

        private void f_Update()
        {
            //刪除明細
            Del_Procsch();           
            Ins_Procsch(); //加入明細
            //------
            Del_Procscm();//刪除排程
            Ins_Procscm();//排程           
        }



        private void Ins_Procsca()
        {
            string sql = string.Empty;
            Procsca p_procsca = new Procsca();
            p_procsca.Sfb01 = f_sfb01.Text;
            p_procsca.Occ02 = f_occ02.Text;
            p_procsca.Ima01 = f_ima01.Text;
            p_procsca.Ima02 = f_ima02.Text;
            p_procsca.Ima021 = f_ima021.Text;
            p_procsca.Sfb06 = f_sfb06.Text;
            p_procsca.Sfb08 = System.Convert.ToDecimal(f_sfb08.Text);
            p_procsca.Sfb13 = f_sfb13.Text;

            int i =  Procsca.Ins_(p_procsca, Login.WU);
            if (i <= 0) MessageBox.Show("新增失敗-Procsca");
        }

        private void Ins_Procsch()
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Procsch p_procsch = new Procsch();
                p_procsch.Ecm01 = f_sfb01.Text;
                p_procsch.Ecm03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecm03"].Value.ToString());
                p_procsch.Ecm04 = dataGridView1.Rows[i].Cells["ecm04"].Value.ToString();
                p_procsch.Ecm45 = dataGridView1.Rows[i].Cells["ecm45"].Value.ToString();
                p_procsch.Ecm06 = dataGridView1.Rows[i].Cells["ecm06"].Value.ToString();
                p_procsch.Eca02 = dataGridView1.Rows[i].Cells["eca02"].Value.ToString();
                p_procsch.Begdate = dataGridView1.Rows[i].Cells["begdate"].Value.ToString();
                p_procsch.Enddate = dataGridView1.Rows[i].Cells["enddate"].Value.ToString();
                p_procsch.Rg = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["rg"].Value.ToString());
                p_procsch.Schdate = string.Empty;               
                sql += Procsch.Set_Insert(p_procsch);
            }
            if (sql.Length > 0)
            {
                Double i = DOSQL.Excute(Login.WU, sql);
                if (i <= 0) MessageBox.Show("新增失敗-Procsch");
            }
        }

        private void Ins_Procscm()
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int DRG = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["rg"].Value.ToString());//間距
                for (int j = 0; j <= DRG; j++)
                {
                    Procscm p_ = new Procscm();
                    p_.Sfb01 = f_sfb01.Text;
                    p_.Ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecm03"].Value.ToString());
                    p_.Schdate = getSchdate(j, dataGridView1.Rows[i].Cells["begdate"].Value.ToString());
                    p_.Ecm04 = dataGridView1.Rows[i].Cells["ecm04"].Value.ToString();
                    p_.Ecm45 = dataGridView1.Rows[i].Cells["ecm45"].Value.ToString();
                    p_.Ecm06 = dataGridView1.Rows[i].Cells["ecm06"].Value.ToString();
                    p_.Eca02 = dataGridView1.Rows[i].Cells["eca02"].Value.ToString();
                    sql += Procscm.Set_Insert(p_);
                }
            }
            if (sql.Length > 0)
            {
                Double i = DOSQL.Excute(Login.WU, sql);
                if (i <= 0) MessageBox.Show("新增失敗-Procscm");
            }
        }

        private void Ins_Wkhproc()
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int DRG = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["rg"].Value.ToString());//間距
                for (int j = 0; j <= DRG; j++)
                {
                    Wkhproc p_wkhproc = new Wkhproc();
                    p_wkhproc.Sfb01 = f_sfb01.Text;
                    p_wkhproc.Ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecm03"].Value.ToString());
                    p_wkhproc.Schdate = getSchdate(j, dataGridView1.Rows[i].Cells["begdate"].Value.ToString());
                    p_wkhproc.Sfb05 = string.Empty;
                    p_wkhproc.Ima02 = string.Empty;
                    p_wkhproc.Ima021 = string.Empty;
                    p_wkhproc.Ecb06 = dataGridView1.Rows[i].Cells["ecm04"].Value.ToString();
                    p_wkhproc.Ecb17 = dataGridView1.Rows[i].Cells["ecm45"].Value.ToString();
                    p_wkhproc.Ecb08 = dataGridView1.Rows[i].Cells["ecm06"].Value.ToString();
                    p_wkhproc.Eca02 = dataGridView1.Rows[i].Cells["eca02"].Value.ToString();
                    p_wkhproc.Occ02 = string.Empty;
                    p_wkhproc.Sfb13 = string.Empty;
                    sql += Wkhproc.Set_Insert(p_wkhproc);
                }
            }
            if (sql.Length > 0)
            {
                Double i = DOSQL.Excute(Login.WU, sql);
                if (i <= 0) MessageBox.Show("新增失敗-Wkhproc");
            }
        }




        private void Del_Procsch()
        {
            string rs = f_sfb01.Text;
            string sql = string.Empty;
            sql += "delete from procsch where ecm01 ='" + rs + "'";
            int i = DOSQL.Excute(Login.WU, sql);
        }

        private void Del_Procscm()
        {
            string rs = f_sfb01.Text;
            string sql = string.Empty;
            sql += "delete from procscm where sfb01 ='" + rs + "'";
            int i = DOSQL.Excute(Login.WU, sql);
        }

        private void Del_Wkhproc()
        {
            string rs = f_sfb01.Text;
            string sql = string.Empty;
            sql += "delete from wkhproc where sfb01 ='" + rs + "'";
            int i = DOSQL.Excute(Login.WU, sql);
        }

        //private void Ins_Procsch()
        //{
        //    string sql = string.Empty;
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        int DRG = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["rg"].Value.ToString());//間距
        //        for (int j = 0; j <= DRG; j++)
        //        {
        //            Procsch p_procsch = new Procsch();
        //            p_procsch.Ecm01 = f_sfb01.Text;
        //            p_procsch.Ecm03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecm03"].Value.ToString());
        //            p_procsch.Ecm04 = dataGridView1.Rows[i].Cells["ecm04"].Value.ToString();
        //            p_procsch.Ecm45 = dataGridView1.Rows[i].Cells["ecm45"].Value.ToString();
        //            p_procsch.Ecm06 = dataGridView1.Rows[i].Cells["ecm06"].Value.ToString();
        //            p_procsch.Eca02 = dataGridView1.Rows[i].Cells["eca02"].Value.ToString();
        //            p_procsch.Begdate = dataGridView1.Rows[i].Cells["begdate"].Value.ToString();
        //            p_procsch.Enddate = dataGridView1.Rows[i].Cells["enddate"].Value.ToString();
        //            p_procsch.Rg = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["rg"].Value.ToString());
        //            p_procsch.Schdate = getSchdate(j, dataGridView1.Rows[i].Cells["begdate"].Value.ToString());
        //            sql += Procsch.Set_Insert(p_procsch);
        //        }
        //    }
        //    if (sql.Length > 0)
        //    {
        //        Double i = DOSQL.Excute(Login.WU, sql);
        //        if (i <= 0) MessageBox.Show("新增失敗-Procsch");
        //    }

        //}


        private string getSchdate(int j,string rd)
        {
            return System.Convert.ToDateTime(rd).AddDays(j).ToString("yyyy/MM/dd");
        }


        private void Close_Form()
        {            
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }

        //private void HeadtlShow()
        //{
        //    string sql = string.Empty;
        //    sql += "SELECT ecm03,ecm04,ecm45,ecm06,eca02 from ecm_file";
        //    sql += " LEFT OUTER JOIN eca_file on eca_file.eca01 = ecm06";
        //    sql += " where 1=1";
        //    sql += " and ecm01='" + f_sfb01.Text + "'";
        //    sql += " ORDER BY ecm01,ecm03";
        //    DataTable dt = DOSQL.GetDataTable(Login.WU, sql);            
        //    dataGridView1.DataSource = dt;
        //}
        
            //檢查整列選取是否取選取一列

        private bool f_ckSel()
        {
            bool rf = false;
            int rcnt = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    rcnt += 1;
                }
            }
            if (rcnt == 1)
                rf = true;
            else
                rf = false;
            return rf;
        }

        private void btn_ecd01_Click(object sender, EventArgs e)
        {
            rEcd fm = new rEcd();
            fm.Dept = string.Empty;
            //fm.Dept = "J";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                RecordShow(dt);//顯示資料
            }
        }

        private void RecordShow(DataTable dt)
        {            
            f_r_ecd01.Text = dt.Rows[0]["ecd01"].ToString();
            f_r_ecd02.Text = dt.Rows[0]["ecd02"].ToString();
            f_r_ecd07.Text = dt.Rows[0]["ecd07"].ToString();
            f_r_eca02.Text = getEca02(f_r_ecd07.Text);
            f_r_begdate_s.Value = DateTime.Now;
            f_r_begdate.Text = f_r_begdate_s.Value.ToString("yyyy/MM/dd");
            f_r_enddate_s.Value = DateTime.Now;
            f_r_enddate.Text = f_r_begdate_s.Value.ToString("yyyy/MM/dd");
            f_r_rg.Text = TimeSpan(f_r_begdate.Text, f_r_enddate.Text).ToString();
        }

        private string getEca02(string Eca01)
        {
            string rs = string.Empty;
            DataTable dt = eca_file.Get(Eca01);
            rs = dt.Rows[0]["eca02"].ToString();
            return rs;
        }

        private void btn_ecd07_Click(object sender, EventArgs e)
        {
            rEca fm = new rEca();
            fm.Dept = string.Empty;
            //fm.Dept = "J";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                f_r_ecd07.Text = dt.Rows[0]["eca01"].ToString();
                f_r_eca02.Text = getEca02(f_r_ecd07.Text);
            }
        }

        private void btn_Ins_Click(object sender, EventArgs e)
        {
            //int i = dataGridView1.Rows.Count;
            if (f_RecordCK() == false)
            {
                MessageBox.Show("欄位不可空白");                
                return;
            }
            //檢查製程序編號
            if (Ecm03Doub()==true)
            {
                MessageBox.Show("序號不可重複");
                f_r_ecm03.Select();
                return;
            }

            dataGridView1.Rows.Add(new object[] {System.Convert.ToInt32(f_r_ecm03.Text),
                f_r_ecd01.Text,
                f_r_ecd02.Text,
                f_r_ecd07.Text,
                f_r_eca02.Text,
                f_r_begdate.Text,
                f_r_rg.Text,
                f_r_enddate.Text});
            GvSort();//排序
        }

        private bool Ecm03Doub()
        {
            bool rf = false;
            Int32 a = System.Convert.ToInt32(f_r_ecm03.Text);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Int32 b = System.Convert.ToInt32(dataGridView1.Rows[i].Cells["ecm03"].Value.ToString());
                if (a == b)
                {
                    rf = true;
                    break;
                }
            }
            return rf;
        }

        private bool f_RecordCK()
        {            
            bool rf = false;
            if (f_r_ecm03.Text.ToString().Trim().Length == 0 ||
                f_r_ecd01.Text.ToString().Trim().Length ==0 ||
                f_r_ecd02.Text.ToString().Trim().Length ==0 ||
                f_r_ecd07.Text.ToString().Trim().Length ==0 ||
                f_r_eca02.Text.ToString().Trim().Length == 0 ||
                f_r_begdate.Text.ToString().Trim().Length == 0 ||
                f_r_enddate.Text.ToString().Trim().Length == 0 )
            {
                rf = false;
            }
            else
            {
                rf = true;
            }
            return rf;
        }


        private void GvSort()
        {
            // 根據 資料行1 (Name) 做 小到大 排序 
            dataGridView1.Sort(dataGridView1.Columns["ecm03"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (Config.Message("確定刪除?") == "Y")
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }
        }
    }
}
