using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class Procsch
    {
        #region 資料屬性
        public string Ecm01 { get; set; }
        public Int16 Ecm03 { get; set; }
        public string Ecm04 { get; set; }
        public string Ecm45 { get; set; }
        public string Ecm06 { get; set; }
        public string Eca02 { get; set; }
        public string Begdate { get; set; }
        public string Enddate { get; set; }
        public Int16 Rg { get; set; }//間距
        public string Schdate { get; set; }
        #endregion

        public static string Set_Insert(Procsch rProcsch)
        {
            string sql = string.Empty;
            sql += "insert into procsch (ecm01,ecm03,ecm04,ecm45,ecm06,eca02,begdate,enddate,rg,schdate) ";
            sql += string.Format("values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}');\r\n",
                rProcsch.Ecm01,
                rProcsch.Ecm03,
                rProcsch.Ecm04,
                rProcsch.Ecm45,
                rProcsch.Ecm06,
                rProcsch.Eca02,
                rProcsch.Begdate,
                rProcsch.Enddate,
                rProcsch.Rg, rProcsch.Schdate);
            return sql;
        }

        public static string Set_Delete(string Sfb01)
        {
            string sql = string.Empty;
            sql += "delete procsch where sfb01='" + Sfb01 + "'";
            return sql;
        }

    }
}
