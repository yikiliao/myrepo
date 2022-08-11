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
    class sst001
    {
        #region 資料屬性
        public string Type { get; set; }
        public string Code { get; set; }
        public string Code_desc { get; set; }
        #endregion

        public static IEnumerable<sst001> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;            
            sql += "select * from sst001 where 1=1 ";

            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst001
                   {
                       Type = p.IsNull("type") ? "" : p.Field<string>("type").Trim(),
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                   };
        }

    }
}
