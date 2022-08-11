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
    class eca_file
    {
        #region 資料屬性
        public string Eca01 { get; set; }
        public string Eca02 { get; set; }
        #endregion

        

        public static DataTable ToDoList(string eca01)
        {
            string sql = string.Empty;
            sql += "SELECT eca01,eca02,eca03 from eca_file";
            sql += " where 1=1";
            if (!string.IsNullOrEmpty(eca01))
            {
                sql += " and eca01='" + eca01 + "'";
            }
            sql += " order by eca01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }



        public static DataTable GetAll(string Dept)
        {
            string sql = string.Empty;
            sql += "SELECT eca01,eca02 from eca_file where 1=1";
            sql += " and ecaacti ='Y'";
            if (Dept.Length > 0)
            {
                sql += " and SUBSTRING(eca01,1,1)='" + Dept + "'";
            }
            sql += " order by eca01 ";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable Get(string Eca01)
        {
            string sql = string.Empty;
            sql += "SELECT eca01,eca02,eca03 from eca_file where 1=1";
            sql += "and eca01 ='" + Eca01 + "'";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }


        //public static DataTable GToDoList(string rSel)
        //{
        //    string sql = string.Empty;
        //    sql += "SELECT eca01, eca02 from eca_file";
        //    sql += " RIGHT JOIN ecd_file on ecd07 = eca_file.eca01";
        //    sql += " WHERE 1=1";
        //    sql += " and ecaacti ='Y'";
        //    sql += " GROUP BY eca01,eca02";
        //    sql += " order by eca01 ";
        //    DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
        //    return dt;
        //}

        public static DataTable GToDoList(string rSel)
        {
            string sql = string.Empty;
            sql += "SELECT eca01, eca02 from eca_file";
            //sql += " RIGHT JOIN ecd_file on ecd07 = eca_file.eca01";
            sql += " RIGHT JOIN ecb_file on ecb08 = eca_file.eca01";
            sql += " RIGHT JOIN gem_file on gem01 = eca_file.eca03 and gem_file.gem02 like ('%-加工%')";
            sql += " WHERE 1=1";
            sql += " and ecaacti ='Y'";
            sql += " and SUBSTRING(eca01,1,1)='" + rSel + "'";
            sql += " GROUP BY eca01,eca02";
            sql += " order by eca01 ";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
