using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class Procscmwork
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
            sql += "SELECT procscmwork.ecm06,procscmwork.eca02 from procscmwork ";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procscmwork.sfb01";
            sql += " WHERE 1=1 ";
            sql += " and procscmwork.schdate ='" + Schdate + "'";
            sql += " and sfb_file.status ='3'";
            sql += " GROUP BY procscmwork.ecm06,procscmwork.eca02";
            sql += " ORDER BY procscmwork.ecm06";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        
        public static DataTable DayWkList(string Dept, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT procscmwork.sfb01,sfb_file.sfb05,sfb_file.ima02,sfb_file.ima021,sfb_file.sfb08 from procscmwork";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procscmwork.sfb01";            
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(procscmwork.sfb01,1,1)='" + Dept + "'";
            sql += " and procscmwork.schdate = '" + Schdate + "'";
            sql += " and procscmwork.ecm06 = '" + Station + "'";
            sql += " and sfb_file.status = '3'";//已派工
            sql += " group by procscmwork.sfb01,sfb_file.sfb05,sfb_file.ima02,sfb_file.ima021,sfb_file.sfb08";
            sql += " ORDER BY procscmwork.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable DayWkSeqList(string sfb01, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT ecb03,ecm04,ecm45,ecm06,eca02 from procscmwork";
            sql += " WHERE 1=1";
            sql += " and sfb01 ='" + sfb01 + "'";
            sql += " and schdate ='" + Schdate + "'";
            sql += " and ecm06 ='" + Station + "'";
            sql += " ORDER BY procscmwork.ecb03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }


    }
}
