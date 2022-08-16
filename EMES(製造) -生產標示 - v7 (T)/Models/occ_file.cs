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
    class occ_file
    {
        #region 資料屬性
        public string Occ01 { get; set; }
        public string Occ02 { get; set; } //工單號
        #endregion

        public static occ_file Get(string occ01)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(occ01.Trim());
            string sql = null;
            sql += string.Format("select * from {0}.occ_file where 1= 1", Login.DEPT);
            sql += " and occ01 = :occ01";

            DataSet DeptDS = DBConnector.executeQuery(Login.TT, sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new occ_file
            {
                Occ01 = DeptDS.Tables[0].Rows[0].IsNull("occ01") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("occ01").Trim(),
                Occ02 = DeptDS.Tables[0].Rows[0].IsNull("occ02") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("occ02").Trim(),
            };
        }

    }
}
