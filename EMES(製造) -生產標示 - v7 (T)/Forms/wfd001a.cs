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
    public partial class wfd001a : Form
    {
        string Menu_Sel;
        DataTable dtWkhproc;
        public string dept;
        public string schdate;
        public string ecb06;
        public string ecb08;
        string Dept;
        DataTable dtEcm;
        public wfd001a()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            init_GridView();
            init_Table();
        }


        private void init_GridView()
        {
            //是否允許使用者編輯
            this.dataGridView1.ReadOnly = true;
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

        public wfd001a(string Sel)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            D_mline();//工作站
            //新增時的處理
            if (Sel == "A")
            {                
                Menu_Sel = "Add";
                f_schdate_s.Value = DateTime.Now;
            }
        }

        //private void D_mline()
        //{
        //    string sql = string.Empty;
        //    sql += "SELECT eca01,eca02 from eca_file";            
        //    sql += " where 1=1";
        //    sql += "and ecaacti ='Y'";
        //    sql += " and SUBSTRING(eca01,1,1)='J'";
        //    sql += " order by eca01 ";

        //    DataTable dt = DOSQL.GetDataTable(Login.WU, sql);

        //    f_mline.DataSource = dt;
        //    f_mline.ValueMember = "eca01";
        //    f_mline.DisplayMember = "eca02";
        //}

        private void D_mline()
        {
            if (Login.DEPT == "ej") Dept = "J";
            DataTable dt = eca_file.GToDoList(Dept);
            f_mline.DataSource = dt;
            f_mline.ValueMember = "eca01";
            f_mline.DisplayMember = "eca02";
            f_mline.SelectedIndex = 0;
            f_mline_SelectedIndexChanged(null, null);
        }

        private void D_line()
        {
            string sql = string.Empty;
            sql += "SELECT ecd07,eca02 from ecd_file";
            sql += " LEFT OUTER JOIN eca_file on eca01 = ecd_file.ecd07 ";
            sql += " where 1=1";
            sql += "and ecdacti ='Y'";
            sql += " and SUBSTRING(ecd07,1,1)='J'";
            sql += " GROUP BY ecd07,eca02";

            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
                        
            f_mline.DataSource = dt;
            f_mline.ValueMember = "ecd07";
            f_mline.DisplayMember = "eca02";
        }
        private void f_OK_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (f_Check() == false) return;
                if (Config.Message("確定新增?") == "Y")                {
                    try
                    {
                        f_Insert();
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
                //Close_Form();//離開畫面
            }
            Close_Form();
        }


        //private void f_OK_Click(object sender, EventArgs e)
        //{
        //    if (Menu_Sel == "Add")
        //    {
        //        if (Config.Message("確定新增?") == "Y")
        //        {
        //            if (f_Check() == false)
        //                return;
        //            try
        //            {
        //                f_Insert();
        //            }
        //            catch (Exception ex)
        //            {
        //                Config.Show(ex.Message);
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }
        //        //Close_Form();//離開畫面
        //    }
        //    Close_Form();
        //}

        private bool f_Check()
        {
            if (f_schdate.Text == String.Empty)
            {
                Config.Show("排程日期不可空白");
                f_schdate.Focus();
                return false;
            }
            if (System.Convert.ToDateTime(f_schdate.Text) >= System.Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")))
            {
                //do nothing
            }
            else
            {
                Config.Show("排程日期不可小於今天");
                f_schdate.Focus();
                return false;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                Config.Show("無任何排程資料");
                f_schdate.Focus();
                return false;
            }            
            
            //檢查是否有被選取的
            bool Choice = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                {
                    Choice = true;
                }
            }
            if (Choice == false)
            {
                Config.Show("請先選擇資料");
                return false;
            }
            return true;
        }

        private void f_Insert()
        {
            string sql = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {                
                if (System.Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true )
                {
                    Wkhproc p_wkhproc = new Wkhproc();
                    p_wkhproc.Sfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
                    p_wkhproc.Ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecb03"].Value.ToString());
                    p_wkhproc.Schdate = f_schdate.Text;
                    p_wkhproc.Sfb05 = dataGridView1.Rows[i].Cells["sfb05"].Value.ToString();
                    p_wkhproc.Ima02 = dataGridView1.Rows[i].Cells["ima02"].Value.ToString();
                    p_wkhproc.Ima021 = dataGridView1.Rows[i].Cells["ima021"].Value.ToString();
                    p_wkhproc.Ecb06 = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    p_wkhproc.Ecb17 = dataGridView1.Rows[i].Cells["ecb17"].Value.ToString();
                    p_wkhproc.Ecb08 = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    p_wkhproc.Eca02 = dataGridView1.Rows[i].Cells["eca02"].Value.ToString();
                    p_wkhproc.Occ02 = dataGridView1.Rows[i].Cells["occ02"].Value.ToString();
                    p_wkhproc.Sfb13 = dataGridView1.Rows[i].Cells["sfb13"].Value.ToString();
                    //
                    if (Wkhproc.havesch(p_wkhproc.Sfb01, p_wkhproc.Ecb03, p_wkhproc.Schdate) == true)
                        continue;
                    else
                        sql += Wkhproc.Set_Insert(p_wkhproc);
                }
            }

            if (sql.Length > 0)
            {
                Double i = DOSQL.Excute(Login.WU, sql);
                if (i <= 0) MessageBox.Show("新增失敗");
            }

        }


        //private void f_Insert()
        //{
        //    string sql = string.Empty;
        //    foreach (DataRow dr in dtWkhproc.Rows)
        //    {
        //        Wkhproc rWkhproc = new Wkhproc();
        //        rWkhproc.Sfb01 = dr["sfb01"].ToString();
        //        rWkhproc.Ecb03 = System.Convert.ToInt16(dr["ecb03"].ToString());
        //        rWkhproc.Schdate = f_schdate.Text;
        //        rWkhproc.Sfb05 = dr["sfb05"].ToString();
        //        rWkhproc.Ima02 = dr["ima02"].ToString();
        //        rWkhproc.Ima021 = dr["ima021"].ToString();
        //        rWkhproc.Ecb06 = dr["ecb06"].ToString();
        //        rWkhproc.Ecb17 = dr["ecb17"].ToString();
        //        rWkhproc.Ecb08 = dr["ecb08"].ToString();
        //        rWkhproc.Eca02 = dr["eca02"].ToString();
        //        rWkhproc.Occ02 = dr["occ02"].ToString();
        //        rWkhproc.Sfb13 = dr["sfb13"].ToString();
        //        if (haveSch(rWkhproc) == true)
        //            continue;
        //        else
        //            sql += Wkhproc.Set_Insert(rWkhproc);
        //    }
        //    if (sql.Trim().Length > 0)
        //    {
        //        var i = DOSQL.Excute(Login.WU, sql);
        //        if (i > 0)
        //            MessageBox.Show("新增成功");
        //        else
        //            MessageBox.Show("新增失敗");
        //    }            
        //}

        private bool haveSch(Wkhproc wkhproc)
        {
            string sql = string.Empty;
            sql += "select * from wkhproc where sfb01='" + wkhproc.Sfb01 + "'";
            sql += " and ecb03 =" + wkhproc.Ecb03;
            sql += " and schdate ='" + wkhproc.Schdate + "'";
            bool i = DOSQL.haveBarcode(Login.WU, sql);
            return i;
        }

        private void Close_Form()
        {
            schdate = f_schdate.Text;            
            ecb08 = f_mline.SelectedValue.ToString();
            ecb06 = f_mlineb.SelectedValue.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }



        private void wfd001a_Load(object sender, EventArgs e)
        {   
            
        }

        private void f_mline_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rSel = f_mline.SelectedValue.ToString();//加工站選擇
            DataTable dt = ecb_file.ToDoList(rSel);
            f_mlineb.DataSource = dt;
            f_mlineb.ValueMember = "ecb06";
            f_mlineb.DisplayMember = "ecb17";

            //--清畫面
            dataGridView1.Rows.Clear();

        }

        //private void f_prno_bt_Click(object sender, EventArgs e)
        //{
        //    wfdwk fm = new wfdwk();//開視窗資料
        //    fm.dept = "J";
        //    fm.schdate = f_schdate.Text;
        //    fm.ecb08 = f_mline.SelectedValue.ToString();
        //    fm.ecb06 = f_mlineb.SelectedValue.ToString();
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        DataTable dt = fm.dtProd;
        //        dataGridView1.DataSource = dt;
        //        dtWkhproc = dt.Copy();
        //        //---畫面字體變大畫面優化------
        //        //FontGridView(dt.Rows.Count);
        //    }
        //}

        private void f_prno_bt_Click(object sender, EventArgs e)
        {
            rWKno fm = new rWKno();
            fm.dept = "J";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = fm.dtProd;
                //MessageBox.Show(dt.Rows.Count.ToString());
                HeadShow(dt);//單頭
                HeadtlShow();//單身


                //顯示工單基本資料

                //dataGridView1.DataSource = dt;
                //dtWkhproc = dt.Copy();
                ////---畫面字體變大畫面優化------
                ////FontGridView(dt.Rows.Count);
            }

            //Int16 i =  getData2();//找出資料
            //Int16 i = getData3();//找出資料
            //if (i == 0) MessageBox.Show("無符合資料");
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
            sql += "SELECT ecm01,ecm03,ecm04,ecm45,ecm06,eca02 from ecm_file";
            sql += " LEFT OUTER JOIN eca_file on eca_file.eca01 = ecm06";
            sql += " where 1=1";
            sql += " and ecm01='" + f_sfb01.Text + "'";
            sql += " ORDER BY ecm01,ecm03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);


            MessageBox.Show(dt.Rows.Count.ToString());
            //ecm_file
        }


        private Int16 getData3()
        {
            dept = "J";

            return 1;
        }


        private Int16 getData2()
        {
            dept = "J";
            ecb06 = f_mlineb.SelectedValue.ToString();
            ecb08 = f_mline.SelectedValue.ToString();
            schdate = f_schdate.Text;
            Int16 rcnt = 0;
            dataGridView1.Rows.Clear();
            DataTable dt = Wfdwk.ToDoList(dept, ecb06, ecb08);            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //wkhproc 有資料就找下一筆
                if (Wkhproc.havesch(dt.Rows[i]["sfb01"].ToString(), System.Convert.ToInt16(dt.Rows[i]["ecb03"].ToString()), schdate) == false)
                {
                    dataGridView1.Rows.Add(new object[] {true, dt.Rows[i]["sfb01"],
                        dt.Rows[i]["ecb03"],
                    dt.Rows[i]["occ02"],
                    dt.Rows[i]["sfb05"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"],
                    
                    dt.Rows[i]["ecb06"],
                    dt.Rows[i]["ecb17"],
                    dt.Rows[i]["ecb08"],
                    dt.Rows[i]["eca02"],
                    dt.Rows[i]["sfb13"]});
                    rcnt += 1;
                }
            }
            return rcnt;
            //---畫面字體變大畫面優化------            
            //FontGridView(rcnt);
        }

        private void FontGridView(int CRow)
        {
            for (int i = 0; i < CRow; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("新細明體", 20);
                //dataGridView1.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //dataGridView1.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if ((i % 2) == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
            }
        }

        private void f_schdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_schdate.Text = f_schdate_s.Value.ToString("yyyy/MM/dd");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
            if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value == false)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            else
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "全不選")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = false;
                }
                button1.Text = "全選";
                return;
            }
            if (button1.Text == "全選")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = true;
                }
                button1.Text = "全不選";
                return;
            }
        }
    }
}
