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
    class Wkhproc
    {
        #region 資料屬性
        public string Sfb01 { get; set; }//工單        
        public Int16 Ecb03 { get; set; }//製程序
        public string Schdate { get; set; }//排程日期
        public string Sfb05 { get; set; }//主件
        public string Ima02 { get; set; }//品名
        public string Ima021 { get; set; }//規格
        public string Ecb06 { get; set; }//作業編號
        public string Ecb17 { get; set; }//作業說明
        public string Ecb08 { get; set; }//工作站
        public string Eca02 { get; set; } //工作站說明
        public string Occ02 { get; set; } //工作站說明
        public string Sfb13 { get; set; } //預計開始生產日
        #endregion

        public static string Set_Insert(Wkhproc rWkhproc)
        {
            string sql = string.Empty;
            sql += "insert into Wkhproc (Sfb01,Ecb03,Schdate,Sfb05,Ima02,Ecb06,Ecb17,Ecb08,Eca02,Occ02,Sfb13) ";
            sql += string.Format("values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');\r\n",
                rWkhproc.Sfb01,
                rWkhproc.Ecb03,
                rWkhproc.Schdate,
                rWkhproc.Sfb05,
                rWkhproc.Ima02,
                rWkhproc.Ecb06,
                rWkhproc.Ecb17,
                rWkhproc.Ecb08,
                rWkhproc.Eca02,
                rWkhproc.Occ02,
                rWkhproc.Sfb13
                );
            return sql;
        }
        public static string Set_Insert2(Wkhproc rWkhproc)
        {
            string sql = string.Empty;
            sql += "insert into Wkhproc (Sfb01,Ecb03,Schdate,Sfb05,Ima02,Ima021,Ecb06,Ecb17,Ecb08,Eca02,Occ02,Sfb13) ";
            sql += string.Format("values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');\r\n",
                rWkhproc.Sfb01,
                rWkhproc.Ecb03,
                rWkhproc.Schdate,
                rWkhproc.Sfb05,
                rWkhproc.Ima02,
                rWkhproc.Ima021,
                rWkhproc.Ecb06,
                rWkhproc.Ecb17,
                rWkhproc.Ecb08,
                rWkhproc.Eca02,
                rWkhproc.Occ02,
                rWkhproc.Sfb13
                );
            return sql;
        }

        public static string Set_Delete(String sfb01,Int16 ecb03,String schdate)
        {
            string sql = string.Empty;
            sql += "delete from Wkhproc where 1=1 ";
            sql += " and Sfb01 ='" + sfb01 + "'";
            sql += " and Ecb03 =" + ecb03 + "";
            sql += " and Schdate ='" + schdate + "';\r\n";
            return sql;
        }

        public static string Set_Update(String sfb01, Int16 ecb03, String schdate, String Tchdate)
        {
            string sql = string.Empty;
            sql += "update wkhproc set schdate = '" + Tchdate + "'";
            sql += " where sfb01 ='" + sfb01 + "'";
            sql += " and ecb03 =" + ecb03 + "";
            sql += " and schdate ='" + schdate + "';\r\n";
            return sql;
        }


        public static string Set_Delete(Wkhproc rWkhproc)
        {
            string sql = string.Empty;
            sql += "delete from Wkhproc where 1=1 ";
            sql += " and Sfb01 ='" + rWkhproc.Sfb01 + "'";
            sql += " and Ecb03 ='" + rWkhproc.Ecb03 + "'";
            sql += " and Schdate ='" + rWkhproc.Schdate + "';\r\n";
            return sql;
        }

        public static DataTable ToDoList(string Dept,string Schdate_Beg,string Schdate_End,string Ecb08,string Ecb06)
        {
            string sql = string.Empty;
            sql += "select * from wkhproc where 1=1 ";
            sql += " and SUBSTRING(sfb01,1,1)='" + Dept + "'";
            sql += " and schdate BETWEEN '" + Schdate_Beg + "' and '" + Schdate_End + "'";            
            sql += " and ecb08 ='" + Ecb08 + "'";
            sql += " and ecb06 ='" + Ecb06 + "'";
            sql += " order by schdate,sfb01";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static int  Delete(string Dept, string Schdate_Beg, string Schdate_End, string Ecb08, string Ecb06)
        {
            String sql = null;
            sql += "delete from wkhproc where 1=1 ";
            sql += " and SUBSTRING(sfb01,1,1)='" + Dept + "'";
            sql += " and schdate BETWEEN '" + Schdate_Beg + "' and '" + Schdate_End + "'";
            sql += " and ecb08 ='" + Ecb08 + "'";
            sql += " and ecb06 ='" + Ecb06 + "'";
            int i = DOSQL.Excute(Login.WU, sql);
            return i;
        }

        public static Boolean havesch(string Sfb01, Int16 Ecb03, string Schdate)
        {
            Boolean rd = false;
            string sql = string.Empty;
            sql += "select * from wkhproc where 1=1 ";
            sql += " and sfb01='" + Sfb01 + "'";
            sql += " and schdate = '" + Schdate + "'";
            sql += " and ecb03 =" + Ecb03 + "";            
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            if (dt.Rows.Count > 0) rd = true;
            return rd;
        }


    }
}
