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
  public  class Account
    {
        #region 資料屬性
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Vaild { get; set; }
        public DateTime Add_date { get; set; }
        public string Add_user { get; set; }
        public DateTime Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Rang { get; set; }
        #endregion

        //public static string Set_Insert(Account p_)
        //{
        //    string ip = p_.Id;
        //    string name = p_.Name;
        //    string pws = p_.Password;
        //    string mail = p_.Mail;
        //    string vaild = p_.Vaild;
        //    string adduser = p_.Add_user;
        //    string moduser = p_.Mod_user;
        //    string rang = p_.Rang.Replace("'","''");

        //    string sql = string.Empty;
        //    sql += $"insert into Account (ID,Name, Password, Mail, Vaild, Add_date, Add_user, Mod_date,Mod_user,Rang) values('{ip}','{name}','{pws}','{mail}','{vaild}',GETDATE(),'{adduser}',GETDATE(),'{moduser}','{rang}')";
        //    sql += ";\n";
        //    //sql += string.Format("",
        //    //    p_.Id,
        //    //    p_.Name,
        //    //    p_.Password,
        //    //    p_.Mail,
        //    //    p_.Vaild,
        //    //    p_.Add_user,
        //    //    p_.Mod_user,
        //    //    p_.Rang);
        //    return sql;
        //}

        public static string Set_Insert(Account p_)
        {
            string sql = string.Empty;
            sql += "insert into Account (ID,Name, Password, Mail, Vaild, Add_date, Add_user, Mod_date,Mod_user,Rang) ";
            sql += string.Format("values('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}',GETDATE(),'{6}','{7}');\r\n",
                p_.Id,
                p_.Name,
                p_.Password,
                p_.Mail,
                p_.Vaild,
                p_.Add_user,
                p_.Mod_user,
                p_.Rang.Replace("'", "''"));
            return sql;
        }

        public static string Set_Update(Account p_)
        {
            string sql = string.Empty;
            sql += "update Account set Name ='" + p_.Name + "',";
            sql += " Password ='" + p_.Password + "',";
            sql += " Mail = '" + p_.Mail + "',";
            sql += " Vaild ='" + p_.Vaild + "'";
            sql += " where ID = '" + p_.Id + "';\r\n";
            return sql;
        }

        public static IEnumerable<Account> ToDoList()
        {
            string sql = null;

            sql += "select * from Account where 1=1 ";
            sql += " order by id ";

            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return from p in dt.AsEnumerable()
                   select new Account
                   {
                       Id = p.IsNull("Id") ? "" : p.Field<string>("Id").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                       Password = p.IsNull("Password") ? "" : p.Field<string>("Password").Trim(),
                       Mail = p.IsNull("Mail") ? "" : p.Field<string>("Mail").Trim(),
                       Vaild = p.IsNull("Vaild") ? "" : p.Field<string>("Vaild").Trim(),
                       Add_date =  p.Field<DateTime>("Add_date"),
                       Add_user = p.IsNull("Add_user") ? "" : p.Field<string>("Add_user").Trim(),
                       Mod_date = p.Field<DateTime>("Mod_date"),
                       Mod_user = p.IsNull("Mod_user") ? "" : p.Field<string>("Mod_user").Trim(),
                       Rang = p.IsNull("Rang") ? "" : p.Field<string>("Rang").Trim(),
                   };
        }


        public string Update(string Erp_id)
        {
            try
            {
                string sql = null;
                sql += "update Account set password= '" + Password.Trim() + "'";
                sql += " where id ='" + Erp_id.Trim() + "'";
                var i = DOSQL.Excute(Login.WU, sql);
                if (i == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

        public static Account Get(string id)
        {
            //// 查詢資料庫資料
            //ArrayList parm = new ArrayList();
            //parm.Add(Erp_id);

            string sql = null;
            sql += "select * from Account ";
            sql += " where id ='" + id.Trim() + "'";
            sql += " and vaild='Y'";

            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            // 將查詢到的資料回傳
            if (dt.Rows.Count == 0)
                return null;
            return new Account
            {
                Id = dt.Rows[0].IsNull("id") ? "" : dt.Rows[0].Field<string>("id").Trim(),
                Name = dt.Rows[0].IsNull("name") ? "" : dt.Rows[0].Field<string>("name").Trim(),
                Password = dt.Rows[0].IsNull("password") ? "" : dt.Rows[0].Field<string>("password").Trim(),
                Mail = dt.Rows[0].IsNull("mail") ? "" : dt.Rows[0].Field<string>("mail").Trim(),
                Vaild = dt.Rows[0].IsNull("vaild") ? "" : dt.Rows[0].Field<string>("vaild").Trim(),
                Add_date = dt.Rows[0].Field<DateTime>("add_date"),
                Add_user = dt.Rows[0].IsNull("add_user") ? "" : dt.Rows[0].Field<string>("add_user").Trim(),
                Mod_date = dt.Rows[0].Field<DateTime>("mod_date"),
                Mod_user = dt.Rows[0].IsNull("mod_user") ? "" : dt.Rows[0].Field<string>("mod_user").Trim(),
                Rang = dt.Rows[0].IsNull("rang") ? "" : dt.Rows[0].Field<string>("rang").Trim(),
            };
        }

    }
}
