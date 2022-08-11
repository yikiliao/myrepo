using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMES.Models
{
    class Inshc
    {
        #region 資料屬性
        public string Doc { get; set; }
        public string Wkno { get; set; }
        public decimal Shc03 { get; set; }
        public string Shc04 { get; set; }
        public decimal Shc05 { get; set; }
        public string Shc06 { get; set; }
        public string Shcacti { get; set; }
        public string Shcuser { get; set; }
        public string Shcgrup { get; set; }
        public string Shcdate { get; set; }
        public string Shcplant { get; set; }
        public string Shclegal { get; set; }
        public string Shcorig { get; set; }
        public string Shcoriu { get; set; }
        public string Status { get; set; }
        #endregion

        public static string Set_Insert(Inshc rc)
        {
            string sql = string.Empty;
            sql += "insert into InShc (doc,wkno,shc03,shc04,shc05,shc06,shcacti,shcuser,shcgrup,shcdate,shcplant,shclegal,shcorig,shcoriu,status)";
            sql += string.Format("values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}');\r\n",
                rc.Doc,
                rc.Wkno,
                rc.Shc03,
                rc.Shc04,
                rc.Shc05,
                rc.Shc06,
                rc.Shcacti,
                rc.Shcuser,
                rc.Shcgrup,
                rc.Shcdate,

                rc.Shcplant,
                rc.Shclegal,
                rc.Shcorig,
                rc.Shcoriu,
                rc.Status
                );
            return sql;
        }

    }
}
