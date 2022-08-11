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
    class umenuE
    {
        #region 資料屬性
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string IdName { get; set; }
        public string Programs { get; set; }
        public string Explanation { get; set; }
        public string User_account { get; set; }
        #endregion

        //public static IEnumerable<umenuE> Treeview(string User_account)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(User_account.Trim());
        //    sql = null;
        //    sql += "select * from umenuE where 1=1 ";
        //    sql += " and user_account=?";
        //    sql += " order by id ";
        //    DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
        //    return from q in DeptDS.Tables[0].AsEnumerable()
        //           select new umenuE
        //           {
        //               Id = q.IsNull("id") ? "" : q.Field<string>("id").Trim(),
        //               ParentId = q.IsNull("parentId") ? "" : q.Field<string>("parentId").Trim(),
        //               IdName = q.IsNull("idname") ? "" : q.Field<string>("idname").Trim(),
        //           };
        //}

        public static IEnumerable<umenuE> Treeview(string User_account)
        {
            string sql = null;            
            sql = null;
            sql += "select * from umenuE where 1=1 ";
            sql += " and user_account='" + User_account.Trim() + "'";
            sql += " order by id ";
            DataTable dt = DOSQL.GetDataTable(Login.MFPD, sql);            
            return from q in dt.AsEnumerable()
                   select new umenuE
                   {
                       Id = q.IsNull("id") ? "" : q.Field<string>("id").Trim(),
                       ParentId = q.IsNull("parentId") ? "" : q.Field<string>("parentId").Trim(),
                       IdName = q.IsNull("idname") ? "" : q.Field<string>("idname").Trim(),
                   };
        }
    }
}
