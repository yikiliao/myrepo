using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class ecg_file
    {
        #region 資料屬性
        public string Ecg01 { get; set; }
        public string Ecg02 { get; set; }
        #endregion

        public static DataTable ToDoList()
        {
            string sql = string.Empty;
            sql += "SELECT ecg01,ecg02 from ecg_file where 1=1 ";
            sql += " and ecgacti ='Y'";
            sql += " order by ecg01 ";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
