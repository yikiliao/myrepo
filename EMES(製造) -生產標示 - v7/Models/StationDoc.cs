using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;
using System.Configuration;

namespace EMES.Models
{
  public  class StationDoc
    {
        #region 資料屬性        
        public string Station { get; set; }
        public string DocType { get; set; }
        public string DocName { get; set; }
        #endregion

        public static string Set_Insert(StationDoc p_)
        {
            string sql = string.Empty;
            sql += "insert into StationDoc (Station,DocType, DocName) ";
            sql += string.Format("values('{0}','{1}','{2}');\r\n",
                p_.Station,
                p_.DocType,
                p_.DocName);
            return sql;
        }

        public static string Set_Update(StationDoc p_)
        {
            string sql = string.Empty;
            sql += "update StationDoc set DocType ='" + p_.DocType + "',";
            sql += " DocName ='" + p_.DocName + "'";
            sql += " where Station = '" + p_.Station + "';\r\n";
            return sql;
        }


        public static IEnumerable<StationDoc> ToDoList()
        {
            string sql = null;
           
            sql += "select * from StationDoc where 1=1 ";
            sql += " order by Station ";

            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return from p in dt.AsEnumerable()
                   select new StationDoc
                   {
                       Station = p.IsNull("Station") ? "" : p.Field<string>("Station").Trim(),
                       DocType = p.IsNull("DocType") ? "" : p.Field<string>("DocType").Trim(),
                       DocName = p.IsNull("DocName") ? "" : p.Field<string>("DocName").Trim(),
                   };
        }

        public static string getDocType(string rStation)
        {
            string sql = "";
            sql += "select * from StationDoc where 1=1";
            sql += " and Station ='" + rStation + "'";
            DataTable a = DOSQL.GetDataTable(Login.WU, sql);
            return a.Rows[0]["DocType"].ToString();
        }

        

        public static string getDocNO(string Dept, string DocType)
        {            
            string rDoc = string.Empty;
            string Nd = DateTime.Now.ToString("yyyy/MM/dd");
            string rTy = Dept.ToUpper() + DocType + Nd.Substring(2, 2) + Nd.Substring(5, 2) + Nd.Substring(8, 2);
            string sql = "";
            sql += "SELECT * FROM InProc WHERE doc LIKE '" + rTy + "%'";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            if (dt.Rows.Count == 0)
            {
                rDoc = string.Format("{0}{1}", rTy, "001");
            }
            else
            {
                sql = "";
                sql += "SELECT convert(int, max(SUBSTRING(doc,10,3)))+1 AS a  FROM InProc WHERE doc LIKE '" + rTy + "%'";
                DataTable dt1 = DOSQL.GetDataTable(Login.WU, sql);
                int a1 = (int)dt1.Rows[0]["a"];
                rDoc = string.Format("{0}{1}", rTy, a1.ToString("000"));
            }
            return rDoc;
        }

        public static string getDocNO(string Dept)
        {
            string rDoc = string.Empty;
            string Nd = DateTime.Now.ToString("yyyy/MM/dd");
            string rTy = Dept.ToUpper() + Nd.Substring(2, 2) + Nd.Substring(5, 2) + Nd.Substring(8, 2);
            string sql = "";
            sql += "SELECT * FROM InProc WHERE doc LIKE '" + rTy + "%'";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            if (dt.Rows.Count == 0)
            {
                rDoc = string.Format("{0}{1}", rTy, "001");
            }
            else
            {
                sql = "";
                sql += "SELECT convert(int, max(SUBSTRING(doc,8,3)))+1 AS a  FROM InProc WHERE doc LIKE '" + rTy + "%'";
                DataTable dt1 = DOSQL.GetDataTable(Login.WU, sql);
                int a1 = (int)dt1.Rows[0]["a"];
                rDoc = string.Format("{0}{1}", rTy, a1.ToString("000"));
            }
            return rDoc;
        }


        public static DataTable getNextStation(string WkNo,Int16 WkSeq)
        {
            string sql = string.Empty;
            sql += "SELECT top 1 * FROM procschwork WHERE 1=1";
            sql += " and ecm01 = '" + WkNo + "'";
            sql += " and ecm03 >" + WkSeq;
            sql += " ORDER BY ecm03";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }

        public static string getNextCdept(string rc)
        {
            string rf = string.Empty;
            DataTable p_eca = eca_file.Get(rc);
            if (p_eca.Rows.Count == 0)
                rf = "";
            else
                rf = p_eca.Rows[0][2].ToString();
            return rf;
        }

        public static string getNextMach(string rc)
        {
            string rf = string.Empty;
            DataTable p_eci = eci_file.GetFirst(rc);
            if (p_eci.Rows.Count == 0)
                rf = "";
            else
                rf = p_eci.Rows[0][0].ToString();
            return rf;
        }


    }
}
