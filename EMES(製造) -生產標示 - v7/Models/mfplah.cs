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
    class mfplah
    {
        #region 資料屬性
        public string Plant { get; set; }//營運中心
        public string Mfdate { get; set; }//生產日
        public string Mfline { get; set; }//生產線別        
        public decimal Ta01 { get; set; }//生產桶數
        public decimal Ta02 { get; set; }//翻料桶數
        public decimal Ta03 { get; set; }//洗桶桶數
        public decimal Ta04 { get; set; }//研發試桶數
        public decimal Ta05 { get; set; }//研發桶數
        public string Ta06 { get; set; }//備註
        #endregion

        public static IEnumerable<mfplah> ToDoList(string rPlant,string rBegDate,string rEndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();


            sql = null;
            sql += "select * from mfplah where 1=1 ";

            //廠部            
            if (!string.IsNullOrEmpty(rPlant.Trim()))
            {
                parm.Add(rPlant.Trim());
                sql += " and plant= ?";
            }
            if (!string.IsNullOrEmpty(rBegDate.Trim()))
            {
                parm.Add(rBegDate.Trim());
                sql += " and mfdate >= ?";
            }
            if (!string.IsNullOrEmpty(rEndDate.Trim()))
            {
                parm.Add(rEndDate.Trim());
                sql += " and mfdate <= ?";
            }

            sql += " order by plant,mfdate,mfline ";

            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mfplah
                   {
                       Plant = p.IsNull("plant") ? "" : p.Field<string>("plant").Trim(),
                       Mfdate = p.IsNull("mfdate") ? "" : System.Convert.ToDateTime(p.Field<string>("mfdate")).ToString("yyyy/MM/dd"),
                       Mfline = p.IsNull("mfline") ? "" : p.Field<string>("mfline").Trim(),                       
                       Ta01 = p.IsNull("ta01") ? 0 : p.Field<decimal>("ta01"),
                       Ta02 = p.IsNull("ta02") ? 0 : p.Field<decimal>("ta02"),
                       Ta03 = p.IsNull("ta03") ? 0 : p.Field<decimal>("ta03"),
                       Ta04 = p.IsNull("ta04") ? 0 : p.Field<decimal>("ta04"),
                       Ta05 = p.IsNull("ta05") ? 0 : p.Field<decimal>("ta05"),
                       Ta06 = p.IsNull("ta06") ? "" : p.Field<string>("ta06").Trim(),                       
                   };
        }

        //public static IEnumerable<mfplah> ToDoList(string rPlant, string rMfdate, string rMfline)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();


        //    sql = null;
        //    sql += "select * from mfplah where 1=1 ";

        //    //廠部
        //    //sql += " and plant = ?";
        //    if (!string.IsNullOrEmpty(rPlant.Trim()))
        //    {
        //        parm.Add(rPlant.Trim());
        //        sql += " and plant= ?";
        //    }

        //    //生產日期
        //    //sql += " and mfdate = ?";
        //    if (!string.IsNullOrEmpty(rMfdate.Trim()))
        //    {
        //        parm.Add(rMfdate.Trim());
        //        sql += " and mfdate = ?";
        //    }
                        
        //    //生產線別
        //    if (!string.IsNullOrEmpty(rMfline.Trim()) && rMfline != null)
        //    {
        //        parm.Add(rMfline);
        //        sql += " and mfline = ? ";
        //    }
        //    sql += " order by plant,mfdate,mfline ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mfplah
        //           {
        //               Plant = p.IsNull("plant") ? "" : p.Field<string>("plant").Trim(),
        //               Mfdate = p.IsNull("mfdate") ? "" : System.Convert.ToDateTime(p.Field<string>("mfdate")).ToString("yyyy/MM/dd"),
        //               Mfline = p.IsNull("mfline") ? "" : p.Field<string>("mfline").Trim(),
        //               Ta01 = p.IsNull("ta01") ? 0 : p.Field<decimal>("ta01"),
        //               Ta02 = p.IsNull("ta02") ? 0 : p.Field<decimal>("ta02"),
        //               Ta03 = p.IsNull("ta03") ? 0 : p.Field<decimal>("ta03"),
        //               Ta04 = p.IsNull("ta04") ? 0 : p.Field<decimal>("ta04"),
        //               Ta05 = p.IsNull("ta05") ? 0 : p.Field<decimal>("ta05"),
        //               Ta06 = p.IsNull("ta06") ? "" : p.Field<string>("ta06").Trim(),
        //           };
        //}

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Plant) ? null : Plant.Trim());
                parm.Add(string.IsNullOrEmpty(Mfdate) ? null : Mfdate.Trim());
                parm.Add(string.IsNullOrEmpty(Mfline) ? null : Mfline.Trim());                
                parm.Add(Ta01);
                parm.Add(Ta02);
                parm.Add(Ta03);
                parm.Add(Ta04);
                parm.Add(Ta05);
                parm.Add(string.IsNullOrEmpty(Ta06) ? null : Ta06.Trim());

                string sql = null;
                sql += "insert into mfplah";
                sql += "(plant,mfdate,mfline,ta01,ta02,ta03,ta04,ta05,ta06)";
                sql += " values(?,?,?,?,?, ?,?,?,?)";
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

        public string Delete(string Plant, string Mfdate, string Mfline)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Plant.Trim());
                parm.Add(Mfdate.Trim());
                parm.Add(Mfline.Trim());

                string sql = null;
                sql += "delete from mfplah where plant=? and mfdate=? and mfline=? ";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Plant, string Mfdate, string Mfline)
        {
            try
            {
                ArrayList parm = new ArrayList();                
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta01)) ? 0 : Ta01);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta02)) ? 0 : Ta02);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta03)) ? 0 : Ta03);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta04)) ? 0 : Ta04);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta05)) ? 0 : Ta05);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta06)) ? null : Ta06);

                parm.Add(Plant.Trim());
                parm.Add(Mfdate.Trim());
                parm.Add(Mfline.Trim());

                string sql = null;
                sql += "update mfplah set ta01=?,ta02=?,ta03=?,ta04=?,ta05=?,ta06=? ";
                sql += " where plant =?";
                sql += " and mfdate =?";
                sql += " and mfline =?";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }


        public static mfplah Get(string Plant, string Mfdate, string Mfline)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();


            string sql = null;
            sql += "select * from mfplah where 1=1 ";

            if (!string.IsNullOrEmpty(Plant.Trim()))
            {
                parm.Add(Plant.Trim());
                sql += " and plant= ?";
            }


            if (!string.IsNullOrEmpty(Mfdate.Trim()))
            {
                parm.Add(Mfdate.Trim());
                sql += " and mfdate= ?";
            }



            if (!string.IsNullOrEmpty(Mfline.ToString()))
            {
                parm.Add(Mfline.Trim());
                sql += " and mfline = ?";
            }


            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new mfplah
            {
                Plant = DeptDS.Tables[0].Rows[0].IsNull("plant") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("plant").Trim(),
                Mfdate = DeptDS.Tables[0].Rows[0].IsNull("mfdate") ? "" : System.Convert.ToDateTime(DeptDS.Tables[0].Rows[0].Field<string>("mfdate")).ToString("yyyy/MM/dd"),
                Mfline = DeptDS.Tables[0].Rows[0].IsNull("mfline") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mfline").Trim(),

                Ta01 = DeptDS.Tables[0].Rows[0].IsNull("ta01") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta01"),
                Ta02 = DeptDS.Tables[0].Rows[0].IsNull("ta02") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta02"),
                Ta03 = DeptDS.Tables[0].Rows[0].IsNull("ta03") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta03"),
                Ta04 = DeptDS.Tables[0].Rows[0].IsNull("ta04") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta04"),
                Ta05 = DeptDS.Tables[0].Rows[0].IsNull("ta05") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta05"),
                Ta06 = DeptDS.Tables[0].Rows[0].IsNull("ta06") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ta06").Trim(),
            };
        }


    }
}
