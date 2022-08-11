using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EMES.Forms;

namespace EMES.Models
{
    class Wfdwk
    {
        public static DataTable ToDoList(string dept, string ecb06, string ecb08)
        {
            string sql = "";
            sql += "SELECT sfb01,sfb05,ima02,ima021,sfb06,sfb81,sfb13,ecb03,ecb06,ecb17,ecb08,eca02,occ02 from sfb_file";
            sql += " LEFT OUTER JOIN ima_file on ima01 = sfb_file.sfb05";
            sql += " LEFT OUTER JOIN ecb_file on ecb02 = sfb_file.sfb06";
            sql += " LEFT OUTER JOIN eca_file on eca01 = ecb_file.ecb08";
            sql += " LEFT OUTER JOIN occ_file on occ01 = sfb_file.sfb223";
            sql += " WHERE 1=1";
            //sql += " and sfb_file.sfb01 like ('JS012%')";
            sql += " and SUBSTRING(sfb01,1,1)='" + dept + "'";
            sql += " and ecb_file.ecb06 ='" + ecb06 + "'";
            sql += " and ecb_file.ecb08 ='" + ecb08 + "'";
            sql += " ORDER BY sfb_file.sfb01,ecb_file.ecb03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable ToDoList(string dept)
        {
            string rf = string.Empty;
            if (dept == "J") rf = "JS012%";
            if (dept == "W") rf = "WS012%";
            string sql = "";
            sql += "SELECT sfb01,occ02,ima01,ima02,ima021,sfb02,sfb06,sfb08,sfb13 from sfb_file";
            sql += " LEFT OUTER JOIN ima_file on ima01 = sfb_file.sfb05";
            sql += " LEFT OUTER JOIN occ_file on occ01 = sfb_file.sfb223";
            sql += " WHERE 1=1";
            sql += " and sfb_file.sfb01 like ('" + rf + "')";
            sql += " ORDER BY sfb_file.sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }


        public static DataTable ToDoList(string dept,string schdate, string ecb06, string ecb08)
        {
            string sql = "";
            sql += "SELECT sfb01,sfb05,ima02,ima021,sfb06,sfb81,sfb13,ecb03,ecb06,ecb17,ecb08,eca02,occ02 from sfb_file";
            sql += " LEFT OUTER JOIN ima_file on ima01 = sfb_file.sfb05";
            sql += " LEFT OUTER JOIN ecb_file on ecb02 = sfb_file.sfb06";
            sql += " LEFT OUTER JOIN eca_file on eca01 = ecb_file.ecb08";
            sql += " LEFT OUTER JOIN occ_file on occ01 = sfb_file.sfb223";
            sql += " WHERE 1=1";
            //sql += " and sfb_file.sfb01 like ('JS012%')";
            sql += " and SUBSTRING(sfb01,1,1)='" + dept + "'";            
            sql += " and ecb_file.ecb06 ='" + ecb06 + "'";
            sql += " and ecb_file.ecb08 ='" + ecb08 + "'";
            sql += " ORDER BY sfb_file.sfb01,ecb_file.ecb03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }
    }
}
