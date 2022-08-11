using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class Procscmday
    {
        #region 資料屬性
        public string Sfb01 { get; set; }//工單        
        public Int16 Ecb03 { get; set; }//製程序
        public string Schdate { get; set; }//排程日期        
        public string Ecm04 { get; set; }//作業編號
        public string Ecm45 { get; set; }//作業說明
        public string Ecm06 { get; set; }//工作站
        public string Eca02 { get; set; } //工作站說明        
        #endregion

        public static DataTable GroupEcm06(string Schdate)
        {
            string sql = string.Empty;
            sql += "SELECT procscmday.ecm06,procscmday.eca02 from procscmday ";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procscmday.sfb01";
            sql += " WHERE 1=1 ";
            sql += " and procscmday.schdate ='" + Schdate + "'";
            sql += " and sfb_file.status ='3'";
            sql += " GROUP BY procscmday.ecm06,procscmday.eca02";
            sql += " ORDER BY procscmday.ecm06";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        //public static DataTable GroupEcm06(string Schdate)
        //{
        //    string sql = string.Empty;
        //    sql += "SELECT ecm06,eca02 from procscmday WHERE 1=1 ";
        //    sql += " and schdate ='" + Schdate + "'";
        //    sql += " GROUP BY ecm06,eca02";
        //    sql += " ORDER BY ecm06";
        //    DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
        //    return dt;
        //}

        

        public static DataTable GroupSfb01(string Schdate,string Ecm06)
        {
            string sql = string.Empty;
            sql += "SELECT sfb01 FROM procscmday WHERE 1=1 ";
            sql += " and schdate ='" + Schdate + "'";
            sql += " and ecm06 ='" + Ecm06 + "'";
            sql += " GROUP BY sfb01";
            sql += " ORDER BY sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable DayWkList(string Dept,string Schdate)
        {
            string sql = string.Empty;
            sql += "SELECT procscmday.sfb01,sfb_file.sfb05,ima_file.ima02,ima_file.ima021,sfb_file.sfb08 from procscmday";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procscmday.sfb01";
            sql += " LEFT OUTER JOIN ima_file on ima_file.ima01 = sfb_file.sfb05";
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(procscmday.sfb01,1,1)='" + Dept + "'";
            sql += " and procscmday.schdate = '" + Schdate + "'";
            sql += " ORDER BY procscmday.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable DayWkList(string Dept, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT procscmday.sfb01,sfb_file.sfb05,ima_file.ima02,ima_file.ima021,sfb_file.sfb08 from procscmday";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procscmday.sfb01";
            sql += " LEFT OUTER JOIN ima_file on ima_file.ima01 = sfb_file.sfb05";
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(procscmday.sfb01,1,1)='" + Dept + "'";
            sql += " and procscmday.schdate = '" + Schdate + "'";
            sql += " and procscmday.ecm06 = '" + Station + "'";
            sql += " and sfb_file.status = '3'";//已派工
            sql += " group by procscmday.sfb01,sfb_file.sfb05,ima_file.ima02,ima_file.ima021,sfb_file.sfb08";
            sql += " ORDER BY procscmday.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }


        public static DataTable DayWkSeqList(string sfb01,string Schdate)
        {
            string sql = string.Empty;
            sql += "SELECT ecb03,ecm04,ecm45,ecm06,eca02 from procscmday";
            sql += " WHERE 1=1";
            sql += " and sfb01 ='" + sfb01 + "'";
            sql += " and schdate ='" + Schdate + "'";
            sql += " ORDER BY procscmday.ecb03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable DayWkSeqList(string sfb01, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT ecb03,ecm04,ecm45,ecm06,eca02 from procscmday";
            sql += " WHERE 1=1";
            sql += " and sfb01 ='" + sfb01 + "'";
            sql += " and schdate ='" + Schdate + "'";
            sql += " and ecm06 ='" + Station + "'";
            sql += " ORDER BY procscmday.ecb03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }


    }
}
