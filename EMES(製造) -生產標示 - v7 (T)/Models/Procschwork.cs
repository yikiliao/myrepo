using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class Procschwork
    {
        public static DataTable GroupEcm06(string Schdate)
        {
            string sql = string.Empty;
            sql += "SELECT procschwork.ecm06,procschwork.eca02 from procschwork ";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procschwork.ecm01 ";
            sql += " WHERE 1=1 ";
            sql += " and '" + Schdate + "' BETWEEN procschwork.begdate and procschwork.enddate";
            sql += " and sfb_file.status ='3'";
            sql += " GROUP BY procschwork.ecm06,procschwork.eca02";
            sql += " ORDER BY procschwork.ecm06";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable DayCutList(string Dept, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT sfb_file.sfb01 ,sfb_file.sfb05,sfb_file.ima02,sfb_file.ima021,sfb_file.sfb08,ecm03,ecm04,ecm45 from procschwork";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procschwork.ecm01 ";
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(procschwork.ecm01,1,1)='" + Dept + "'";
            sql += " and '" + Schdate + "' BETWEEN procschwork.begdate and procschwork.enddate";
            sql += " and procschwork.ecm06 = '" + Station + "'";
            sql += " and sfb_file.status = '3'";//已派工
            sql += " group by sfb_file.sfb01,sfb_file.sfb05,sfb_file.ima02,sfb_file.ima021,sfb_file.sfb08,ecm03,ecm04,ecm45";
            sql += " ORDER BY sfb_file.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }



        public static DataTable DayWkList(string Dept, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT sfb_file.sfb01 ,sfb_file.sfb05,sfb_file.ima02,sfb_file.ima021,sfb_file.sfb08 from procschwork";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procschwork.ecm01 ";
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(procschwork.ecm01,1,1)='" + Dept + "'";
            sql += " and '" + Schdate + "' BETWEEN procschwork.begdate and procschwork.enddate";
            sql += " and procschwork.ecm06 = '" + Station + "'";
            sql += " and sfb_file.status = '3'";//已派工
            sql += " group by sfb_file.sfb01,sfb_file.sfb05,sfb_file.ima02,sfb_file.ima021,sfb_file.sfb08";
            sql += " ORDER BY sfb_file.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable DayWkSeqList(string sfb01, string Schdate, string Station)
        {
            string sql = string.Empty;
            sql += "SELECT ecm03 ecb03,ecm04,ecm45,ecm06,eca02 from procschwork ";
            sql += " WHERE 1=1";
            sql += " and ecm01 ='" + sfb01 + "'";
            sql += " and '" + Schdate + "' BETWEEN procschwork.begdate and procschwork.enddate";
            sql += " and ecm06 ='" + Station + "'";
            sql += " ORDER BY procschwork.ecm03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
