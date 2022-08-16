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
    class sst100
    {
        #region 資料屬性
        public string Type { get; set; }
        public string Code { get; set; }
        public string Code_desc { get; set; }
        public string Dept { get; set; }
        #endregion

        //public static IEnumerable<sst100> ToDoList()
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    sql = null;
        //    sql += "select * from sst100 where 1=1 ";

        //    DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);            
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new sst100
        //           {
        //               Type = p.IsNull("type") ? "" : p.Field<string>("type").Trim(),
        //               Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
        //               Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
        //               Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
        //           };
        //}

        public static IEnumerable<sst100> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst100 where 1=1 ";
            DataTable dt = DOSQL.GetDataTable(Login.MFPD, sql);            
            return from p in dt.AsEnumerable()
                   select new sst100
                   {
                       Type = p.IsNull("type") ? "" : p.Field<string>("type").Trim(),
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                   };
        }

        

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Type) ? null : Type.Trim());
                parm.Add(string.IsNullOrEmpty(Code) ? null : Code.Trim());
                parm.Add(string.IsNullOrEmpty(Code_desc) ? null : Code_desc.Trim());                
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());

                string sql = null;
                sql += "insert into sst100";
                sql += "(type,code,code_desc,dept)";                
                sql += " values(?,?,?,?)";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "新增失敗";
                //}

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete(string Type, string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Type.Trim());
                parm.Add(Dept.Trim());
                string sql = null;
                sql += "delete from sst100 where type=? and dept=? ";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Type, string Dept, string Code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Code_desc)) ? null : Code_desc);

                parm.Add(Type.Trim());
                parm.Add(Dept.Trim());
                parm.Add(Code);
                string sql = null;
                sql += "update sst100 set code_desc=?";                
                sql += " where type =?";
                sql += " and dept =?";
                sql += " and code =?";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

    }
}
