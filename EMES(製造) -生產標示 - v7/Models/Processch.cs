using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using EMES.Forms;

namespace EMES.Models
{
  public   class Processch
    {
        #region 資料屬性
        public string Dept { get; set; }//營運中心
        public string Station { get; set; }//
        public string DocNo { get; set; }//單據號
        public string MakeDate { get; set; }//輸入日
        public decimal OperNumber { get; set; }//作業人數
        public decimal GoodQty { get; set; }//良品
        public decimal UnGoodQty { get; set; }//不良
        public string JobStart { get; set; }//工作開始
        public string JobEnd { get; set; }//工作結束
        public string AddUser { get; set; } //新增人員
        public string AddDate { get; set; } //輸入時間
        public string ModUser { get; set; } //異動者
        public string ModDate { get; set; } //異動時間
        public string TTStation { get; set; }//TT工作站
        #endregion

        public static IEnumerable<Processch> ToDoList(string rDept, string rBegDate, string rEndDate)
        {
            string sql = null;           

            sql = null;
            sql += "select * from Processch where 1=1 ";

            //廠部            
            if (!string.IsNullOrEmpty(rDept.Trim()))
            {
                sql += " and Dept= '" + rDept.Trim() + "'";
            }

            //生產日期
            if (!string.IsNullOrEmpty(rBegDate.Trim()))
            {
                sql += " and MakeDate >='" + rBegDate.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(rEndDate.Trim()))
            {                
                sql += " and MakeDate <= '" + rEndDate.Trim() + "'";
            }
            sql += " order by Dept,Station,MakeDate,DocNo ";


            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return from p in dt.AsEnumerable()
                   select new Processch
                   {
                       Dept = p.IsNull("Dept") ? "" : p.Field<string>("Dept").Trim(),
                       Station = p.IsNull("Station") ? "" : p.Field<string>("Station").Trim(),
                       DocNo = p.IsNull("DocNo") ? "" : p.Field<string>("DocNo").Trim(),
                       MakeDate = p.IsNull("MakeDate") ? "" : p.Field<string>("MakeDate").Trim(),
                       OperNumber = p.IsNull("OperNumber") ? 0 : p.Field<decimal>("OperNumber"),
                       GoodQty = p.IsNull("GoodQty") ? 0 : p.Field<decimal>("GoodQty"),
                       UnGoodQty = p.IsNull("UnGoodQty") ? 0 : p.Field<decimal>("UnGoodQty"),
                       JobStart = p.IsNull("JobStart") ? "" : p.Field<DateTime>("JobStart").ToString("yyyy/MM/dd HH:mm:ss.fff"),
                       JobEnd = p.IsNull("JobEnd") ? "" : p.Field<DateTime>("JobEnd").ToString("yyyy/MM/dd HH:mm:ss.fff"),
                   };
        }

        public static string Set_Insert(Processch rProcessch)
        {
            string sql = string.Empty;
            sql += "insert into Processch (ID,Dept,Station,DocNo,MakeDate,OperNumber,GoodQty,UnGoodQty,JobStart,JobEnd,AddUser,AddDate,ModUser,ModDate) ";
            sql += string.Format("values(NEWID(),'{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}',GETDATE(),'{10}',GETDATE());\r\n",
                rProcessch.Dept,
                rProcessch.Station,
                rProcessch.DocNo,
                rProcessch.MakeDate,
                rProcessch.OperNumber,
                rProcessch.GoodQty,
                rProcessch.UnGoodQty,
                rProcessch.JobStart,
                rProcessch.JobEnd,
                rProcessch.AddUser,
                rProcessch.ModUser);
            return sql;
        }

        public static string Set_Update(Processch rProcessch)
        {
            string sql = string.Empty;
            sql += "update Processch set OperNumber = " + rProcessch.OperNumber;
            sql += " ,GoodQty =" + rProcessch.GoodQty;
            sql += " ,UnGoodQty =" + rProcessch.UnGoodQty;
            sql += " ,ModUser ='" + rProcessch.ModUser + "'";
            sql += " ,ModDate = GETDATE()";
            sql += " where docno ='" + rProcessch.DocNo + "';\r\n";
            return sql;
        }
        

        public static string Set_Delete(Processch rProcessch)
        {
            string sql = string.Empty;
            sql += "delete from Processch ";
            sql += " where DocNo ='" + rProcessch.DocNo + "';\r\n";
            return sql;
        }

    }
}
