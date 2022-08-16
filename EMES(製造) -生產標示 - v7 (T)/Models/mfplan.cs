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
    class mfplan
    {
        #region 資料屬性
        public string Plant { get; set; }//營運中心
        public string Mfdate { get; set; }//生產日
        public string Mfline { get; set; }//生產線別

        public Int32 Seqno { get; set; }// 序號
        public string Mftable { get; set; }//炊台

        public string Wkno { get; set; }//工單號
        public decimal Tubno { get; set; }//實際生產桶數
        public decimal Workqty { get; set; }//工作生產數量(床)        

        public decimal Ta_sfb04 { get; set; }//上模厚
        public decimal Ta_sfb02 { get; set; }//上模長
        public decimal Ta_sfb03 { get; set; }//上模寬
        public decimal Ta_sfb08 { get; set; }//下模厚
        public decimal Ta_sfb06 { get; set; }//下模長
        public decimal Ta_sfb07 { get; set; }//下模寬


        public string Sp { get; set; }// SP
        public string Cond { get; set; }//條件

        public decimal Tubno_1 { get; set; }//實際生產桶數 1
        public decimal Tubno_2 { get; set; }//實際生產桶數 2
        public decimal Tubno_3 { get; set; }//實際生產桶數 3
        public decimal Tubno_4 { get; set; }//實際生產桶數 4
        public decimal Tubno_5 { get; set; }//實際生產桶數 5
        public decimal Tubno_6 { get; set; }//實際生產桶數 6

        public decimal Cut_long { get; set; }//切料尺寸_長
        public decimal Cut_width { get; set; }//切料尺寸_寬

        public decimal S_qty { get; set; }//實際應發數量

        public string Tubno_memo { get; set; }//工作桶數備註


        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
       

        public string Sfb223 { get; set; }//客戶編號
        public string Occ02 { get; set; }//客戶名稱
        public decimal Ta_sfb17 { get; set; }//原床厚
        public decimal Sfb08 { get; set; }//生產數量
        public string Sfb05 { get; set; }//料號
        public string Ima02 { get; set; }//品名
        public string Ima021 { get; set; }//規格
        public decimal Ta_sfb19 { get; set; }//預計生產桶數
        public string Sfb81 { get; set; }//開單日期

        public string Upmode { get; set; }//上模字串
        public string Downmode { get; set; }//下模字串

        public decimal Ta_sfb20 { get; set; }//每桶重量

        public decimal Ta01 { get; set; }
        public decimal Ta02 { get; set; }
        public decimal Ta03 { get; set; }
        public decimal Ta04 { get; set; }
        public decimal Ta05 { get; set; }
        public string Ta06 { get; set; }

        #endregion



        public static IEnumerable<mfplan> ToDoListGroup(string rPlant, string rMfline, string rMftable, string rBegDate, string rEndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select plant,mfdate,mfline from mfplan where 1= 1 ";
            if (!string.IsNullOrEmpty(rPlant.Trim()))
            {
                parm.Add(rPlant.Trim());
                sql += " and plant= ?";
            }

            //生產日期
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
            //生產線別
            if (!string.IsNullOrEmpty(rMfline.Trim()) && rMfline != null)
            {
                parm.Add(rMfline);
                sql += " and mfline = ? ";
            }
            //炊台
            if (!string.IsNullOrEmpty(rMftable.Trim()) && rMftable != null)
            {
                parm.Add(rMftable);
                sql += " and mftable = ? ";
            }
            sql += " GROUP BY plant,mfdate,mfline ";
            sql += " order by plant,mfdate,mfline ";

            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mfplan
                   {
                       Plant = p.IsNull("plant") ? "" : p.Field<string>("plant").Trim(),
                       //Mfdate = p.IsNull("mfdate") ? "" : p.Field<string>("mfdate").Trim(),
                       Mfdate = p.IsNull("mfdate") ? "" : System.Convert.ToDateTime(p.Field<string>("mfdate")).ToString("yyyy/MM/dd"),
                       Mfline = p.IsNull("mfline") ? "" : p.Field<string>("mfline").Trim(),
                   };
        }

        public static IEnumerable<mfplan> TToDoList(string rPlant, string rMfdate, string rMfline, string rMftable)
        {
            string sql = null;
            ArrayList parm = new ArrayList();


            sql = null;
            sql += "select * from mfplan where 1=1 ";

            //廠部            
            if (!string.IsNullOrEmpty(rPlant.Trim()))
            {
                parm.Add(rPlant.Trim());
                sql += " and plant= ?";
            }

            //生產日期            
            if (!string.IsNullOrEmpty(rMfdate.Trim()))
            {
                parm.Add(rMfdate.Trim());
                sql += " and mfdate = ?";
            }

            //生產線
            if (!string.IsNullOrEmpty(rMfline.Trim()) && rMfline != null)
            {
                parm.Add(rMfline);
                sql += " and mfline = ? ";
            }

            //炊台            
            if (!string.IsNullOrEmpty(rMftable.Trim()) && rMftable != null)
            {
                parm.Add(rMftable);
                sql += " and mftable = ? ";
            }
            sql += " order by plant,mfdate,mfline,mftable,wkno ";


            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mfplan
                   {
                       Plant = p.IsNull("plant") ? "" : p.Field<string>("plant").Trim(),
                       Mfdate = p.IsNull("mfdate") ? "" : System.Convert.ToDateTime(p.Field<string>("mfdate")).ToString("yyyy/MM/dd"),
                       Mfline = p.IsNull("mfline") ? "" : p.Field<string>("mfline").Trim(),
                       Seqno = p.IsNull("seqno") ? 0 : p.Field<Int32>("seqno"),
                       Mftable = p.IsNull("mftable") ? "" : p.Field<string>("mftable").Trim(),

                       Wkno = p.IsNull("wkno") ? "" : p.Field<string>("wkno").Trim(),
                       Tubno = p.IsNull("tubno") ? 0 : p.Field<decimal>("tubno"),
                       Workqty = p.IsNull("workqty") ? 0 : p.Field<decimal>("workqty"),
                       Ta_sfb02 = p.IsNull("ta_sfb02") ? 0 : p.Field<decimal>("ta_sfb02"),
                       Ta_sfb03 = p.IsNull("ta_sfb03") ? 0 : p.Field<decimal>("ta_sfb03"),
                       Ta_sfb04 = p.IsNull("ta_sfb04") ? 0 : p.Field<decimal>("ta_sfb04"),

                       Ta_sfb06 = p.IsNull("ta_sfb06") ? 0 : p.Field<decimal>("ta_sfb06"),
                       Ta_sfb07 = p.IsNull("ta_sfb07") ? 0 : p.Field<decimal>("ta_sfb07"),
                       Ta_sfb08 = p.IsNull("ta_sfb08") ? 0 : p.Field<decimal>("ta_sfb08"),

                       Sp = p.IsNull("sp") ? "" : p.Field<string>("sp").Trim(),
                       Cond = p.IsNull("cond") ? "" : p.Field<string>("cond").Trim(),

                       Tubno_1 = p.IsNull("tubno_1") ? 0 : p.Field<decimal>("tubno_1"),
                       Tubno_2 = p.IsNull("tubno_2") ? 0 : p.Field<decimal>("tubno_2"),
                       Tubno_3 = p.IsNull("tubno_3") ? 0 : p.Field<decimal>("tubno_3"),
                       Tubno_4 = p.IsNull("tubno_4") ? 0 : p.Field<decimal>("tubno_4"),
                       Tubno_5 = p.IsNull("tubno_5") ? 0 : p.Field<decimal>("tubno_5"),
                       Tubno_6 = p.IsNull("tubno_6") ? 0 : p.Field<decimal>("tubno_6"),

                       Cut_long = p.IsNull("cut_long") ? 0 : p.Field<decimal>("cut_long"),
                       Cut_width = p.IsNull("cut_width") ? 0 : p.Field<decimal>("cut_width"),


                       S_qty = p.IsNull("s_qty") ? 0 : p.Field<decimal>("s_qty"),
                       Tubno_memo = p.IsNull("tubno_memo") ? "" : p.Field<string>("tubno_memo").Trim(),

                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                   };
        }
        
        
        public static IEnumerable<mfplan> ToDoList(string rPlant, string rMfline, string rMftable, string rBegDate, string rEndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from mfplan where 1=1 ";
            if (!string.IsNullOrEmpty(rPlant.Trim()))
            {
                parm.Add(rPlant.Trim());
                sql += " and plant= ?";
            }
            //生產線別
            if (!string.IsNullOrEmpty(rMfline.Trim()) && rMfline != null)
            {
                parm.Add(rMfline);
                sql += " and mfline = ? ";
            }

            //炊台
            if (!string.IsNullOrEmpty(rMftable.Trim()) && rMftable != null)
            {
                parm.Add(rMftable);
                sql += " and mftable = ? ";
            }
            //生產日期
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

            sql += " order by plant,mfdate,mfline,mftable,wkno ";

            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mfplan
                   {
                       Plant = p.IsNull("plant") ? "" : p.Field<string>("plant").Trim(),
                       Mfdate = p.IsNull("mfdate") ? "" : System.Convert.ToDateTime(p.Field<string>("mfdate")).ToString("yyyy/MM/dd"),
                       Mfline = p.IsNull("mfline") ? "" : p.Field<string>("mfline").Trim(),
                       Mftable = p.IsNull("mftable") ? "" : p.Field<string>("mftable").Trim(),
                       Wkno = p.IsNull("wkno") ? "" : p.Field<string>("wkno").Trim(),
                       Tubno = p.IsNull("tubno") ? 0 : p.Field<decimal>("tubno"),//實際生產桶數
                       Workqty = p.IsNull("workqty") ? 0 : p.Field<decimal>("workqty"),//實際生產數量

                       Ta_sfb02 = p.IsNull("ta_sfb02") ? 0 : p.Field<decimal>("ta_sfb02"),
                       Ta_sfb03 = p.IsNull("ta_sfb03") ? 0 : p.Field<decimal>("ta_sfb03"),
                       Ta_sfb04 = p.IsNull("ta_sfb04") ? 0 : p.Field<decimal>("ta_sfb04"),

                       Ta_sfb06 = p.IsNull("ta_sfb06") ? 0 : p.Field<decimal>("ta_sfb06"),
                       Ta_sfb07 = p.IsNull("ta_sfb07") ? 0 : p.Field<decimal>("ta_sfb07"),
                       Ta_sfb08 = p.IsNull("ta_sfb08") ? 0 : p.Field<decimal>("ta_sfb08"),

                       Sp = p.IsNull("sp") ? "" : p.Field<string>("sp").Trim(),
                       Cond = p.IsNull("cond") ? "" : p.Field<string>("cond").Trim(),

                       Tubno_1 = p.IsNull("tubno_1") ? 0 : p.Field<decimal>("tubno_1"),
                       Tubno_2 = p.IsNull("tubno_2") ? 0 : p.Field<decimal>("tubno_2"),
                       Tubno_3 = p.IsNull("tubno_3") ? 0 : p.Field<decimal>("tubno_3"),
                       Tubno_4 = p.IsNull("tubno_4") ? 0 : p.Field<decimal>("tubno_4"),
                       Tubno_5 = p.IsNull("tubno_5") ? 0 : p.Field<decimal>("tubno_5"),
                       Tubno_6 = p.IsNull("tubno_6") ? 0 : p.Field<decimal>("tubno_6"),

                       Cut_long = p.IsNull("cut_long") ? 0 : p.Field<decimal>("cut_long"),
                       Cut_width = p.IsNull("cut_width") ? 0 : p.Field<decimal>("cut_width"),


                       S_qty = p.IsNull("s_qty") ? 0 : p.Field<decimal>("s_qty"),
                       Tubno_memo = p.IsNull("tubno_memo") ? "" : p.Field<string>("tubno_memo").Trim(),

                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),


                       Sfb223 = sfb_file.Get(p.Field<string>("wkno")) == null ? "" : sfb_file.Get(p.Field<string>("wkno")).Sfb223,//客戶編號
                       Occ02 = sfb_file.Get(p.Field<string>("wkno")) == null ? "" : sfb_file.Get(p.Field<string>("wkno")).Occ02,//客戶簡稱
                       Ta_sfb17 = sfb_file.Get(p.Field<string>("wkno")) == null ? 0 : sfb_file.Get(p.Field<string>("wkno")).Ta_sfb17,//厚度
                       Sfb08 = sfb_file.Get(p.Field<string>("wkno")) == null ? 0 : sfb_file.Get(p.Field<string>("wkno")).Ta_sfb08,//生產數量

                       Sfb05 = sfb_file.Get(p.Field<string>("wkno")) == null ? "MISC" : sfb_file.Get(p.Field<string>("wkno")).Sfb05,//料號                       
                       Ima02 = sfb_file.Get(p.Field<string>("wkno")) == null ? p.Field<string>("tubno_memo").Trim() : sfb_file.Get(p.Field<string>("wkno")).Ima02,//品名
                       Ima021 = sfb_file.Get(p.Field<string>("wkno")) == null ? "" : sfb_file.Get(p.Field<string>("wkno")).Ima021,//規格
                       Ta_sfb19 = sfb_file.Get(p.Field<string>("wkno")) == null ? 0 : sfb_file.Get(p.Field<string>("wkno")).Ta_sfb19,//預計生產桶數
                       Sfb81 = sfb_file.Get(p.Field<string>("wkno")) == null ? "" : sfb_file.Get(p.Field<string>("wkno")).Sfb81,//開單日
                       Ta_sfb20 = sfb_file.Get(p.Field<string>("wkno")) == null ? 0 : sfb_file.Get(p.Field<string>("wkno")).Ta_sfb20    //每桶重量
                   };
        }

        
        

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Plant) ? null : Plant.Trim());                
                parm.Add(string.IsNullOrEmpty(Mfdate) ? null : Mfdate.Trim());
                parm.Add(string.IsNullOrEmpty(Mfline) ? null : Mfline.Trim());
                parm.Add(Seqno);
                parm.Add(string.IsNullOrEmpty(Mftable) ? null : Mftable.Trim());
                parm.Add(string.IsNullOrEmpty(Wkno) ? null : Wkno.Trim());
                parm.Add(Tubno);
                parm.Add(Workqty);
                parm.Add(Ta_sfb02);
                parm.Add(Ta_sfb03);
                parm.Add(Ta_sfb04);
                parm.Add(Ta_sfb06);
                parm.Add(Ta_sfb07);
                parm.Add(Ta_sfb08);

                parm.Add(string.IsNullOrEmpty(Sp) ? null : Sp.Trim());
                parm.Add(string.IsNullOrEmpty(Cond) ? null : Cond.Trim());

                parm.Add(Tubno_1);
                parm.Add(Tubno_2);
                parm.Add(Tubno_3);
                parm.Add(Tubno_4);
                parm.Add(Tubno_5);
                parm.Add(Tubno_6);
                parm.Add(Cut_long);
                parm.Add(Cut_width);
                parm.Add(S_qty);

                parm.Add(string.IsNullOrEmpty(Tubno_memo) ? null : Tubno_memo.Trim());


                parm.Add(Login.ID);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(Login.ID);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                

                //if (Get(Plant, Mfdate, Mfline, Wkno) != null)
                //{
                //    return "已有此筆資料";
                //}
                //else
                //{
                    string sql = null;
                    sql += "insert into mfplan";
                    sql += "(plant,mfdate,mfline,seqno,mftable,wkno,tubno,workqty,ta_sfb02,ta_sfb03,";
                    sql += "ta_sfb04,ta_sfb06,ta_sfb07,ta_sfb08,sp,cond,tubno_1,tubno_2,tubno_3,tubno_4,";
                    sql += "tubno_5,tubno_6,cut_long,cut_width,s_qty,tubno_memo,add_user,add_date,mod_user,mod_date)";
                    sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?)";
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

        

        

        public string Delete(string Plant, string Mfdate, Int32 Seqno)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Plant.Trim());
                parm.Add(Mfdate.Trim());
                parm.Add(Seqno);
                string sql = null;
                sql += "delete from mfplan where plant=? and mfdate=? and seqno=? ";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        

        public string Update(string Plant, string Mfdate, Int32 Seqno)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Mfline)) ? null : Mfline);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Mftable)) ? null : Mftable);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Wkno)) ? null : Wkno);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno)) ? 0 : Tubno);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Workqty)) ? 0 : Workqty);

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta_sfb02)) ? 0 : Ta_sfb02);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta_sfb03)) ? 0 : Ta_sfb03);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta_sfb04)) ? 0 : Ta_sfb04);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta_sfb06)) ? 0 : Ta_sfb06);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta_sfb07)) ? 0 : Ta_sfb07);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Ta_sfb08)) ? 0 : Ta_sfb08);

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Sp)) ? null : Sp);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cond)) ? null : Cond);

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_1)) ? 0 : Tubno_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_2)) ? 0 : Tubno_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_3)) ? 0 : Tubno_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_4)) ? 0 : Tubno_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_5)) ? 0 : Tubno_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_6)) ? 0 : Tubno_6);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cut_long)) ? 0 : Cut_long);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cut_width)) ? 0 : Cut_width);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(S_qty)) ? 0 : S_qty);

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tubno_memo)) ? null : Tubno_memo);



                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(Login.ID);

                parm.Add(Plant.Trim());
                parm.Add(Mfdate.Trim());
                parm.Add(Seqno);
                string sql = null;
                sql += "update mfplan set mfline=?, mftable=?,wkno=?,tubno=?,workqty=?,ta_sfb02=?,ta_sfb03=?,ta_sfb04=?,ta_sfb06=?,ta_sfb07=?,ta_sfb08=?,sp=?,cond=?,";
                sql += "tubno_1=?,tubno_2=?,tubno_3=?,tubno_4=?,tubno_5=?,tubno_6=?,cut_long=?,cut_width=?,s_qty=?,tubno_memo=?,mod_date=?,mod_user=? ";
                sql += " where plant =?";
                sql += " and mfdate =?";                
                sql += " and seqno =?";
                if (DBConnector.executeSQL(Login.MFPD, sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

        

        public static mfplan Get(string Plant, string Mfdate, Int32 Seqno)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();


            string sql = null;
            sql += "select * from mfplan where 1=1 ";

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

                        

            if (!string.IsNullOrEmpty(Seqno.ToString()))
            {
                parm.Add(Seqno);
                sql += " and seqno = ?";
            }
            DataSet DeptDS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new mfplan
            {
                Plant = DeptDS.Tables[0].Rows[0].IsNull("plant") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("plant").Trim(),
                Mfdate = DeptDS.Tables[0].Rows[0].IsNull("mfdate") ? "" : System.Convert.ToDateTime(DeptDS.Tables[0].Rows[0].Field<string>("mfdate")).ToString("yyyy/MM/dd"),
                Mfline = DeptDS.Tables[0].Rows[0].IsNull("mfline") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mfline").Trim(),
                Seqno = DeptDS.Tables[0].Rows[0].IsNull("seqno") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("seqno"),
                Mftable = DeptDS.Tables[0].Rows[0].IsNull("mftable") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mftable").Trim(),
                Wkno = DeptDS.Tables[0].Rows[0].IsNull("wkno") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wkno").Trim(),
                Tubno = DeptDS.Tables[0].Rows[0].IsNull("tubno") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno"),
                Workqty = DeptDS.Tables[0].Rows[0].IsNull("workqty") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("workqty"),

                Ta_sfb02 = DeptDS.Tables[0].Rows[0].IsNull("ta_sfb02") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta_sfb02"),
                Ta_sfb03 = DeptDS.Tables[0].Rows[0].IsNull("ta_sfb03") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta_sfb03"),
                Ta_sfb04 = DeptDS.Tables[0].Rows[0].IsNull("ta_sfb04") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta_sfb04"),

                Ta_sfb06 = DeptDS.Tables[0].Rows[0].IsNull("ta_sfb06") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta_sfb06"),
                Ta_sfb07 = DeptDS.Tables[0].Rows[0].IsNull("ta_sfb07") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta_sfb07"),
                Ta_sfb08 = DeptDS.Tables[0].Rows[0].IsNull("ta_sfb08") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("ta_sfb08"),

                Sp = DeptDS.Tables[0].Rows[0].IsNull("sp") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("sp").Trim(),
                Cond = DeptDS.Tables[0].Rows[0].IsNull("cond") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cond").Trim(),

                Tubno_1 = DeptDS.Tables[0].Rows[0].IsNull("tubno_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno_1"),
                Tubno_2 = DeptDS.Tables[0].Rows[0].IsNull("tubno_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno_2"),
                Tubno_3 = DeptDS.Tables[0].Rows[0].IsNull("tubno_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno_3"),
                Tubno_4 = DeptDS.Tables[0].Rows[0].IsNull("tubno_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno_4"),
                Tubno_5 = DeptDS.Tables[0].Rows[0].IsNull("tubno_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno_5"),
                Tubno_6 = DeptDS.Tables[0].Rows[0].IsNull("tubno_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tubno_6"),
                Cut_long = DeptDS.Tables[0].Rows[0].IsNull("cut_long") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("cut_long"),
                Cut_width = DeptDS.Tables[0].Rows[0].IsNull("cut_width") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("cut_width"),

                S_qty = DeptDS.Tables[0].Rows[0].IsNull("s_qty") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("s_qty"),
                Tubno_memo = DeptDS.Tables[0].Rows[0].IsNull("tubno_memo") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tubno_memo").Trim(),


                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),

            };
        }

        

        public static Int32 GetSeqNo(string Plant, string Mfdate)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Plant.Trim());
            parm.Add(Mfdate.Trim());
            
            string sql = "";
            sql += "SELECT max(seqno+1) aa from mfplan ";
            sql += " where plant =?";
            sql += " and mfdate = ?";

            DataSet DS = DBConnector.executeQuery(Login.MFPD, sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return 1;
            if (DS.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                return System.Convert.ToInt32(a1);
            }


        }

    }
}
