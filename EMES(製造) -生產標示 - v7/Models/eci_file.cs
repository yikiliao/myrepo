using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class eci_file
    {
        #region 資料屬性
        public string Eci01 { get; set; }
        public string Eci02 { get; set; }
        public string Eci06 { get; set; }
        public string Eca03 { get; set; }
        public string Gem02 { get; set; }
        #endregion

        
        public static DataTable ToDoList(string rSel,string Eci03)
        {
            string sql = string.Empty;
            sql += "SELECT eci_file.eci01,eci_file.eci03,eci_file.eci06,eca_file.eca03,gem_file.gem02 FROM 	eci_file";
            sql += " LEFT OUTER JOIN eca_file on eca_file.eca01 = eci_file.eci03";
            sql += " LEFT OUTER JOIN gem_file on gem_file.gem01 = eca_file.eca03";
            sql += " where 1=1";
            sql += " and SUBSTRING(eci01,1,1)='" + rSel + "'";
            sql += " and eci03='" + Eci03 + "'";
            sql += " ORDER BY eci_file.eci01 ";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static DataTable GetFirst(string Eci03)
        {
            string sql = string.Empty;
            sql += "SELECT top 1 eci01,eci03,eci06 from eci_file where 1=1";
            sql += " and eci03 ='" + Eci03 + "'";
            sql += " ORDER BY eci01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
