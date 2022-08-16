using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EMES.Forms;

namespace EMES.Models
{
  public  class Proch
    {
        #region 資料屬性
        public string Dept { get; set; }//營運中心
        public string Station { get; set; }//生產日
        public string Docno { get; set; }//單據號
        public string Mfd { get; set; }//輸入日
        public decimal Works { get; set; }//作業人數
        public decimal Gp { get; set; }//良品
        public decimal Ng { get; set; }//不良
        public string Jobgo { get; set; }//工作開始
        public string Jobed { get; set; }//工作結束
        public string Adduser { get; set; } //新增人員
        public string Adddate { get; set; } //輸入時間
        public string Moduser { get; set; } //異動者
        public string Moddate { get; set; } //異動時間
        #endregion

        public static IEnumerable<Proch> ToDoList(string rDept, string rBegDate, string rEndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from Proch where 1=1 ";

            //廠部            
            if (!string.IsNullOrEmpty(rDept.Trim()))
            {
                sql += " and dept= '" + rDept.Trim() + "'";
            }

            //生產日期
            if (!string.IsNullOrEmpty(rBegDate.Trim()))
            {
                sql += " and mfd >='" + rBegDate.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(rEndDate.Trim()))
            {
                parm.Add(rEndDate.Trim());
                sql += " and mfd <= '" + rEndDate.Trim() + "'";
            }
            sql += " order by dept,station,mfd ";


            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return from p in dt.AsEnumerable()
                   select new Proch
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Station = p.IsNull("Station") ? "" : p.Field<string>("Station").Trim(),
                       Docno = p.IsNull("Docno") ? "" : p.Field<string>("Docno").Trim(),
                       Mfd = p.IsNull("Mfd") ? "" : p.Field<string>("Mfd").Trim(),
                       Works = p.IsNull("Works") ? 0 : p.Field<decimal>("Works"),
                       Gp = p.IsNull("gp") ? 0 : p.Field<decimal>("gp"),
                       Ng = p.IsNull("ng") ? 0 : p.Field<decimal>("ng"),
                       Jobgo = p.IsNull("Jobgo") ? "" : p.Field<DateTime>("Jobgo").ToString("yyyy/MM/dd HH:mm:ss.fff"),
                       Jobed = p.IsNull("Jobed") ? "" : p.Field<DateTime>("Jobed").ToString("yyyy/MM/dd HH:mm:ss.fff"),
                       //Adduser = p.IsNull("adduser") ? "" : p.Field<string>("adduser").Trim(),
                       //Adddate = p.IsNull("adddate") ? "" : p.Field<string>("adddate").Trim(),
                       //Moduser = p.IsNull("moduser") ? "" : p.Field<string>("moduser").Trim(),
                       //Moddate = p.IsNull("moddate") ? "" : p.Field<string>("moddate").Trim(),
                   };
        }

        public static DataTable ToDataTable(string rDept, string rBegDate, string rEndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from Proch where 1=1 ";

            //廠部            
            if (!string.IsNullOrEmpty(rDept.Trim()))
            {
                sql += " and dept= '" + rDept.Trim() + "'";
            }

            //生產日期
            if (!string.IsNullOrEmpty(rBegDate.Trim()))
            {
                sql += " and mfd >='" + rBegDate.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(rEndDate.Trim()))
            {
                parm.Add(rEndDate.Trim());
                sql += " and mfd <= '" + rEndDate.Trim() + "'";
            }
            sql += " order by dept,station,mfd ";

            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
            //return from p in dt.AsEnumerable()
            //       select new Proch
            //       {
            //           Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
            //           Station = p.IsNull("Station") ? "" : p.Field<string>("Station").Trim(),
            //           Docno = p.IsNull("Docno") ? "" : p.Field<string>("Docno").Trim(),
            //           Mfd = p.IsNull("Mfd") ? "" : p.Field<string>("Mfd").Trim(),
            //           Works = p.IsNull("Works") ? 0 : p.Field<decimal>("Works"),
            //           Gp = p.IsNull("gp") ? 0 : p.Field<decimal>("gp"),
            //           Ng = p.IsNull("ng") ? 0 : p.Field<decimal>("ng"),
            //           Jobgo = p.IsNull("Jobgo") ? "" : p.Field<DateTime>("Jobgo").ToString("yyyy/MM/dd HH:mm:ss.fff"),
            //           Jobed = p.IsNull("Jobed") ? "" : p.Field<DateTime>("Jobed").ToString("yyyy/MM/dd HH:mm:ss.fff"),
            //           Adduser = p.IsNull("adduser") ? "" : p.Field<string>("adduser").Trim(),
            //           Adddate = p.IsNull("adddate") ? "" : p.Field<string>("adddate").Trim(),
            //           Moduser = p.IsNull("moduser") ? "" : p.Field<string>("moduser").Trim(),
            //           Moddate = p.IsNull("moddate") ? "" : p.Field<string>("moddate").Trim(),
            //       };
        }


        public static string Set_Insert(Proch p_Proch)
        {
            string sql = string.Empty;
            sql += "insert into Proch (ID,dept,station,docno,mfd,works,gp,ng,jobgo,jobed,adduser,adddate) ";
            sql += string.Format("values(NEWID(),'{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}','{10}');\r\n",
                p_Proch.Dept,
                p_Proch.Station,
                p_Proch.Docno,
                p_Proch.Mfd,
                p_Proch.Works,
                p_Proch.Gp,
                p_Proch.Ng,
                p_Proch.Jobgo,
                p_Proch.Jobgo,
                p_Proch.Adduser,
                p_Proch.Adddate);
            return sql;
        }

        public static string Set_Update(Proch p_Proch)
        {
            string sql = string.Empty;
            sql += "update Proch set works = " + p_Proch.Works;
            sql += " ,gp =" + p_Proch.Gp;
            sql += " ,ng =" + p_Proch.Ng;
            sql += " where docno ='" + p_Proch.Docno + "';\r\n";
            return sql;
        }

        public static string Set_Delete(Proch p_Proch)
        {
            string sql = string.Empty;
            sql += "delete from Proch ";
            sql += " where docno ='" + p_Proch.Docno + "';\r\n";
            return sql;
        }


    }
}
