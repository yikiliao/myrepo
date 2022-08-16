using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class Procscm
    {
        #region 資料屬性
        public string Sfb01 { get; set; }//工單        
        public Int16 Ecb03 { get; set; }//製程序
        public string Schdate { get; set; }//排程日期        
        public string Ecm04 { get; set; }//作業編號
        public string Ecm45 { get; set; }//作業說明
        public string Ecm06 { get; set; }//工作站
        public string Eca02 { get; set; } //工作站說明        
        #endregion

        public static string Set_Insert(Procscm rc)
        {
            string sql = string.Empty;
            sql += "insert into procscm (Sfb01,Ecb03,Schdate,Ecm04,Ecm45,Ecm06,Eca02) ";
            sql += string.Format("values('{0}',{1},'{2}','{3}','{4}','{5}','{6}');\r\n",
                rc.Sfb01,
                rc.Ecb03,
                rc.Schdate,
                rc.Ecm04,
                rc.Ecm45,
                rc.Ecm06,
                rc.Eca02
                );
            return sql;
        }

        public static DataTable SumScm(string Schdate,string Ecm04)
        {
            string sql = string.Empty;
            //sql += "SELECT procscm.sfb01,procscm.ecm04,procscm.ecm45,procscm.ecm06,procscm.eca02,sfb_file.sfb08 from procscm";
            sql += "SELECT procscm.sfb01,procscm.ecm04,sfb_file.sfb08 from procscm";
            sql += " LEFT OUTER JOIN sfb_file on sfb_file.sfb01 = procscm.sfb01";
            sql += " WHERE 1=1";
            sql += " and procscm.schdate = '" + Schdate + "'";
            sql += " and procscm.ecm04 = '" + Ecm04 + "'";
            sql += " ORDER BY procscm.sfb01";            
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

    }
}
