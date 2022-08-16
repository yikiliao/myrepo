using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EMES.Forms;

namespace EMES.Models
{
    class sst014
    {
        #region 資料屬性
        public string Code { get; set; }
        public string Cn_name { get; set; }
        public string En_name { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user{get;set;}
        public string Remark { get; set; }
        #endregion

        public static IEnumerable<sst014> ToDoList(string Code, string Cn_name, string En_name)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst014 where 1= 1 ";
            if (!string.IsNullOrEmpty(Code.Trim()))
            {
                parm.Add(String.Format("%{0}%", Code.Trim()));
                sql += " and code like ?";
            }
            if (!string.IsNullOrEmpty(Cn_name.Trim()))
            {
                parm.Add(String.Format("%{0}%", Cn_name.Trim()));
                sql += " and cn_name like ?";
            }
            if (!string.IsNullOrEmpty(En_name.Trim()))
            {
                parm.Add(String.Format("%{0}%", En_name.Trim()));
                sql += " and en_name like ?";
            }
            sql += " order by code ";

            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst014
                   {
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Cn_name = p.IsNull("cn_name") ? "" : p.Field<string>("cn_name").Trim(),
                       En_name = p.IsNull("en_name") ? "" : p.Field<string>("en_name").Trim(),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
                       Add_date= p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Remark = p.IsNull("remark") ? "" : p.Field<string>("remark").Trim(),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Code) ? null : Code.Trim());
                parm.Add(string.IsNullOrEmpty(Cn_name) ? null : Cn_name.Trim());
                parm.Add(string.IsNullOrEmpty(En_name) ? null : En_name.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                if (sst014.Get(Code) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into sst014";
                    sql += "(code,cn_name,en_name,vaild,add_date,add_user,mod_date,mod_user,remark)";
                    sql += " values(?,?,?,?,?,?,?,?,?)";
                    if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                        return "新增失敗";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功"; 
        }

        public string Delete(string Code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Code);
                string sql = null;
                sql += "delete from sst014 where code=?";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功"; 
        }

        public string Update(string Code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Cn_name) ? null : Cn_name.Trim());
                parm.Add(string.IsNullOrEmpty(En_name) ? null : En_name.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                parm.Add(string.IsNullOrEmpty(Code) ? null : Code.Trim());
                string sql = null;
                sql += "update sst014 set cn_name=?,en_name=?,vaild=?,mod_date=?,mod_user=?,remark=?";
                sql += " where code =?";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }


        public static sst014 Get(string Code)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Code);

            string sql = null;
            sql += "select * from sst014 ";
            sql += " where code = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst014
            {
                Code = DeptDS.Tables[0].Rows[0].IsNull("code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("code").Trim(),
                Cn_name = DeptDS.Tables[0].Rows[0].IsNull("cn_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cn_name").Trim(),
                En_name = DeptDS.Tables[0].Rows[0].IsNull("en_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("en_name").Trim(),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Remark = DeptDS.Tables[0].Rows[0].IsNull("remark") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("remark").Trim(),
            };
        }

        public static IEnumerable<sst014> ToDoListCode(string Vaild)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select code,cn_name,en_name  from sst014 where 1= 1 ";
            if (Vaild.Length > 0)
            {
                parm.Add(Vaild.Trim());
                sql += " and vaild= ?";
            }
            sql += " order by code ";

            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst014
                   {
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Cn_name = p.IsNull("cn_name") ? "" : p.Field<string>("cn_name").Trim(),
                       En_name = p.IsNull("en_name") ? "" : p.Field<string>("en_name").Trim(),
                   };
        }

    }
}
