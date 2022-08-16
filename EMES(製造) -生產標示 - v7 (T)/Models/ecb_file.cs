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
    class ecb_file
    {
        public static DataTable ToDoList(string rSel)
        {
            string sql = string.Empty;
            sql += "select ecb06,ecb17 from ecb_file where ecb08='" + rSel + "'";
            sql += " GROUP BY ecb06,ecb17";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable GToDoList(string Dept)
        {
            string sql = string.Empty;
            sql += "select ecb06,ecb17 from ecb_file WHERE 1=1";
            sql += " and SUBSTRING(ecb06,1,1)='" + Dept + "'";
            sql += " GROUP BY ecb06,ecb17";
            sql += " ORDER BY ecb06";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
