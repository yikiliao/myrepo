using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;
using EMES.Forms;

namespace EMES.Models
{
    class ima_file
    {
        #region 資料屬性
        public string Ima01 { get; set; }
        public string Ima02 { get; set; }//品名
        public string Ima021 { get; set; } //規格
        #endregion

        public static ima_file Get(string ima01)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(ima01.Trim());
            string sql = null;
            sql += string.Format("select ima02,ima021 from {0}.ima_file where 1= 1", Login.DEPT);
            sql += " and ima01 = :ima01";

            DataSet DeptDS = DBConnector.executeQuery(Login.TT, sql, parm);
            //DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new ima_file
            {
                Ima01 = ima01,
                Ima02 = DeptDS.Tables[0].Rows[0].IsNull("ima02") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ima02").Trim(),
                Ima021 = DeptDS.Tables[0].Rows[0].IsNull("ima021") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ima021").Trim(),
            };
        }

    }
}
