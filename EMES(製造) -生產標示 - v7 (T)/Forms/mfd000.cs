using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

using EMES.Models;

namespace EMES.Forms
{
    public partial class mfd000 : Form
    {        
        static List<mfplan> LS1 = new List<mfplan>();
        List<mfplah> LS = new List<mfplah>();
                
        string Dept = Login.DEPT;
        

        public string rCdept;//部門
        public string rBegdate;//離職日(起)
        public string rEnddate;//離職日(迄)


        public string rPlant;//部門
        public string rMfdate;//生產日
        public string rMfline;//生產線別
        public string rWkno;//工單號
        public string rMftable;//炊台
        public Int32 rSeqno;//序號

        public string cPlant;//部門
        public string cMfdate;//生產日
        public string cMfline;//生產線別
        public string cWkno;//工單號
        public string cMftable;//炊台
        public Int32 cSeqno;//序號

        public string fPlant;//部門
        public string fMfdate;//生產日
        public string fMfline;//生產線別
        public bool rOK = false;//按下確認鍵        

        public mfd000()
        {
            InitializeComponent();            
            Config.SetFormSize(this,"F");
            Config.SetPer(this);
            set_dept();            
            FontBlod(this, true);//加粗體
            f_sdate_s.Value = DateTime.Now;
            dataGridView1.Rows.Clear();
            //label1.Text = " 1.確認 勾選 表示存入\n 2.選擇你要的資料對著列快點兩下 可看明細資料。";
        }

        

        private void FontBlod(Control ctl_false, bool Blod)
        {
            foreach (Control c in ctl_false.Controls)
            {
                FontBlod(c, true);
                var fm = new FontFamily(c.Font.Name);//控制項字型
                var fs = c.Font.Size;//控制項字體大小
                if (c is TextBox)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is NumericUpDown)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is ComboBox)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is DateTimePicker)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
            }
        }

        //private void set_dept()
        //{
        //    //--廠部下拉選單
        //    //f_plant.DataSource = sst011.ToDoList().ToList();
        //    //f_plant.DisplayMember = "dept_name";
        //    //f_plant.ValueMember = "dept";
        //}

        private void set_dept()
        {
            //--廠部下拉選單
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(Login.DEPT_NAME, Login.DEPT));            
            f_plant.DisplayMember = "Key";
            f_plant.ValueMember = "Value";
            f_plant.DataSource = data;

        }

        //private void confirm_Click(object sender, EventArgs e)
        //{
        //    dataGridView1.Rows.Clear();
        //    var rPlant = f_plant.SelectedValue.ToString();
        //    var rBegDate = f_mfdate_beg.Text;
        //    var rEndDate = f_mfdate_end.Text;
        //    if (mfplah.ToDoList(rPlant, rBegDate, rEndDate).Count() > 0)
        //    {
        //        bindingSource1.DataSource = mfplah.ToDoList(rPlant, rBegDate, rEndDate);
        //        dataGridView1.Rows[0].Selected = true;//讓游標停在第一列
        //        //模擬點一下選取列的資料
        //        dataGridView1_Click(sender, e);
        //    }
        //    else
        //    {
        //        Config.Show("無符合資料");                
        //    }
        //}

        private void confirm_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var rPlant = f_plant.SelectedValue.ToString();
            var rBegDate = f_mfdate_beg.Text;
            var rEndDate = f_mfdate_end.Text;            
            if (mfplah.ToDoList(rPlant, rBegDate, rEndDate).Count() > 0)
            {
                bindingSource1.DataSource = mfplah.ToDoList(rPlant, rBegDate, rEndDate);

                //實際排程桶數 mfplap
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {   
                    dataGridView1.Rows[i].Cells[2].Value = mfplap.ToDoList(
                        rPlant, 
                        dataGridView1.Rows[i].Cells[1].Value.ToString(), 
                        string.Empty, 
                        dataGridView1.Rows[i].Cells[0].Value.ToString(), 
                        dataGridView1.Rows[i].Cells[0].Value.ToString()).Sum(a => a.Tubno);
                }
                //------------------                

                dataGridView1.Rows[0].Selected = true;//讓游標停在第一列
                //模擬點一下選取列的資料
                dataGridView1_Click(sender, e);
            }
            else
            {
                Config.Show("無符合資料");
            }
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            rPlant = f_plant.SelectedValue.ToString();
            rMfdate = f_mfdate_beg.Text;
            mfd000a fm = new mfd000a("A", rPlant, rMfdate, string.Empty);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //找資料 retive
                fPlant = fm.rPlant;
                fMfdate = fm.rMfdate;
                fMfline = fm.rMfline;
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();

            //如果不是上一個畫面 按確認鍵過來的就return回去
            if (rOK == false) return;    

            f_plant.SelectedValue = fPlant;
            f_sdate_s.Value = System.Convert.ToDateTime(fMfdate);
            f_sdate_e.Value = System.Convert.ToDateTime(fMfdate);

            
            //顯示明細資料
            confirm_Click(sender, e);

            //模擬點一下選取列的資料
            dataGridView1_Click( sender,  e);
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {            
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("無符合資料,請先查詢");
                return;
            }
            else
            {
                //所選到的是哪一列的index 記錄起來
                int index = dataGridView1.CurrentRow.Index;

                mfd000a fm = new mfd000a("U", cPlant, cMfdate, cMfline);
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    //找資料 retive
                    fPlant = fm.rPlant;
                    fMfdate = fm.rMfdate;
                    fMfline = fm.rMfline;
                    rOK = true;
                }
                else
                {
                    rOK = false;
                }
                fm.Dispose();

                //如果不是上一個畫面 按確認鍵過來的就return回去
                if (rOK == false) return;

                f_plant.SelectedValue = fPlant;
                f_sdate_s.Value = System.Convert.ToDateTime(fMfdate);
                f_sdate_e.Value = System.Convert.ToDateTime(fMfdate);


                //顯示明細資料(重新review所以index會改變)
                confirm_Click(sender, e);

                //整列反藍
                dataGridView1.Rows[index].Selected = true;

                //指定DataGridView的指標停留於某一欄位
                dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];

                //模擬點一下選取列的資料
                dataGridView1_Click(sender, e);
            }
            //------------

        }



        private void menu_query_Click(object sender, EventArgs e)
        {
            cancel_Click(sender, e);            
            f_sdate_s.Value = DateTime.Now;
            confirm_Click(sender, e);
        }

        //private void Show_Gdata(string rPlant, string rMfdate, string rMfline, string rMftable)
        //{
        //    var _p = mfplan.TToDoList(rPlant, rMfdate, rMfline, rMftable).ToList();
        //    bindingSource1.Clear();
        //    foreach (var i in _p.ToList())
        //    {
        //        mfplan a_mfplan = new mfplan();
        //        var p_sfb_file = sfb_file.Get(i.Wkno);

        //        a_mfplan.Mftable = i.Mftable;
        //        a_mfplan.Wkno = i.Wkno;
        //        if (i.Wkno == "樣品")
        //        {
        //            a_mfplan.Ta_sfb17 = 0; //原床厚度
        //            a_mfplan.Occ02 = string.Empty;      //客戶名稱
        //            a_mfplan.Ima02 = "MISC";      //品名
        //            a_mfplan.Ima021 = string.Empty;    //規格
        //            a_mfplan.Sfb08 = 0;      //生產數量
        //            a_mfplan.Ta_sfb19 = 0; //預計生產桶數
        //        }
        //        else
        //        {
        //            a_mfplan.Ta_sfb17 = p_sfb_file.Ta_sfb17; //原床厚度
        //            a_mfplan.Occ02 = p_sfb_file.Occ02;      //客戶名稱
        //            a_mfplan.Ima02 = p_sfb_file.Ima02;      //品名
        //            a_mfplan.Ima021 = p_sfb_file.Ima021;    //規格
        //            a_mfplan.Sfb08 = p_sfb_file.Sfb08;      //生產數量
        //            a_mfplan.Ta_sfb19 = p_sfb_file.Ta_sfb19; //預計生產桶數
        //        }
        //        a_mfplan.Tubno = i.Tubno;
        //        a_mfplan.Upmode = string.Format("{0}*{1}*{2}", i.Ta_sfb04, i.Ta_sfb02, i.Ta_sfb03);
        //        a_mfplan.Downmode = string.Format("{0}*{1}*{2}", i.Ta_sfb08, i.Ta_sfb06, i.Ta_sfb07);
        //        a_mfplan.Seqno = i.Seqno;

        //        bindingSource1.Add(a_mfplan);
        //    };
        //    //把gridview 的ckeckbox 設成打勾
        //    GridView_check_f();
        //    dataGridView1_Click(null, null);
        //}
        

        //private void menu_next_Click(object sender, EventArgs e)
        //{
        //    i = i + 1;
        //    f_show(i);
        //    if (i > LS1.Count - 1) i = LS1.Count - 1;
        //}
                

        //private void menu_previous_Click(object sender, EventArgs e)
        //{
        //    i = i - 1;
        //    f_show(i);
        //    if (i < 0) i = 0;
        //}

        private void mnu_exit_Click(object sender, EventArgs e)
        {            
            if (Config.Message("是否離開?")=="Y")
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {   
            dataGridView1.Rows.Clear();
        }
        
        //private void menu_last_Click(object sender, EventArgs e)
        //{
        //    i = LS1.Count() - 1;
        //    f_show(i);
        //}

        //private void menu_first_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    f_show(i);
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            base.OnKeyPress(e);
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
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                    (c as RadioButton).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
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
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
            }
        }

        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                SetColumn(a);
                if (a is TextBox)
                {
                    (a as TextBox).Text = "";
                    (a as TextBox).Enabled = true;
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Checked = false;
                    (a as RadioButton).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
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
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }
        }


        

        private void menu_del_Click(object sender, EventArgs e)
        {
            //所選到的是哪一列的index 記錄起來
            int index = dataGridView1.CurrentRow.Index;

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("無符合資料,請先查詢");
                return;
            }
            else
            {
                if (Config.Message("是否刪除"+"\n"+ "日期：" + cMfdate+"\n"+"線別："+cMfline) == "Y")
                {
                    new mfplah().Delete(cPlant, cMfdate, cMfline);                    
                }
                else
                {
                    return;
                }
                //顯示明細資料
                confirm_Click(sender, e);
                if (dataGridView1.RowCount == 0)
                {
                    return;
                }
                else
                {
                    index = index - 1;
                    if (index < 0) index = 0;

                    dataGridView1.Rows[index].Selected = true;//讓游標停在第一列                    
                    //指定DataGridView的指標停留於某一欄位
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];

                    //模擬點一下選取列的資料
                    dataGridView1_Click(sender, e);
                }
            }
            //------------
        }

        

        private void GridView_check_f()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = "Y";
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

        private void pri036_KeyDown(object sender, KeyEventArgs e)
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
            //刪除(Control+D)
            if (e.Control && e.KeyCode == Keys.D)
            {
                menu_del_Click(sender, e);
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
        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;
            cPlant = f_plant.SelectedValue.ToString();
            cMfdate = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();//生產日
            cMfline = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();//生產線別
                        
            //整列反藍
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_Click(sender, e);

            mfd000a fm = new mfd000a("S", cPlant, cMfdate, cMfline);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //找資料 retive
                rPlant = fm.rPlant;
                rMfdate = fm.rMfdate;
                rMfline = fm.rMfline;                
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
            //如果不是上一個畫面 按確認鍵過來的就return回去
            if (rOK == false) return;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_Click(sender, e);
        }

        //數字欄位靠右
        private void DataGrid_Right()
        {
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void mfd001_Load(object sender, EventArgs e)
        {
            DataGrid_Right();            
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

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate_beg.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
            f_mfdate_end.Text = f_mfdate_beg.Text;
        }

        private void f_sdate_e_ValueChanged(object sender, EventArgs e)
        {
            f_mfdate_end.Text = f_sdate_e.Value.ToString("yyyy/MM/dd");
        }
                
    }
}
