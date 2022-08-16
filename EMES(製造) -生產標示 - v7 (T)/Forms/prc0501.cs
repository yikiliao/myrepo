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
using EMES.Crpts;
using System.Drawing.Printing;

namespace EMES.Forms
{
    public partial class prc0501 : Form
    {
        public DataTable dtProd = new DataTable();
        public prc0501()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Init_DataTable();//初始化            
        }
        private void Init_DataTable()
        {
            //--定義datatable 欄位
            dtProd.Reset();
            dtProd.Columns.Add("mfdate", typeof(String));//生產日
            dtProd.Columns.Add("mfline", typeof(String));//利拿
            dtProd.Columns.Add("mftable", typeof(String));//壓力台
            dtProd.Columns.Add("wkno", typeof(String));//工單
            dtProd.Columns.Add("cond", typeof(String));//品名
            dtProd.Columns.Add("workqty", typeof(String));//生產數
            dtProd.Columns.Add("story", typeof(String));//樓層
            dtProd.Columns.Add("long_lower", typeof(String));//長(下限)
            dtProd.Columns.Add("long_upper", typeof(String));//長(上限)
            dtProd.Columns.Add("width_lower", typeof(String));//寬(下限)
            dtProd.Columns.Add("width_upper", typeof(String));//寬(上限)

            dtProd.Columns.Add("sfb05", typeof(String));//料號
            dtProd.Columns.Add("ta_sfb15", typeof(String));//長
            dtProd.Columns.Add("ta_sfb16", typeof(String));//寬        
            dtProd.Columns.Add("ta_sfb17", typeof(String));//高
            dtProd.Columns.Add("ima02", typeof(String));//品名
            dtProd.Columns.Add("ima021", typeof(String));//規格
            dtProd.Columns.Add("imaud02", typeof(String));//配方
            dtProd.Columns.Add("occ02", typeof(String));//客戶
            dtProd.Columns.Add("imsz", typeof(String));//長X寬X高
            dtProd.Columns.Add("imaud07", typeof(String));//熟成天數
            dtProd.Columns.Add("cold_long", typeof(String));//冷料條件-長
            dtProd.Columns.Add("cold_width", typeof(String));//冷料條件-寬
        }
                

        private void prc0501_Load(object sender, EventArgs e)
        {
            Find_D();
            var count = dtProd.Rows.Count;
            if (count == 0)
            {
                //Config.Show("...無符合資料...");
                doMsg("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(dtProd); 
            }            
        }

        private void doMsg(string Meg)
        {
            prc050_msg fm = new prc050_msg();
            fm.Msg = Meg;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //do nothing
            }
        }

        private void Print_cs(DataTable dt)
        {
            CrystalReport_prc050X rp = new CrystalReport_prc050X();
            DataTable dt2 = GetMeno();//工單備註

            rp.SetDataSource(dt);
            rp.Subreports["CrystalReport_prc050_2.rpt"].SetDataSource(dt2); //子報表-工單備註

            rp.SetParameterValue("CompName", Login.COMPNAME);//公司名稱            
            rp.SetParameterValue("ReportName", "製造課生產標示明細");//報表名稱
            rp.SetParameterValue("ReportCond", string.Empty);//列印條件
            rp.SetParameterValue("ReportId", "prc050");//程式編號 
            rp.SetParameterValue("ReportAuthor", Login.ID);//製表人
            //rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        //private void Print_cs(DataTable dt)
        //{
        //    CrystalReport_prc050 rp = new CrystalReport_prc050();
        //    DataTable dt2 = GetMeno();//工單備註

        //    rp.SetDataSource(dt);
        //    rp.Subreports["CrystalReport_prc050_2.rpt"].SetDataSource(dt2); //子報表-工單備註

        //    rp.SetParameterValue("CompName", Login.COMPNAME);//公司名稱            
        //    rp.SetParameterValue("ReportName", string.Empty);//報表名稱
        //    rp.SetParameterValue("ReportCond", string.Empty);//列印條件
        //    rp.SetParameterValue("ReportId", "prc050");//程式編號 
        //    rp.SetParameterValue("ReportAuthor", Login.ID);//製表人
        //    //rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
        //    crystalReportViewer1.ReportSource = rp;
        //    crystalReportViewer1.Refresh();
        //}        

        private void Find_D()
        {
            dtProd.Clear();
            for (int i = 0; i < prc050.dtProd.Rows.Count; i++)
            {
                string wkno = prc050.dtProd.Rows[i]["wkno"].ToString();//工單
                DataTable dt =  GetWk(wkno);
                DataRow dr = dtProd.NewRow();
                dr["mfdate"] = prc050.dtProd.Rows[i]["mfdate"].ToString();//排程日期
                dr["mfline"] = prc050.dtProd.Rows[i]["mfline"].ToString();//利拿
                dr["mftable"] = prc050.dtProd.Rows[i]["mftable"].ToString();//壓力台
                dr["wkno"] = wkno;//工單
                dr["cond"] = prc050.dtProd.Rows[i]["cond"].ToString();//規格
                dr["workqty"] = prc050.dtProd.Rows[i]["workqty"].ToString();//工單數

                dr["story"] = prc050.dtProd.Rows[i]["story"].ToString();//樓層
                dr["long_lower"] = prc050.dtProd.Rows[i]["long_lower"].ToString();//長(下限)
                dr["long_upper"] = prc050.dtProd.Rows[i]["long_upper"].ToString();//長(上限)
                dr["width_lower"] = prc050.dtProd.Rows[i]["width_lower"].ToString();//寬(下限)
                dr["width_upper"] = prc050.dtProd.Rows[i]["width_upper"].ToString();//寬(上限)

                dr["sfb05"] = dt.Rows[0]["sfb05"].ToString();
                dr["ta_sfb15"] = dt.Rows[0]["ta_sfb15"].ToString();
                dr["ta_sfb16"] = dt.Rows[0]["ta_sfb16"].ToString();
                dr["ta_sfb17"] = dt.Rows[0]["ta_sfb17"].ToString();                
                dr["ima02"] = dt.Rows[0]["ima02"].ToString();
                dr["ima021"] = dt.Rows[0]["ima021"].ToString();
                dr["imaud02"] = dt.Rows[0]["imaud02"].ToString();
                dr["occ02"] = dt.Rows[0]["occ02"].ToString();//客戶        
                dr["imsz"] = string.Format("{0}cm X {1}cm X {2}mm", 
                    dt.Rows[0]["ta_sfb15"].ToString(), 
                    dt.Rows[0]["ta_sfb16"].ToString(), 
                    dt.Rows[0]["ta_sfb17"].ToString());
                dr["imaud07"] = string.Format("{0} 天", dt.Rows[0]["imaud07"].ToString());//熟成天數

                dr["cold_long"] = string.Format("{0}～{1}", prc050.dtProd.Rows[i]["long_lower"].ToString(), prc050.dtProd.Rows[i]["long_upper"].ToString());//冷料條件_長
                dr["cold_width"] = string.Format("{0}～{1}", prc050.dtProd.Rows[i]["width_lower"].ToString(), prc050.dtProd.Rows[i]["width_upper"].ToString());//冷料條件_寬
                dtProd.Rows.Add(dr);
            }
        }

        private DataTable GetWk(string wkno)
        {
            string sql = string.Empty;
            sql += "select sfb05,ta_sfb15,ta_sfb16,ta_sfb17,ima02,ima021,imaud02,occ02,imaud07 from ew.sfb_file  ";
            sql += " LEFT OUTER JOIN ew.ima_file on ima_file.ima01 = sfb05";
            sql += " LEFT OUTER JOIN ew.occ_file on occ_file.occ01 = sfb223";
            sql += " where 1=1";
            sql += " and sfb01 ='" + wkno + "'";

            DataTable dt = DOORC.GetDataTable(Login.TT, sql);
            return dt;
        }


        private DataTable GetMeno()
        {
            string sql = string.Empty;
            sql += " select sfw01,sfw03 from ew.sfw_file where 1=1";
            sql += " order by sfw02";
            DataTable dt = DOORC.GetDataTable(Login.TT, sql);
            return dt;
        }



    }
}
