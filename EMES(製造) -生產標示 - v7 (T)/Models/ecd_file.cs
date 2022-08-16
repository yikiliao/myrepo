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
    class ecd_file
    {
        #region 資料屬性
        public string Ecd01 { get; set; }
        public string Ecd02 { get; set; }
        #endregion

        public static DataTable ToDoList(string rSel)
        {
            string sql = string.Empty;
            sql += "select ecd01,ecd02 from ecd_file where ecd07='" + rSel + "'";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable GetAll(string Dept)
        {
            string sql = string.Empty;
            sql += "select ecd01,ecd02,ecd05,ecd07 from ecd_file where 1=1";
            sql += " and ecdacti ='Y'";
            if (Dept.Length > 0)
            {
                sql += " and SUBSTRING(ecd01,1,1)='" + Dept + "'";
            }
            sql += " order by ecd01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
