using System;
using System.Collections;
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
    public partial class wfd001 : Form
    {
        bool rOK;
        string Dept;
        string rSfb01 = string.Empty;
        public wfd001()
        {
            InitializeComponent();
            init_Form();
        }

        private void init_Form()
        {
            set_dept(); //下拉廠部
            //D_mline();//工作站
            f_sdate_s.Value = DateTime.Now;//給生產日期
            D_ecm04();//作業名稱
        }

        private void D_ecm04()
        {
            if (Login.DEPT == "ej") Dept = "J";
            DataTable dt = ecb_file.GToDoList(Dept);
            f_ecm04.DataSource = dt;
            f_ecm04.ValueMember = "ecb06";
            f_ecm04.DisplayMember = "ecb17";
            f_ecm04.SelectedIndex = 0;            
        }




        //private void f_add_Click(object sender, EventArgs e)
        //{
        //    wfd001a fm = new wfd001a("A");            
        //    if (f_plant.SelectedValue.ToString() == "ej") fm.dept = "J";            
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_sdate_s.Value = System.Convert.ToDateTime(fm.schdate);
        //        f_mline.SelectedValue = fm.ecb08;
        //        f_mlineb.SelectedValue = fm.ecb06;
        //        confirm_Click(null, null);
        //        rOK = true;
        //    }
        //    else
        //    {
        //        rOK = false;
        //    }
        //    fm.Dispose();

        //}

        private void f_add_Click(object sender, EventArgs e)
        {
            wfd010 fm = new wfd010("A", string.Empty);
            if (f_plant.SelectedValue.ToString() == "ej") fm.dept = "J";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_sfb01.Text = fm.rSfb01;
                confirm_Click(null, null);
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void set_dept()
        {
            //--廠部下拉選單
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(Login.DEPT_NAME, Login.DEPT));
            f_plant.DisplayMember = "Key";
            f_plant.ValueMember = "Value";
            f_plant.DataSource = data;
        }

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

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate_beg.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
            f_mfdate_end.Text = f_mfdate_beg.Text;
        }

        private void f_sdate_e_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate_end.Text = f_sdate_e.Value.ToString("yyyy/MM/dd");
        }

        private void f_mline_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rSel = f_mline.SelectedValue.ToString();
            DataTable dt = ecb_file.ToDoList(rSel);
            //DataTable dt = ecd_file.ToDoList(rSel);
            f_mlineb.DataSource = dt;
            f_mlineb.ValueMember = "ecb06";
            f_mlineb.DisplayMember = "ecb17";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            ClsForm();
        }

        private void ClsForm()
        {
            if (this.dataGridView1.DataSource != null)
            {
                this.dataGridView1.DataSource = null;
            }
            else
            {
                this.dataGridView1.Rows.Clear();
            }
            f_sfb01.Text = string.Empty;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string Ecm04 = f_ecm04.SelectedValue.ToString();
            if (f_plant.SelectedValue.ToString() == "ej") Dept = "J";
            string begDate = f_mfdate_beg.Text;
            string endDate = f_mfdate_end.Text;
            string sql = string.Empty;
            sql += "SELECT procscm.sfb01,procsca.occ02,procsca.ima01,procsca.ima02,procsca.sfb06,procsca.sfb08 from procscm";
            sql += " LEFT OUTER JOIN procsca on procsca.sfb01 = procscm.sfb01";
            sql += " WHERE 1=1 ";
            sql += " and procscm.schdate BETWEEN '" + begDate + "' and '" + endDate + "'";
            sql += " and procscm.ecm04 ='" + Ecm04 + "'";
            //sql += " and procscm.ecm06 ='" + f_mline.SelectedValue.ToString() + "'";
            sql += " GROUP BY procscm.sfb01,procsca.occ02,procsca.ima01,procsca.ima02,procsca.sfb06,procsca.sfb08";
            sql += " ORDER BY procscm.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count>0)  dataGridView1.Rows[0].Selected = true;

        }

        //private void confirm_Click(object sender, EventArgs e)
        //{
        //    if (f_plant.SelectedValue.ToString() == "ej") Dept = "J";
        //    string begDate = f_mfdate_beg.Text;
        //    string endDate = f_mfdate_end.Text;
        //    string sql = string.Empty;
        //    sql += "SELECT procscm.sfb01,procscm.schdate,procscm.ecb03,procscm.ecm06,procscm.eca02,procsca.occ02,procsca.ima01,procsca.ima02,procsca.sfb06,procsca.sfb08 from procscm";
        //    sql += " LEFT OUTER JOIN procsca on procsca.sfb01 = procscm.sfb01";
        //    sql += " WHERE 1=1 ";
        //    sql += " and procscm.schdate BETWEEN '" + begDate + "' and '" + endDate + "'";
        //    sql += " and procscm.ecm06 ='" + f_mline.SelectedValue.ToString() + "'";
        //    sql += " GROUP BY procscm.sfb01,procscm.schdate,procscm.ecb03,procscm.ecm06,procscm.eca02,procsca.occ02,procsca.ima01,procsca.ima02,procsca.sfb06,procsca.sfb08";
        //    sql += " ORDER BY procscm.sfb01";
        //    DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
        //    dataGridView1.DataSource = dt;
        //}


        //private void confirm_Click(object sender, EventArgs e)
        //{            
        //    if (f_plant.SelectedValue.ToString() == "ej") Dept = "J";
        //    string Sfb01 = f_sfb01.Text;            
        //    DataTable dt = Procsca.ToDoList(Sfb01);
        //    dataGridView1.DataSource = dt;
        //}

        //private void confirm_Click(object sender, EventArgs e)
        //{            
        //    if (f_plant.SelectedValue.ToString() == "ej") Dept = "J";
        //    string Schdate_Beg = f_mfdate_beg.Text;
        //    string Schdate_End = f_mfdate_end.Text;
        //    string Ecb08 = f_mline.SelectedValue.ToString();
        //    string Ecb06 = f_mlineb.SelectedValue.ToString();
        //    DataTable dt = Wkhproc.ToDoList(Dept, Schdate_Beg, Schdate_End, Ecb08, Ecb06);
        //    dataGridView1.DataSource = dt;            
        //}

        //private void f_del_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.Rows.Count == 0)
        //    {
        //        MessageBox.Show("請先選擇資料");
        //        return;
        //    }
        //    string sql = string.Empty;
        //    if (dataGridView1.Rows.Count > 0)
        //    {
        //        if (Config.Message("是否刪除？") == "Y")
        //        {
        //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //            {
        //                if (dataGridView1.Rows[i].Selected == true)
        //                {
        //                    String sfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
        //                    Int16 ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecb03"].Value.ToString());
        //                    String schdate = dataGridView1.Rows[i].Cells["schdate"].Value.ToString();
        //                    sql += Wkhproc.Set_Delete(sfb01, ecb03, schdate);
        //                }
        //            }
        //        }
        //    }            
        //    if (sql.Length > 0)
        //    {
        //        Double i = DOSQL.Excute(Login.WU, sql);
        //        if (i <=0) MessageBox.Show("刪除失敗");                
        //    }
        //    confirm_Click(null, null);
        //}


        //private void f_del_Click(object sender, EventArgs e)
        //{
        //    Boolean Choice = false;
        //    String sql = string.Empty;
        //    //檢查是否有被選取的
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Selected == true)
        //        {
        //            Choice = true;
        //        }
        //    }
        //    if (Choice == false)
        //    {
        //        MessageBox.Show("請先選擇資料");
        //        return;
        //    }
        //    if (Config.Message("是否刪除？") == "Y")
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (dataGridView1.Rows[i].Selected == true)
        //            {
        //                String sfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
        //                Int16 ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecb03"].Value.ToString());
        //                String schdate = dataGridView1.Rows[i].Cells["schdate"].Value.ToString();
        //                sql += Wkhproc.Set_Delete(sfb01, ecb03, schdate);
        //            }
        //        }
        //    }
        //    if (sql.Length > 0)
        //    {
        //        Double i = DOSQL.Excute(Login.WU, sql);
        //        if (i <= 0) MessageBox.Show("刪除失敗");
        //    }
        //    confirm_Click(null, null);
        //}





        //private void f_upd_Click(object sender, EventArgs e)
        //{
        //    Boolean Choice = false;
        //    String sql = string.Empty;
        //    //檢查是否有被選取的
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Selected == true)
        //        {
        //            Choice = true;
        //        }
        //    }

        //    if (Choice == false)
        //    {
        //        MessageBox.Show("請先選擇資料");
        //        return;
        //    }
        //    if (Config.Message("是否修改？") == "Y")
        //    {
        //        wfd001u fm = new wfd001u();
        //        if (fm.ShowDialog() == DialogResult.OK)
        //        {
        //            f_sdate_s.Value = System.Convert.ToDateTime(fm.schdate);
        //            schUpdate(fm.schdate);
        //        }
        //    }
        //    confirm_Click(null, null);
        //}

        //private void f_upd_Click(object sender, EventArgs e)
        //{
        //    Boolean Choice = false;
        //    String sql = string.Empty;
        //    //檢查是否有被選取的
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Selected == true)
        //        {
        //            Choice = true;
        //        }
        //    }

        //    if (Choice == false)
        //    {
        //        MessageBox.Show("請先選擇資料");
        //        return;
        //    }
        //    wfd001u fm = new wfd001u();
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_sdate_s.Value = System.Convert.ToDateTime(fm.schdate);
        //        schUpdate(fm.schdate);
        //    }
        //    confirm_Click(null, null);
        //}

        private void f_upd_Click(object sender, EventArgs e)
        {
            Boolean Choice = false;
            String sql = string.Empty;
            //檢查是否有被選取的
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    Choice = true;
                    rSfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
                }
            }
            if (Choice == false)
            {
                MessageBox.Show("請先選擇資料");
                return;
            }

            wfd010 fm = new wfd010("U", rSfb01);            
            if (f_plant.SelectedValue.ToString() == "ej") fm.dept = "J";            
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_sfb01.Text = fm.rSfb01;
                confirm_Click(null, null);
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
        }

        private void f_del_Click(object sender, EventArgs e)
        {
            Boolean Choice = false;
            String sql = string.Empty;
            //檢查是否有被選取的
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    Choice = true;
                }
            }
            if (Choice == false)
            {
                MessageBox.Show("請先選擇資料");
                return;
            }
            if (Config.Message("是否刪除？") == "Y")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        rSfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
                        f_Delete(rSfb01);
                    }
                }
            }
            if (sql.Length > 0)
            {
                Double i = DOSQL.Excute(Login.WU, sql);
                if (i <= 0) MessageBox.Show("刪除失敗");
            }
            confirm_Click(null, null);
        }

        private void f_Delete(string sfb01)
        {
            string sql = string.Empty;
            sql += "delete from procsca where sfb01='" + sfb01 + "'\n";
            sql += "delete from procsch where ecm01='" + sfb01 + "'\n";
            sql += "delete from procscm where sfb01='" + sfb01 + "'\n";
            if (sql.Trim().Length > 0) DOSQL.Excute(Login.WU, sql);
        }



        private void schUpdate(string Tschdate)
        {
            String sql = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        String sfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
                        Int16 ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecb03"].Value.ToString());
                        String schdate = dataGridView1.Rows[i].Cells["schdate"].Value.ToString();
                        if (Wkhproc.havesch(sfb01, ecb03, Tschdate) == true)
                            continue;
                        //sql += Wkhproc.Set_Delete(sfb01, ecb03, schdate);
                        else
                            sql += Wkhproc.Set_Update(sfb01, ecb03, schdate, Tschdate);
                    }
                }

                //MessageBox.Show(sql);

                if (sql.Length > 0)
                {
                    Double i = DOSQL.Excute(Login.WU, sql);
                    if (i <= 0) MessageBox.Show("修改失敗");
                }
            }
        }

        private void f_prno_bt_Click(object sender, EventArgs e)
        {
            f_sfb01.Text = string.Empty;            
            rWKno fm = new rWKno();
            fm.dept = "J";
            fm.rType = "B";//抓procsca
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_sfb01.Text = fm.rSfb01;
                confirm_Click(null, null);
            }
            fm.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }


        //private void f_del_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.Rows.Count > 0)
        //    {
        //        string sql = string.Empty;
        //        //刪除
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            String sfb01 = dataGridView1.Rows[i].Cells["sfb01"].Value.ToString();
        //            Int16 ecb03 = System.Convert.ToInt16(dataGridView1.Rows[i].Cells["ecb03"].Value.ToString());
        //            String schdate = dataGridView1.Rows[i].Cells["schdate"].Value.ToString();
        //            sql += Wkhproc.Set_Delete(sfb01, ecb03, schdate);
        //        }
        //        if (sql.Length > 0)
        //        {
        //            Double i = DOSQL.Excute(Login.WU, sql);
        //            if (i > 0)
        //                MessageBox.Show("刪除成功");
        //            else
        //                MessageBox.Show("刪除失敗");
        //        }
        //    }
        //    else
        //    {
        //        Config.Message("無符合資料");
        //    }
        //    confirm_Click(null, null);
        //}


    }
}
