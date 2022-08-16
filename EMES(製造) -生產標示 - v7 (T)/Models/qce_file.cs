using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class qce_file
    {
        public static DataTable GetAll()
        {
            string sql = string.Empty;
            sql += "SELECT qce01,qce03 from qce_file where 1=1";
            sql += " and qceacti ='Y'";
            sql += " and (qce01 LIKE('0201%') or qce01 LIKE('0202%'))";
            sql += " order by qce01 ";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }
    }
}
