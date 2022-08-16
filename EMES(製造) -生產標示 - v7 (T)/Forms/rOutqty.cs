using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMES.Forms
{
    public partial class rOutqty : Form
    {
        public DataTable dtProd = new DataTable();
        public int sumSch05;
        public string Sch06;
        public string Sch06no;
        public rOutqty()
        {
            InitializeComponent();
            initForm();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void initForm()
        {
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //--定義datatable 欄位
            dtProd.Columns.Add("shc03", typeof(String));
            dtProd.Columns.Add("shc04", typeof(String));
            dtProd.Columns.Add("shc04name", typeof(String));
            dtProd.Columns.Add("shc05", typeof(String));
            dtProd.Columns.Add("shc06", typeof(String));
            dtProd.Columns.Add("shc06no", typeof(String));

            //標題字體
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView1.DefaultCellStyle.Font = new Font("新細明體", 22);

            //--
            getdv();
        }
        

        private void getdv()
        {
            DataTable dt = prc020.dtFewProd;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[] {dt.Rows[i]["shc03"].ToString(),
                dt.Rows[i]["shc04"].ToString(),
                dt.Rows[i]["shc04name"].ToString(),
                dt.Rows[i]["shc05"].ToString(),
                dt.Rows[i]["shc06"].ToString(),
                dt.Rows[i]["shc06no"].ToString()});
            }
        }


        private void btn_qce01_Click(object sender, EventArgs e)
        {
            rQce fm = new rQce();
            fm.Dept = string.Empty;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //接收回傳資料
                DataTable dt = fm.dtProd;
                RecordShow(dt);//顯示資料
            }
        }
        private void RecordShow(DataTable dt)
        {
            f_r_shc04.Text = dt.Rows[0]["qce01"].ToString();
            f_r_shc04_name.Text = dt.Rows[0]["qce03"].ToString();
            f_r_shc06.Text = Sch06;
            f_r_shc06_no.Text = Sch06no;
        }

        private void isDecimal(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar != 46 &&
                (byte)e.KeyChar != 49 &&
                (byte)e.KeyChar != 50 &&
                (byte)e.KeyChar != 51 &&
                (byte)e.KeyChar != 52 &&
                (byte)e.KeyChar != 53 &&
                (byte)e.KeyChar != 54 &&
                (byte)e.KeyChar != 55 &&
                (byte)e.KeyChar != 56 &&
                (byte)e.KeyChar != 57 &&
                (byte)e.KeyChar != 48 &&
                (byte)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btn_upd_Click(object sender, EventArgs e)
        {
            if (f_RecordCK() == false)
            {
                MessageBox.Show("欄位不可空白");
                return;
            }

            //檢查製程序編號
            if (Ecm03Doub() == true)
            {
                rowUpd();
            }
            else
            {
                rowAdd();
            }
            f_RecordClear();
        }

        private void rowUpd()
        {
            Int16 a = System.Convert.ToInt16(f_r_shc03.Text); //製程序

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Int32 b = System.Convert.ToInt32(dataGridView1.Rows[i].Cells["shc03"].Value.ToString());
                if (a == b)
                {                    
                    dataGridView1.Rows[i].Cells["shc04"].Value = f_r_shc04.Text;
                    dataGridView1.Rows[i].Cells["shc04name"].Value = f_r_shc04_name.Text;
                    dataGridView1.Rows[i].Cells["shc05"].Value = f_r_shc05.Text;
                    dataGridView1.Rows[i].Cells["shc06"].Value = f_r_shc06.Text;
                    dataGridView1.Rows[i].Cells["shc06no"].Value = f_r_shc06_no.Text;
                }
            }

        }

            private bool Ecm03Doub()
        {
            bool rf = false;
            Int32 a = f_r_shc03.Text.Length == 0 ? 0 : System.Convert.ToInt32(f_r_shc03.Text);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Int32 b = System.Convert.ToInt32(dataGridView1.Rows[i].Cells["shc03"].Value.ToString());
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
            if (f_r_shc04.Text.ToString().Trim().Length == 0 ||
                f_r_shc05.Text.ToString().Trim().Length == 0 ||
                f_r_shc06.Text.ToString().Trim().Length == 0 ||
                f_r_shc06_no.Text.ToString().Trim().Length == 0 ||
                f_r_shc04_name.Text.ToString().Trim().Length == 0)
            {
                rf = false;
            }
            else
            {
                rf = true;
            }
            return rf;
        }


        private void rowAdd()
        {
            int ridx = 0;
            ridx = dataGridView1.Rows.Count + 1;
            dataGridView1.Rows.Add(new object[] {ridx,
                f_r_shc04.Text,
                f_r_shc04_name.Text,
                f_r_shc05.Text,
                f_r_shc06.Text,
                f_r_shc06_no.Text});
            GvSort();//排序
        }

        private void GvSort()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["shc03"].Value = i + 1;
            }
            // 根據 資料行1 (Name) 做 小到大 排序 
            dataGridView1.Sort(dataGridView1.Columns["shc03"], System.ComponentModel.ListSortDirection.Ascending);
        }

        //private void GvSort()
        //{
        //    // 根據 資料行1 (Name) 做 小到大 排序 
        //    dataGridView1.Sort(dataGridView1.Columns["shc03"], System.ComponentModel.ListSortDirection.Ascending);

        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        dataGridView1.Rows[i].Cells["shc03"].Value = i + 1;
        //    }
        //}

        private void f_RecordClear()
        {
            f_r_shc03.Text = string.Empty;
            f_r_shc04.Text = string.Empty;
            f_r_shc05.Text = string.Empty;
            f_r_shc06.Text = string.Empty;
            f_r_shc06_no.Text = string.Empty;
            f_r_shc04_name.Text = string.Empty;
        }

        //private void btn_Del_Click(object sender, EventArgs e)
        //{
        //    if (f_r_shc04.Text.Length == 0) return;
        //    if (Config.Message("確定刪除?") == "Y")
        //    {
        //        foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
        //        {
        //            dataGridView1.Rows.RemoveAt(item.Index);
        //        }
        //        f_RecordClear();
        //    }
        //    GvSort();
        //}

        private void btn_Del_Click(object sender, EventArgs e)
        {
            DelBadQty();
        }

        private void DelBadQty()
        {
            if (f_r_shc04.Text.Length == 0) return;
            if (Config.Message("確定刪除?") == "Y")
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
                f_RecordClear();
            }
            GvSort();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
            //匯入相關資料
            SingRecord();
        }

        private void SingRecord()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    f_r_shc03.Text = dataGridView1.Rows[i].Cells["shc03"].Value.ToString();
                    f_r_shc04.Text = dataGridView1.Rows[i].Cells["shc04"].Value.ToString();
                    f_r_shc04_name.Text = dataGridView1.Rows[i].Cells["shc04name"].Value.ToString();
                    f_r_shc05.Text = dataGridView1.Rows[i].Cells["shc05"].Value.ToString();
                    f_r_shc06.Text = dataGridView1.Rows[i].Cells["shc06"].Value.ToString();
                    f_r_shc06_no.Text = dataGridView1.Rows[i].Cells["shc06no"].Value.ToString();
                }
            }
        }

        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            switch (bt.Text)
            {
                case "C":
                    f_r_shc05.Text = string.Empty;
                    f_r_shc05.Select();
                    f_r_shc05.Focus();
                    break;

                case "<--":
                    if (f_r_shc05.Text.Trim().Length == 0) break;
                    f_r_shc05.Text = f_r_shc05.Text.Substring(0, f_r_shc05.Text.Length - 1);
                    break;

                default:
                    f_r_shc05.Text += bt.Text;
                    break;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Add_();
        }

        private void Add_()
        {
            sumSch05 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataRow dr = dtProd.NewRow();
                dr["shc03"] = dataGridView1.Rows[i].Cells["shc03"].Value.ToString();
                dr["shc04"] = dataGridView1.Rows[i].Cells["shc04"].Value.ToString();
                dr["shc04name"] = dataGridView1.Rows[i].Cells["shc04name"].Value.ToString();
                dr["shc05"] = dataGridView1.Rows[i].Cells["shc05"].Value.ToString();
                dr["shc06"] = dataGridView1.Rows[i].Cells["shc06"].Value.ToString();
                dr["shc06no"] = dataGridView1.Rows[i].Cells["shc06no"].Value.ToString();
                dtProd.Rows.Add(dr);
                sumSch05 += System.Convert.ToInt16(dr["shc05"].ToString());
            }                    
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void btn_DelBadQty_Click(object sender, EventArgs e)
        {
            DelBadQty();
        }
    }
}
